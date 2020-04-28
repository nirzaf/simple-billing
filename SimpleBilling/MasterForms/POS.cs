using SimpleBilling.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            SystemTimer_Tick(sender, e);
            LoadDateAndTime();
        }

        private void LoadDateAndTime()
        {
            using (BillingContext db = new BillingContext())
            {
                customersBindingSource.DataSource = db.Customers.ToList();
            }
        }

        private void SystemTimer_Tick(object sender, EventArgs e)
        {           
            LblDate.Text = DateTime.Now.ToShortDateString();
            LblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
