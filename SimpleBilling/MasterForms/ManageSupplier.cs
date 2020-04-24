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
                supplierBindingSource.DataSource = db.Suppliers.ToList();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            supplierBindingSource.Add(new Supplier());
            supplierBindingSource.MoveLast();
            TxtSupplierName.Focus();
        }

        private void Info(string Message)
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
                        Supplier sup = supplierBindingSource.Current as Supplier;

                        if (sup != null)
                        {
                            if (db.Entry(sup).State == EntityState.Detached)
                                db.Set<Supplier>().Attach(sup);
                            db.Entry(sup).State = EntityState.Deleted;
                            db.SaveChanges();
                            Info("Supplier Deleted Successfully");
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
                            db.Entry(sup).State = EntityState.Added;
                            Info("Supplier Added");
                        }
                        else
                        {
                            db.Entry(sup).State = EntityState.Modified;
                            Info("Supplier Modified");
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
            finally
            {
                DGVSupplier.Refresh();
                LoadDGV();
            }
        }
    }
}
