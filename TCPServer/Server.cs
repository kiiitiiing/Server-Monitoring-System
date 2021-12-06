using Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TCPServer
{
    public partial class Server : Form
    {
        private readonly ResourceManager Resources = new ResourceManager("TCPServer.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

        #region SERVER MONITORING VARIABLES
        TcpListener server = null;
        CancellationTokenSource token = new CancellationTokenSource();
        int port;
        IPAddress serverAddress;
        byte[] bytes = new byte[256];
        string data = null;
        BindingList<string> ConnectedUsers = new BindingList<string>();
        #endregion

        #region PUBLIC IP MONITORING VARIABLES
        private const string publicIPMonitoringResxFile = @".\Resources.resx";
        System.Timers.Timer timer;
        BindingList<IPAddress> Addresses = new BindingList<IPAddress>();
        List<PublicIp> PublicIps = new List<PublicIp>();
        private int Interval { get; set; }
        #endregion
        public Server()
        {
            InitializeComponent();
            #region SERVER MONITORING
            btn_stop.Enabled = false;
            txt_addess.Text = Network.GetLocalIPAddress();
            port = txt_port.Text.ToInt();
            serverAddress = txt_addess.Text.ToIpAddress();

            connections.DataSource = ConnectedUsers;
            machineName.Text = Environment.MachineName;
            #endregion

            #region PUBLIC IP MONITORING
            btnStop.Enabled = false;
            Addresses.Add("222.127.126.35".ToIpAddress());
            Addresses.Add("122.3.84.178".ToIpAddress());
            lstIpAddress.DataSource = Addresses;
            foreach(var address in Addresses)
            {
                PublicIps.Add(new PublicIp
                {
                    Address = address,
                    AverageRoundTripTime = new Queue<long>(10)
                });
            }
            #endregion
        }

        #region SERVER MONITORING
        private void btn_start_Click(object sender, EventArgs e)
        {
            server = new TcpListener(serverAddress, port);

            logs.Text += "Server Starting...\n";
            server.Start();
            logs.Text += "Server Started!\n";
            btn_start.Enabled = false;
            btn_stop.Enabled = true;
            _ = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        logs.Invoke((MethodInvoker)delegate
                        {
                            logs.Text += "listening\n";
                        });
                        var client = await server.AcceptTcpClientAsync();

                        connections.Invoke((MethodInvoker)delegate
                        {
                            if (ConnectedUsers.Count == 0)
                            {
                                connections.DataSource = null;
                                ConnectedUsers.Add(client.Client.RemoteEndPoint.ToString());
                                connections.DataSource = ConnectedUsers;
                            }
                            else
                            {
                                ConnectedUsers.Add(client.Client.RemoteEndPoint.ToString());
                            }
                        });
                        logs.Invoke((MethodInvoker)delegate
                        {
                            logs.Text += $"{client.Client.RemoteEndPoint} has Connected!\n";
                        });
                        _ = Task.Run(() =>
                        {
                            this.ListenToPorts(client);
                        });
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine("BTN ERROR: " + ex.Message);
                        if (ex.InnerException != null) Debug.WriteLine("BTN INNER: " + ex.InnerException.Message);
                    }
                }
            });
        }

        private void ListenToPorts(TcpClient client)
        {
            data = null;
            try
            {
                var stream = client.GetStream();
                int i;
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    logs.Invoke((MethodInvoker)delegate
                    {
                        logs.Text += $"Received: {data}\n";
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FNC ERROR: " + ex.Message);
                if (ex.InnerException != null) Debug.WriteLine(" FNC INNER: " + ex.InnerException.Message);

                logs.Invoke((MethodInvoker)delegate
                {
                    logs.Text += $"{client.Client.RemoteEndPoint.ToString()} has disconnected.\n";
                });
                connections.Invoke((MethodInvoker)delegate{
                    ConnectedUsers.Remove(client.Client.RemoteEndPoint.ToString());
                });
            }   
            //client.Close();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            token.Cancel();
            logs.Text += "Server Stoping...\n";
            server.Stop();
            logs.Text += "Server Stopped!\n";
            btn_stop.Enabled = false;
            btn_start.Enabled = true;
        }
        #endregion

        #region PUBLIC IP MONITORING
        private void btnStart_Click(object sender, EventArgs e)
        {
            Interval = Resources.GetString("INTERVAL").ToInt();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            timer = new System.Timers.Timer();
            timer.Interval = Interval;
            timer.Elapsed += OnTimer;
            timer.Start();
            AppendLogs(pingLogs, "Ping Service Started.");
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            timer.Stop();
            AppendLogs(pingLogs, "Ping Service has stopped.");
        }

        private void OnTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            AddLogs(rtbStatus, "");
            foreach (var ipaddress in PublicIps)
            {
                _ = Task.Run(() =>
                {
                    Ping ping = new Ping();
                    PingOptions options = new PingOptions();
                    options.DontFragment = true;

                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;
                    AppendLogs(pingLogs, $"Pinging {ipaddress.Address}...");
                    PingReply reply = ping.Send(ipaddress.Address, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                        if (ipaddress.AverageRoundTripTime.Count == 10)
                        {
                            ipaddress.AverageRoundTripTime.Dequeue();
                        }
                        ipaddress.AverageRoundTripTime.Enqueue(reply.RoundtripTime);
                        var result = $"Address: {reply.Address}\n" +
                        $"RoundTrip Time: {reply.RoundtripTime}ms\n" +
                        $"Time to Live: {reply.Options.Ttl}\n" +
                        $"Buffer Size: {reply.Buffer.Length} bytes";
                        AppendLogs(pingLogs, result);
                    }
                    else
                    {
                        AppendLogs(pingLogs, Enum.GetName(typeof(IPStatus), reply.Status));
                    }
                    AppendLogs(rtbStatus, $"{ipaddress.Address}: {ipaddress.AverageRoundTripTime.Average().ToString("##.##")}");
                });
            }
            pingLogs.Invoke((MethodInvoker)delegate
            {
                var logsLength = pingLogs.Text.Length;
                Debug.WriteLine(logsLength);
                var limit = 1500;
                if (logsLength > limit)
                {
                    var sub = logsLength - limit;
                    pingLogs.Text = pingLogs.Text.Substring(sub, limit);
                }
            });
        }
        public void AppendLogs(RichTextBox logs, string text)
        {
            if (!logs.InvokeRequired)
            {
                logs.Text += text + "\n";
                logs.SelectionStart = logs.Text.Length;
                logs.ScrollToCaret();
            }
            else
            {
                logs.Invoke((MethodInvoker)delegate
                {
                    logs.Text += text + "\n";
                    logs.SelectionStart = logs.Text.Length;
                    logs.ScrollToCaret();
                });
            }
        }
        public void AddLogs(RichTextBox logs, string text)
        {
            if (!logs.InvokeRequired)
            {
                logs.Text = text;
            }
            else
            {
                logs.Invoke((MethodInvoker)delegate
                {
                    logs.Text = text;
                });
            }
        }
        public void ClearLogs(RichTextBox rtb)
        {
            rtb.Text = "";
        }

        public void UpdateStatusBox()
        {

        }
        #endregion

        public class PublicIp
        {
            public IPAddress Address { get; set; }
            public Queue<long> AverageRoundTripTime { get; set; }
        }

        #region TEST
        private void button2_Click(object sender, EventArgs e)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                if (!clientSocket.Connected)
                    clientSocket.Connect(IPAddress.Parse("10.10.20.14"), 20281);
                Debug.WriteLine("wtf");
                clientSocket.Send(Encoding.UTF8.GetBytes("Esto es una prueba"));
                clientSocket.Disconnect(true);
                clientSocket.Close();
                //You need to close the send code
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
