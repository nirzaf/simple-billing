using SimpleBilling.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class PurchaseOrder : Form
    {
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
                            }).OrderByDescending(c => c.StockQty).ToList();
                DGVItemsToOrder.DataSource = data;

            }
        }
    }
}
