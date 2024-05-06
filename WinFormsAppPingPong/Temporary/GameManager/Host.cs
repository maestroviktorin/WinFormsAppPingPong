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
        public IPEndPoint ownEndPoint {  get; private set; }
        public EndPoint connectedEndPoint { get; private set; }
        SendGameDataDto data2Send;
        PingPongData gameData;
        Game gameForm;


        private byte[] buffer;
        private ArraySegment<byte> bufferSegment;

        public Host()
        {
            ownEndPoint = new IPEndPoint(LocalIPAddress(), PORT);
        }

        public Host Setup()
        {

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

        public Host AddGame(Game game)
        {
            gameForm = game;
            return this;
        }

        async public Task<bool> WaitForOtherConnection()
        {
            try
            {
                var info = await socket.ReceiveMessageFromAsync(bufferSegment, new IPEndPoint(IPAddress.Any, 0));
                connectedEndPoint = info.RemoteEndPoint;
                PingPongData.Instance.ClientName = Encoding.UTF8.GetString(bufferSegment);
                await socket.SendToAsync(Encoding.UTF8.GetBytes(PingPongData.Instance.HostName), connectedEndPoint);

                PlayerJoinEvent evt = new PlayerJoinEvent(connectedEndPoint);

                PingPongEvents.OnPlayerJoin.Invoke(evt);
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
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.DefaultBufferSize = 34;
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        res = await socket.ReceiveMessageFromAsync(buffer, ep);
                        if (res.RemoteEndPoint.ToString() != connectedEndPoint.ToString())
                        {
                            continue;
                        }
                        byte[] segment = bufferSegment.Array.Where((x, i) => i < res.ReceivedBytes).ToArray();
                        dto = JsonSerializer.Deserialize<SendInputDto>(segment, JsonSerializerOptions.Default);
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
            gameForm.CheckCollisions();

            if (gameData.ClientInputUp)
            {
                gameData.ClientPosition = new Point(
                    gameData.ClientPosition.X, 
                    gameData.ClientPosition.Y - gameForm.playerSpeed
                    );
            }
            if (gameData.ClientInputDown)
            {
                gameData.ClientPosition = new Point(
                    gameData.ClientPosition.X,
                    gameData.ClientPosition.Y + gameForm.playerSpeed
                    );
            }
            if (gameData.HostInputUp)
            {
                gameData.HostPosition = new Point(
                    gameData.HostPosition.X,
                    gameData.HostPosition.Y - gameForm.playerSpeed
                    );
            }
            if (gameData.HostInputDown)
            {
                gameData.HostPosition = new Point(
                    gameData.HostPosition.X,
                    gameData.HostPosition.Y + gameForm.playerSpeed
                    );
            }
            if (gameData.ClientPosition.Y < 0) 
            {
                gameData.ClientPosition = new Point(gameData.ClientPosition.X, 0);
            }
            if (gameData.ClientPosition.Y + gameForm.alien.Height > gameForm.heightBorder)
            {
                gameData.ClientPosition = new Point(gameData.ClientPosition.X, gameForm.heightBorder - gameForm.alien.Height);
            }
            if (gameData.HostPosition.Y < 0)
            {
                gameData.HostPosition = new Point(gameData.HostPosition.X, 0);
            }
            if (gameData.HostPosition.Y + gameForm.cyborg.Height > gameForm.heightBorder)
            {
                gameData.HostPosition = new Point(gameData.HostPosition.X, gameForm.heightBorder - gameForm.cyborg.Height);
            }

            if (gameForm.ballMove)
            {
                gameData.BallPosition = new Point(
                    gameData.BallPosition.X - gameForm.ballSpeedX, 
                    gameData.BallPosition.Y - gameForm.ballSpeedY);
                if (gameData.BallPosition.Y <= 0 || 
                    gameData.BallPosition.Y + gameForm.ball.Height >= gameForm.heightBorder)
                {
                    gameForm.ballSpeedY = -gameForm.ballSpeedY;
                }
            }

            if (gameData.BallPosition.X + gameForm.ball.Width >= gameForm.Width)
            {
                gameData.HostScore++;
                gameForm.NewRound();
            }
            if (gameData.BallPosition.X <= 0)
            {
                gameData.ClientScore++;
                gameForm.NewRound();
            }
            //if (ballMove)
            //{
            //    ball.Top -= ballSpeedY;
            //    ball.Left -= ballSpeedX;

            //    if (ball.Top <= 0 || ball.Bottom >= ClientSize.Height)
            //    {
            //        ballSpeedY = -ballSpeedY;
            //    }
            //}

            //if (ball.Left > ClientSize.Width)
            //{
            //    ++cyborgCounter;
            //    NewRound();
            //}
            //if (ball.Right < 0)
            //{
            //    ++alienCounter;
            //    NewRound();
            //}
        }
        public void Destroy()
        {
            if (socket  != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
    }
}
