using System;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            TxtLogin.Focus();
        }
    }
}