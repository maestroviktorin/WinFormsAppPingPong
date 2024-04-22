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

        public Game()
        {
            InitializeComponent();
        }

        public Game(int ballSpeedX, int ballSpeedY)
        {
            this.ballSpeedX = ballSpeedX;
            this.ballSpeedY = ballSpeedY;

            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
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

            if (alienDown)
            {
                MoveAlienBy(playerSpeed);
            }

            if (alienUp)
            {
                MoveAlienBy(-playerSpeed);
            }

            if (cyborgDown)
            {
                MoveCyborgBy(playerSpeed);
            }
            if (cyborgUp)
            {
                MoveCyborgBy(-playerSpeed);
            }

            if (alien.Top < 0)
            {
                MoveAlienBy(playerSpeed);
            }
            if (cyborg.Top < 0)
            {
                MoveCyborgBy(playerSpeed);
            }

            if (alien.Bottom > ClientSize.Height)
            {
                MoveAlienBy(-playerSpeed);
            }
            if (cyborg.Bottom > ClientSize.Height)
            {
                MoveCyborgBy(-playerSpeed);
            }

            alienCounterLabel.Text = alienCounter.ToString();
            cyborgCounterLabel.Text = cyborgCounter.ToString();

            CheckCollisions();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                alienDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                alienUp = true;
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

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                alienDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                alienUp = false;
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

        private void MoveAlienBy(int speed)
        {
            alien.Top += speed;
            alienBottom.Top += speed;
            alienTop.Top += speed;
            alienFront.Top += speed;
        }

        private void MoveCyborgBy(int speed)
        {
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
            if (ball.Bounds.IntersectsWith(cyborgFront.Bounds))
            {
                ballSpeedX = -ballSpeedX;
                ball.Left = cyborg.Right + ballSpeedX;
                return;
            }
            if (ball.Bounds.IntersectsWith(cyborgTop.Bounds))
            {
                ballSpeedY = -ballSpeedY;
                ball.Top = cyborg.Top - ball.Height;

                MoveCyborgBy(Math.Abs(ballSpeedY) * playerSpeed);
                return;
            }
            if (ball.Bounds.IntersectsWith(cyborgBottom.Bounds))
            {
                ballSpeedY = -ballSpeedY;
                ball.Top = cyborg.Bottom + ball.Height;

                MoveCyborgBy(Math.Abs(ballSpeedY) * (-playerSpeed));
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
            if (ball.Bounds.IntersectsWith(alienFront.Bounds))
            {
                ballSpeedX = -ballSpeedX;
                ball.Left = alien.Left + ballSpeedX - ball.Width;
                return;
            }
            if (ball.Bounds.IntersectsWith(alienTop.Bounds))
            {
                ballSpeedY = -ballSpeedY;
                ball.Top = alien.Top - ballSpeedY;

                MoveAlienBy(Math.Abs(ballSpeedY) * (-playerSpeed));
                return;
            }
            if (ball.Bounds.IntersectsWith(alienBottom.Bounds))
            {
                ballSpeedY = -ballSpeedY;
                ball.Top = alien.Bottom + ballSpeedY;

                MoveAlienBy(Math.Abs(ballSpeedY) * (-playerSpeed));
                return;
            }
        }

        private void NewRound()
        {
            ballSpeedX = -ballSpeedX;
            ballSpeedY = -ballSpeedY;

            Random random = new Random();
            ball.Top = random.Next(ClientSize.Height / 3, 2 * ClientSize.Height / 3);
            ball.Left = random.Next(ClientSize.Width / 3, 2 * ClientSize.Width / 3);
        }
    }
}
