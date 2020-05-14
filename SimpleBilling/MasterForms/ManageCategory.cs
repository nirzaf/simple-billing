using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageCategory : Form
    {
        private int CatId;

        public ManageCategory()
        {
            InitializeComponent();
        }

        private void ManageCategory_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            LblMessage.Text = "";
            PanelCRUD.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                var dgv = (from cat in db.Categories.Where(c => !c.IsDeleted)
                           select new
                           {
                               cat.CategoryId,
                               cat.CategoryName
                           }).ToList();
                DGVCategories.DataSource = dgv;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = true;
            BtnSave.Enabled = true;
            TxtCategoryName.Focus();
            TxtCatId.Text = "0";
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = true;
            BtnSave.Enabled = true;
            TxtCategoryName.Focus();
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
                        var cat = db.Categories.FirstOrDefault(c => c.CategoryId == CatId);

                        if (cat != null)
                        {
                            if (db.Entry(cat).State == EntityState.Detached)
                                db.Set<Category>().Attach(cat);
                            cat.IsDeleted = true;
                            cat.UpdatedDate = Info.Today();
                            db.Entry(cat).State = EntityState.Modified;
                            db.BulkSaveChangesAsync();
                            Info.Mes("Category Deleted Successfully");
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
                DGVCategories.Refresh();
                LoadDGV();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Info.IsEmpty(TxtCatId)) CatId = Convert.ToInt32(TxtCatId.Text.Trim());
                using (BillingContext db = new BillingContext())
                {
                    Category cat = db.Categories.FirstOrDefault(c => c.CategoryId == CatId);
                    if (cat == null)
                    {
                        if (Info.IsEmpty(TxtCategoryName))
                        {
                            Category ca = new Category
                            {
                                CategoryName = TxtCategoryName.Text.Trim(),
                                CreatedDate = Info.Today()
                            };
                            if (db.Entry(ca).State == EntityState.Detached)
                                db.Set<Category>().Attach(ca);
                            db.Entry(ca).State = EntityState.Added;
                            Info.Mes("Category Added");
                            db.BulkSaveChangesAsync();
                        }
                    }
                    else
                    {
                        if (Info.IsEmpty(TxtCategoryName))
                        {
                            cat.CategoryName = TxtCategoryName.Text.Trim();
                            cat.UpdatedDate = Info.Today();
                            if (db.Entry(cat).State == EntityState.Detached)
                                db.Set<Category>().Attach(cat);
                            db.Entry(cat).State = EntityState.Modified;
                            Info.Mes("Category Modified");
                            db.BulkSaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex); Info.Mes(ex.Message);
            }
            finally
            {
                DGVCategories.Refresh();
                LoadDGV();
            }
        }

        private void DGVCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVCategories.SelectedRows.Count > 0)
            {
                CatId = Convert.ToInt32(DGVCategories.SelectedRows[0].Cells[0].Value + string.Empty);
                TxtCatId.Text = DGVCategories.SelectedRows[0].Cells[0].Value + string.Empty;
                TxtCategoryName.Text = DGVCategories.SelectedRows[0].Cells[1].Value + string.Empty;
                TxtCatId.ReadOnly = true;
            }
        }
    }
}