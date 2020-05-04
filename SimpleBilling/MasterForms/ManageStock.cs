using SimpleBilling.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageStock : Form
    {
        private int StockId;

        public ManageStock()
        {
            InitializeComponent();
        }

        private void ManageStock_Load(object sender, EventArgs e)
        {
            DGVLoad();
        }

        private void DGVLoad()
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from i in db.Items.Where(c => c.IsDeleted == false && c.IsService == false)
                            select new
                            {
                                i.Id,
                                i.Barcode,
                                i.Code,
                                Item_Name = i.ItemName,
                                i.StockQty
                            }).ToList();
                DGVManageStocks.DataSource = data;
            }
        }

        private void DGVManageStocks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVManageStocks.SelectedRows.Count > 0)
            {
                StockId = Convert.ToInt32(DGVManageStocks.SelectedRows[0].Cells[0].Value + string.Empty);
                TxtUpdateStockCount.Text = DGVManageStocks.SelectedRows[0].Cells[0].Value + string.Empty;
            }
        }

        private void TxtFilterProducts_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string Filter = TxtFilterProducts.Text.Trim();
                using (BillingContext db = new BillingContext())
                {
                    if (Filter.Length > 0)
                    {
                        var data = (from i in db.Items
                                    .Where(c => c.Code.Contains(Filter)
                                    || c.Barcode.Contains(Filter)
                                    || c.ItemName.Contains(Filter)
                                    && c.IsDeleted == false
                                    && c.IsService == false)
                                    select new
                                    {
                                        i.Id,
                                        i.Barcode,
                                        i.Code,
                                        Item_Name = i.ItemName,
                                        i.StockQty
                                    }).ToList();
                        DGVManageStocks.DataSource = data;
                        DGVManageStocks.Refresh();
                    }
                    else
                    {
                        var data = (from i in db.Items.Where(c => c.IsDeleted == false && c.IsService == false)
                                    select new
                                    {
                                        i.Id,
                                        i.Barcode,
                                        i.Code,
                                        Item_Name = i.ItemName,
                                        i.StockQty
                                    }).ToList();
                        DGVManageStocks.DataSource = data;
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }
    }
}