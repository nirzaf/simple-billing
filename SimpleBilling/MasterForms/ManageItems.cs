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
            Form_Load();
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
                        Info("Item Added Successfully");
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
                var data = (from sem in db.Items.ToList()
                            join ses in db.Categories
                            on sem.Id equals ses.CategoryId
                            select new
                            {
                                sem.Id,
                                sem.Code,
                                sem.ItemName,
                                sem.Unit,
                                sem.Barcode,
                                sem.Categories
                            }).ToList();
                DGVItems.DataSource = data;
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
    }
}
