using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinFormsAppPingPong;
using WinFormsAppPingPong.Temporary.AdditionalClasses;
using WinFormsAppPingPong.Temporary.GameManager;
using WinFormsAppPingPong.Temporary.GameManager.Database;
using WinFormsAppPingPong.Temporary.GameManager.Events;

namespace PingPong.GameManager
{
    public class Host: IPlayer
    {
        public const int PORT = 8079;
        private Socket socket;
        private EndPoint ownEndPoint;
        private EndPoint connectedEndPoint;
        SendGameDataDto data2Send;
        PingPongData gameData;
        Game gameForm;


        private byte[] buffer;
        private ArraySegment<byte> bufferSegment;

        public Host Setup(Game game)
        {
            gameForm = game;

            buffer = new byte[4096];
            bufferSegment = new ArraySegment<byte>(buffer);
            data2Send = new SendGameDataDto();
            gameData = PingPongData.Instance;

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

        // TODO: Refactor.
        async public Task Send()
        {
            data2Send.ClientPosition = PingPongData.Instance.ClientPosition;
            data2Send.HostPosition = PingPongData.Instance.HostPosition;
            data2Send.BallPosition = PingPongData.Instance.BallPosition;
            byte[] data = JsonSerializer.SerializeToUtf8Bytes(data2Send);
            await socket.SendToAsync(data, connectedEndPoint);
        }

        // TODO: Refactor. Add a "Wait-for-Connection" loop and a `OnPlayerJoin` event.
        public void StartReceivingLoop()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, PORT);
            PingPongData data = PingPongData.Instance;
            SendInputDto dto;
            SocketReceiveMessageFromResult res;
            Task.Run(async () =>
            {
                // waiting for first message that must be a name of user
                // TODO
                while (true)
                {
                    try
                    {
                        res = await socket.ReceiveMessageFromAsync(bufferSegment, ep);

                        connectedEndPoint = ep;
                        string name = JsonSerializer.Deserialize<string>(bufferSegment);
                        //await socket.SendToAsync()

                        break;
                    }
                    catch
                    {
                        // do smt
                    }
                }

                while (true)
                {
                    try
                    {
                        res = await socket.ReceiveMessageFromAsync(bufferSegment, ep);
                        if (res.RemoteEndPoint != connectedEndPoint)
                        {
                            continue;
                        }
                        dto = JsonSerializer.Deserialize<SendInputDto>(bufferSegment);
                        data.ClientInputUp = dto.InputUp;
                        data.ClientInputDown = dto.InputDown;
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

        public void Run()
        {
            if (gameData.ClientInputUp)
            {
                gameForm.MoveAlienBy(gameForm.playerSpeed);
            }
            if (gameData.ClientInputDown)
            {
                gameForm.MoveAlienBy(-gameForm.playerSpeed);
            }
            if (gameData.HostInputUp)
            {
                gameForm.MoveCyborgBy(gameForm.playerSpeed);
            }
            if (gameData.HostInputDown)
            {
                gameForm.MoveCyborgBy(-gameForm.playerSpeed);
            }
        }
    }
}
