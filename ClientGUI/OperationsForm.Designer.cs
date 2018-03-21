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
            this.systemPurchaseOrdersTextBox = new System.Windows.Forms.TextBox();
            this.currentQuoteLabel = new System.Windows.Forms.Label();
            this.currentQuoteTextBox = new System.Windows.Forms.TextBox();
            this.systemPurchaseOrdersLabel = new System.Windows.Forms.Label();
            this.systemSellingOrdersTextBox = new System.Windows.Forms.TextBox();
            this.systemSellingOrdersLabel = new System.Windows.Forms.Label();
            this.infoUpdateButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.myInfo = new System.Windows.Forms.GroupBox();
            this.myDiginotesTextBox = new System.Windows.Forms.TextBox();
            this.myDiginotesLabel = new System.Windows.Forms.Label();
            this.myPurchaseOrdersTextBox = new System.Windows.Forms.TextBox();
            this.mySellingOrdersTextBox = new System.Windows.Forms.TextBox();
            this.myPurchaseOrdersLabel = new System.Windows.Forms.Label();
            this.mySellingOrdersLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.submitMyOrders = new System.Windows.Forms.Button();
            this.systemInfo.SuspendLayout();
            this.myInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // systemInfo
            // 
            this.systemInfo.Controls.Add(this.systemPurchaseOrdersTextBox);
            this.systemInfo.Controls.Add(this.currentQuoteLabel);
            this.systemInfo.Controls.Add(this.currentQuoteTextBox);
            this.systemInfo.Controls.Add(this.systemPurchaseOrdersLabel);
            this.systemInfo.Controls.Add(this.systemSellingOrdersTextBox);
            this.systemInfo.Controls.Add(this.systemSellingOrdersLabel);
            this.systemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.systemInfo.Location = new System.Drawing.Point(18, 157);
            this.systemInfo.Name = "systemInfo";
            this.systemInfo.Size = new System.Drawing.Size(925, 103);
            this.systemInfo.TabIndex = 0;
            this.systemInfo.TabStop = false;
            this.systemInfo.Text = "System Information";
            // 
            // systemPurchaseOrdersTextBox
            // 
            this.systemPurchaseOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemPurchaseOrdersTextBox.Location = new System.Drawing.Point(849, 48);
            this.systemPurchaseOrdersTextBox.Name = "systemPurchaseOrdersTextBox";
            this.systemPurchaseOrdersTextBox.ReadOnly = true;
            this.systemPurchaseOrdersTextBox.Size = new System.Drawing.Size(45, 32);
            this.systemPurchaseOrdersTextBox.TabIndex = 5;
            // 
            // currentQuoteLabel
            // 
            this.currentQuoteLabel.AutoSize = true;
            this.currentQuoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentQuoteLabel.Location = new System.Drawing.Point(13, 51);
            this.currentQuoteLabel.Name = "currentQuoteLabel";
            this.currentQuoteLabel.Size = new System.Drawing.Size(168, 26);
            this.currentQuoteLabel.TabIndex = 0;
            this.currentQuoteLabel.Text = "Diginotes Quote";
            // 
            // currentQuoteTextBox
            // 
            this.currentQuoteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentQuoteTextBox.Location = new System.Drawing.Point(187, 48);
            this.currentQuoteTextBox.Name = "currentQuoteTextBox";
            this.currentQuoteTextBox.ReadOnly = true;
            this.currentQuoteTextBox.Size = new System.Drawing.Size(75, 32);
            this.currentQuoteTextBox.TabIndex = 1;
            // 
            // systemPurchaseOrdersLabel
            // 
            this.systemPurchaseOrdersLabel.AutoSize = true;
            this.systemPurchaseOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemPurchaseOrdersLabel.Location = new System.Drawing.Point(667, 51);
            this.systemPurchaseOrdersLabel.Name = "systemPurchaseOrdersLabel";
            this.systemPurchaseOrdersLabel.Size = new System.Drawing.Size(176, 26);
            this.systemPurchaseOrdersLabel.TabIndex = 4;
            this.systemPurchaseOrdersLabel.Text = "Purchase Orders";
            // 
            // systemSellingOrdersTextBox
            // 
            this.systemSellingOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemSellingOrdersTextBox.Location = new System.Drawing.Point(511, 48);
            this.systemSellingOrdersTextBox.Name = "systemSellingOrdersTextBox";
            this.systemSellingOrdersTextBox.ReadOnly = true;
            this.systemSellingOrdersTextBox.Size = new System.Drawing.Size(45, 32);
            this.systemSellingOrdersTextBox.TabIndex = 3;
            // 
            // systemSellingOrdersLabel
            // 
            this.systemSellingOrdersLabel.AutoSize = true;
            this.systemSellingOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemSellingOrdersLabel.Location = new System.Drawing.Point(355, 51);
            this.systemSellingOrdersLabel.Name = "systemSellingOrdersLabel";
            this.systemSellingOrdersLabel.Size = new System.Drawing.Size(150, 26);
            this.systemSellingOrdersLabel.TabIndex = 2;
            this.systemSellingOrdersLabel.Text = "Selling Orders";
            // 
            // infoUpdateButton
            // 
            this.infoUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.infoUpdateButton.Location = new System.Drawing.Point(18, 74);
            this.infoUpdateButton.Name = "infoUpdateButton";
            this.infoUpdateButton.Size = new System.Drawing.Size(168, 45);
            this.infoUpdateButton.TabIndex = 6;
            this.infoUpdateButton.Text = "Update Info";
            this.infoUpdateButton.UseVisualStyleBackColor = true;
            this.infoUpdateButton.Click += new System.EventHandler(this.infoUpdateButton_Click);
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
            this.myInfo.Controls.Add(this.submitMyOrders);
            this.myInfo.Controls.Add(this.myDiginotesTextBox);
            this.myInfo.Controls.Add(this.myDiginotesLabel);
            this.myInfo.Controls.Add(this.myPurchaseOrdersTextBox);
            this.myInfo.Controls.Add(this.mySellingOrdersTextBox);
            this.myInfo.Controls.Add(this.myPurchaseOrdersLabel);
            this.myInfo.Controls.Add(this.mySellingOrdersLabel);
            this.myInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.myInfo.Location = new System.Drawing.Point(18, 304);
            this.myInfo.Name = "myInfo";
            this.myInfo.Size = new System.Drawing.Size(925, 179);
            this.myInfo.TabIndex = 10;
            this.myInfo.TabStop = false;
            this.myInfo.Text = "My Information";
            // 
            // myDiginotesTextBox
            // 
            this.myDiginotesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.myDiginotesTextBox.Location = new System.Drawing.Point(157, 49);
            this.myDiginotesTextBox.Name = "myDiginotesTextBox";
            this.myDiginotesTextBox.ReadOnly = true;
            this.myDiginotesTextBox.Size = new System.Drawing.Size(45, 32);
            this.myDiginotesTextBox.TabIndex = 10;
            // 
            // myDiginotesLabel
            // 
            this.myDiginotesLabel.AutoSize = true;
            this.myDiginotesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.myDiginotesLabel.Location = new System.Drawing.Point(13, 52);
            this.myDiginotesLabel.Name = "myDiginotesLabel";
            this.myDiginotesLabel.Size = new System.Drawing.Size(138, 26);
            this.myDiginotesLabel.TabIndex = 9;
            this.myDiginotesLabel.Text = "My Diginotes";
            // 
            // myPurchaseOrdersTextBox
            // 
            this.myPurchaseOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.myPurchaseOrdersTextBox.Location = new System.Drawing.Point(860, 49);
            this.myPurchaseOrdersTextBox.Name = "myPurchaseOrdersTextBox";
            this.myPurchaseOrdersTextBox.Size = new System.Drawing.Size(45, 32);
            this.myPurchaseOrdersTextBox.TabIndex = 8;
            // 
            // mySellingOrdersTextBox
            // 
            this.mySellingOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.mySellingOrdersTextBox.Location = new System.Drawing.Point(489, 49);
            this.mySellingOrdersTextBox.Name = "mySellingOrdersTextBox";
            this.mySellingOrdersTextBox.Size = new System.Drawing.Size(45, 32);
            this.mySellingOrdersTextBox.TabIndex = 7;
            // 
            // myPurchaseOrdersLabel
            // 
            this.myPurchaseOrdersLabel.AutoSize = true;
            this.myPurchaseOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.myPurchaseOrdersLabel.Location = new System.Drawing.Point(643, 52);
            this.myPurchaseOrdersLabel.Name = "myPurchaseOrdersLabel";
            this.myPurchaseOrdersLabel.Size = new System.Drawing.Size(211, 26);
            this.myPurchaseOrdersLabel.TabIndex = 1;
            this.myPurchaseOrdersLabel.Text = "My Purchase Orders";
            // 
            // mySellingOrdersLabel
            // 
            this.mySellingOrdersLabel.AutoSize = true;
            this.mySellingOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.mySellingOrdersLabel.Location = new System.Drawing.Point(298, 52);
            this.mySellingOrdersLabel.Name = "mySellingOrdersLabel";
            this.mySellingOrdersLabel.Size = new System.Drawing.Size(185, 26);
            this.mySellingOrdersLabel.TabIndex = 0;
            this.mySellingOrdersLabel.Text = "My Selling Orders";
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.logoutButton.Location = new System.Drawing.Point(775, 74);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(168, 45);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // submitMyOrders
            // 
            this.submitMyOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.submitMyOrders.Location = new System.Drawing.Point(18, 111);
            this.submitMyOrders.Name = "submitMyOrders";
            this.submitMyOrders.Size = new System.Drawing.Size(887, 45);
            this.submitMyOrders.TabIndex = 11;
            this.submitMyOrders.Text = "Submit Changes";
            this.submitMyOrders.UseVisualStyleBackColor = true;
            this.submitMyOrders.Click += new System.EventHandler(this.submitMyOrders_Click);
            // 
            // OperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 565);
            this.Controls.Add(this.infoUpdateButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.myInfo);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.title);
            this.Controls.Add(this.systemInfo);
            this.MaximizeBox = false;
            this.Name = "OperationsForm";
            this.Text = "Diginote Exchange System Client";
            this.Load += new System.EventHandler(this.OperationsForm_Load);
            this.systemInfo.ResumeLayout(false);
            this.systemInfo.PerformLayout();
            this.myInfo.ResumeLayout(false);
            this.myInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox systemInfo;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox currentQuoteTextBox;
        private System.Windows.Forms.Label currentQuoteLabel;
        private System.Windows.Forms.TextBox systemSellingOrdersTextBox;
        private System.Windows.Forms.Label systemSellingOrdersLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.TextBox systemPurchaseOrdersTextBox;
        private System.Windows.Forms.Label systemPurchaseOrdersLabel;
        private System.Windows.Forms.Button infoUpdateButton;
        private System.Windows.Forms.GroupBox myInfo;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label mySellingOrdersLabel;
        private System.Windows.Forms.TextBox myDiginotesTextBox;
        private System.Windows.Forms.Label myDiginotesLabel;
        private System.Windows.Forms.TextBox myPurchaseOrdersTextBox;
        private System.Windows.Forms.TextBox mySellingOrdersTextBox;
        private System.Windows.Forms.Label myPurchaseOrdersLabel;
        private System.Windows.Forms.Button submitMyOrders;
    }
}