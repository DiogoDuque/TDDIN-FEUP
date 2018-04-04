using Common;
using Coord;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class OperationsForm : Form
    {
        private Coordinator coordinator;
        private string username;
        private int userAvailableDiginotes;
        private decimal diginoteQuote;
        private int mySellingOrders;
        private int myPurchasingOrders;
        private int totalSellingOrders;
        private int totalPurchasingOrders;

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public OperationsForm(Coordinator coordinator, string username)
        {
            this.coordinator = coordinator;
            this.username = username;
            InitializeComponent();
            nicknameLabel.Text = "Hello "+username +" !";
            update();
            coordinator.logger += ShowTransactionMessage;
            coordinator.update += updateInfo;
            coordinator.onQuoteChange += ShowWarningQuoteChanged;
        }

        public void ShowTransactionMessage(string oldOwner, string newOwner, int quantity)
        {
            if(this.messagesTextBox.InvokeRequired)
            {
                LogDelegate del = new LogDelegate(ShowTransactionMessage);
                this.Invoke(del, new object[] { oldOwner, newOwner, quantity });
            }
            else
            {
                if (oldOwner == username)
                    messagesTextBox.Text += "\n" + newOwner + " purchased " + quantity.ToString() + " diginotes from you";
                else if (newOwner == username)
                    messagesTextBox.Text += "\n You purchased " + quantity.ToString() + " diginotes from " + oldOwner;
            }
        }

        public void ShowWarningQuoteChanged(string username, decimal quote, OrderType orderType)
        {
            if (messagesTextBox.InvokeRequired) //randomly chosen component from ui thread
            {
                QuoteChange del = new QuoteChange(ShowWarningQuoteChanged);
                messagesTextBox.BeginInvoke(del, new object[] { username, quote, orderType });
                return;
            }
            if (username != this.username)
            {
                string message = username + " changed the diginote quote to\n" + quote.ToString() + "\nDo you want to keep your pending orders? If you don't answer in 30s, your orders will be kept.";
                DialogResult result = MessageBoxEx.Show(message, "Quote Change", MessageBoxButtons.YesNo, MessageBoxIcon.Information, 30000);

                if (result == DialogResult.No)
                {
                    int numOrders = 0;
                    if (orderType == OrderType.BUYING)
                    {
                        numOrders = coordinator.GetAmountBuyingOrders(this.username);
                        coordinator.CancelPurchasingOrders(numOrders);
                    }
                    else
                    {
                        numOrders = coordinator.GetAmountSellingOrders(this.username);
                        coordinator.CancelSellingOrders(numOrders);
                    }
                }
            }
        }

        public void updateInfo()
        {
            if(this.InvokeRequired)
            {
                UpdateDelegate del = new UpdateDelegate(update);
                this.Invoke(del, new object[] { });
            }
            else
            {
                update();
            }
        }
        private void update()
        {
            userAvailableDiginotes = coordinator.GetUserDiginoteQuantity(username) - coordinator.GetAmountSellingOrders(username);
            diginoteQuote = (decimal)coordinator.DiginoteQuote;
            mySellingOrders = coordinator.GetAmountSellingOrders(username);
            myPurchasingOrders = coordinator.GetAmountBuyingOrders(username);
            totalSellingOrders = coordinator.GetAmountSellingOrders();
            totalPurchasingOrders = coordinator.GetAmountBuyingOrders();

            updateSystemInformation();
            updateMyInformation();
            updateEmitSellOrder();
            updateEmitPurchaseOrder();

        }

        private void updateSystemInformation()
        {
            currentQuoteTextBox.Text = diginoteQuote.ToString();
            systemSellingOrdersTextBox.Text = totalSellingOrders.ToString();
            systemPurchaseOrdersTextBox.Text = totalPurchasingOrders.ToString();
        }

        private void updateMyInformation()
        {
            myDiginotesTextBox.Text = userAvailableDiginotes.ToString();
            mySellingOrdersTextBox.Text = mySellingOrders.ToString();
            myPurchaseOrdersTextBox.Text = myPurchasingOrders.ToString();
            changeQuoteSellNumeric.Maximum = diginoteQuote;
            changeQuotePurchaseNumeric.Minimum = diginoteQuote;
            //changeQuoteSellNumeric.Value = diginoteQuote;
            //changeQuotePurchaseNumeric.Value = diginoteQuote;

            if (mySellingOrders > 0)
            {
                changeQuoteSellNumeric.ReadOnly = false;
                changeQuoteSellNumeric.Enabled = true;
            }
            else
            {
                changeQuoteSellNumeric.ReadOnly = true;
                changeQuoteSellNumeric.Enabled = false;
            }

            if (myPurchasingOrders > 0)
            {
                changeQuotePurchaseNumeric.ReadOnly = false;
                changeQuotePurchaseNumeric.Enabled = true;
            }
            else
            {
                changeQuotePurchaseNumeric.ReadOnly = true;
                changeQuotePurchaseNumeric.Enabled = false;
            }

            if (mySellingOrders > 0 || myPurchasingOrders > 0)
            {
                submitChangeQuoteButton.Visible = true;
            }
            else
            {
                submitChangeQuoteButton.Visible = false;
            }
        }

        private void updateEmitSellOrder()
        {
            if (userAvailableDiginotes > 0)
            {
                sendSellingOrderButton.Enabled = true;
            }
            else
            {
                sendSellingOrderButton.Enabled = false;
            }

            numDiginotesSellNumeric.Maximum = userAvailableDiginotes;
            //numDiginotesSellNumeric.Value = userAvailableDiginotes;
            remainingSellQuoteNumeric.Maximum = diginoteQuote;
            //remainingSellQuoteNumeric.Value = diginoteQuote;

            //Show warnings when limit is passed
            if (numDiginotesSellNumeric.Value > 0 && (decimal)totalSellingOrders + numDiginotesSellNumeric.Value > (decimal)totalPurchasingOrders)
            {
                sellingOrderWarningTextBox.Visible = true;
                remainingSellQuoteNumeric.Visible = true;
                label4.Visible = true;
            }
            else
            {
                sellingOrderWarningTextBox.Visible = false;
                remainingSellQuoteNumeric.Visible = false;
                label4.Visible = false;
            }
        }

        private void updateEmitPurchaseOrder()
        {
            remainingPurchaseQuoteNumeric.Minimum = diginoteQuote;
            //remainingPurchaseQuoteNumeric.Value = diginoteQuote;

            if (numDiginotesPurchaseNumeric.Value > 0 && (decimal)totalPurchasingOrders + numDiginotesPurchaseNumeric.Value > (decimal)totalSellingOrders)
            {
                purchasingOrderWarningTextBox.Visible = true;
                remainingPurchaseQuoteNumeric.Visible = true;
                label3.Visible = true;
            }
            else
            {
                purchasingOrderWarningTextBox.Visible = false;
                remainingPurchaseQuoteNumeric.Visible = false;
                label3.Visible = false;
            }
        }

        private void infoUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (coordinator.LogOut(username))
                    this.DialogResult = DialogResult.OK;
                else this.DialogResult = DialogResult.No;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OperationsForm_Load(object sender, EventArgs e)
        {

        }

        private void submitMyOrders_Click(object sender, EventArgs e)
        {
            //TODO submit new orders
            update();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void welcomeLabel_Click(object sender, EventArgs e)
        {

        }

        private void myDiginotesLabel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void currentQuoteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void mySellingOrdersTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void myPurchaseOrdersTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void addDiginotesButton_Click(object sender, EventArgs e)
        {
            try
            {
                coordinator.CreateDiginote(username);
                update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendSellingOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                int nDiginotes = Convert.ToInt32(numDiginotesSellNumeric.Value);
                MessageQueue sellingQueue = new MessageQueue(@".\private$\sellingOrders");
                sellingQueue.Formatter = new BinaryMessageFormatter();
                if (totalSellingOrders + numDiginotesSellNumeric.Value > totalPurchasingOrders &&
                    coordinator.DiginoteQuote != (float)remainingSellQuoteNumeric.Value)
                {
                    coordinator.ChangeQuote(username, (float)remainingSellQuoteNumeric.Value, OrderType.SELLING);
                }
                for (int i = 0; i < nDiginotes; i++)
                {
                    sellingQueue.Send(new Order(username, OrderType.SELLING));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendPurchasingOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                int nDiginotes = Convert.ToInt32(numDiginotesPurchaseNumeric.Value);
                MessageQueue sellingQueue = new MessageQueue(@".\private$\purchaseOrders");
                sellingQueue.Formatter = new BinaryMessageFormatter();
                if(totalPurchasingOrders + numDiginotesPurchaseNumeric.Value > totalSellingOrders &&
                    coordinator.DiginoteQuote != (float) remainingPurchaseQuoteNumeric.Value)
                {
                    coordinator.ChangeQuote(username, (float)remainingPurchaseQuoteNumeric.Value, OrderType.BUYING);
                }
                for (int i = 0; i < nDiginotes; i++)
                {
                    sellingQueue.Send(new Order(username, OrderType.BUYING));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numDiginotesSellNumeric_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                updateEmitSellOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numDiginotesPurchaseNumeric_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                updateEmitPurchaseOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
