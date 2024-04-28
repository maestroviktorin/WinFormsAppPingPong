using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinFormsAppPingPong.Temporary.GameManager;
using WinFormsAppPingPong.Temporary.GameManager.Database;

namespace PingPong.GameManager
{
    public class Client
    {
        public const int PORT = 8079;
        private Socket socket;
        private EndPoint ownEndPoint;
        private EndPoint serverEndPoint;

        private byte[] buffer;
        private ArraySegment<byte> bufferSegment;

        public static Client Create(IPAddress address, int port)
        {
            return new Client().Setup(address, port);
        }

        public Client Setup(IPAddress address, int port)
        {
            buffer = new byte[4096];
            bufferSegment = new ArraySegment<byte>(buffer);

            ownEndPoint = new IPEndPoint(IPAddress.Any, PORT);
            serverEndPoint = new IPEndPoint(address, port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
            socket.Bind(ownEndPoint);

            return this;
        }

        public void StartReceiving()
        {
            _ = Task.Run(async () =>
            {
                SocketReceiveMessageFromResult res;
                PingPongDataDto data;
                PingPongData mainData = PingPongData.Instance;

                while (true)
                {
                    res = await socket.ReceiveMessageFromAsync(bufferSegment, SocketFlags.None, serverEndPoint);
                    try
                    {
                        data = JsonSerializer.Deserialize<PingPongDataDto>(bufferSegment);
                        mainData.BallPosition = data.BallPos;
                        mainData.HostPosition = data.HostPos;
                        mainData.ClientPosition = data.ClientPos;
                    }
                    catch (Exception ex)
                    {
                        // todo
                    }
                }
            });
        }

        async public Task Send(SendDataDto obj)
        {
            try
            {
                byte[] data = JsonSerializer.SerializeToUtf8Bytes(obj);

                await socket.SendToAsync(data, serverEndPoint);
            }
            catch (Exception ex)
            {
                // add something to handle but let it be for now
            }
            
        }

        public static IPAddress LocalIPAddress()
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
