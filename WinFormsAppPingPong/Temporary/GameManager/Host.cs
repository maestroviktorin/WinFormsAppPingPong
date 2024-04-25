using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.GameManager
{
    public class Host: Client
    {
        public IPAddress IP { get; }

        public int Port { get; } = 8000;
        
        public Host()
        {
            IP = LocalIPAddress();
            var server = new UdpClient(Port);

            var endPoint = new IPEndPoint(IP, Port);

            server.Receive(ref endPoint);
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
