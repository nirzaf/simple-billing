using SimpleBilling.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class CustomerLookUp : Form
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public CustomerLookUp()
        {
            InitializeComponent();
        }

        private void CustomerLookUp_Load(object sender, EventArgs e)
        {
            LoadAllCustomers(string.Empty);
        }

        private void LoadAllCustomers(string Input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Input))
                {
                    using (BillingContext db = new BillingContext())
                    {
                        var data = (from i in db.Customers.Where(c => !c.IsDeleted)
                                    select new
                                    {
                                        i.CustomerId,
                                        i.Name
                                    }).ToList();
                        DGVCustomers.DataSource = data;
                    }
                }
                else
                {
                    using (BillingContext db = new BillingContext())
                    {
                        var data = (from i in db.Customers.Where(c => c.Name.Contains(Input) && !c.IsDeleted)
                                    select new
                                    {
                                        i.CustomerId,
                                        i.Name
                                    }).ToList();
                        DGVCustomers.DataSource = data;
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }            
        }

        private void TxtSearchCustomers_KeyUp(object sender, KeyEventArgs e)
        {
            TxtSearchCustomers.Text.Trim();
            LoadAllCustomers(TxtSearchCustomers.Text.Trim());
        }

        private void DGVCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVCustomers.SelectedRows.Count > 0)
            {
                CustomerId = DGVCustomers.SelectedRows[0].Cells[0].Value + string.Empty;
                CustomerName = DGVCustomers.SelectedRows[0].Cells[1].Value + string.Empty;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
