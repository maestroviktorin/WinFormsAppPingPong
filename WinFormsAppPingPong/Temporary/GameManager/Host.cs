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
using WinFormsAppPingPong.Temporary.GameManager.Events;

namespace PingPong.GameManager
{
    public class Host
    {
        public const int PORT = 8079;
        private Socket socket;
        private EndPoint ownEndPoint;
        private EndPoint connectedEndPoint;
        PingPongDataDto data2Send;


        private byte[] buffer;
        private ArraySegment<byte> bufferSegment;

        public static Host Create()
        {
            return new Host().Setup();
        }

        public Host Setup()
        {
            buffer = new byte[4096];
            bufferSegment = new ArraySegment<byte>(buffer);
            data2Send = new PingPongDataDto();

            ownEndPoint = new IPEndPoint(IPAddress.Any, PORT);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
            socket.Bind(ownEndPoint);

            return this;
        }

        async public Task<bool> WaitForOtherConnection()
        {
            try
            {
                var info = await socket.ReceiveMessageFromAsync(bufferSegment, connectedEndPoint);
                connectedEndPoint = info.RemoteEndPoint;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        async public Task SendDataToConnectedClient()
        {
            data2Send.ClientPos = PingPongData.Instance.ClientPosition;
            data2Send.HostPos = PingPongData.Instance.HostPosition;
            data2Send.BallPos = PingPongData.Instance.BallPosition;
            byte[] data = JsonSerializer.SerializeToUtf8Bytes(data2Send);
            await socket.SendToAsync(data, connectedEndPoint);
        }

        public void StartReceivingFromClient()
        {
            PingPongData data = PingPongData.Instance;
            SendDataDto dto;
            SocketReceiveMessageFromResult res;
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        res = await socket.ReceiveMessageFromAsync(bufferSegment, connectedEndPoint);
                        if (res.RemoteEndPoint != connectedEndPoint)
                        {
                            continue;
                        }
                        dto = JsonSerializer.Deserialize<SendDataDto>(bufferSegment);
                        data.ClientInput = dto.Input;
                    }
                    catch (Exception ex)
                    {
                        // todo
                    }

                }
            });
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
