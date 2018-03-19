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
        public OperationsForm(string username)
        {
            InitializeComponent();
            welcomeLabel.Text = "Hello "+username;
        }

        private void systemInfoUpdateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
