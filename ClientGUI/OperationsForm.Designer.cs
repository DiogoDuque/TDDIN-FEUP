namespace ClientGUI
{
    partial class OperationsForm
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
            this.systemInfo = new System.Windows.Forms.GroupBox();
            this.systemInfoUpdateButton = new System.Windows.Forms.Button();
            this.currentPurchaseOrdersTextBox = new System.Windows.Forms.TextBox();
            this.currentQuoteLabel = new System.Windows.Forms.Label();
            this.currentQuoteTextBox = new System.Windows.Forms.TextBox();
            this.currentPurchaseOrdersLabel = new System.Windows.Forms.Label();
            this.currentSellingOrdersTextBox = new System.Windows.Forms.TextBox();
            this.currentSellingOrdersLabel = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.myInfo = new System.Windows.Forms.GroupBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.systemInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // systemInfo
            // 
            this.systemInfo.Controls.Add(this.systemInfoUpdateButton);
            this.systemInfo.Controls.Add(this.currentPurchaseOrdersTextBox);
            this.systemInfo.Controls.Add(this.currentQuoteLabel);
            this.systemInfo.Controls.Add(this.currentQuoteTextBox);
            this.systemInfo.Controls.Add(this.currentPurchaseOrdersLabel);
            this.systemInfo.Controls.Add(this.currentSellingOrdersTextBox);
            this.systemInfo.Controls.Add(this.currentSellingOrdersLabel);
            this.systemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.systemInfo.Location = new System.Drawing.Point(18, 64);
            this.systemInfo.Name = "systemInfo";
            this.systemInfo.Size = new System.Drawing.Size(925, 103);
            this.systemInfo.TabIndex = 0;
            this.systemInfo.TabStop = false;
            this.systemInfo.Text = "System Information";
            // 
            // systemInfoUpdateButton
            // 
            this.systemInfoUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemInfoUpdateButton.Location = new System.Drawing.Point(18, 42);
            this.systemInfoUpdateButton.Name = "systemInfoUpdateButton";
            this.systemInfoUpdateButton.Size = new System.Drawing.Size(168, 45);
            this.systemInfoUpdateButton.TabIndex = 6;
            this.systemInfoUpdateButton.Text = "Update Info";
            this.systemInfoUpdateButton.UseVisualStyleBackColor = true;
            this.systemInfoUpdateButton.Click += new System.EventHandler(this.systemInfoUpdateButton_Click);
            // 
            // currentPurchaseOrdersTextBox
            // 
            this.currentPurchaseOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentPurchaseOrdersTextBox.Location = new System.Drawing.Point(849, 48);
            this.currentPurchaseOrdersTextBox.Name = "currentPurchaseOrdersTextBox";
            this.currentPurchaseOrdersTextBox.ReadOnly = true;
            this.currentPurchaseOrdersTextBox.Size = new System.Drawing.Size(45, 32);
            this.currentPurchaseOrdersTextBox.TabIndex = 5;
            // 
            // currentQuoteLabel
            // 
            this.currentQuoteLabel.AutoSize = true;
            this.currentQuoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentQuoteLabel.Location = new System.Drawing.Point(218, 51);
            this.currentQuoteLabel.Name = "currentQuoteLabel";
            this.currentQuoteLabel.Size = new System.Drawing.Size(71, 26);
            this.currentQuoteLabel.TabIndex = 0;
            this.currentQuoteLabel.Text = "Quote";
            // 
            // currentQuoteTextBox
            // 
            this.currentQuoteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentQuoteTextBox.Location = new System.Drawing.Point(295, 48);
            this.currentQuoteTextBox.Name = "currentQuoteTextBox";
            this.currentQuoteTextBox.ReadOnly = true;
            this.currentQuoteTextBox.Size = new System.Drawing.Size(75, 32);
            this.currentQuoteTextBox.TabIndex = 1;
            // 
            // currentPurchaseOrdersLabel
            // 
            this.currentPurchaseOrdersLabel.AutoSize = true;
            this.currentPurchaseOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentPurchaseOrdersLabel.Location = new System.Drawing.Point(667, 51);
            this.currentPurchaseOrdersLabel.Name = "currentPurchaseOrdersLabel";
            this.currentPurchaseOrdersLabel.Size = new System.Drawing.Size(176, 26);
            this.currentPurchaseOrdersLabel.TabIndex = 4;
            this.currentPurchaseOrdersLabel.Text = "Purchase Orders";
            // 
            // currentSellingOrdersTextBox
            // 
            this.currentSellingOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentSellingOrdersTextBox.Location = new System.Drawing.Point(569, 48);
            this.currentSellingOrdersTextBox.Name = "currentSellingOrdersTextBox";
            this.currentSellingOrdersTextBox.ReadOnly = true;
            this.currentSellingOrdersTextBox.Size = new System.Drawing.Size(45, 32);
            this.currentSellingOrdersTextBox.TabIndex = 3;
            // 
            // currentSellingOrdersLabel
            // 
            this.currentSellingOrdersLabel.AutoSize = true;
            this.currentSellingOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentSellingOrdersLabel.Location = new System.Drawing.Point(413, 51);
            this.currentSellingOrdersLabel.Name = "currentSellingOrdersLabel";
            this.currentSellingOrdersLabel.Size = new System.Drawing.Size(150, 26);
            this.currentSellingOrdersLabel.TabIndex = 2;
            this.currentSellingOrdersLabel.Text = "Selling Orders";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(455, 36);
            this.title.TabIndex = 8;
            this.title.Text = "Diginote Exchange System Client";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.welcomeLabel.Location = new System.Drawing.Point(806, 18);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(137, 25);
            this.welcomeLabel.TabIndex = 9;
            this.welcomeLabel.Text = "welcomeLabel";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // myInfo
            // 
            this.myInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.myInfo.Location = new System.Drawing.Point(18, 204);
            this.myInfo.Name = "myInfo";
            this.myInfo.Size = new System.Drawing.Size(925, 103);
            this.myInfo.TabIndex = 10;
            this.myInfo.TabStop = false;
            this.myInfo.Text = "My Information";
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.logoutButton.Location = new System.Drawing.Point(775, 508);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(168, 45);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // OperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 565);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.myInfo);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.title);
            this.Controls.Add(this.systemInfo);
            this.Name = "OperationsForm";
            this.Text = "Diginote Exchange System Client";
            this.systemInfo.ResumeLayout(false);
            this.systemInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox systemInfo;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox currentQuoteTextBox;
        private System.Windows.Forms.Label currentQuoteLabel;
        private System.Windows.Forms.TextBox currentSellingOrdersTextBox;
        private System.Windows.Forms.Label currentSellingOrdersLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.TextBox currentPurchaseOrdersTextBox;
        private System.Windows.Forms.Label currentPurchaseOrdersLabel;
        private System.Windows.Forms.Button systemInfoUpdateButton;
        private System.Windows.Forms.GroupBox myInfo;
        private System.Windows.Forms.Button logoutButton;
    }
}