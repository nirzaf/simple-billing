using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling
{
    public partial class ManageCustomers : Form
    {
        public ManageCustomers()
        {
            InitializeComponent();
        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            LblMessage.Text = "";
            CRUDPanel.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                customersBindingSource.DataSource = db.Customers.ToList();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            customersBindingSource.Add(new Customers());
            customersBindingSource.MoveLast();
            TxtName.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            TxtName.Focus();
            Customers cus = customersBindingSource.Current as Customers;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected Item?", "Confirmation delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (BillingContext db = new BillingContext())
                    {
                        Customers cus = customersBindingSource.Current as Customers;

                        if (cus != null)
                        {
                            if (db.Entry(cus).State == EntityState.Detached)
                                db.Set<Customers>().Attach(cus);
                            db.Entry(cus).State = EntityState.Deleted;
                            db.SaveChanges();
                            Info("Customer Deleted Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
            finally
            {
                DGVCustomers.Refresh();
                LoadDGV();
            }
        }

        private void Info(string Message)
        {
            LblMessage.Text = Message;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (customersBindingSource.Current is Customers cat)
                    {
                        if (db.Entry(cat).State == EntityState.Detached)
                            db.Set<Customers>().Attach(cat);
                        if (cat.CustomerId == 0)
                        {
                            db.Entry(cat).State = EntityState.Added;
                            Info("Customer Added");
                        }
                        else
                        {
                            db.Entry(cat).State = EntityState.Modified;
                            Info("Customer Modified");
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
        }


        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            LblMessage.Text = string.Empty;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = false;
        }
    }
}
