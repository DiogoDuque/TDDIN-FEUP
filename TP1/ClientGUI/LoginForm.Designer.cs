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
            this.loginGroupBox.SuspendLayout();
            this.registerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.title.Location = new System.Drawing.Point(8, 6);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(302, 25);
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
            this.loginGroupBox.Location = new System.Drawing.Point(9, 60);
            this.loginGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginGroupBox.Size = new System.Drawing.Size(147, 223);
            this.loginGroupBox.TabIndex = 2;
            this.loginGroupBox.TabStop = false;
            this.loginGroupBox.Text = "Login";
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginButton.Location = new System.Drawing.Point(57, 183);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(77, 29);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.loginPasswordLabel.Location = new System.Drawing.Point(9, 109);
            this.loginPasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(79, 18);
            this.loginPasswordLabel.TabIndex = 3;
            this.loginPasswordLabel.Text = "Password:";
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginPasswordTextBox.Location = new System.Drawing.Point(12, 127);
            this.loginPasswordTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.PasswordChar = '*';
            this.loginPasswordTextBox.Size = new System.Drawing.Size(123, 23);
            this.loginPasswordTextBox.TabIndex = 2;
            // 
            // loginUsernameLabel
            // 
            this.loginUsernameLabel.AutoSize = true;
            this.loginUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.loginUsernameLabel.Location = new System.Drawing.Point(9, 48);
            this.loginUsernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loginUsernameLabel.Name = "loginUsernameLabel";
            this.loginUsernameLabel.Size = new System.Drawing.Size(81, 18);
            this.loginUsernameLabel.TabIndex = 1;
            this.loginUsernameLabel.Text = "Username:";
            // 
            // loginUsernameTextBox
            // 
            this.loginUsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginUsernameTextBox.Location = new System.Drawing.Point(12, 67);
            this.loginUsernameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginUsernameTextBox.Name = "loginUsernameTextBox";
            this.loginUsernameTextBox.Size = new System.Drawing.Size(123, 23);
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
            this.registerGroupBox.Location = new System.Drawing.Point(173, 60);
            this.registerGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerGroupBox.Name = "registerGroupBox";
            this.registerGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerGroupBox.Size = new System.Drawing.Size(147, 287);
            this.registerGroupBox.TabIndex = 5;
            this.registerGroupBox.TabStop = false;
            this.registerGroupBox.Text = "Register";
            // 
            // registerUsernameLabel
            // 
            this.registerUsernameLabel.AutoSize = true;
            this.registerUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.registerUsernameLabel.Location = new System.Drawing.Point(9, 48);
            this.registerUsernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.registerUsernameLabel.Name = "registerUsernameLabel";
            this.registerUsernameLabel.Size = new System.Drawing.Size(81, 18);
            this.registerUsernameLabel.TabIndex = 1;
            this.registerUsernameLabel.Text = "Username:";
            // 
            // registerUsernameTextBox
            // 
            this.registerUsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.registerUsernameTextBox.Location = new System.Drawing.Point(12, 67);
            this.registerUsernameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerUsernameTextBox.Name = "registerUsernameTextBox";
            this.registerUsernameTextBox.Size = new System.Drawing.Size(123, 23);
            this.registerUsernameTextBox.TabIndex = 0;
            // 
            // registerNameLabel
            // 
            this.registerNameLabel.AutoSize = true;
            this.registerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.registerNameLabel.Location = new System.Drawing.Point(9, 109);
            this.registerNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.registerNameLabel.Name = "registerNameLabel";
            this.registerNameLabel.Size = new System.Drawing.Size(52, 18);
            this.registerNameLabel.TabIndex = 6;
            this.registerNameLabel.Text = "Name:";
            // 
            // registerNameTextBox
            // 
            this.registerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.registerNameTextBox.Location = new System.Drawing.Point(12, 127);
            this.registerNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerNameTextBox.Name = "registerNameTextBox";
            this.registerNameTextBox.Size = new System.Drawing.Size(123, 23);
            this.registerNameTextBox.TabIndex = 1;
            // 
            // registerPasswordLabel
            // 
            this.registerPasswordLabel.AutoSize = true;
            this.registerPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.registerPasswordLabel.Location = new System.Drawing.Point(9, 169);
            this.registerPasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.registerPasswordLabel.Name = "registerPasswordLabel";
            this.registerPasswordLabel.Size = new System.Drawing.Size(79, 18);
            this.registerPasswordLabel.TabIndex = 3;
            this.registerPasswordLabel.Text = "Password:";
            // 
            // registerPasswordTextBox
            // 
            this.registerPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.registerPasswordTextBox.Location = new System.Drawing.Point(12, 188);
            this.registerPasswordTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerPasswordTextBox.Name = "registerPasswordTextBox";
            this.registerPasswordTextBox.PasswordChar = '*';
            this.registerPasswordTextBox.Size = new System.Drawing.Size(123, 23);
            this.registerPasswordTextBox.TabIndex = 2;
            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.registerButton.Location = new System.Drawing.Point(57, 246);
            this.registerButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(77, 29);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(9, 298);
            this.logBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(147, 50);
            this.logBox.TabIndex = 6;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 354);
            this.Controls.Add(this.title);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.registerGroupBox);
            this.Controls.Add(this.loginGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}

