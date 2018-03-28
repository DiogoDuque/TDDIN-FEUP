namespace ClientGUI
{
    partial class LoginForm
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
            this.title = new System.Windows.Forms.Label();
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.loginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginUsernameLabel = new System.Windows.Forms.Label();
            this.loginUsernameTextBox = new System.Windows.Forms.TextBox();
            this.registerGroupBox = new System.Windows.Forms.GroupBox();
            this.registerUsernameLabel = new System.Windows.Forms.Label();
            this.registerUsernameTextBox = new System.Windows.Forms.TextBox();
            this.registerNameLabel = new System.Windows.Forms.Label();
            this.registerNameTextBox = new System.Windows.Forms.TextBox();
            this.registerPasswordLabel = new System.Windows.Forms.Label();
            this.registerPasswordTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.loginGroupBox.SuspendLayout();
            this.registerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(455, 36);
            this.title.TabIndex = 7;
            this.title.Text = "Diginote Exchange System Client";
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.loginButton);
            this.loginGroupBox.Controls.Add(this.loginPasswordLabel);
            this.loginGroupBox.Controls.Add(this.loginPasswordTextBox);
            this.loginGroupBox.Controls.Add(this.loginUsernameLabel);
            this.loginGroupBox.Controls.Add(this.loginUsernameTextBox);
            this.loginGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.loginGroupBox.Location = new System.Drawing.Point(13, 92);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.Size = new System.Drawing.Size(220, 343);
            this.loginGroupBox.TabIndex = 2;
            this.loginGroupBox.TabStop = false;
            this.loginGroupBox.Text = "Login";
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginButton.Location = new System.Drawing.Point(86, 281);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(115, 44);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.loginPasswordLabel.Location = new System.Drawing.Point(13, 167);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(114, 26);
            this.loginPasswordLabel.TabIndex = 3;
            this.loginPasswordLabel.Text = "Password:";
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginPasswordTextBox.Location = new System.Drawing.Point(18, 196);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.PasswordChar = '*';
            this.loginPasswordTextBox.Size = new System.Drawing.Size(183, 30);
            this.loginPasswordTextBox.TabIndex = 2;
            // 
            // loginUsernameLabel
            // 
            this.loginUsernameLabel.AutoSize = true;
            this.loginUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.loginUsernameLabel.Location = new System.Drawing.Point(13, 74);
            this.loginUsernameLabel.Name = "loginUsernameLabel";
            this.loginUsernameLabel.Size = new System.Drawing.Size(119, 26);
            this.loginUsernameLabel.TabIndex = 1;
            this.loginUsernameLabel.Text = "Username:";
            // 
            // loginUsernameTextBox
            // 
            this.loginUsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginUsernameTextBox.Location = new System.Drawing.Point(18, 103);
            this.loginUsernameTextBox.Name = "loginUsernameTextBox";
            this.loginUsernameTextBox.Size = new System.Drawing.Size(183, 30);
            this.loginUsernameTextBox.TabIndex = 0;
            // 
            // registerGroupBox
            // 
            this.registerGroupBox.Controls.Add(this.registerUsernameLabel);
            this.registerGroupBox.Controls.Add(this.registerUsernameTextBox);
            this.registerGroupBox.Controls.Add(this.registerNameLabel);
            this.registerGroupBox.Controls.Add(this.registerNameTextBox);
            this.registerGroupBox.Controls.Add(this.registerPasswordLabel);
            this.registerGroupBox.Controls.Add(this.registerPasswordTextBox);
            this.registerGroupBox.Controls.Add(this.registerButton);
            this.registerGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.registerGroupBox.Location = new System.Drawing.Point(259, 92);
            this.registerGroupBox.Name = "registerGroupBox";
            this.registerGroupBox.Size = new System.Drawing.Size(220, 441);
            this.registerGroupBox.TabIndex = 5;
            this.registerGroupBox.TabStop = false;
            this.registerGroupBox.Text = "Register";
            // 
            // registerUsernameLabel
            // 
            this.registerUsernameLabel.AutoSize = true;
            this.registerUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.registerUsernameLabel.Location = new System.Drawing.Point(13, 74);
            this.registerUsernameLabel.Name = "registerUsernameLabel";
            this.registerUsernameLabel.Size = new System.Drawing.Size(119, 26);
            this.registerUsernameLabel.TabIndex = 1;
            this.registerUsernameLabel.Text = "Username:";
            // 
            // registerUsernameTextBox
            // 
            this.registerUsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.registerUsernameTextBox.Location = new System.Drawing.Point(18, 103);
            this.registerUsernameTextBox.Name = "registerUsernameTextBox";
            this.registerUsernameTextBox.Size = new System.Drawing.Size(183, 30);
            this.registerUsernameTextBox.TabIndex = 0;
            // 
            // registerNameLabel
            // 
            this.registerNameLabel.AutoSize = true;
            this.registerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.registerNameLabel.Location = new System.Drawing.Point(13, 167);
            this.registerNameLabel.Name = "registerNameLabel";
            this.registerNameLabel.Size = new System.Drawing.Size(77, 26);
            this.registerNameLabel.TabIndex = 6;
            this.registerNameLabel.Text = "Name:";
            // 
            // registerNameTextBox
            // 
            this.registerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.registerNameTextBox.Location = new System.Drawing.Point(18, 196);
            this.registerNameTextBox.Name = "registerNameTextBox";
            this.registerNameTextBox.Size = new System.Drawing.Size(183, 30);
            this.registerNameTextBox.TabIndex = 1;
            // 
            // registerPasswordLabel
            // 
            this.registerPasswordLabel.AutoSize = true;
            this.registerPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.registerPasswordLabel.Location = new System.Drawing.Point(13, 260);
            this.registerPasswordLabel.Name = "registerPasswordLabel";
            this.registerPasswordLabel.Size = new System.Drawing.Size(114, 26);
            this.registerPasswordLabel.TabIndex = 3;
            this.registerPasswordLabel.Text = "Password:";
            // 
            // registerPasswordTextBox
            // 
            this.registerPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.registerPasswordTextBox.Location = new System.Drawing.Point(18, 289);
            this.registerPasswordTextBox.Name = "registerPasswordTextBox";
            this.registerPasswordTextBox.PasswordChar = '*';
            this.registerPasswordTextBox.Size = new System.Drawing.Size(183, 30);
            this.registerPasswordTextBox.TabIndex = 2;
            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.registerButton.Location = new System.Drawing.Point(86, 379);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(115, 44);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(13, 458);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(219, 75);
            this.logBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(304, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "activate Queue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 545);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.registerGroupBox);
            this.Controls.Add(this.loginGroupBox);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Diginote Exchange System Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            this.registerGroupBox.ResumeLayout(false);
            this.registerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.Label loginUsernameLabel;
        private System.Windows.Forms.TextBox loginUsernameTextBox;
        private System.Windows.Forms.Label loginPasswordLabel;
        private System.Windows.Forms.TextBox loginPasswordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.GroupBox registerGroupBox;
        private System.Windows.Forms.Label registerUsernameLabel;
        private System.Windows.Forms.TextBox registerUsernameTextBox;
        private System.Windows.Forms.Label registerNameLabel;
        private System.Windows.Forms.TextBox registerNameTextBox;
        private System.Windows.Forms.Label registerPasswordLabel;
        private System.Windows.Forms.TextBox registerPasswordTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button button1;
    }
}

