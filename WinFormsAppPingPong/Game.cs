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
        bool alienUp, alienDown;
        bool cyborgUp, cyborgDown;
        int alienCounter, cyborgCounter;
        bool ballMove = true;

        IPlayer player;

        public Game()
        {
            InitializeComponent();
            

        }

        public Game(int ballSpeedX, int ballSpeedY, bool isHost)
        {
            this.ballSpeedX = ballSpeedX;
            this.ballSpeedY = ballSpeedY;

            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            //if (isHost) player = new Host().Setup(this);
            //else player = new Client().Setup();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var obj in UpdateObject.objects)
            {
                obj.Update();
            }


            if (ballMove)
            {
                ball.Top -= ballSpeedY;
                ball.Left -= ballSpeedX;

                if (ball.Top <= 0 || ball.Bottom >= ClientSize.Height)
                {
                    ballSpeedY = -ballSpeedY;
                }
            }

            if (ball.Left > ClientSize.Width)
            {
                ++cyborgCounter;
                NewRound();
            }
            if (ball.Right < 0)
            {
                ++alienCounter;
                NewRound();
            }

            

            // !!! WARNING !!!
            //MoveAlienBy(PingPongData.Instance.ClientInput * playerSpeed);
            //MoveAlienBy(PingPongData.Instance.HostInput * playerSpeed);

            alienCounterLabel.Text = alienCounter.ToString();
            cyborgCounterLabel.Text = cyborgCounter.ToString();

            CheckCollisions();
        }

        // !!! WARNING !!!
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                PingPongData.Instance.HostInputDown = true;
                downButtonLabel.Text = "1";
            }
            if (e.KeyCode == Keys.Up)
            {
                PingPongData.Instance.HostInputUp = true;
                upButtonLabel.Text = "1";
            }

            if (e.KeyCode == Keys.W)
            {
                cyborgUp = true;
            }
            if (e.KeyCode == Keys.S)
            {
                cyborgDown = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                ballMove = true;
            }
        }

        // !!! WARNING !!!
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (
                (e.KeyCode == Keys.Down && PingPongData.Instance.HostInput != -1) ||
                (e.KeyCode == Keys.Up && PingPongData.Instance.HostInput != 1)
                )
            {
                PingPongData.Instance.HostInput = 0;
            }

            if (e.KeyCode == Keys.Down)
            {
                downButtonLabel.Text = "0";
            }
            if (e.KeyCode == Keys.Up)
            {
                upButtonLabel.Text = "0";
            }

            if (e.KeyCode == Keys.W)
            {
                cyborgUp = false;
            }
            if (e.KeyCode == Keys.S)
            {
                cyborgDown = false;
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

        private void CheckCollisions()
        {
            if (ball.Bounds.IntersectsWith(cyborgFront.Bounds)
                && (ball.Bounds.IntersectsWith(cyborgTop.Bounds) || ball.Bounds.IntersectsWith(cyborgBottom.Bounds)))
            {
                ballSpeedX = -ballSpeedX;
                ballSpeedY = -ballSpeedY;
                ball.Left = cyborg.Right + ballSpeedX;
                ball.Top += ballSpeedY;
                return;
            }
            if (ball.Bounds.IntersectsWith(cyborgTop.Bounds))
            {
                if (ballSpeedY < 0) ballSpeedY = -ballSpeedY;
                ball.Top = cyborg.Top - ball.Height;
                ball.Left += ballSpeedX;

                MoveCyborgBy(Math.Abs(ballSpeedY) * playerSpeed);
                return;
            }
            if (ball.Bounds.IntersectsWith(cyborgBottom.Bounds))
            {
                if (ballSpeedY > 0) ballSpeedY = -ballSpeedY;
                ball.Top = cyborg.Bottom + ball.Height;
                ball.Left += ballSpeedX;

                MoveCyborgBy(Math.Abs(ballSpeedY) * (-playerSpeed));
                return;
            }
            if (ball.Bounds.IntersectsWith(cyborgFront.Bounds))
            {
                ballSpeedX = -ballSpeedX;
                ball.Left = cyborg.Right + ballSpeedX;
                ball.Top += ballSpeedY;
                return;
            }

            if (ball.Bounds.IntersectsWith(alienFront.Bounds)
                && (ball.Bounds.IntersectsWith(alienTop.Bounds) || ball.Bounds.IntersectsWith(alienBottom.Bounds)))
            {
                ballSpeedX = -ballSpeedX;
                ballSpeedY = -ballSpeedY;
                ball.Left = alien.Left + ballSpeedX - ball.Width;
                ball.Top += ballSpeedY;
                return;
            }
            if (ball.Bounds.IntersectsWith(alienTop.Bounds))
            {
                if (ballSpeedY < 0) ballSpeedY = -ballSpeedY;
                ball.Top = alien.Top - ballSpeedY - ball.Height;
                ball.Left += ballSpeedX;

                MoveAlienBy(Math.Abs(ballSpeedY) * playerSpeed);
                return;
            }
            if (ball.Bounds.IntersectsWith(alienBottom.Bounds))
            {
                if (ballSpeedY > 0) ballSpeedY = -ballSpeedY;
                ball.Top = alien.Bottom + ballSpeedY;
                ball.Left += ballSpeedX;

                MoveAlienBy(Math.Abs(ballSpeedY) * (-playerSpeed));
                return;
            }
            if (ball.Bounds.IntersectsWith(alienFront.Bounds))
            {
                ballSpeedX = -ballSpeedX;
                ball.Left = alien.Left + ballSpeedX - ball.Width;
                ball.Top += ballSpeedY;
                return;
            }
        }

        private void NewRound()
        {
            Random random = new Random();
            if (ballSpeedX < 0)
            {
                ball.Top = random.Next(ClientSize.Height / 3, ClientSize.Height / 2);
                ball.Left = random.Next(ClientSize.Width / 3, ClientSize.Width / 2);
            }
            else
            {
                ball.Top = random.Next(ClientSize.Height / 2, 2 * ClientSize.Height / 3);
                ball.Left = random.Next(ClientSize.Width / 2, 2 * ClientSize.Width / 3);
            }

            if (random.Next(0, 2) == 1)
            {
                ballSpeedY = -ballSpeedY;
            }
        }
    }
}
