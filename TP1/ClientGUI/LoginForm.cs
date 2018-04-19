using Common;
using Coord;
using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Messaging;

namespace ClientGUI
{
    public partial class LoginForm : Form
    {
        private Coordinator coordinator;
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
                    logBox.Text = "";
                    this.Hide();
                    OperationsForm opsForm = new OperationsForm(coordinator, username);
                    if (opsForm.ShowDialog() == DialogResult.OK)
                        logBox.Text = username + " logged out.";
                    else logBox.Text = "You were not properly logged in!";
                    this.Show();
                }
                else logBox.Text = "There was a problem with your credentials! Please try again.";
            } catch(ArgumentException ex)
            {
                logBox.Text = ex.Message;
            }
            loginPasswordTextBox.Text = "";
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = registerUsernameTextBox.Text;
            string name = registerNameTextBox.Text;
            string password = registerPasswordTextBox.Text;
            User user = new User(name, username, Utils.GetSha256FromString(password));
            if (coordinator.Register(user)) {
                logBox.Text = "Registered new user!";
                loginUsernameTextBox.Text = username;
                registerUsernameTextBox.Text = "";
                registerNameTextBox.Text = "";
            }
            else logBox.Text = "That username already exists!\r\nPlease choose a new one!";
            registerPasswordTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageQueue sellingQueue = new MessageQueue(@".\private$\sellingOrders");
            sellingQueue.Formatter = new BinaryMessageFormatter();
            sellingQueue.Send("oi");
        }
    }
}
