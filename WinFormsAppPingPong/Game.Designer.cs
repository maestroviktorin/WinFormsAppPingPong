namespace WinFormsAppPingPong
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            alien = new PictureBox();
            cyborg = new PictureBox();
            Timer = new System.Windows.Forms.Timer(components);
            ball = new PictureBox();
            cyborgTop = new PictureBox();
            cyborgBottom = new PictureBox();
            alienBottom = new PictureBox();
            alienTop = new PictureBox();
            cyborgFront = new PictureBox();
            alienFront = new PictureBox();
            cyborgCounterLabel = new Label();
            alienCounterLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)alien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cyborg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cyborgTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cyborgBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alienBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alienTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cyborgFront).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alienFront).BeginInit();
            SuspendLayout();
            // 
            // alien
            // 
            alien.BackColor = Color.PaleGreen;
            resources.ApplyResources(alien, "alien");
            alien.BorderStyle = BorderStyle.FixedSingle;
            alien.Name = "alien";
            alien.TabStop = false;
            // 
            // cyborg
            // 
            cyborg.BackColor = Color.DarkOrchid;
            resources.ApplyResources(cyborg, "cyborg");
            cyborg.BorderStyle = BorderStyle.FixedSingle;
            cyborg.Name = "cyborg";
            cyborg.TabStop = false;
            // 
            // Timer
            // 
            Timer.Enabled = true;
            Timer.Interval = 5;
            Timer.Tick += Timer_Tick;
            // 
            // ball
            // 
            ball.BackColor = Color.Transparent;
            resources.ApplyResources(ball, "ball");
            ball.Name = "ball";
            ball.TabStop = false;
            // 
            // cyborgTop
            // 
            cyborgTop.BackColor = Color.Indigo;
            resources.ApplyResources(cyborgTop, "cyborgTop");
            cyborgTop.Name = "cyborgTop";
            cyborgTop.TabStop = false;
            // 
            // cyborgBottom
            // 
            cyborgBottom.BackColor = Color.Indigo;
            resources.ApplyResources(cyborgBottom, "cyborgBottom");
            cyborgBottom.Name = "cyborgBottom";
            cyborgBottom.TabStop = false;
            // 
            // alienBottom
            // 
            alienBottom.BackColor = Color.LimeGreen;
            resources.ApplyResources(alienBottom, "alienBottom");
            alienBottom.Name = "alienBottom";
            alienBottom.TabStop = false;
            // 
            // alienTop
            // 
            alienTop.BackColor = Color.LimeGreen;
            resources.ApplyResources(alienTop, "alienTop");
            alienTop.Name = "alienTop";
            alienTop.TabStop = false;
            // 
            // cyborgFront
            // 
            cyborgFront.BackColor = Color.Indigo;
            resources.ApplyResources(cyborgFront, "cyborgFront");
            cyborgFront.Name = "cyborgFront";
            cyborgFront.TabStop = false;
            // 
            // alienFront
            // 
            alienFront.BackColor = Color.LimeGreen;
            resources.ApplyResources(alienFront, "alienFront");
            alienFront.Name = "alienFront";
            alienFront.TabStop = false;
            // 
            // cyborgCounterLabel
            // 
            resources.ApplyResources(cyborgCounterLabel, "cyborgCounterLabel");
            cyborgCounterLabel.Name = "cyborgCounterLabel";
            // 
            // alienCounterLabel
            // 
            resources.ApplyResources(alienCounterLabel, "alienCounterLabel");
            alienCounterLabel.Name = "alienCounterLabel";
            // 
            // Game
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            Controls.Add(alienFront);
            Controls.Add(cyborgFront);
            Controls.Add(alienBottom);
            Controls.Add(alienTop);
            Controls.Add(cyborgBottom);
            Controls.Add(cyborgTop);
            Controls.Add(ball);
            Controls.Add(cyborg);
            Controls.Add(alien);
            Controls.Add(alienCounterLabel);
            Controls.Add(cyborgCounterLabel);
            DoubleBuffered = true;
            Name = "Game";
            KeyDown += Game_KeyDown;
            KeyUp += Game_KeyUp;
            ((System.ComponentModel.ISupportInitialize)alien).EndInit();
            ((System.ComponentModel.ISupportInitialize)cyborg).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ((System.ComponentModel.ISupportInitialize)cyborgTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)cyborgBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)alienBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)alienTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)cyborgFront).EndInit();
            ((System.ComponentModel.ISupportInitialize)alienFront).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox alien;
        private PictureBox cyborg;
        private System.Windows.Forms.Timer Timer;
        private PictureBox ball;
        private PictureBox cyborgTop;
        private PictureBox cyborgBottom;
        private PictureBox alienBottom;
        private PictureBox alienTop;
        private PictureBox cyborgFront;
        private PictureBox alienFront;
        private Label cyborgCounterLabel;
        private Label alienCounterLabel;
    }
}
