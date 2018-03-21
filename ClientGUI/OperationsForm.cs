using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            welcomeLabel.Text = "Hello "+username;
            updateInfo();
        }

        private void updateInfo()
        {
            currentQuoteTextBox.Text = coordinator.DiginoteQuote.ToString();
            //TODO update system selling orders
            //TODO update system purchase orders

            //TODO update my diginotes
            //TODO update my selling orders
            //TODO update my purchase orders
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
        }
    }
}
