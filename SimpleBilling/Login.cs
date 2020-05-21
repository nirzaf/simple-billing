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
                ExportJson.Add(ex);
                Info.Mes(ex.Message);
            }
        }

        private void CashierLogin()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (Info.IsEmpty(TxtLogin))
                    {
                        var data = db.Employee.FirstOrDefault(c => c.SecretCode == TxtLogin.Text.Trim());
                        if (data != null)
                        {
                            Info.CashierId = data.EmployeeId;
                            Info.UserType = 3;
                            Main m = new Main();
                            m.Show();
                            Hide();
                        }
                        else
                        {
                            Info.Mes("Pass code is not valid, Please try again");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private void TxtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CashierLogin();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAdminExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAdminLogin_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                string UName = TxtUsername.Text.Trim();
                string PWord = TxtPassword.Text.Trim();
                var users = db.Users.FirstOrDefault(c => c.Username == UName && c.Password == PWord && !c.IsDeleted);
                if (users != null)
                {
                    Info.CashierId = users.EmployeeId;
                    Info.UserType = users.UserType;
                    Main m = new Main();
                    m.Show();
                    Hide();
                }
                else
                {
                    Info.Mes("Username or password not valid, Please try again");
                }
            }
        }
    }
}