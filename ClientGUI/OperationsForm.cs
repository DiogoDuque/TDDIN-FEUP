using Coord;
using System;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class OperationsForm : Form
    {
        private Coordinator coordinator;
        private string username;

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
            updateInfo();
        }

        private void updateInfo()
        {
            int numUserDiginotes = coordinator.GetUserDiginoteQuantity(username);
            decimal diginoteQuote = (decimal)coordinator.DiginoteQuote;

            //System Information

            currentQuoteTextBox.Text = diginoteQuote.ToString();
            //TODO update system selling orders
            //TODO update system purchase orders

            //My Information

            myDiginotesTextBox.Text = numUserDiginotes.ToString();
            //TODO update my selling orders
            //TODO update my purchase orders
            changeQuoteSellNumeric.Value = diginoteQuote;
            changeQuotePurchaseNumeric.Value = diginoteQuote;

            //Emit Sell Order

            numDiginotesSellNumeric.Maximum = numUserDiginotes;
            numDiginotesSellNumeric.Value = numUserDiginotes;
            remainingSellQuoteNumeric.Minimum = diginoteQuote;
            remainingSellQuoteNumeric.Value = diginoteQuote;

            //Emit Purchase Order

            remainingPurchaseQuoteNumeric.Maximum = diginoteQuote;
            remainingPurchaseQuoteNumeric.Value = diginoteQuote;


        }

        private void infoUpdateButton_Click(object sender, EventArgs e)
        {
            updateInfo();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (coordinator.LogOut(username))
                this.DialogResult = DialogResult.OK;
            else this.DialogResult = DialogResult.No;
        }

        private void OperationsForm_Load(object sender, EventArgs e)
        {

        }

        private void submitMyOrders_Click(object sender, EventArgs e)
        {
            //TODO submit new orders
            updateInfo();

            string message = "Another user has changed the diginotes quote to: \n 15 \n Do you accept this quote?\n Pressing NO will remove your pending orders";

            MessageBox.Show(message, "Form Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                updateInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
