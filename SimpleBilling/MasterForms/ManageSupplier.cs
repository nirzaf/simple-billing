using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageSupplier : Form
    {
        public ManageSupplier()
        {
            InitializeComponent();
        }

        private void ManageSupplier_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            CRUDPanel.Enabled = false;
            LblMessage.Text = string.Empty;
            using (BillingContext db = new BillingContext())
            {
                supplierBindingSource.DataSource = db.Suppliers.Where(c => !c.IsDeleted).ToList();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ResetValues();
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            supplierBindingSource.Add(new Supplier());
            supplierBindingSource.MoveLast();
            TxtSupplierName.Focus();
        }

        private void ResetValues()
        {
            TxtAddress.Text = string.Empty;
            TxtCodeNumber.Text = string.Empty;
            TxtContact.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtSupplierName.Text = string.Empty;
            TxtSupplierId.Text = string.Empty;
        }

        private void Message(string Message)
        {
            LblMessage.Text = Message;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            TxtSupplierName.Focus();
            Supplier sup = supplierBindingSource.Current as Supplier;
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            LblMessage.Text = string.Empty;
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
                        if (supplierBindingSource.Current is Supplier sup)
                        {
                            if (db.Entry(sup).State == EntityState.Detached)
                                db.Set<Supplier>().Attach(sup);
                            sup.UpdatedDate = DateTime.Now;
                            sup.IsDeleted = true;
                            db.Entry(sup).State = EntityState.Modified;
                            db.SaveChanges();
                            Message("Supplier Deleted Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message(ex.ToString());
            }
            finally
            {
                DGVSupplier.Refresh();
                LoadDGV();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (supplierBindingSource.Current is Supplier sup)
                    {
                        if (db.Entry(sup).State == EntityState.Detached)
                            db.Set<Supplier>().Attach(sup);
                        if (sup.SupplierId == 0)
                        {
                            sup.CreatedDate = DateTime.Now;
                            db.Entry(sup).State = EntityState.Added;
                            Message("Supplier Added");
                        }
                        else
                        {
                            sup.UpdatedDate = DateTime.Now;
                            db.Entry(sup).State = EntityState.Modified;
                            Message("Supplier Modified");
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
                DGVSupplier.Refresh();
                LoadDGV();
            }
        }

        private void TxtSearchSuppliers_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtSearchSuppliers.Text.Trim().Length > 0)
            {
                SearchDGV(TxtSearchSuppliers.Text.Trim());
            }
            else
            {
                LoadDGV();
            }
        }

        private void SearchDGV(string Text)
        {
            CRUDPanel.Enabled = false;
            LblMessage.Text = string.Empty;
            using (BillingContext db = new BillingContext())
            {
                supplierBindingSource.DataSource = db.Suppliers.Where(c => c.Name.Contains(Text) || c.Address.Contains(Text) || c.CodeNumber.Contains(Text) || c.Contact.Contains(Text) || c.Email.Contains(Text) && !c.IsDeleted).ToList();
            }
        }

        private void TxtSupplierName_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtSupplierName);
        }

        private void TxtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtAddress);
        }

        private void TxtCodeNumber_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtCodeNumber);
        }
    }
}