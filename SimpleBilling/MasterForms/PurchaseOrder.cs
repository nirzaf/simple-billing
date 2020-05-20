using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class PurchaseOrder : Form
    {
        private string PurchaseOrderDate;
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            FormLoad(DateTime.Today.ToShortDateString());
        }

        private void FormLoad(string Date)
        {
            FormLoadAll(string.Empty);
            using (BillingContext db = new BillingContext())
            {
                var orderedItems = (from po in db.PurchaseOrders.Where(c => c.Date == Date && !c.IsDeleted)
                                    join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                    on po.Date equals oi.OrderedDate
                                    join it in db.Items.Where(c => !c.IsDeleted)
                                    on oi.ItemCode equals it.Code
                                    select new
                                    {
                                        oi.ItemCode,
                                        it.PrintableName,
                                        oi.Quantity
                                    }).ToList();
                DGVOrderedItems.DataSource = orderedItems;

                var receivedItems = (from po in db.PurchaseOrders.Where(c => c.Date == Date && !c.IsDeleted)
                                     join oi in db.OrderedItems.Where(c => c.IsReceived && !c.IsDeleted)
                                     on po.Date equals oi.OrderedDate
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

                var pendingOrders = db.PurchaseOrders.Where(c => !c.IsReceived && !c.IsDeleted).Select(c => c.Date).ToList();
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

        private void BtnAddToOrder_Click(object sender, EventArgs e)
        {
            AddToOrder();
        }

        private void AddToOrder()
        {
            try
            {
                string Date = DtpOrderDate.Value.ToShortDateString();
                using (BillingContext db = new BillingContext())
                {
                    if (DGVItemsToOrder.SelectedRows.Count > 0)
                    {
                        string Code = DGVItemsToOrder.SelectedRows[0].Cells[0].Value + string.Empty;
                        var OrdItem = db.OrderedItems.FirstOrDefault(c => c.ItemCode == Code && c.OrderedDate == Date);
                        if (OrdItem == null)
                        {
                            OrderedItem oi = new OrderedItem
                            {
                                ItemCode = Code,
                                Quantity = Info.ToInt(TxtOrderQuantity),
                                UnitType = Info.ToString(TxtUnitType),
                                CreatedDate = DateTime.Today,
                                OrderedDate = Date
                            };
                            if (db.Entry(oi).State == EntityState.Detached)
                                db.Set<OrderedItem>().Attach(oi);
                            db.Entry(oi).State = EntityState.Added;
                            db.SaveChanges();
                            FormLoad(Date);
                        }
                        else
                        {
                            OrdItem.Quantity = Info.ToInt(TxtOrderQuantity);
                            OrdItem.UnitType = Info.ToString(TxtUnitType);
                            OrdItem.UpdatedDate = DateTime.Today;
                            OrdItem.OrderedDate = Date;
                            if (db.Entry(OrdItem).State == EntityState.Detached)
                                db.Set<OrderedItem>().Attach(OrdItem);
                            db.Entry(OrdItem).State = EntityState.Modified;
                            db.SaveChanges();
                            FormLoad(Date);
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
                PurchaseOrderDate = DtpOrderDate.Value.ToShortDateString();
                using (BillingContext db = new BillingContext())
                {
                    var data = db.PurchaseOrders.FirstOrDefault(c => c.Date == PurchaseOrderDate);
                    if (data != null)
                    {
                        bool result = Info.YesNoConfirmation("For Selected date you have already created a purchase order, would you like to update again", "Confirmation");
                        if (result)
                        {
                            FormLoad(DtpOrderDate.Value.ToShortDateString());
                            BtnAddToOrder.Enabled = true;
                            BtnRemove.Enabled = true;
                        }
                    }
                    else
                    {
                        Model.PurchaseOrder po = new Model.PurchaseOrder
                        {
                            Date = PurchaseOrderDate,
                            CreatedDate = DateTime.Today
                        };
                        if (db.Entry(po).State == EntityState.Detached)
                            db.Set<Model.PurchaseOrder>().Attach(po);
                        db.Entry(po).State = EntityState.Added;
                        db.SaveChanges();
                        PurchaseOrderDate = po.Date;
                        BtnAddToOrder.Enabled = true;
                        BtnRemove.Enabled = true;
                    }
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
                        TxtUnitType.Text = item.Unit;
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
            PurchaseOrderDate = DtpOrderDate.Value.ToShortDateString();
            FormLoad(PurchaseOrderDate);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                if (DGVOrderedItems.SelectedRows.Count > 0)
                {
                    PurchaseOrderDate = DtpOrderDate.Value.ToShortDateString();
                    string code = DGVOrderedItems.SelectedRows[0].Cells[0].Value + string.Empty;
                    var item = db.OrderedItems.FirstOrDefault(c => c.ItemCode == code && c.OrderedDate == PurchaseOrderDate);
                    if (item != null)
                    {
                        if (db.Entry(item).State == EntityState.Detached)
                            db.Set<OrderedItem>().Attach(item);
                        db.Entry(item).State = EntityState.Deleted;
                        db.SaveChanges();
                        FormLoad(PurchaseOrderDate);
                    }
                }
            }
        }

        private void LstBoxPendingOrders_DoubleClick(object sender, EventArgs e)
        {
            PurchaseOrderDate = LstBoxPendingOrders.SelectedItem.ToString();
            ViewPendingOrders(PurchaseOrderDate, 1);
        }

        private void ViewPendingOrders(string Date, int type)
        {
            using (BillingContext db = new BillingContext())
            {
                var orderedItems = (from po in db.PurchaseOrders.Where(c => c.Date == Date && !c.IsDeleted)
                                    join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                    on po.Date equals oi.OrderedDate
                                    join it in db.Items.Where(c => !c.IsDeleted)
                                    on oi.ItemCode equals it.Code
                                    select new
                                    {
                                        oi.ItemCode,
                                        it.PrintableName,
                                        oi.Quantity
                                    }).ToList();
                DGVOrderedItems.DataSource = orderedItems;

                var receivedItems = (from po in db.PurchaseOrders.Where(c => c.Date == Date && !c.IsDeleted)
                                     join oi in db.OrderedItems.Where(c => c.IsReceived && !c.IsDeleted)
                                     on po.Date equals oi.OrderedDate
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
            if (!string.IsNullOrWhiteSpace(PurchaseOrderDate))
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.PurchaseOrders.FirstOrDefault(c => c.Date == PurchaseOrderDate);
                    if (data != null)
                    {
                        data.IsReceived = true;
                        if (db.Entry(data).State == EntityState.Detached)
                            db.Set<Model.PurchaseOrder>().Attach(data);
                        db.Entry(data).State = EntityState.Modified;
                        db.SaveChanges();
                        FormLoad(PurchaseOrderDate);
                    }
                }
            }
        }

        private void LstBoxPendingOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrderDate = LstBoxPendingOrders.SelectedItem.ToString();
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            FormLoadAll(string.Empty);
        }

        private void FormLoadAll(string Date)
        {

            using (BillingContext db = new BillingContext())
            {
                if (string.IsNullOrWhiteSpace(Date))
                {
                    var pendingOrders = db.PurchaseOrders.Where(c => c.IsReceived && !c.IsDeleted).Select(c => c.Date).ToList();
                    LstReceivedOrders.DataSource = pendingOrders;
                }
                else
                {
                    var pendingOrders = db.PurchaseOrders.Where(c => c.Date == Date && c.IsReceived && !c.IsDeleted).Select(c => c.Date).ToList();
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
            PurchaseOrderDate = LstReceivedOrders.SelectedItem.ToString();
            ViewPendingOrders(PurchaseOrderDate, 2);
        }

        private void DGVOrderedItems_DoubleClick(object sender, EventArgs e)
        {
            string Code = DGVOrderedItems.SelectedRows[0].Cells[0].Value + string.Empty;
            using (BillingContext db = new BillingContext())
            {
                var data = db.OrderedItems.FirstOrDefault(c => c.OrderedDate == PurchaseOrderDate && c.ItemCode == Code && !c.IsReceived && !c.IsDeleted);
                if (data != null)
                {
                    data.IsReceived = true;
                    if (db.Entry(data).State == EntityState.Detached)
                        db.Set<OrderedItem>().Attach(data);
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewPendingOrders(PurchaseOrderDate, 2);
                }
            }
        }

        private void DGVReceivedItems_MouseClick(object sender, MouseEventArgs e)
        {
            string Code = DGVReceivedItems.SelectedRows[0].Cells[0].Value + string.Empty;
            using (BillingContext db = new BillingContext())
            {
                var data = db.OrderedItems.FirstOrDefault(c => c.OrderedDate == PurchaseOrderDate && c.ItemCode == Code && c.IsReceived && !c.IsDeleted);
                if (data != null)
                {
                    data.IsReceived = false;
                    if (db.Entry(data).State == EntityState.Detached)
                        db.Set<OrderedItem>().Attach(data);
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewPendingOrders(PurchaseOrderDate, 2);
                }
            }
        }
    }
}
