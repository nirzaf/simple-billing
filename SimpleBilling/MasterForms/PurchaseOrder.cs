using SimpleBilling.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class PurchaseOrder : Form
    {
        private int SupplierId;
        private string PurchaseOrderId;
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            FormLoad(string.Empty);
        }

        private void FormLoad(string OrderId)
        {
            FormLoadAll(string.Empty);
            try
            {
                LoabCMB();
                using (BillingContext db = new BillingContext())
                {
                    var orderedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == OrderId && !c.IsDeleted)
                                        join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                        on po.OrderUniqueId equals oi.OrderId
                                        join it in db.Items.Where(c => !c.IsDeleted)
                                        on oi.ItemCode equals it.Code
                                        select new
                                        {
                                            oi.ItemCode,
                                            it.PrintableName,
                                            oi.Quantity
                                        }).ToList();
                    DGVOrderedItems.DataSource = orderedItems;

                    var receivedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == OrderId && !c.IsDeleted)
                                         join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                         on po.OrderUniqueId equals oi.OrderId
                                         join it in db.Items.Where(c => !c.IsDeleted)
                                         on oi.ItemCode equals it.Code
                                         select new
                                         {
                                             oi.ItemCode,
                                             it.PrintableName,
                                             oi.Quantity
                                         }).ToList();
                    DGVReceivedItems.DataSource = receivedItems;

                    var data = (from item in db.Items.Where(c => !c.IsDeleted)
                                select new
                                {
                                    item.Code,
                                    item.PrintableName,
                                    item.StockQty
                                }).OrderBy(c => c.StockQty).ToList();
                    DGVItemsToOrder.DataSource = data;

                    var pendingOrders = db.PurchaseOrders.Where(c => !c.IsReceived && !c.IsDeleted).Select(c => c.OrderUniqueId).ToList();
                    LstBoxPendingOrders.DataSource = pendingOrders;

                    LblDate.Text = DateTime.Today.ToShortDateString();
                    if (orderedItems.Count == 0)
                    {
                        BtnAddToOrder.Enabled = false;
                        BtnRemove.Enabled = false;
                    }
                    else
                    {
                        BtnAddToOrder.Enabled = true;
                        BtnRemove.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }         
        }


        private void LoabCMB()
        {
            using (BillingContext db = new BillingContext())
            {
                CmbSuppliers.ValueMember = "SupplierId";
                CmbSuppliers.DisplayMember = "Name";
                CmbSuppliers.DataSource = db.Suppliers.Where(c => !c.IsDeleted).ToList();
            }
        }

        private void BtnAddToOrder_Click(object sender, EventArgs e)
        {
            AddToOrder();
        }

        private void AddToOrder()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (DGVItemsToOrder.SelectedRows.Count > 0)
                    {
                        string Code = DGVItemsToOrder.SelectedRows[0].Cells[0].Value + string.Empty;
                        var OrdItem = db.OrderedItems.FirstOrDefault(c => c.ItemCode == Code && c.OrderId == PurchaseOrderId);
                        if (Info.IsEmpty(TxtOrderQuantity))
                        {
                            if (OrdItem == null)
                            {
                                OrderedItem oi = new OrderedItem
                                {
                                    ItemCode = Code,
                                    Quantity = Info.ToInt(TxtOrderQuantity),
                                    UnitType = CmbUnitType.Text,
                                    CreatedDate = DateTime.Today,
                                };
                                if (db.Entry(oi).State == EntityState.Detached)
                                    db.Set<OrderedItem>().Attach(oi);
                                db.Entry(oi).State = EntityState.Added;
                                db.SaveChanges();
                                FormLoad(PurchaseOrderId);
                            }
                            else
                            {
                                OrdItem.Quantity = Info.ToInt(TxtOrderQuantity);
                                OrdItem.UnitType = CmbUnitType.Text;
                                OrdItem.UpdatedDate = DateTime.Today;
                                if (db.Entry(OrdItem).State == EntityState.Detached)
                                    db.Set<OrderedItem>().Attach(OrdItem);
                                db.Entry(OrdItem).State = EntityState.Modified;
                                db.SaveChanges();
                                FormLoad(PurchaseOrderId);
                            }
                        }
                        else
                        {
                            Info.Mes("Quantity Cannot be Empty");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string PurchaseOrderDate = DtpOrderDate.Value.ToShortDateString();
                SupplierId = Convert.ToInt32(CmbSuppliers.SelectedValue.ToString());
                string SupplierName = CmbSuppliers.Text;
                using (BillingContext db = new BillingContext())
                {
                    Model.PurchaseOrder po = new Model.PurchaseOrder
                    {
                        OrderUniqueId = Info.RandomString(4) + "-" + PurchaseOrderDate + "-" + SupplierId + "-" + SupplierName,
                        OrderedDate = PurchaseOrderDate,
                        SupplierId = SupplierId,
                        CreatedDate = DateTime.Today
                    };
                    if (db.Entry(po).State == EntityState.Detached)
                        db.Set<Model.PurchaseOrder>().Attach(po);
                    db.Entry(po).State = EntityState.Added;
                    db.SaveChanges();
                    PurchaseOrderDate = po.OrderedDate;
                    BtnAddToOrder.Enabled = true;
                    BtnRemove.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
                ExportJson.Add(ex);
            }
        }

        private void DGVItemsToOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVItemsToOrder.SelectedRows.Count > 0)
            {
                string Code = DGVItemsToOrder.SelectedRows[0].Cells[0].Value + string.Empty;
                using (BillingContext db = new BillingContext())
                {
                    var item = db.Items.FirstOrDefault(c => c.Code == Code);
                    if (item != null)
                    {
                        CmbUnitType.Text = item.Unit;
                    }
                }
            }
        }

        private void DGVOrderedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVOrderedItems.SelectedRows.Count > 0)
            {
                BtnRemove.Enabled = true;
            }
        }

        private void DtpOrderDate_ValueChanged(object sender, EventArgs e)
        {
            //string PurchaseOrderDate = DtpOrderDate.Value.ToShortDateString();
            //FormLoad(OrderId);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                if (DGVOrderedItems.SelectedRows.Count > 0)
                {
                    string code = DGVOrderedItems.SelectedRows[0].Cells[0].Value + string.Empty;
                    var item = db.OrderedItems.FirstOrDefault(c => c.ItemCode == code && c.OrderId == PurchaseOrderId);
                    if (item != null)
                    {
                        if (db.Entry(item).State == EntityState.Detached)
                            db.Set<OrderedItem>().Attach(item);
                        db.Entry(item).State = EntityState.Deleted;
                        db.SaveChanges();
                        FormLoad(PurchaseOrderId);
                    }
                }
            }
        }

        private void LstBoxPendingOrders_DoubleClick(object sender, EventArgs e)
        {
            PurchaseOrderId = LstBoxPendingOrders.SelectedItem.ToString();
            ViewPendingOrders(PurchaseOrderId, 1);
        }

        private void ViewPendingOrders(string OrderId, int type)
        {
            using (BillingContext db = new BillingContext())
            {
                var orderedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == OrderId && !c.IsDeleted)
                                    join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                    on po.OrderUniqueId equals oi.OrderId
                                    join it in db.Items.Where(c => !c.IsDeleted)
                                    on oi.ItemCode equals it.Code
                                    select new
                                    {
                                        oi.ItemCode,
                                        it.PrintableName,
                                        oi.Quantity
                                    }).ToList();
                DGVOrderedItems.DataSource = orderedItems;

                var receivedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == OrderId && !c.IsDeleted)
                                     join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                     on po.OrderUniqueId equals oi.OrderId
                                     join it in db.Items.Where(c => !c.IsDeleted)
                                     on oi.ItemCode equals it.Code
                                     select new
                                     {
                                         oi.ItemCode,
                                         it.PrintableName,
                                         oi.Quantity
                                     }).ToList();
                DGVReceivedItems.DataSource = receivedItems;

                var data = (from item in db.Items.Where(c => !c.IsDeleted)
                            select new
                            {
                                item.Code,
                                item.PrintableName,
                                item.StockQty
                            }).OrderBy(c => c.StockQty).ToList();
                DGVItemsToOrder.DataSource = data;

                LblDate.Text = DateTime.Today.ToShortDateString();
                if (orderedItems.Count == 0 || type == 2)
                {
                    BtnAddToOrder.Enabled = false;
                    BtnRemove.Enabled = false;
                }
                else
                {
                    BtnAddToOrder.Enabled = true;
                    BtnRemove.Enabled = true;
                }
            }
        }

        private void BtnMarkReceived_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PurchaseOrderId))
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.PurchaseOrders.FirstOrDefault(c => c.OrderUniqueId == PurchaseOrderId);
                    if (data != null)
                    {
                        data.IsReceived = true;
                        if (db.Entry(data).State == EntityState.Detached)
                            db.Set<Model.PurchaseOrder>().Attach(data);
                        db.Entry(data).State = EntityState.Modified;
                        db.SaveChanges();
                        FormLoad(PurchaseOrderId);
                    }
                }
            }
        }

        private void LstBoxPendingOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrderId = LstBoxPendingOrders.SelectedItem.ToString();
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            FormLoadAll(string.Empty);
        }

        private void FormLoadAll(string OrderId)
        {

            using (BillingContext db = new BillingContext())
            {
                if (string.IsNullOrWhiteSpace(OrderId))
                {
                    var pendingOrders = db.PurchaseOrders.Where(c => c.IsReceived && !c.IsDeleted).Select(c => c.OrderUniqueId).ToList();
                    LstReceivedOrders.DataSource = pendingOrders;
                }
                else
                {
                    var pendingOrders = db.PurchaseOrders.Where(c => c.OrderUniqueId == PurchaseOrderId && c.IsReceived && !c.IsDeleted).Select(c => c.OrderUniqueId).ToList();
                    LstReceivedOrders.DataSource = pendingOrders;
                }

                LblDate.Text = DateTime.Today.ToShortDateString();
                BtnAddToOrder.Enabled = false;
                BtnRemove.Enabled = false;
            }
        }

        private void DTReceivedOrder_ValueChanged(object sender, EventArgs e)
        {
            string Date = DTReceivedOrder.Value.ToShortDateString();
            FormLoadAll(Date);
        }

        private void LstReceivedOrders_DoubleClick(object sender, EventArgs e)
        {
            PurchaseOrderId = LstReceivedOrders.SelectedItem.ToString();
            ViewPendingOrders(PurchaseOrderId, 2);
        }

        private void DGVOrderedItems_DoubleClick(object sender, EventArgs e)
        {
            string Code = DGVOrderedItems.SelectedRows[0].Cells[0].Value + string.Empty;
            using (BillingContext db = new BillingContext())
            {
                var data = db.OrderedItems.FirstOrDefault(c => c.OrderId == PurchaseOrderId && c.ItemCode == Code && !c.IsReceived && !c.IsDeleted);
                if (data != null)
                {
                    data.IsReceived = true;
                    if (db.Entry(data).State == EntityState.Detached)
                        db.Set<OrderedItem>().Attach(data);
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewPendingOrders(PurchaseOrderId, 2);
                }
            }
        }

        private void DGVReceivedItems_MouseClick(object sender, MouseEventArgs e)
        {
            string Code = DGVReceivedItems.SelectedRows[0].Cells[0].Value + string.Empty;
            using (BillingContext db = new BillingContext())
            {
                var data = db.OrderedItems.FirstOrDefault(c => c.OrderId == PurchaseOrderId && c.ItemCode == Code && c.IsReceived && !c.IsDeleted);
                if (data != null)
                {
                    data.IsReceived = false;
                    if (db.Entry(data).State == EntityState.Detached)
                        db.Set<OrderedItem>().Attach(data);
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewPendingOrders(PurchaseOrderId, 2);
                }
            }
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var orderedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == PurchaseOrderId && !c.IsDeleted)
                                        join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                        on po.OrderUniqueId equals oi.OrderId
                                        join it in db.Items.Where(c => !c.IsDeleted)
                                        on oi.ItemCode equals it.Code
                                        select new
                                        {
                                            oi.ItemCode,
                                            it.PrintableName,
                                            oi.Quantity
                                        }).ToList();
                    DataTable Orders = Info.ToDataTable(orderedItems);
                    Info.ExportPurchaseOrders(Orders, PurchaseOrderId);
                }
            }
            catch (Exception ex)
            {
                Info.Add(ex);
            }
        }

        private void BaseLayout_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVItemsToOrder_MouseUp(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVOrderedItems_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVReceivedItems_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void TxtFilterItems_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtFilterItems);
        }

        private void CmbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupplierId = Convert.ToInt32(CmbSuppliers.SelectedValue.ToString());
        }
    }
}
