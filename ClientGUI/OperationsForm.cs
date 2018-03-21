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

        public OperationsForm(Coordinator coordinator, string username)
        {
            this.coordinator = coordinator;
            this.username = username;
            InitializeComponent();
            welcomeLabel.Text = "Hello "+username;
            updateSystemInfo();
        }

        private void updateSystemInfo()
        {
            currentQuoteTextBox.Text = coordinator.DiginoteQuote.ToString();
        }

        private void systemInfoUpdateButton_Click(object sender, EventArgs e)
        {
            updateSystemInfo();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (coordinator.LogOut(username))
                this.DialogResult = DialogResult.OK;
            else this.DialogResult = DialogResult.No;
        }
    }
}
