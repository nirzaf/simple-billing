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
            businessModelBindingSource.Add(new BusinessModel());
            businessModelBindingSource.MoveLast();
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
                businessModelBindingSource.DataSource = db.BusinessModels.Where(c=>c.IsDeleted==false).ToList();
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
                    if (businessModelBindingSource.Current is BusinessModel model)
                    {
                        if (db.Entry(model).State == EntityState.Detached)
                            db.Set<BusinessModel>().Attach(model);
                        if (model.Id == 0)
                        {
                            db.Entry(model).State = EntityState.Added;
                            Info.Mes("Business Info Added");
                        }
                        else
                        {
                            db.Entry(model).State = EntityState.Modified;
                            Info.Mes("Business Info Modified");
                        }
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
                        if (businessModelBindingSource.Current is BusinessModel model)
                        {
                            model.IsDeleted = true;
                            if (db.Entry(model).State == EntityState.Detached)
                                db.Set<BusinessModel>().Attach(model);
                            db.Entry(model).State = EntityState.Modified;
                            db.SaveChanges();
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
            }
        }
    }
}
