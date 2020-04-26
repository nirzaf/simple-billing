using System;
using SimpleBilling.Model;
using System.Windows.Forms;
using System.Data.Entity;
using System.Linq;

namespace SimpleBilling.MasterForms
{
    public partial class ManageItems : Form
    {
        public ManageItems()
        {
            InitializeComponent();
        }

        private void ManageItems_Load(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = false;
            BtnCancel.Enabled = false;
            LblMessage.Text = string.Empty;
            LoadDGV();
            DGVItems_CellClick(sender, e as DataGridViewCellEventArgs);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = true;
            BtnCancel.Enabled = true;
            BtnSave.Enabled = true;
            TxtItemId.Text = "0";
            TxtItemCode.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = true;
            BtnCancel.Enabled = true;
            TxtItemCode.Focus();
            BtnSave.Enabled = true;
        }

        private void ItemCRUD()
        {
            using (BillingContext db = new BillingContext())
            {
                int CatId = Convert.ToInt32(CmbCategories.SelectedValue.ToString());
                Category cat = db.Categories.FirstOrDefault(s => s.CategoryId == CatId);

                Item items = new Item
                {
                    Id = Convert.ToInt32(TxtItemId.Text.Trim()),
                    Code = TxtItemCode.Text.Trim(),
                    ItemName = TxtItemName.Text.Trim(),
                    Unit = TxtUnit.Text.Trim(),
                    UnitCost = Convert.ToSingle(TxtUnitCost.Text.Trim()),
                    Barcode = TxtBarcode.Text.Trim(),
                    Categories = cat
                };

                if (items.Id == 0)
                {
                    db.Entry(items).State = EntityState.Added;
                    db.SaveChanges();
                    Info("Item Added Successfully");                   
                }
                else
                {
                    var result = db.Items.SingleOrDefault(b => b.Id == items.Id);
                    if (result != null)
                    {
                        result.Code= items.Code;
                        result.ItemName = items.ItemName;
                        result.Unit = items.Unit;
                        result.UnitCost = items.UnitCost;
                        result.Barcode = items.Barcode;
                        result.Categories = items.Categories;
                        db.SaveChanges();
                        Info("Item Modified Successfully");
                    }                   
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ItemCRUD();
            }
            catch (Exception ex)
            {
                Info(ex.Message.ToString());
            }
            finally 
            {
                PanelCRUD.Enabled = false;
                BtnCancel.Enabled = false;
                BtnSave.Enabled = false;
                DGVItems.Refresh();
                LoadDGV();
                int lastRow = DGVItems.Rows.Count;
                DGVItems.CurrentCell = DGVItems.Rows[lastRow - 1].Cells[0];
            }
        }

        private void LoadDGV()
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from item in db.Items
                            join cat in db.Categories
                            on item.Categories.CategoryId equals cat.CategoryId
                            select new
                            {
                                item.Id,
                                item.Code,
                                item.ItemName,
                                item.Unit,
                                item.UnitCost,
                                item.Barcode,
                                item.Categories.CategoryName
                            }).ToList();
                DGVItems.DataSource = data;
                CmbCategories.ValueMember = "CategoryId";
                CmbCategories.DisplayMember = "CategoryName";
                CmbCategories.DataSource = db.Categories.ToList();
            }
        }

        private void TimerMessage_Tick(object sender, EventArgs e)
        {
            LblMessage.Text = string.Empty;
        }

        private void Info(string Message)
        {
            LblMessage.Text = Message;
        }

        private void DGVItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = DGVItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)DGVItems.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)DGVItems.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void DGVItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVItems.SelectedRows.Count > 0)
            {
                TxtItemId.Text = DGVItems.SelectedRows[0].Cells[0].Value + string.Empty;
                TxtItemCode.Text = DGVItems.SelectedRows[0].Cells[1].Value + string.Empty;
                TxtItemName.Text = DGVItems.SelectedRows[0].Cells[2].Value + string.Empty;
                TxtUnit.Text = DGVItems.SelectedRows[0].Cells[3].Value + string.Empty;
                TxtBarcode.Text = DGVItems.SelectedRows[0].Cells[4].Value + string.Empty;
                CmbCategories.Text = DGVItems.SelectedRows[0].Cells[5].Value + string.Empty;
            }
            else
            {
                //TxtItemId.Text = DGVItems.SelectedRows[0].Cells[0].Value + string.Empty;
                //TxtItemCode.Text = DGVItems.SelectedRows[0].Cells[1].Value + string.Empty;
                //TxtItemName.Text = DGVItems.SelectedRows[0].Cells[2].Value + string.Empty;
                //TxtUnit.Text = DGVItems.SelectedRows[0].Cells[3].Value + string.Empty;
                //TxtBarcode.Text = DGVItems.SelectedRows[0].Cells[4].Value + string.Empty;
                //CmbCategories.Text = DGVItems.SelectedRows[0].Cells[5].Value + string.Empty;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = false;
            BtnCancel.Enabled = false;
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
                        int Id = Convert.ToInt32(TxtItemId.Text.Trim().ToString());
                        Item items = db.Items.FirstOrDefault(s => s.Id == Id);

                        if (items != null)
                        {
                            db.Entry(items).State = EntityState.Deleted;
                            db.SaveChanges();
                            Info("Item Deleted Successfully");
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
                DGVItems.Refresh();
                LoadDGV();
            }
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageCategory))
                {
                    form.Activate();
                    return;
                }
            }

            ManageCategory manageCategory = new ManageCategory();
            manageCategory.Show();
            Close();
        }
    }
}
