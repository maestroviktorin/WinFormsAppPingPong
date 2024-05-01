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
            medium = new Button();
            hard = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // easy
            // 
            easy.Anchor = AnchorStyles.None;
            easy.BackColor = Color.Ivory;
            easy.Font = new Font("Cascadia Mono", 25.92F, FontStyle.Bold, GraphicsUnit.Point, 0);
            easy.ForeColor = Color.CornflowerBlue;
            easy.Location = new Point(13, 324);
            easy.Margin = new Padding(4, 3, 4, 3);
            easy.Name = "easy";
            easy.Size = new Size(103, 85);
            easy.TabIndex = 4;
            easy.Text = "😊";
            easy.UseVisualStyleBackColor = false;
            easy.Click += button1_Click;
            // 
            // medium
            // 
            medium.Anchor = AnchorStyles.None;
            medium.BackColor = Color.Ivory;
            medium.Font = new Font("Cascadia Mono", 25.92F, FontStyle.Bold);
            medium.ForeColor = Color.Orange;
            medium.Location = new Point(124, 324);
            medium.Margin = new Padding(4, 3, 4, 3);
            medium.Name = "medium";
            medium.Size = new Size(103, 85);
            medium.TabIndex = 5;
            medium.Text = "🙃";
            medium.UseVisualStyleBackColor = false;
            medium.Click += button2_Click;
            // 
            // hard
            // 
            hard.Anchor = AnchorStyles.None;
            hard.BackColor = Color.Ivory;
            hard.Font = new Font("Cascadia Mono", 25.92F, FontStyle.Bold);
            hard.ForeColor = Color.Crimson;
            hard.Location = new Point(235, 324);
            hard.Margin = new Padding(4, 3, 4, 3);
            hard.Name = "hard";
            hard.Size = new Size(103, 85);
            hard.TabIndex = 6;
            hard.Text = "☠️";
            hard.UseVisualStyleBackColor = false;
            hard.Click += button3_Click;
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
            label1.Size = new Size(905, 83);
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
            label2.Location = new Point(0, 83);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(905, 35);
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
            label3.Location = new Point(12, 265);
            label3.Name = "label3";
            label3.Size = new Size(336, 56);
            label3.TabIndex = 9;
            label3.Text = "      CREATE NEW GAME\r\nAND DEFEND YOUR COMPUTER...";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Ivory;
            label4.Location = new Point(518, 293);
            label4.Name = "label4";
            label4.Size = new Size(360, 28);
            label4.TabIndex = 10;
            label4.Text = "...OR INVADE ANOTHER COMPUTER";
            // 
            // button1
            // 
            button1.Font = new Font("Cascadia Mono", 25.92F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(533, 324);
            button1.Name = "button1";
            button1.Size = new Size(325, 85);
            button1.TabIndex = 11;
            button1.Text = "JOIN";
            button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Cascadia Mono", 47.808F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Fuchsia;
            label5.Location = new Point(102, 156);
            label5.Name = "label5";
            label5.Size = new Size(155, 109);
            label5.TabIndex = 12;
            label5.Text = "🤖";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Cascadia Mono", 47.808F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Chartreuse;
            label6.Location = new Point(617, 156);
            label6.Name = "label6";
            label6.Size = new Size(155, 109);
            label6.TabIndex = 13;
            label6.Text = "👽";
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(905, 526);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hard);
            Controls.Add(medium);
            Controls.Add(easy);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MenuForm";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button easy;
        private Button medium;
        private Button hard;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Label label5;
        private Label label6;
    }
}