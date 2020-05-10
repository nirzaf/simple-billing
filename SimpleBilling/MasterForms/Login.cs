using SimpleBilling.Model;
using System;
using System.Linq;
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                CashierLogin();
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }

        private void CashierLogin()
        {
            using (BillingContext db = new BillingContext())
            {
                if (Info.IsEmpty(TxtLogin))
                {
                    var data = db.Employee.FirstOrDefault(c => c.SecretCode == TxtLogin.Text.Trim());
                    if (data != null)
                    {
                    }
                }
            }
        }
    }
}