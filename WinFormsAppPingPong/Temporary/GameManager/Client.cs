using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinFormsAppPingPong.Temporary.AdditionalClasses;
using WinFormsAppPingPong.Temporary.GameManager;
using WinFormsAppPingPong.Temporary.GameManager.Database;

namespace PingPong.GameManager
{
    public class Client: IPlayer
    {
        public const int PORT = 8079;
        private Socket socket;
        private EndPoint ownEndPoint;
        private EndPoint serverEndPoint;
        private SendInputDto sendInputDto;

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
            sendInputDto = new SendInputDto();

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
            socket.Bind(ownEndPoint);

            return this;
        }

        public void StartReceivingLoop()
        {
            _ = Task.Run(async () =>
            {
                SocketReceiveMessageFromResult res;
                SendGameDataDto data;
                PingPongData mainData = PingPongData.Instance;

                while (true)
                {
                    res = await socket.ReceiveMessageFromAsync(bufferSegment, SocketFlags.None, serverEndPoint);
                    try
                    {
                        data = JsonSerializer.Deserialize<SendGameDataDto>(bufferSegment);
                        mainData.BallPosition = data.BallPosition;
                        mainData.HostPosition = data.HostPosition;
                        mainData.ClientPosition = data.ClientPosition;
                    }
                    catch (Exception ex)
                    {
                        // todo
                    }
                }
            });
        }

        async public Task Send()
        {
            sendInputDto.InputUp = PingPongData.Instance.HostInputUp;
            sendInputDto.InputDown = PingPongData.Instance.HostInputDown;
            try
            {
                byte[] data = JsonSerializer.SerializeToUtf8Bytes(sendInputDto);

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

        public void Run()
        {
            // Do nothing
        }
    }
}
