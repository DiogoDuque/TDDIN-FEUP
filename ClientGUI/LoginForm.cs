using Common;
using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class LoginForm : Form
    {
        private Coordinator coordinator;
        private User currentUser;
        public LoginForm()
        {
            InitializeComponent();
            RemotingConfiguration.Configure("ClientGUI.exe.config", false);
            this.coordinator = new Coordinator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = loginUsernameTextBox.Text;
            string password = loginPasswordTextBox.Text;
            try
            {
                if (coordinator.LogIn(username, Utils.GetSha256FromString(password)))
                {
                    logBox.Text = "SUCCESS";
                }
                else logBox.Text = "This username is already logged in!";
            } catch(ArgumentException ex)
            {
                logBox.Text = ex.Message;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = registerUsernameTextBox.Text;
            string name = registerNameTextBox.Text;
            string password = registerPasswordTextBox.Text;
            User user = new User(name, username, Utils.GetSha256FromString(password));
            if (coordinator.Register(user))
            {
                currentUser = user;
                logBox.Text = "Registered new user!";
            }
            else logBox.Text = "That username already exists!\n\rPlease choose a new one!";
        }
    }
}
