using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class PurchaseOrder : Form
    {
        private int PurchaseOrderId;
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            FormLoad(string.Empty);
        }

        private void FormLoad(string Date)
        {
            using (BillingContext db = new BillingContext())
            {
                var orderedItems = (from po in db.PurchaseOrders.Where(c => c.Date == Date && !c.IsDeleted)
                                    join oi in db.OrderedItems.Where(c => !c.IsDeleted)
                                    on po.PurchaseOrderId equals oi.PurchaseOrderId
                                    join it in db.Items.Where(c => !c.IsDeleted)
                                    on oi.ItemCode equals it.Code
                                    select new
                                    {
                                        oi.ItemCode,
                                        it.PrintableName,
                                        oi.Quantity
                                    }).ToList();

                DGVOrderedItems.DataSource = orderedItems;

                var data = (from item in db.Items.Where(c => !c.IsDeleted)
                            select new
                            {
                                item.Code,
                                item.PrintableName,
                                item.StockQty
                            }).OrderBy(c => c.StockQty).ToList();
                DGVItemsToOrder.DataSource = data;

                LblDate.Text = DateTime.Today.ToShortDateString();
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
                        var OrdItem = db.OrderedItems.FirstOrDefault(c => c.ItemCode == Code && c.PurchaseOrderId == PurchaseOrderId);
                        if (OrdItem == null)
                        {
                            OrderedItem oi = new OrderedItem
                            {
                                ItemCode = Code,
                                Quantity = Info.ToInt(TxtOrderQuantity),
                                UnitType = Info.ToString(TxtUnitType),
                                CreatedDate = DateTime.Today,
                                PurchaseOrderId = PurchaseOrderId
                            };
                            if (db.Entry(oi).State == EntityState.Detached)
                                db.Set<OrderedItem>().Attach(oi);
                            db.Entry(oi).State = EntityState.Added;
                            db.SaveChanges();
                        }
                        else
                        {
                            OrdItem.Quantity = Info.ToInt(TxtOrderQuantity);
                            OrdItem.UnitType = Info.ToString(TxtUnitType);
                            OrdItem.UpdatedDate = DateTime.Today;
                            OrdItem.PurchaseOrderId = PurchaseOrderId;
                            if (db.Entry(OrdItem).State == EntityState.Detached)
                                db.Set<OrderedItem>().Attach(OrdItem);
                            db.Entry(OrdItem).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
            finally
            {
                FormLoad(DtpOrderDate.Value.ToShortDateString());
            }

        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.PurchaseOrders.FirstOrDefault(c => c.Date == DtpOrderDate.Value.ToShortDateString());
                    if (data != null)
                    {
                        bool result = Info.YesNoConfirmation("For Selected date you have already created a purchase order, would you like to create again", "Confirmation");
                        if (result)
                        {
                            Model.PurchaseOrder po = new Model.PurchaseOrder
                            {
                                Date = DtpOrderDate.Value.ToShortDateString(),
                                CreatedDate = DateTime.Today
                            };
                            if (db.Entry(po).State == EntityState.Detached)
                                db.Set<Model.PurchaseOrder>().Attach(po);
                            db.Entry(po).State = EntityState.Added;
                            db.SaveChanges();
                            PurchaseOrderId = po.PurchaseOrderId;
                        }
                        else
                        {
                            FormLoad(DtpOrderDate.Value.ToShortDateString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
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
    }
}
