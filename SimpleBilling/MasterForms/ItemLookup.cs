using SimpleBilling.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ItemLookup : Form
    {
        public string Code { get; set; }
        public string ItemName { get; set; }
        public ItemLookup()
        {
            InitializeComponent();
        }

        private void ItemLookup_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private async void FormLoad()
        {
            TxtItemLookUp.Focus();
            using (BillingContext db = new BillingContext())
            {
                var data = await (from i in db.Items.Where(c => !c.IsDeleted)
                                  select new
                                  {
                                      i.Code,
                                      i.ItemName
                                  }).ToListAsync();
                DGVItems.DataSource = data;
            }
        }

        private void LoadAllItems()
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from i in db.Items.Where(c => !c.IsDeleted)
                                  select new
                                  {
                                      i.Code,
                                      i.ItemName
                                  }).ToList();
                DGVItems.DataSource = data;
            }
        }

        private void SearchItems(string Input)
        {
            using (BillingContext db = new BillingContext())
            {
                var data =  (from i in db.Items.Where(c => (c.Code.Contains(Input) || c.ItemName.Contains(Input)) && !c.IsDeleted)
                                  select new
                                  {
                                      i.Code,
                                      i.ItemName
                                  }).ToList();
                DGVItems.DataSource = data;
            }
        }

        private void TxtItemLookUp_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtItemLookUp.Text.Length > 0)
            {
                SearchItems(TxtItemLookUp.Text.Trim());
            }
            else
            {
                LoadAllItems();
            }
        }

        private void DGVItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVItems.SelectedRows.Count > 0)
            {
                Code = DGVItems.SelectedRows[0].Cells[0].Value + string.Empty;
                ItemName = DGVItems.SelectedRows[0].Cells[1].Value + string.Empty;
            }
        }

        private void DGVItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVItems.SelectedRows.Count > 0)
            {
                Code = DGVItems.SelectedRows[0].Cells[0].Value + string.Empty;
                ItemName = DGVItems.SelectedRows[0].Cells[1].Value + string.Empty;
            }
        }

        private void DGVItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (DGVItems.SelectedRows.Count > 0)
            {
                Code = DGVItems.SelectedRows[0].Cells[0].Value + string.Empty;
                ItemName = DGVItems.SelectedRows[0].Cells[1].Value + string.Empty;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
