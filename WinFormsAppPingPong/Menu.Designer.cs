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
            easy.Location = new Point(103, 232);
            easy.Margin = new Padding(4, 2, 4, 2);
            easy.Name = "easy";
            easy.Size = new Size(80, 61);
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
            label1.Size = new Size(704, 59);
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
            label2.Location = new Point(0, 59);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(704, 25);
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
            label3.Location = new Point(10, 189);
            label3.Name = "label3";
            label3.Size = new Size(253, 42);
            label3.TabIndex = 9;
            label3.Text = "      CREATE NEW GAME\r\nAND DEFEND YOUR COMPUTER...";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Ivory;
            label4.Location = new Point(402, 209);
            label4.Name = "label4";
            label4.Size = new Size(271, 21);
            label4.TabIndex = 10;
            label4.Text = "...OR INVADE ANOTHER COMPUTER";
            // 
            // button1
            // 
            button1.Font = new Font("Cascadia Mono", 25.92F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(415, 232);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(253, 61);
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
            label5.Location = new Point(80, 112);
            label5.Name = "label5";
            label5.Size = new Size(125, 85);
            label5.TabIndex = 12;
            label5.Text = "🤖";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Cascadia Mono", 47.808F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Chartreuse;
            label6.Location = new Point(480, 112);
            label6.Name = "label6";
            label6.Size = new Size(116, 85);
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
            HostPanel.Location = new Point(10, 96);
            HostPanel.Margin = new Padding(3, 2, 3, 2);
            HostPanel.Name = "HostPanel";
            HostPanel.Size = new Size(339, 282);
            HostPanel.TabIndex = 15;
            // 
            // PlayersConnectedLabel
            // 
            PlayersConnectedLabel.Anchor = AnchorStyles.Left;
            PlayersConnectedLabel.BackColor = Color.Transparent;
            PlayersConnectedLabel.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold);
            PlayersConnectedLabel.ForeColor = Color.Ivory;
            PlayersConnectedLabel.Location = new Point(11, 213);
            PlayersConnectedLabel.Margin = new Padding(4, 0, 4, 0);
            PlayersConnectedLabel.Name = "PlayersConnectedLabel";
            PlayersConnectedLabel.Size = new Size(203, 29);
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
            HostPortLabel.Location = new Point(-183, 59);
            HostPortLabel.Margin = new Padding(4, 0, 4, 0);
            HostPortLabel.Name = "HostPortLabel";
            HostPortLabel.Size = new Size(704, 48);
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
            HostIpLabel.Location = new Point(-183, 5);
            HostIpLabel.Margin = new Padding(4, 0, 4, 0);
            HostIpLabel.Name = "HostIpLabel";
            HostIpLabel.Size = new Size(704, 54);
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
            JoinPanel.Location = new Point(354, 96);
            JoinPanel.Margin = new Padding(3, 2, 3, 2);
            JoinPanel.Name = "JoinPanel";
            JoinPanel.Size = new Size(339, 282);
            JoinPanel.TabIndex = 16;
            // 
            // PortInput
            // 
            PortInput.Location = new Point(77, 87);
            PortInput.Margin = new Padding(3, 2, 3, 2);
            PortInput.Name = "PortInput";
            PortInput.Size = new Size(174, 23);
            PortInput.TabIndex = 22;
            // 
            // IpInput
            // 
            IpInput.Location = new Point(77, 49);
            IpInput.Margin = new Padding(3, 2, 3, 2);
            IpInput.Name = "IpInput";
            IpInput.Size = new Size(174, 23);
            IpInput.TabIndex = 21;
            // 
            // SubmitIpPort
            // 
            SubmitIpPort.Anchor = AnchorStyles.None;
            SubmitIpPort.Location = new Point(125, 158);
            SubmitIpPort.Margin = new Padding(3, 2, 3, 2);
            SubmitIpPort.Name = "SubmitIpPort";
            SubmitIpPort.Size = new Size(82, 22);
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
            label8.Location = new Point(11, 316);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(203, 29);
            label8.TabIndex = 19;
            label8.Text = "Players: 1/2";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(704, 376);
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
            Margin = new Padding(4, 2, 4, 2);
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