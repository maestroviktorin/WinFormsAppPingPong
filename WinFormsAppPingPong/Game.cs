using Microsoft.VisualBasic.Logging;
using PingPong.GameManager;
using System.Diagnostics;
using WinFormsAppPingPong.Temporary.AdditionalClasses;
using WinFormsAppPingPong.Temporary.GameManager;
using WinFormsAppPingPong.Temporary.GameManager.Database;

namespace WinFormsAppPingPong
{
    public partial class Game : Form
    {
        public int ballSpeedX = 3;
        public int ballSpeedY = 3;
        public int playerSpeed = 4;
        int alienCounter, cyborgCounter;
        public bool ballMove = true;
        public Size clientSize;
        public int heightBorder;

        private IPlayer player;
        private MenuForm menu;

        public Game()
        {
            InitializeComponent();
        }

        public Game(int ballSpeedX, int ballSpeedY, IPlayer player, MenuForm menu) : base()
        {

            if (player.GetType() == typeof(Host))
            {
                (player as Host).AddGame(this);
            }

            player.StartReceivingLoop();

            this.ballSpeedX = ballSpeedX;
            this.ballSpeedY = ballSpeedY;
            this.player = player;
            this.menu = menu;

            this.clientSize = ClientSize;
            heightBorder =this.Size.Height + 134;

            InitializeComponent();

            PingPongData.Instance.HostPosition = cyborg.Location;
            PingPongData.Instance.ClientPosition = alien.Location;
            PingPongData.Instance.BallPosition = ball.Location;


            //if (isHost) player = new Host().Setup(this);
            //else player = new Client().Setup();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Sends positions
            player.Send();
            // Do logic if host
            player.Run();
            // Render players and balls
            AdjustPositions();



            upButtonLabel.Text = $"{PingPongData.Instance.HostPosition}: {PingPongData.Instance.HostInputUp}, {PingPongData.Instance.HostInputDown}";
            downButtonLabel.Text = $"{PingPongData.Instance.ClientPosition}: {PingPongData.Instance.ClientInputUp}, {PingPongData.Instance.ClientInputDown}";
            BallPosLabel.Text = $"{PingPongData.Instance.BallPosition} {this.clientSize}";

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



            // !!! WARNING !!!
            //MoveAlienBy(PingPongData.Instance.ClientInput * playerSpeed);
            //MoveAlienBy(PingPongData.Instance.HostInput * playerSpeed);

            //alienCounterLabel.Text = alienCounter.ToString();
            //cyborgCounterLabel.Text = cyborgCounter.ToString();

            //CheckCollisions();
        }

        // !!! WARNING !!!
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                PingPongData.Instance.HostInputDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                PingPongData.Instance.HostInputUp = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                ballMove = true;
            }
        }

        // !!! WARNING !!!
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && PingPongData.Instance.HostInputDown)
            {
                PingPongData.Instance.HostInputDown = false;
            }
            if (e.KeyCode == Keys.Up && PingPongData.Instance.HostInputUp)
            {
                PingPongData.Instance.HostInputUp = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                ballMove = false;
            }
        }

        public void MoveAlienBy(int speed)
        {
            if (alien.Top + speed < 0 || alien.Bottom + speed > ClientSize.Height) return;
            alien.Top += speed;
            alienBottom.Top += speed;
            alienTop.Top += speed;
            alienFront.Top += speed;
        }

        public void MoveCyborgBy(int speed)
        {
            if (cyborg.Top + speed < 0 || cyborg.Top + speed > ClientSize.Height) return;
            cyborg.Top += speed;
            cyborgBottom.Top += speed;
            cyborgTop.Top += speed;
            cyborgFront.Top += speed;
        }

        public void CheckCollisions()
        {
            if (ball.Bounds.IntersectsWith(cyborgFront.Bounds)
                && (ball.Bounds.IntersectsWith(cyborgTop.Bounds)
                || ball.Bounds.IntersectsWith(cyborgBottom.Bounds)))
            {
                ballSpeedX = -ballSpeedX;
                ballSpeedY = -ballSpeedY;
                PingPongData.Instance.BallPosition = new Point(
                    cyborg.Right - ballSpeedX,
                    ball.Top - ballSpeedY
                    );
                return;
            }
            if (ball.Bounds.IntersectsWith(cyborgTop.Bounds))
            {
                if (ballSpeedY < 0) ballSpeedY = -ballSpeedY;
                //ball.Location
                PingPongData.Instance.BallPosition = new Point(
                     ball.Left - ballSpeedX,
                     cyborg.Top - ball.Height
                    );
                //ball.Top = cyborg.Top - ball.Height;
                //ball.Left += ballSpeedX;

                //MoveCyborgBy(Math.Abs(ballSpeedY) * playerSpeed);
                return;
            }
            if (ball.Bounds.IntersectsWith(cyborgBottom.Bounds))
            {
                if (ballSpeedY > 0) ballSpeedY = -ballSpeedY;
                PingPongData.Instance.BallPosition = new Point(
                    ball.Left - ballSpeedX,
                    cyborg.Bottom + ball.Height
                    );
                //ball.Top = cyborg.Bottom + ball.Height;
                //ball.Left += ballSpeedX;

                //MoveCyborgBy(Math.Abs(ballSpeedY) * (-playerSpeed));
                return;
            }
            if (ball.Bounds.IntersectsWith(cyborgFront.Bounds))
            {
                ballSpeedX = -ballSpeedX;
                PingPongData.Instance.BallPosition = new Point(
                    cyborg.Right - ballSpeedX,
                    ball.Top + ballSpeedY
                    );
                //ball.Left = cyborg.Right + ballSpeedX;
                //ball.Top += ballSpeedY;
                return;
            }

            if (ball.Bounds.IntersectsWith(alienFront.Bounds)
                && (ball.Bounds.IntersectsWith(alienTop.Bounds) || ball.Bounds.IntersectsWith(alienBottom.Bounds)))
            {
                ballSpeedX = -ballSpeedX;
                ballSpeedY = -ballSpeedY;
                PingPongData.Instance.BallPosition = new Point(
                    alien.Left - ballSpeedX - ball.Width,
                    ball.Top + ballSpeedY
                    );
                //ball.Left = alien.Left + ballSpeedX - ball.Width;
                //ball.Top += ballSpeedY;
                return;
            }
            if (ball.Bounds.IntersectsWith(alienTop.Bounds))
            {
                if (ballSpeedY < 0) ballSpeedY = -ballSpeedY;
                PingPongData.Instance.BallPosition = new Point(
                     ball.Left - ballSpeedX,
                     alien.Top - ballSpeedY - ball.Height
                    );
                //ball.Top = alien.Top - ballSpeedY - ball.Height;
                //ball.Left += ballSpeedX;

                //MoveAlienBy(Math.Abs(ballSpeedY) * playerSpeed);
                return;
            }
            if (ball.Bounds.IntersectsWith(alienBottom.Bounds))
            {
                if (ballSpeedY > 0) ballSpeedY = -ballSpeedY;
                PingPongData.Instance.BallPosition = new Point(
                    ball.Left - ballSpeedX,
                    alien.Bottom + ballSpeedY
                    );
                //ball.Top = alien.Bottom + ballSpeedY;
                //ball.Left += ballSpeedX;

                //MoveAlienBy(Math.Abs(ballSpeedY) * (-playerSpeed));
                return;
            }
            if (ball.Bounds.IntersectsWith(alienFront.Bounds))
            {
                ballSpeedX = -ballSpeedX;
                PingPongData.Instance.BallPosition = new Point(
                    alien.Left + ballSpeedX - ball.Width,
                    ball.Top + ballSpeedY
                    );
                //ball.Left = alien.Left + ballSpeedX - ball.Width;
                //ball.Top += ballSpeedY;
                return;
            }
        }

        public void AdjustPositions()
        {
            cyborg.Location = PingPongData.Instance.HostPosition;
            cyborgBottom.Location = new Point(cyborg.Location.X,
                                                cyborg.Location.Y + cyborg.Height - 1);
            cyborgTop.Location = cyborg.Location;
            cyborgFront.Location = new Point(cyborg.Location.X + cyborg.Width,
                                            cyborg.Location.Y);

            alien.Location = PingPongData.Instance.ClientPosition;
            alienBottom.Location = new Point(alien.Location.X,
                                                alien.Location.Y + alien.Height - 1);
            alienTop.Location = alien.Location;
            alienFront.Location = new Point(alien.Location.X,
                                            alien.Location.Y);

            ball.Location = PingPongData.Instance.BallPosition;

            alienCounterLabel.Text = PingPongData.Instance.ClientScore.ToString();
            cyborgCounterLabel.Text = PingPongData.Instance.HostScore.ToString();
        }

        public void NewRound()
        {
            Random random = new Random();
            if (ballSpeedX < 0)
            {
                PingPongData.Instance.BallPosition = new Point(
                    random.Next(ClientSize.Height / 3, ClientSize.Height / 2),
                    random.Next(ClientSize.Width / 3, ClientSize.Width / 2)
                    );
            }
            else
            {
                PingPongData.Instance.BallPosition = new Point(
                    random.Next(ClientSize.Width / 2, 2 * ClientSize.Width / 3),
                    random.Next(ClientSize.Height / 2, 2 * ClientSize.Height / 3)
                    );
                //ball.Top = random.Next(ClientSize.Height / 2, 2 * ClientSize.Height / 3);
                //ball.Left = random.Next(ClientSize.Width / 2, 2 * ClientSize.Width / 3);
            }

            if (random.Next(0, 2) == 1)
            {
                ballSpeedY = -ballSpeedY;
            }
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
