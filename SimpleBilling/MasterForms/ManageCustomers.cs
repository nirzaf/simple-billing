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
            LoadDGV(string.Empty);
        }

        private void LoadDGV(string Input)
        {
            CRUDPanel.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnDelete.Enabled = false;
            if (!string.IsNullOrWhiteSpace(Input))
            {
                using (BillingContext db = new BillingContext())
                {
                    customersBindingSource1.DataSource = db.Customers.Where(c => !c.IsDeleted).ToList();
                }
            }
            else
            {
                using (BillingContext db = new BillingContext())
                {
                    customersBindingSource1.DataSource = db.Customers.Where(c => (c.Name.Contains(Input) || c.Address.Contains(Input) || c.Contact.Contains(Input) || c.Email.Contains(Input)) && !c.IsDeleted).ToList();
                }
            }
        }

        private void Message(string Message)
        {
            Info.Mes(Message);
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
                            Message("Customer Added");
                        }
                        else
                        {
                            db.Entry(cat).State = EntityState.Modified;
                            cat.UpdatedDate = DateTime.Now;
                            Message("Customer Modified");
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Message(ex.ToString());
            }
            finally
            {
                DGVCustomers.Refresh();
                LoadDGV(string.Empty);
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
                            Message("Customer Deleted Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Message(ex.ToString());
            }
            finally
            {
                DGVCustomers.Refresh();
                LoadDGV(string.Empty);
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

        private void TxtName_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtName);
        }

        private void TxtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtAddress);
        }

        private void TxtSearchCustomers_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtSearchCustomers);
            LoadDGV(TxtSearchCustomers.Text.Trim());
        }
    }
}