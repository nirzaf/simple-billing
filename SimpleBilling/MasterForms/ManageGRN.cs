using SimpleBilling.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageGRN : Form
    {
        public ManageGRN()
        {
            InitializeComponent();
        }

        private void ManageGRN_Load(object sender, EventArgs e)
        {
            LoadCmb();
        }

        private void LoadCmb()
        {
            using (BillingContext db = new BillingContext()) 
            {
                itemBindingSource.DataSource = db.Items.ToList();
                supplierBindingSource.DataSource = db.Suppliers.ToList();
            }
        }

        private void BtnCreateGRN_Click(object sender, EventArgs e)
        { 
            string ReferenceNo = TxtReference.Text.Trim();
            string Date = DTPDate.Value.ToShortDateString();
            string SupplierId = CMBSupplier.SelectedValue.ToString();


        }
    }
}
