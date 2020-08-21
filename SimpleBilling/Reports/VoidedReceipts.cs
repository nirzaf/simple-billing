using SimpleBilling.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.Reports
{
    public partial class VoidedReceipts : Form
    {
        public VoidedReceipts()
        {
            InitializeComponent();
        }

        private void VoidedReceipts_Load(object sender, EventArgs e)
        {

        }

        private void FilterByDate(string FromDate, string ToDate)
        {
            using (BillingContext db = new BillingContext())
            {
                //var data = (from header in db.ReceiptHeaders.Where(c => !c.IsDeleted && !c.IsQuotation & c.Status == 0)
                //            join cashier in db.Employee
                //            on header.Cashier equals cashier.EmployeeId
                //            join cus in db.Customers
                //            on header.CustomerId equals cus.CustomerId
                //            select new
                //            {
                //                header.ReceiptNo,
                //                header.Date,
                //                header.Time,
                //                cashier.EmployeeName,
                //                cus.Name,
                //                header.SubTotal,
                //                header.TotalDiscount,
                //                header.NetTotal,
                //                header.PaymentType
                //            }).Where(c=>c.Date == ).ToList();
                //DGVReport.DataSource = data;
            }
        }
    }
}
