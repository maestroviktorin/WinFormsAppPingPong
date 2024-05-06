namespace WinFormsAppPingPong
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            easy = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            label6 = new Label();
            HostPanel = new Panel();
            PlayersConnectedLabel = new Label();
            HostPortLabel = new Label();
            HostIpLabel = new Label();
            JoinPanel = new Panel();
            PortInput = new TextBox();
            IpInput = new TextBox();
            SubmitIpPort = new Button();
            label8 = new Label();
            HostPanel.SuspendLayout();
            JoinPanel.SuspendLayout();
            SuspendLayout();
            // 
            // easy
            // 
            easy.Anchor = AnchorStyles.None;
            easy.BackColor = Color.Ivory;
            easy.Font = new Font("Cascadia Mono", 25.92F, FontStyle.Bold, GraphicsUnit.Point, 0);
            easy.ForeColor = Color.CornflowerBlue;
            easy.Location = new Point(118, 309);
            easy.Margin = new Padding(4, 3, 4, 3);
            easy.Name = "easy";
            easy.Size = new Size(92, 81);
            easy.TabIndex = 4;
            easy.Text = "😊";
            easy.UseVisualStyleBackColor = false;
            easy.Click += HostButtonClick;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Cascadia Mono", 36.288F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Ivory;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(804, 79);
            label1.TabIndex = 7;
            label1.Text = "CYBORGS VS. ALIENS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Cascadia Mono", 15F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.Ivory;
            label2.Location = new Point(0, 79);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(804, 33);
            label2.TabIndex = 8;
            label2.Text = "PING-PONG";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Ivory;
            label3.Location = new Point(11, 252);
            label3.Name = "label3";
            label3.Size = new Size(336, 54);
            label3.TabIndex = 9;
            label3.Text = "      CREATE NEW GAME\r\nAND DEFEND YOUR COMPUTER...";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Ivory;
            label4.Location = new Point(460, 279);
            label4.Name = "label4";
            label4.Size = new Size(360, 27);
            label4.TabIndex = 10;
            label4.Text = "...OR INVADE ANOTHER COMPUTER";
            // 
            // button1
            // 
            button1.Font = new Font("Cascadia Mono", 25.92F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(474, 309);
            button1.Name = "button1";
            button1.Size = new Size(289, 81);
            button1.TabIndex = 11;
            button1.Text = "JOIN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += JoinButtonClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Cascadia Mono", 47.808F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Fuchsia;
            label5.Location = new Point(91, 149);
            label5.Name = "label5";
            label5.Size = new Size(154, 106);
            label5.TabIndex = 12;
            label5.Text = "🤖";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Cascadia Mono", 47.808F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Chartreuse;
            label6.Location = new Point(548, 149);
            label6.Name = "label6";
            label6.Size = new Size(143, 106);
            label6.TabIndex = 13;
            label6.Text = "👽";
            // 
            // HostPanel
            // 
            HostPanel.Anchor = AnchorStyles.None;
            HostPanel.BackColor = Color.Transparent;
            HostPanel.BackgroundImageLayout = ImageLayout.Center;
            HostPanel.Controls.Add(PlayersConnectedLabel);
            HostPanel.Controls.Add(HostPortLabel);
            HostPanel.Controls.Add(HostIpLabel);
            HostPanel.Location = new Point(11, 128);
            HostPanel.Name = "HostPanel";
            HostPanel.Size = new Size(387, 376);
            HostPanel.TabIndex = 15;
            // 
            // PlayersConnectedLabel
            // 
            PlayersConnectedLabel.Anchor = AnchorStyles.Left;
            PlayersConnectedLabel.BackColor = Color.Transparent;
            PlayersConnectedLabel.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold);
            PlayersConnectedLabel.ForeColor = Color.Ivory;
            PlayersConnectedLabel.Location = new Point(13, 284);
            PlayersConnectedLabel.Margin = new Padding(4, 0, 4, 0);
            PlayersConnectedLabel.Name = "PlayersConnectedLabel";
            PlayersConnectedLabel.Size = new Size(232, 39);
            PlayersConnectedLabel.TabIndex = 19;
            PlayersConnectedLabel.Text = "Waiting...";
            PlayersConnectedLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HostPortLabel
            // 
            HostPortLabel.Anchor = AnchorStyles.None;
            HostPortLabel.BackColor = Color.Transparent;
            HostPortLabel.Font = new Font("Cascadia Mono", 18F, FontStyle.Bold);
            HostPortLabel.ForeColor = Color.Ivory;
            HostPortLabel.Location = new Point(-209, 79);
            HostPortLabel.Margin = new Padding(4, 0, 4, 0);
            HostPortLabel.Name = "HostPortLabel";
            HostPortLabel.Size = new Size(804, 64);
            HostPortLabel.TabIndex = 18;
            HostPortLabel.Text = "Port: 8079";
            HostPortLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HostIpLabel
            // 
            HostIpLabel.Anchor = AnchorStyles.None;
            HostIpLabel.BackColor = Color.Transparent;
            HostIpLabel.Font = new Font("Cascadia Mono", 18F, FontStyle.Bold);
            HostIpLabel.ForeColor = Color.Ivory;
            HostIpLabel.Location = new Point(-209, 7);
            HostIpLabel.Margin = new Padding(4, 0, 4, 0);
            HostIpLabel.Name = "HostIpLabel";
            HostIpLabel.Size = new Size(804, 72);
            HostIpLabel.TabIndex = 17;
            HostIpLabel.Text = "Local IP: 127.0.0.1";
            HostIpLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // JoinPanel
            // 
            JoinPanel.Anchor = AnchorStyles.None;
            JoinPanel.BackColor = Color.Transparent;
            JoinPanel.BackgroundImageLayout = ImageLayout.Center;
            JoinPanel.Controls.Add(PortInput);
            JoinPanel.Controls.Add(IpInput);
            JoinPanel.Controls.Add(SubmitIpPort);
            JoinPanel.Controls.Add(label8);
            JoinPanel.Location = new Point(405, 128);
            JoinPanel.Name = "JoinPanel";
            JoinPanel.Size = new Size(387, 376);
            JoinPanel.TabIndex = 16;
            // 
            // PortInput
            // 
            PortInput.Location = new Point(88, 116);
            PortInput.Name = "PortInput";
            PortInput.Size = new Size(198, 27);
            PortInput.TabIndex = 22;
            // 
            // IpInput
            // 
            IpInput.Location = new Point(88, 65);
            IpInput.Name = "IpInput";
            IpInput.Size = new Size(198, 27);
            IpInput.TabIndex = 21;
            // 
            // SubmitIpPort
            // 
            SubmitIpPort.Anchor = AnchorStyles.None;
            SubmitIpPort.Location = new Point(143, 210);
            SubmitIpPort.Name = "SubmitIpPort";
            SubmitIpPort.Size = new Size(94, 29);
            SubmitIpPort.TabIndex = 20;
            SubmitIpPort.Text = "Join";
            SubmitIpPort.UseVisualStyleBackColor = true;
            SubmitIpPort.Click += IPAndPortSubmit;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold);
            label8.ForeColor = Color.Ivory;
            label8.Location = new Point(13, 422);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(232, 39);
            label8.TabIndex = 19;
            label8.Text = "Players: 1/2";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(804, 501);
            Controls.Add(JoinPanel);
            Controls.Add(HostPanel);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(easy);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MenuForm";
            Text = "Menu";
            HostPanel.ResumeLayout(false);
            JoinPanel.ResumeLayout(false);
            JoinPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button easy;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button button1;
        private Label label5;
        private Label label6;
        public Label label2;
        public Panel HostPanel;
        private Label HostIpLabel;
        private Label HostPortLabel;
        public Panel JoinPanel;
        private Button SubmitIpPort;
        private Label label8;
        private TextBox PortInput;
        private TextBox IpInput;
        private Label PlayersConnectedLabel;
    }
}