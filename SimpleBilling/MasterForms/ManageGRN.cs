using SimpleBilling.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    GRNHeader header = new GRNHeader
                    {
                        ReferenceNo = TxtReference.Text.Trim(),
                        GRN_Date = DTPDate.Value.ToShortDateString(),
                        Supplier = (Supplier)CMBSupplier.SelectedItem,
                        GrossTotal = 0,
                        NetTotal = 0,
                        TotalDiscout = 0,
                        Employee = null,
                        Status = 1
                    };

                    if (db.Entry(header).State == EntityState.Detached)
                        db.Set<GRNHeader>().Attach(header);
                    db.Entry(header).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
        }
        private void Info(string Message)
        {
            LblMessage.Text = Message;
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            LblMessage.Text = string.Empty;
        }
    }
}
