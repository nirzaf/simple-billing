using Microsoft.OData.Edm;
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
            try
            {
                CRUDPanel.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnDelete.Enabled = false;
                using (BillingContext db = new BillingContext())
                {
                    customersBindingSource1.DataSource = db.Customers.Where(c => !c.IsDeleted).ToList();
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
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
                    var path = db.Settings.Take(1).FirstOrDefault();
                    if (customersBindingSource1.Current is Customers cat)
                    {
                        if (db.Entry(cat).State == EntityState.Detached)
                            db.Set<Customers>().Attach(cat);
                        if (cat.CustomerId == 0)
                        {
                            db.Entry(cat).State = EntityState.Added;
                            cat.CreatedDate = DateTime.Now;
                            db.SaveChanges();
                            if (path.EnableSMS)
                            {
                                SMS.Sender.Send(TxtContact.Text.Trim(), "Greetings " + TxtName.Text.Trim() + ", Welcome to Carwest Auto Service");
                            }
                            Message("Customer Added");
                        }
                        else
                        {
                            db.Entry(cat).State = EntityState.Modified;
                            cat.UpdatedDate = DateTime.Now;
                            db.SaveChanges();
                            Message("Customer Modified");
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
                LoadDGV();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVCustomers.SelectedRows.Count > 0)
                {
                    int CusId = Convert.ToInt32(TxtCustomerId.Text.Trim());
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected Item?", "Confirmation delete", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (BillingContext db = new BillingContext())
                        {
                            var cus = db.Customers.FirstOrDefault(c => c.CustomerId == CusId);
                            if (cus != null)
                            {
                                if (db.Entry(cus).State == EntityState.Detached)
                                    db.Set<Customers>().Attach(cus);
                                cus.IsDeleted = true;
                                cus.UpdatedDate = DateTime.Now;
                                db.Entry(cus).State = EntityState.Modified;
                                db.SaveChanges();
                                Message("Customer Deleted Successfully");
                            }
                        }
                    }
                } else
                {
                    Info.Mes("Please select a customer to delete");
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
                TxtCustomerId.Text = DGVCustomers.SelectedRows[0].Cells[0].Value + string.Empty;
                TxtName.Text = DGVCustomers.SelectedRows[0].Cells[1].Value + string.Empty;
                TxtContact.Text = DGVCustomers.SelectedRows[0].Cells[2].Value + string.Empty;
                TxtEmail.Text = DGVCustomers.SelectedRows[0].Cells[3].Value + string.Empty;
                TxtAddress.Text = DGVCustomers.SelectedRows[0].Cells[4].Value + string.Empty;

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
            Search(TxtSearchCustomers.Text.Trim());
        }

        private void Search(string Input)
        {
            using (BillingContext db = new BillingContext())
            {
                if (!string.IsNullOrWhiteSpace(Input))
                {
                    var data = (from cus in db.Customers.Where(c => !c.IsDeleted)
                                select new
                                {
                                    cus.CustomerId,
                                    cus.Name,
                                    cus.Contact,
                                    cus.Address,
                                    cus.Email
                                }).Where(b => b.Name.Contains(Input) || b.Address.Contains(Input) || b.Contact.Contains(Input) || b.Email.Contains(Input)).ToList();
                    DGVCustomers.DataSource = data;
                }
                else
                {
                    var data = (from cus in db.Customers.Where(c => !c.IsDeleted)
                                select new
                                {
                                    cus.CustomerId,
                                    cus.Name,
                                    cus.Contact,
                                    cus.Address,
                                    cus.Email
                                }).ToList();
                    DGVCustomers.DataSource = data;
                }          
            } 
        }
    }
}