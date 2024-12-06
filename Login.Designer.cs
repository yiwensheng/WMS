namespace WMS
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            lsystemname = new Label();
            luser = new Label();
            tuser = new TextBox();
            lpassword = new Label();
            tpassword = new TextBox();
            Bok = new Button();
            Bno = new Button();
            Bquit = new Button();
            SuspendLayout();
            // 
            // lsystemname
            // 
            lsystemname.Dock = DockStyle.Top;
            lsystemname.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lsystemname.ForeColor = Color.White;
            lsystemname.Location = new Point(0, 0);
            lsystemname.Name = "lsystemname";
            lsystemname.Size = new Size(800, 129);
            lsystemname.TabIndex = 0;
            lsystemname.Text = "label1";
            lsystemname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // luser
            // 
            luser.AutoSize = true;
            luser.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            luser.ForeColor = Color.White;
            luser.Location = new Point(268, 183);
            luser.Name = "luser";
            luser.Size = new Size(69, 26);
            luser.TabIndex = 1;
            luser.Text = "用户：";
            // 
            // tuser
            // 
            tuser.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tuser.Location = new Point(343, 185);
            tuser.Name = "tuser";
            tuser.Size = new Size(188, 25);
            tuser.TabIndex = 2;
            // 
            // lpassword
            // 
            lpassword.AutoSize = true;
            lpassword.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lpassword.ForeColor = Color.White;
            lpassword.Location = new Point(268, 231);
            lpassword.Name = "lpassword";
            lpassword.Size = new Size(69, 26);
            lpassword.TabIndex = 3;
            lpassword.Text = "密码：";
            // 
            // tpassword
            // 
            tpassword.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tpassword.Location = new Point(343, 234);
            tpassword.Name = "tpassword";
            tpassword.PasswordChar = '*';
            tpassword.Size = new Size(188, 25);
            tpassword.TabIndex = 4;
            // 
            // Bok
            // 
            Bok.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Bok.Location = new Point(248, 315);
            Bok.Name = "Bok";
            Bok.Size = new Size(97, 39);
            Bok.TabIndex = 5;
            Bok.Text = "登录";
            Bok.UseVisualStyleBackColor = true;
            Bok.Click += Bok_Click;
            // 
            // Bno
            // 
            Bno.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Bno.Location = new Point(353, 315);
            Bno.Name = "Bno";
            Bno.Size = new Size(97, 39);
            Bno.TabIndex = 6;
            Bno.Text = "取消";
            Bno.UseVisualStyleBackColor = true;
            Bno.Click += Bno_Click;
            // 
            // Bquit
            // 
            Bquit.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Bquit.Location = new Point(456, 315);
            Bquit.Name = "Bquit";
            Bquit.Size = new Size(97, 39);
            Bquit.TabIndex = 7;
            Bquit.Text = "退出";
            Bquit.UseVisualStyleBackColor = true;
            Bquit.Click += Bquit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(Bquit);
            Controls.Add(Bno);
            Controls.Add(Bok);
            Controls.Add(tpassword);
            Controls.Add(lpassword);
            Controls.Add(tuser);
            Controls.Add(luser);
            Controls.Add(lsystemname);
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lsystemname;
        private Label luser;
        private TextBox tuser;
        private Label lpassword;
        private TextBox tpassword;
        private Button Bok;
        private Button Bno;
        private Button Bquit;
    }
}