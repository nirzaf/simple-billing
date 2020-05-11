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
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnDelete.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                customersBindingSource1.DataSource = db.Customers.Where(c => c.IsDeleted == false).ToList();
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnDelete.Enabled = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            customersBindingSource1.Add(new Customers());
            customersBindingSource1.MoveLast();
            TxtName.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (customersBindingSource1.Current is Customers cat)
                    {
                        if (db.Entry(cat).State == EntityState.Detached)
                            db.Set<Customers>().Attach(cat);
                        if (cat.CustomerId == 0)
                        {
                            db.Entry(cat).State = EntityState.Added;
                            cat.CreatedDate = DateTime.Now;
                            Info("Customer Added");
                        }
                        else
                        {
                            db.Entry(cat).State = EntityState.Modified;
                            cat.UpdatedDate = DateTime.Now;
                            Info("Customer Modified");
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info(ex.ToString());
            }
            finally
            {
                DGVCustomers.Refresh();
                LoadDGV();
            }
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
                        Customers cus = customersBindingSource1.Current as Customers;

                        if (cus != null)
                        {
                            if (db.Entry(cus).State == EntityState.Detached)
                                db.Set<Customers>().Attach(cus);
                            cus.IsDeleted = true;
                            cus.UpdatedDate = DateTime.Now;
                            db.Entry(cus).State = EntityState.Modified;
                            cus.UpdatedDate = DateTime.Now;
                            db.SaveChanges();
                            Info("Customer Deleted Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info(ex.ToString());
            }
            finally
            {
                DGVCustomers.Refresh();
                LoadDGV();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            TxtName.Focus();
            _ = customersBindingSource1.Current as Customers;
        }

        private void DGVCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVCustomers.SelectedRows.Count > 0)
            {
                BtnDelete.Enabled = true;
                BtnEdit.Enabled = true;
                BtnAdd.Enabled = true;
            }
        }
    }
}