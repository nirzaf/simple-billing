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
            PanelCRUD.Enabled = false;
            LoadCMBCategory();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = true;
            itemBindingSource.Add(new Item());
            itemBindingSource.MoveLast();
            TxtItemCode.Focus();
        }

        private void LoadCMBCategory()
        {
            BillingContext db = new BillingContext();
            CmbCategories.DataSource = (from d in db.Categories select d).ToList(); 
            CmbCategories.ValueMember = "CategoryId";
            CmbCategories.DisplayMember = "CategoryName";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                Item items = itemBindingSource.Current as Item;
                if(items != null)
                {
                    if (db.Entry(items).State == EntityState.Detached)
                    {
                        db.Set<Item>().Attach(items);
                    }
                }
            }
        }
    }
}
