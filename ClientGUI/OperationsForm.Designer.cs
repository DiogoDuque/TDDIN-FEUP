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
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.myInfo = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.changeQuotePurchaseNumeric = new System.Windows.Forms.NumericUpDown();
            this.changeQuoteSellNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.submitChangeQuoteButton = new System.Windows.Forms.Button();
            this.myDiginotesTextBox = new System.Windows.Forms.TextBox();
            this.myDiginotesLabel = new System.Windows.Forms.Label();
            this.myPurchaseOrdersTextBox = new System.Windows.Forms.TextBox();
            this.mySellingOrdersTextBox = new System.Windows.Forms.TextBox();
            this.myPurchaseOrdersLabel = new System.Windows.Forms.Label();
            this.mySellingOrdersLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.remainingSellQuoteNumeric = new System.Windows.Forms.NumericUpDown();
            this.sellingOrderWarningTextBox = new System.Windows.Forms.RichTextBox();
            this.sendSellingOrderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numDiginotesSellNumeric = new System.Windows.Forms.NumericUpDown();
            this.tabSellAndPurchaseOrders = new System.Windows.Forms.TabControl();
            this.tabPageSelling = new System.Windows.Forms.TabPage();
            this.tabPagePurchasing = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.remainingPurchaseQuoteNumeric = new System.Windows.Forms.NumericUpDown();
            this.purchasingOrderWarningTextBox = new System.Windows.Forms.RichTextBox();
            this.sendPurchasingOrderButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numDiginotesPurchaseNumeric = new System.Windows.Forms.NumericUpDown();
            this.AddDiginotes = new System.Windows.Forms.GroupBox();
            this.addDiginotesButton = new System.Windows.Forms.Button();
            this.messagesTextBox = new System.Windows.Forms.RichTextBox();
            this.systemInfo.SuspendLayout();
            this.myInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeQuotePurchaseNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeQuoteSellNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remainingSellQuoteNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiginotesSellNumeric)).BeginInit();
            this.tabSellAndPurchaseOrders.SuspendLayout();
            this.tabPageSelling.SuspendLayout();
            this.tabPagePurchasing.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remainingPurchaseQuoteNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiginotesPurchaseNumeric)).BeginInit();
            this.AddDiginotes.SuspendLayout();
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
            this.systemInfo.Location = new System.Drawing.Point(12, 102);
            this.systemInfo.Margin = new System.Windows.Forms.Padding(2);
            this.systemInfo.Name = "systemInfo";
            this.systemInfo.Padding = new System.Windows.Forms.Padding(2);
            this.systemInfo.Size = new System.Drawing.Size(617, 67);
            this.systemInfo.TabIndex = 0;
            this.systemInfo.TabStop = false;
            this.systemInfo.Text = "System Information";
            // 
            // systemPurchaseOrdersTextBox
            // 
            this.systemPurchaseOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemPurchaseOrdersTextBox.Location = new System.Drawing.Point(566, 31);
            this.systemPurchaseOrdersTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.systemPurchaseOrdersTextBox.Name = "systemPurchaseOrdersTextBox";
            this.systemPurchaseOrdersTextBox.ReadOnly = true;
            this.systemPurchaseOrdersTextBox.Size = new System.Drawing.Size(31, 24);
            this.systemPurchaseOrdersTextBox.TabIndex = 5;
            // 
            // currentQuoteLabel
            // 
            this.currentQuoteLabel.AutoSize = true;
            this.currentQuoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentQuoteLabel.Location = new System.Drawing.Point(9, 33);
            this.currentQuoteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentQuoteLabel.Name = "currentQuoteLabel";
            this.currentQuoteLabel.Size = new System.Drawing.Size(115, 18);
            this.currentQuoteLabel.TabIndex = 0;
            this.currentQuoteLabel.Text = "Diginotes Quote";
            // 
            // currentQuoteTextBox
            // 
            this.currentQuoteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.currentQuoteTextBox.Location = new System.Drawing.Point(125, 31);
            this.currentQuoteTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.currentQuoteTextBox.Name = "currentQuoteTextBox";
            this.currentQuoteTextBox.ReadOnly = true;
            this.currentQuoteTextBox.Size = new System.Drawing.Size(51, 24);
            this.currentQuoteTextBox.TabIndex = 1;
            this.currentQuoteTextBox.TextChanged += new System.EventHandler(this.currentQuoteTextBox_TextChanged);
            // 
            // systemPurchaseOrdersLabel
            // 
            this.systemPurchaseOrdersLabel.AutoSize = true;
            this.systemPurchaseOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemPurchaseOrdersLabel.Location = new System.Drawing.Point(445, 33);
            this.systemPurchaseOrdersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.systemPurchaseOrdersLabel.Name = "systemPurchaseOrdersLabel";
            this.systemPurchaseOrdersLabel.Size = new System.Drawing.Size(121, 18);
            this.systemPurchaseOrdersLabel.TabIndex = 4;
            this.systemPurchaseOrdersLabel.Text = "Purchase Orders";
            // 
            // systemSellingOrdersTextBox
            // 
            this.systemSellingOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemSellingOrdersTextBox.Location = new System.Drawing.Point(341, 31);
            this.systemSellingOrdersTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.systemSellingOrdersTextBox.Name = "systemSellingOrdersTextBox";
            this.systemSellingOrdersTextBox.ReadOnly = true;
            this.systemSellingOrdersTextBox.Size = new System.Drawing.Size(31, 24);
            this.systemSellingOrdersTextBox.TabIndex = 3;
            // 
            // systemSellingOrdersLabel
            // 
            this.systemSellingOrdersLabel.AutoSize = true;
            this.systemSellingOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.systemSellingOrdersLabel.Location = new System.Drawing.Point(237, 33);
            this.systemSellingOrdersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.systemSellingOrdersLabel.Name = "systemSellingOrdersLabel";
            this.systemSellingOrdersLabel.Size = new System.Drawing.Size(101, 18);
            this.systemSellingOrdersLabel.TabIndex = 2;
            this.systemSellingOrdersLabel.Text = "Selling Orders";
            // 
            // infoUpdateButton
            // 
            this.infoUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.infoUpdateButton.Location = new System.Drawing.Point(12, 48);
            this.infoUpdateButton.Margin = new System.Windows.Forms.Padding(2);
            this.infoUpdateButton.Name = "infoUpdateButton";
            this.infoUpdateButton.Size = new System.Drawing.Size(112, 29);
            this.infoUpdateButton.TabIndex = 6;
            this.infoUpdateButton.Text = "Update Info";
            this.infoUpdateButton.UseVisualStyleBackColor = true;
            this.infoUpdateButton.Click += new System.EventHandler(this.infoUpdateButton_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.title.Location = new System.Drawing.Point(8, 6);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(302, 25);
            this.title.TabIndex = 8;
            this.title.Text = "Diginote Exchange System Client";
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nicknameLabel.Location = new System.Drawing.Point(529, 13);
            this.nicknameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(100, 17);
            this.nicknameLabel.TabIndex = 9;
            this.nicknameLabel.Text = "UserNickname";
            this.nicknameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.nicknameLabel.Click += new System.EventHandler(this.welcomeLabel_Click);
            // 
            // myInfo
            // 
            this.myInfo.Controls.Add(this.panel1);
            this.myInfo.Controls.Add(this.label2);
            this.myInfo.Controls.Add(this.submitChangeQuoteButton);
            this.myInfo.Controls.Add(this.myDiginotesTextBox);
            this.myInfo.Controls.Add(this.myDiginotesLabel);
            this.myInfo.Controls.Add(this.myPurchaseOrdersTextBox);
            this.myInfo.Controls.Add(this.mySellingOrdersTextBox);
            this.myInfo.Controls.Add(this.myPurchaseOrdersLabel);
            this.myInfo.Controls.Add(this.mySellingOrdersLabel);
            this.myInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.myInfo.Location = new System.Drawing.Point(12, 198);
            this.myInfo.Margin = new System.Windows.Forms.Padding(2);
            this.myInfo.Name = "myInfo";
            this.myInfo.Padding = new System.Windows.Forms.Padding(2);
            this.myInfo.Size = new System.Drawing.Size(298, 257);
            this.myInfo.TabIndex = 10;
            this.myInfo.TabStop = false;
            this.myInfo.Text = "My Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.changeQuotePurchaseNumeric);
            this.panel1.Controls.Add(this.changeQuoteSellNumeric);
            this.panel1.Location = new System.Drawing.Point(188, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 126);
            this.panel1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Change Quote";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // changeQuotePurchaseNumeric
            // 
            this.changeQuotePurchaseNumeric.DecimalPlaces = 2;
            this.changeQuotePurchaseNumeric.Enabled = false;
            this.changeQuotePurchaseNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.changeQuotePurchaseNumeric.Location = new System.Drawing.Point(18, 91);
            this.changeQuotePurchaseNumeric.Name = "changeQuotePurchaseNumeric";
            this.changeQuotePurchaseNumeric.ReadOnly = true;
            this.changeQuotePurchaseNumeric.Size = new System.Drawing.Size(61, 24);
            this.changeQuotePurchaseNumeric.TabIndex = 1;
            this.changeQuotePurchaseNumeric.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // changeQuoteSellNumeric
            // 
            this.changeQuoteSellNumeric.DecimalPlaces = 2;
            this.changeQuoteSellNumeric.Enabled = false;
            this.changeQuoteSellNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.changeQuoteSellNumeric.Location = new System.Drawing.Point(18, 46);
            this.changeQuoteSellNumeric.Name = "changeQuoteSellNumeric";
            this.changeQuoteSellNumeric.ReadOnly = true;
            this.changeQuoteSellNumeric.Size = new System.Drawing.Size(61, 24);
            this.changeQuoteSellNumeric.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Complete User Name";
            // 
            // submitChangeQuoteButton
            // 
            this.submitChangeQuoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.submitChangeQuoteButton.Location = new System.Drawing.Point(12, 219);
            this.submitChangeQuoteButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitChangeQuoteButton.Name = "submitChangeQuoteButton";
            this.submitChangeQuoteButton.Size = new System.Drawing.Size(282, 29);
            this.submitChangeQuoteButton.TabIndex = 11;
            this.submitChangeQuoteButton.Text = "Submit Changes";
            this.submitChangeQuoteButton.UseVisualStyleBackColor = true;
            this.submitChangeQuoteButton.Visible = false;
            this.submitChangeQuoteButton.Click += new System.EventHandler(this.submitMyOrders_Click);
            // 
            // myDiginotesTextBox
            // 
            this.myDiginotesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.myDiginotesTextBox.Location = new System.Drawing.Point(152, 94);
            this.myDiginotesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.myDiginotesTextBox.Name = "myDiginotesTextBox";
            this.myDiginotesTextBox.ReadOnly = true;
            this.myDiginotesTextBox.Size = new System.Drawing.Size(31, 24);
            this.myDiginotesTextBox.TabIndex = 10;
            // 
            // myDiginotesLabel
            // 
            this.myDiginotesLabel.AutoSize = true;
            this.myDiginotesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.myDiginotesLabel.Location = new System.Drawing.Point(54, 94);
            this.myDiginotesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myDiginotesLabel.Name = "myDiginotesLabel";
            this.myDiginotesLabel.Size = new System.Drawing.Size(94, 18);
            this.myDiginotesLabel.TabIndex = 9;
            this.myDiginotesLabel.Text = "My Diginotes";
            this.myDiginotesLabel.Click += new System.EventHandler(this.myDiginotesLabel_Click);
            // 
            // myPurchaseOrdersTextBox
            // 
            this.myPurchaseOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.myPurchaseOrdersTextBox.Location = new System.Drawing.Point(152, 180);
            this.myPurchaseOrdersTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.myPurchaseOrdersTextBox.Name = "myPurchaseOrdersTextBox";
            this.myPurchaseOrdersTextBox.ReadOnly = true;
            this.myPurchaseOrdersTextBox.Size = new System.Drawing.Size(31, 24);
            this.myPurchaseOrdersTextBox.TabIndex = 8;
            this.myPurchaseOrdersTextBox.TextChanged += new System.EventHandler(this.myPurchaseOrdersTextBox_TextChanged);
            // 
            // mySellingOrdersTextBox
            // 
            this.mySellingOrdersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.mySellingOrdersTextBox.Location = new System.Drawing.Point(152, 135);
            this.mySellingOrdersTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mySellingOrdersTextBox.Name = "mySellingOrdersTextBox";
            this.mySellingOrdersTextBox.ReadOnly = true;
            this.mySellingOrdersTextBox.Size = new System.Drawing.Size(31, 24);
            this.mySellingOrdersTextBox.TabIndex = 7;
            this.mySellingOrdersTextBox.TextChanged += new System.EventHandler(this.mySellingOrdersTextBox_TextChanged);
            // 
            // myPurchaseOrdersLabel
            // 
            this.myPurchaseOrdersLabel.AutoSize = true;
            this.myPurchaseOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.myPurchaseOrdersLabel.Location = new System.Drawing.Point(3, 183);
            this.myPurchaseOrdersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.myPurchaseOrdersLabel.Name = "myPurchaseOrdersLabel";
            this.myPurchaseOrdersLabel.Size = new System.Drawing.Size(145, 18);
            this.myPurchaseOrdersLabel.TabIndex = 1;
            this.myPurchaseOrdersLabel.Text = "My Purchase Orders";
            // 
            // mySellingOrdersLabel
            // 
            this.mySellingOrdersLabel.AutoSize = true;
            this.mySellingOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.mySellingOrdersLabel.Location = new System.Drawing.Point(23, 138);
            this.mySellingOrdersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mySellingOrdersLabel.Name = "mySellingOrdersLabel";
            this.mySellingOrdersLabel.Size = new System.Drawing.Size(125, 18);
            this.mySellingOrdersLabel.TabIndex = 0;
            this.mySellingOrdersLabel.Text = "My Selling Orders";
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.logoutButton.Location = new System.Drawing.Point(532, 48);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(97, 29);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.remainingSellQuoteNumeric);
            this.groupBox1.Controls.Add(this.sellingOrderWarningTextBox);
            this.groupBox1.Controls.Add(this.sendSellingOrderButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numDiginotesSellNumeric);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 219);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Emit Sell Order";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(18, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Remaining Diginotes Quote";
            this.label4.Visible = false;
            // 
            // remainingSellQuoteNumeric
            // 
            this.remainingSellQuoteNumeric.DecimalPlaces = 2;
            this.remainingSellQuoteNumeric.Location = new System.Drawing.Point(205, 147);
            this.remainingSellQuoteNumeric.Name = "remainingSellQuoteNumeric";
            this.remainingSellQuoteNumeric.Size = new System.Drawing.Size(67, 30);
            this.remainingSellQuoteNumeric.TabIndex = 4;
            this.remainingSellQuoteNumeric.Visible = false;
            this.remainingSellQuoteNumeric.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // sellingOrderWarningTextBox
            // 
            this.sellingOrderWarningTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sellingOrderWarningTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sellingOrderWarningTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.sellingOrderWarningTextBox.ForeColor = System.Drawing.Color.Red;
            this.sellingOrderWarningTextBox.Location = new System.Drawing.Point(21, 68);
            this.sellingOrderWarningTextBox.Name = "sellingOrderWarningTextBox";
            this.sellingOrderWarningTextBox.ReadOnly = true;
            this.sellingOrderWarningTextBox.Size = new System.Drawing.Size(256, 78);
            this.sellingOrderWarningTextBox.TabIndex = 3;
            this.sellingOrderWarningTextBox.Text = "The number of diginotes you want to sell is higher than the quantity the other us" +
    "ers want to buy. You may choose a lower quote for the remaining diginotes.";
            this.sellingOrderWarningTextBox.Visible = false;
            // 
            // sendSellingOrderButton
            // 
            this.sendSellingOrderButton.Location = new System.Drawing.Point(26, 185);
            this.sendSellingOrderButton.Name = "sendSellingOrderButton";
            this.sendSellingOrderButton.Size = new System.Drawing.Size(256, 28);
            this.sendSellingOrderButton.TabIndex = 2;
            this.sendSellingOrderButton.Text = "Send";
            this.sendSellingOrderButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "No. of Diginotes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numDiginotesSellNumeric
            // 
            this.numDiginotesSellNumeric.Location = new System.Drawing.Point(155, 33);
            this.numDiginotesSellNumeric.Name = "numDiginotesSellNumeric";
            this.numDiginotesSellNumeric.Size = new System.Drawing.Size(67, 30);
            this.numDiginotesSellNumeric.TabIndex = 0;
            // 
            // tabSellAndPurchaseOrders
            // 
            this.tabSellAndPurchaseOrders.Controls.Add(this.tabPageSelling);
            this.tabSellAndPurchaseOrders.Controls.Add(this.tabPagePurchasing);
            this.tabSellAndPurchaseOrders.ItemSize = new System.Drawing.Size(43, 18);
            this.tabSellAndPurchaseOrders.Location = new System.Drawing.Point(315, 198);
            this.tabSellAndPurchaseOrders.Name = "tabSellAndPurchaseOrders";
            this.tabSellAndPurchaseOrders.SelectedIndex = 0;
            this.tabSellAndPurchaseOrders.Size = new System.Drawing.Size(314, 257);
            this.tabSellAndPurchaseOrders.TabIndex = 12;
            // 
            // tabPageSelling
            // 
            this.tabPageSelling.BackColor = System.Drawing.Color.DarkKhaki;
            this.tabPageSelling.Controls.Add(this.groupBox1);
            this.tabPageSelling.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelling.Name = "tabPageSelling";
            this.tabPageSelling.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelling.Size = new System.Drawing.Size(306, 231);
            this.tabPageSelling.TabIndex = 0;
            this.tabPageSelling.Text = "Selling";
            // 
            // tabPagePurchasing
            // 
            this.tabPagePurchasing.BackColor = System.Drawing.Color.LightCoral;
            this.tabPagePurchasing.Controls.Add(this.groupBox2);
            this.tabPagePurchasing.Location = new System.Drawing.Point(4, 22);
            this.tabPagePurchasing.Name = "tabPagePurchasing";
            this.tabPagePurchasing.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePurchasing.Size = new System.Drawing.Size(306, 231);
            this.tabPagePurchasing.TabIndex = 1;
            this.tabPagePurchasing.Text = "Purchasing";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.remainingPurchaseQuoteNumeric);
            this.groupBox2.Controls.Add(this.purchasingOrderWarningTextBox);
            this.groupBox2.Controls.Add(this.sendPurchasingOrderButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numDiginotesPurchaseNumeric);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 219);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Emit Purchase Order";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(18, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remaining Diginotes Quote";
            this.label3.Visible = false;
            // 
            // remainingPurchaseQuoteNumeric
            // 
            this.remainingPurchaseQuoteNumeric.DecimalPlaces = 2;
            this.remainingPurchaseQuoteNumeric.Location = new System.Drawing.Point(205, 147);
            this.remainingPurchaseQuoteNumeric.Name = "remainingPurchaseQuoteNumeric";
            this.remainingPurchaseQuoteNumeric.Size = new System.Drawing.Size(67, 30);
            this.remainingPurchaseQuoteNumeric.TabIndex = 4;
            this.remainingPurchaseQuoteNumeric.Visible = false;
            // 
            // purchasingOrderWarningTextBox
            // 
            this.purchasingOrderWarningTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.purchasingOrderWarningTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.purchasingOrderWarningTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.purchasingOrderWarningTextBox.ForeColor = System.Drawing.Color.Red;
            this.purchasingOrderWarningTextBox.Location = new System.Drawing.Point(21, 68);
            this.purchasingOrderWarningTextBox.Name = "purchasingOrderWarningTextBox";
            this.purchasingOrderWarningTextBox.ReadOnly = true;
            this.purchasingOrderWarningTextBox.Size = new System.Drawing.Size(256, 77);
            this.purchasingOrderWarningTextBox.TabIndex = 3;
            this.purchasingOrderWarningTextBox.Text = "The number of diginotes you want to purchase is higher than the quantity the othe" +
    "r users want to sell. You may choose a higher quote for the remaining diginotes." +
    "";
            this.purchasingOrderWarningTextBox.Visible = false;
            // 
            // sendPurchasingOrderButton
            // 
            this.sendPurchasingOrderButton.Location = new System.Drawing.Point(26, 185);
            this.sendPurchasingOrderButton.Name = "sendPurchasingOrderButton";
            this.sendPurchasingOrderButton.Size = new System.Drawing.Size(256, 28);
            this.sendPurchasingOrderButton.TabIndex = 2;
            this.sendPurchasingOrderButton.Text = "Send";
            this.sendPurchasingOrderButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(25, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "No. of Diginotes";
            // 
            // numDiginotesPurchaseNumeric
            // 
            this.numDiginotesPurchaseNumeric.Location = new System.Drawing.Point(155, 33);
            this.numDiginotesPurchaseNumeric.Name = "numDiginotesPurchaseNumeric";
            this.numDiginotesPurchaseNumeric.Size = new System.Drawing.Size(67, 30);
            this.numDiginotesPurchaseNumeric.TabIndex = 0;
            // 
            // AddDiginotes
            // 
            this.AddDiginotes.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.AddDiginotes.Controls.Add(this.addDiginotesButton);
            this.AddDiginotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.AddDiginotes.Location = new System.Drawing.Point(13, 482);
            this.AddDiginotes.Name = "AddDiginotes";
            this.AddDiginotes.Size = new System.Drawing.Size(297, 87);
            this.AddDiginotes.TabIndex = 13;
            this.AddDiginotes.TabStop = false;
            this.AddDiginotes.Text = "Add Diginotes";
            // 
            // addDiginotesButton
            // 
            this.addDiginotesButton.Location = new System.Drawing.Point(23, 41);
            this.addDiginotesButton.Name = "addDiginotesButton";
            this.addDiginotesButton.Size = new System.Drawing.Size(228, 40);
            this.addDiginotesButton.TabIndex = 0;
            this.addDiginotesButton.Text = "Add 1 Diginote";
            this.addDiginotesButton.UseVisualStyleBackColor = true;
            this.addDiginotesButton.Click += new System.EventHandler(this.addDiginotesButton_Click);
            // 
            // messagesTextBox
            // 
            this.messagesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.messagesTextBox.Location = new System.Drawing.Point(323, 482);
            this.messagesTextBox.Name = "messagesTextBox";
            this.messagesTextBox.ReadOnly = true;
            this.messagesTextBox.Size = new System.Drawing.Size(305, 87);
            this.messagesTextBox.TabIndex = 14;
            this.messagesTextBox.Text = "This is the message screen";
            // 
            // OperationsForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 581);
            this.Controls.Add(this.messagesTextBox);
            this.Controls.Add(this.AddDiginotes);
            this.Controls.Add(this.tabSellAndPurchaseOrders);
            this.Controls.Add(this.infoUpdateButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.myInfo);
            this.Controls.Add(this.nicknameLabel);
            this.Controls.Add(this.title);
            this.Controls.Add(this.systemInfo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "OperationsForm";
            this.Text = "Diginote Exchange System Client";
            this.Load += new System.EventHandler(this.OperationsForm_Load);
            this.systemInfo.ResumeLayout(false);
            this.systemInfo.PerformLayout();
            this.myInfo.ResumeLayout(false);
            this.myInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeQuotePurchaseNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeQuoteSellNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remainingSellQuoteNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiginotesSellNumeric)).EndInit();
            this.tabSellAndPurchaseOrders.ResumeLayout(false);
            this.tabPageSelling.ResumeLayout(false);
            this.tabPagePurchasing.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remainingPurchaseQuoteNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiginotesPurchaseNumeric)).EndInit();
            this.AddDiginotes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox systemInfo;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label currentQuoteLabel;
        private System.Windows.Forms.TextBox systemSellingOrdersTextBox;
        private System.Windows.Forms.Label systemSellingOrdersLabel;
        private System.Windows.Forms.Label nicknameLabel;
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
        private System.Windows.Forms.Button submitChangeQuoteButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numDiginotesSellNumeric;
        private System.Windows.Forms.Button sendSellingOrderButton;
        private System.Windows.Forms.TabControl tabSellAndPurchaseOrders;
        private System.Windows.Forms.TabPage tabPageSelling;
        private System.Windows.Forms.TabPage tabPagePurchasing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown remainingSellQuoteNumeric;
        private System.Windows.Forms.RichTextBox sellingOrderWarningTextBox;
        private System.Windows.Forms.TextBox currentQuoteTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown remainingPurchaseQuoteNumeric;
        private System.Windows.Forms.RichTextBox purchasingOrderWarningTextBox;
        private System.Windows.Forms.Button sendPurchasingOrderButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numDiginotesPurchaseNumeric;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown changeQuotePurchaseNumeric;
        private System.Windows.Forms.NumericUpDown changeQuoteSellNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox AddDiginotes;
        private System.Windows.Forms.Button addDiginotesButton;
        private System.Windows.Forms.RichTextBox messagesTextBox;
    }
}