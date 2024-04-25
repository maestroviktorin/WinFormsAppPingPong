using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppPingPong.Temporary.GameManager.Database;

namespace PingPong.GameManager
{
    public class Host: Client
    {
        public IPAddress IP { get; }
        UdpClient server;
        IPEndPoint endPoint;

        bool isConnected = false;

        public int Port { get; }
        
        public Host(int port)
        {
            this.Port = port;
            IP = LocalIPAddress();

            if (IP == null) throw new Exception("You're not connected to the internet");

            server = new UdpClient(Port);

            endPoint = new IPEndPoint(IP, Port);

            

        }

        public override void Update()
        {
            byte[] data = server.Receive(ref endPoint);
            if (!isConnected && data != null)
            {
                isConnected = true;
                PingPongData.Instance.ClientName = data.ToString();
            }
            // TODO check client for some sort of identification
            if (isConnected)
            {
                object transferredDTO = data;
                // assign data to PingPongData

                byte[] data2Send = new byte[5];

            }
        }

        private IPAddress? LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }


    }
}
