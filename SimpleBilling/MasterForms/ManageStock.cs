using SimpleBilling.Model;
using System;
using System.Data.Entity;
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
                var data = (from i in db.Items.Where(c => !c.IsDeleted && !c.IsService)
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
                TxtUpdateStockCount.Text = DGVManageStocks.SelectedRows[0].Cells[4].Value + string.Empty;
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
                                    && !c.IsDeleted && !c.IsService)
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
                    else
                    {
                        var data = (from i in db.Items.Where(c => !c.IsDeleted && !c.IsService)
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
                ExportJSON.Add(ex);
                Info.Mes(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this stock quantity?", "Confirmation Update", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (BillingContext db = new BillingContext())
                    {
                        if (DGVManageStocks.SelectedRows.Count > 0)
                        {
                            var data = db.Items.FirstOrDefault(c => c.Id == StockId);
                            if (data != null)
                            {
                                if (Info.IsEmpty(TxtUpdateStockCount))
                                {
                                    data.StockQty = Convert.ToInt32(TxtUpdateStockCount.Text.Trim());
                                    if (db.Entry(data).State == EntityState.Detached)
                                        db.Set<Item>().Attach(data);
                                    db.Entry(data).State = EntityState.Modified;
                                    db.SaveChanges();
                                }
                                else
                                {
                                    Info.Mes("Please enter a new quantity to update new value");
                                }
                            }
                        }
                        else
                        {
                            Info.Mes("Please enter a new quantity to update new value");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info.Mes(ex.Message);
            }
            finally
            {
                DGVLoad();
            }
        }
    }
}