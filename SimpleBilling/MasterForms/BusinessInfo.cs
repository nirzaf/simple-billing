using SimpleBilling.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class BusinessInfo : Form
    {
        public BusinessInfo()
        {
            InitializeComponent();
            DGVLoad();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CRUDLayout.Enabled = true;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            TxtName.Focus();
        }

        private void BusinessInfo_Load(object sender, EventArgs e)
        {
            DGVLoad();
        }

        private void DGVLoad()
        {
            CRUDLayout.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                var data = (from bm in db.BusinessModels.Where(c => c.IsDeleted == false)
                            select new
                            {
                                bm.Id,
                                bm.Name,
                                bm.Address,
                                bm.Contact,
                                bm.IsActive
                            }).ToList();
                DGVBusinessInfo.DataSource = data;
            }
            BtnActivate.Enabled = false;
            DGVBusinessInfo_CellFormatting();
        }

        private void BtnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVBusinessInfo.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(DGVBusinessInfo.SelectedRows[0].Cells[0].Value + string.Empty);
                    using (BillingContext db = new BillingContext())
                    {
                        var item = db.BusinessModels.FirstOrDefault(c => c.Id == id);
                        var data = db.BusinessModels.Where(c => c.Id != id).ToList();
                        foreach (var d in data)
                        {
                            d.IsActive = false;
                            db.Entry(d).State = EntityState.Modified;
                        }
                        item.IsActive = true;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
            finally
            {
                DGVLoad();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    int Id = Convert.ToInt32(TxtId.Text.Trim());
                    if (Id == 0)
                    {
                        if (Info.IsEmpty(TxtName) && Info.IsEmpty(TxtAddress) && Info.IsEmpty(TxtContact))
                        {
                            BusinessModel bm = new BusinessModel
                            {
                                Name = TxtName.Text.Trim(),
                                Address = TxtAddress.Text.Trim(),
                                Contact = TxtContact.Text.Trim(),
                                CreatedDate = DateTime.Now
                            };
                            if (db.Entry(bm).State == EntityState.Detached)
                                db.Set<BusinessModel>().Attach(bm);
                            db.Entry(bm).State = EntityState.Added;
                            db.SaveChanges();
                            Info.Mes("Business Info Added");
                        }
                        else
                        {
                            Info.Required();
                        }
                    }
                    else
                    {
                        var bm = db.BusinessModels.FirstOrDefault(c => c.Id == Id);
                        if (Info.IsEmpty(TxtName) && Info.IsEmpty(TxtAddress) && Info.IsEmpty(TxtContact))
                        {
                            bm.Name = TxtName.Text.Trim();
                            bm.Address = TxtAddress.Text.Trim();
                            bm.Contact = TxtContact.Text.Trim();
                            bm.UpdatedDate = DateTime.Now;
                            if (db.Entry(bm).State == EntityState.Detached)
                                db.Set<BusinessModel>().Attach(bm);
                            db.Entry(bm).State = EntityState.Modified;
                            db.SaveChanges();
                            Info.Mes("Business Info Modified");
                        }
                        else
                        {
                            Info.Required();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
            finally
            {
                DGVLoad();
                CRUDLayout.Enabled = false;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CRUDLayout.Enabled = true;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            TxtName.Focus();
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
                        if (DGVBusinessInfo.SelectedRows.Count > 0)
                        {
                            int id = Convert.ToInt32(DGVBusinessInfo.SelectedRows[0].Cells[0].Value + string.Empty);
                            var model = db.BusinessModels.FirstOrDefault(c => c.Id == id);
                            model.IsDeleted = true;
                            if (db.Entry(model).State == EntityState.Detached)
                                db.Set<BusinessModel>().Attach(model);
                            model.UpdatedDate = DateTime.Now;
                            db.Entry(model).State = EntityState.Modified;
                            db.SaveChangesAsync();
                            Info.Mes("Business Info Deleted Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.ToString());
            }
            finally
            {
                DGVBusinessInfo.Refresh();
                DGVLoad();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CRUDLayout.Enabled = false;
            BtnSave.Enabled = false;
        }

        private void DGVBusinessInfo_CellFormatting()
        {
            foreach (DataGridViewRow Myrow in DGVBusinessInfo.Rows)
            {
                if (Convert.ToBoolean(Myrow.Cells[4].Value) == true)
                {
                    Myrow.DefaultCellStyle.BackColor = Color.SkyBlue;
                }
            }
        }

        private void DGVBusinessInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVBusinessInfo.SelectedRows.Count > 0)
            {
                BtnActivate.Enabled = true;
                TxtId.Text = DGVBusinessInfo.SelectedRows[0].Cells[0].Value + string.Empty;
                TxtName.Text = DGVBusinessInfo.SelectedRows[0].Cells[1].Value + string.Empty;
                TxtAddress.Text = DGVBusinessInfo.SelectedRows[0].Cells[2].Value + string.Empty;
                TxtContact.Text = DGVBusinessInfo.SelectedRows[0].Cells[3].Value + string.Empty;
            }
        }
    }
}