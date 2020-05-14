using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ConfigureSellingPrice : Form
    {
        private int ItemId;
        float Price;
        public ConfigureSellingPrice()
        {
            InitializeComponent();
        }

        private void ConfigureSellingPrice_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            using (BillingContext db = new BillingContext())
            {
                itemBindingSource.DataSource = db.Items.ToList();
            }
        }

        private void DGVSellingPrice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemId = Convert.ToInt32(DGVSellingPrice.SelectedRows[0].Cells[0].Value + string.Empty);
            TxtSellingPrice.Text = DGVSellingPrice.SelectedRows[0].Cells[3].Value + string.Empty;

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            Price = Convert.ToSingle(TxtSellingPrice.Text.Trim());
            using (BillingContext db = new BillingContext())
            {
                var Item = db.Items.FirstOrDefault(c => c.Id.Equals(ItemId));
                Item.SellingPrice = Price;
                if (db.Entry(Item).State == EntityState.Detached)
                    db.Set<Item>().Attach(Item);
                db.Entry(Item).State = EntityState.Modified;
                db.BulkSaveChanges();
                LoadDGV();
            }
        }
    }
}
