using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppPingPong.Temporary.GameManager;

namespace PingPong.GameManager
{
    public class Client: UpdateObject
    {
        private UdpClient client;
        public Client() 
        {
            client = new UdpClient(8000);
        }

        public override void Update()
        {
            client.Receive()
        }
    }
}
