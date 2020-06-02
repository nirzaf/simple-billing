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
                var data = (from s in db.Suppliers.Where(c => !c.IsDeleted)
                            select new
                            {
                                s.SupplierId,
                                s.Name,
                                s.Contact,
                                s.Address,
                                s.Email
                            }).ToList();
                DGVSupplier.DataSource = data;
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
                    int SupId = Convert.ToInt32(TxtSupplierId.Text.Trim());
                    var Sup = db.Suppliers.FirstOrDefault(c => c.SupplierId == SupId && !c.IsDeleted);
                    if (Sup != null)
                    {
                        Sup.Name = TxtSupplierName.Text.Trim();
                        Sup.Address = TxtAddress.Text.Trim();
                        Sup.Contact = TxtContact.Text.Trim();
                        Sup.Email = TxtEmail.Text.Trim();
                        Sup.UpdatedDate = DateTime.Today;
                        if (db.Entry(Sup).State == EntityState.Detached)
                            db.Set<Supplier>().Attach(Sup);
                        db.Entry(Sup).State = EntityState.Modified;
                        db.SaveChanges();
                        Message("Supplier Modified Successfully");
                    }
                    else
                    {
                        Supplier sup = new Supplier
                        {
                            Name = TxtSupplierName.Text.Trim(),
                            Address = TxtAddress.Text.Trim(),
                            Contact = TxtContact.Text.Trim(),
                            Email = TxtEmail.Text.Trim(),
                            PendingAmount = Convert.ToInt32(TxtCodeNumber.Text.Trim())
                        };
                        if (db.Entry(sup).State == EntityState.Detached)
                            db.Set<Supplier>().Attach(sup);
                        sup.CreatedDate = DateTime.Now;
                        db.Entry(sup).State = EntityState.Added;
                        db.SaveChanges();
                        Info.Mes("Supplier Added Successfully");
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
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    var data = (from s in db.Suppliers.Where(c => c.Name.Contains(Text) || c.Address.Contains(Text) || c.Contact.Contains(Text) || c.Email.Contains(Text) && !c.IsDeleted)
                                select new
                                {
                                    s.SupplierId,
                                    s.Name,
                                    s.Contact,
                                    s.Address,
                                    s.Email
                                }).ToList();
                    DGVSupplier.DataSource = data;
                }
                else
                {
                    var data = (from s in db.Suppliers.Where(c => !c.IsDeleted)
                                select new
                                {
                                    s.SupplierId,
                                    s.Name,
                                    s.Contact,
                                    s.Address,
                                    s.Email
                                }).ToList();
                    DGVSupplier.DataSource = data;
                }
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

        private void DGVSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVSupplier.SelectedRows.Count > 0)
            {
                TxtSupplierId.Text = DGVSupplier.SelectedRows[0].Cells[0].Value + string.Empty;
                TxtSupplierName.Text = DGVSupplier.SelectedRows[0].Cells[1].Value + string.Empty;
                TxtContact.Text = DGVSupplier.SelectedRows[0].Cells[2].Value + string.Empty;
                TxtAddress.Text = DGVSupplier.SelectedRows[0].Cells[3].Value + string.Empty;
                TxtEmail.Text = DGVSupplier.SelectedRows[0].Cells[4].Value + string.Empty;



                int SupID = Convert.ToInt32(TxtSupplierId.Text.Trim());
                using (BillingContext db = new BillingContext()) 
                {
                    var sup = db.Suppliers.FirstOrDefault(c => c.SupplierId == SupID && !c.IsDeleted);
                    float PendingAmount = sup.PendingAmount;
                    var grn = (from g in db.GRNHeaders.Where(c => c.Supplier.SupplierId == SupID && !c.IsDeleted)
                               select new { g.PendingAmount }).ToList();
                    foreach (var g in grn)
                    {
                        PendingAmount += g.PendingAmount;
                    }
                    TxtCodeNumber.Text = PendingAmount.ToString();
                }
            }
        }
    }
}