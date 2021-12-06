using Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TCPClientService
{
    public partial class TCPClient : ServiceBase
    {
        string ClientSource = "_clientSource";
        string ClientLogs = "_clientLogs";

        int port;
        IPAddress serverAddress;
        TcpClient client = new TcpClient() { NoDelay = true };
        NetworkStream serverStream = default(NetworkStream);
        string data = null;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);
        public TCPClient()
        {
            InitializeComponent();
            Logs = new EventLog();
            if (!EventLog.SourceExists("_clientSource"))
            {
                EventLog.CreateEventSource("_clientSource", "_clientLogs");
            }
            Logs.Source = "_clientSource";
            Logs.Log = "_clientLogs";
            port = 13000;
            serverAddress = Network.GetLocalIPAddress().ToIpAddress();
        }

        protected override void OnStart(string[] args)
        {
            Logs.WriteEntry("In OnStartsss");

            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
            Logs.WriteEntry("Client Listening..");

            System.Timers.Timer timer = new System.Timers.Timer();

            Logs.WriteEntry("Testing..");

            timer.Interval = 5000;
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }
        private async void OnTimer(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!client.Connected)
                {
                    await client.ConnectAsync(serverAddress, port);
                    Logs.WriteEntry($"Connected to {serverAddress} on port {port}");
                    Logs.WriteEntry($"Your address is {client.Client.RemoteEndPoint}");

                    _ = Task.Run(async () =>
                    {
                        while (client.Connected)
                        {
                            await GetMessages();
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Logs.WriteEntry(ex.Message, EventLogEntryType.Error);
                if (ex.InnerException != null) Logs.WriteEntry(ex.InnerException.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            byte[] outStream = Encoding.ASCII.GetBytes("GOODBYE");

            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            Logs.WriteEntry("Service stopped", EventLogEntryType.Information);
            client.Close();
            client.Dispose();
            // Update the service state to Stop Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            // Update the service state to Stopped.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnContinue()
        {
            client = new TcpClient() { NoDelay = true };
        }


        private async Task GetMessages()
        {
            string returnData;

            while (client.Connected)
            {
                serverStream = client.GetStream();

                var buffSize = client.ReceiveBufferSize;
                byte[] inStream = new byte[buffSize];

                await serverStream.ReadAsync(inStream, 0, buffSize);

                returnData = Encoding.ASCII.GetString(inStream);

                data = returnData;
                    
                Logs.WriteEntry($"Received: {data}");
            }
        }
    }

    public enum ServiceState
    {

        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public int dwServiceType;
        public ServiceState dwCurrentState;
        public int dwControlsAccepted;
        public int dwWin32ExitCode;
        public int dwServiceSpecificExitCode;
        public int dwCheckPoint;
        public int dwWaitHint;
    };
}
