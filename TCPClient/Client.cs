using Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class Client : Form
    {
        int port;
        IPAddress serverAddress;
        TcpClient client = new TcpClient() { NoDelay = true };
        NetworkStream serverStream = default(NetworkStream);
        string data = null;
        public Client()
        {
            InitializeComponent();
            txt_address.Text = Network.GetLocalIPAddress();
            port = txt_port.Text.ToInt();
            serverAddress = txt_address.Text.ToIpAddress();
        }

        private async void btn_connect_Click(object sender, EventArgs e)
        {
            if (!client.Connected)
            {
                await client.ConnectAsync(serverAddress, port);
                logs.Text += $"Connected to {serverAddress} on port {port}\n";
                logs.Text += $"Your address is {client.Client.RemoteEndPoint}";

                _ = Task.Run(async () =>
                {
                    while (client.Connected)
                    {
                        await GetMessages();
                    }
                });

            }
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(txt_msg.Text);

            serverStream.Write(outStream, 0, outStream.Length);
            await serverStream.FlushAsync();
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

                logs.Invoke((MethodInvoker)delegate
                {
                    logs.Text += $"Received: {data}\n";
                });
            }
        }
    }
}
