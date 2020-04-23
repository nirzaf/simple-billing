using System;
using SimpleBilling.Model;
using System.Windows.Forms;
using System.Collections.Generic;
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
            //Form_Load();
            LoadDGV();
        }

        private void Form_Load()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    itemBindingSource.DataSource = db.Items.ToList();
                    categoryBindingSource.DataSource = db.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = true;
            itemBindingSource.Add(new Item());
            itemBindingSource.MoveLast();
            TxtItemCode.Focus();
        }

        //private void LoadCMBCategory()
        //{
        //    BillingContext db = new BillingContext();
        //    CmbCategories.DataSource = (from d in db.Categories select d).ToList();
        //    CmbCategories.ValueMember = "CategoryId";
        //    CmbCategories.DisplayMember = "CategoryName";
        //}

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (itemBindingSource.Current is Item items)
                    {
                        if (items != null)
                        {
                            items.Categories = (Category)CmbCategories.SelectedItem;
                            if (db.Entry(items).State == EntityState.Detached)
                            {
                                db.Set<Item>().Attach(items);
                            }
                            if (items.Id == 0)
                            {
                                db.Entry(items).State = EntityState.Added;
                            }
                            else
                            {
                                db.Entry(items).State = EntityState.Modified;
                            }
                            db.SaveChanges();
                            LoadDGV();
                            Info("Item Added Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Info(ex.Message.ToString());
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
                                item.Barcode,
                                item.Categories.CategoryName
                            }).ToList();
                DGVItems.DataSource = data;
                categoryBindingSource.DataSource = db.Categories.ToList();
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

        private void CmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblMessage.Text = CmbCategories.SelectedValue.ToString();
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
        }
    }
}
