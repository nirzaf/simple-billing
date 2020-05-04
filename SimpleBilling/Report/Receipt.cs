using Microsoft.Reporting.WinForms;
using SimpleBilling.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.Report
{
    public partial class Receipt : Form
    {
        public Receipt(string ReceiptNo)
        {
            InitializeComponent();
            RVLoad(ReceiptNo);
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            //RVReceipt.RefreshReport();
        }

        private void RVLoad(string ReceiptNo)
        {
            using (BillingContext db = new BillingContext())
            {
                var RptHeader = (from header in db.ReceiptHeaders.Where(c => c.IsDeleted == false && c.ReceiptNo == ReceiptNo)
                                 join cashier in db.Employee
                                 on header.Cashier equals cashier.EmployeeId
                                 select new
                                 {
                                     header.Date,
                                     header.Time,
                                     header.TotalDiscount,
                                     header.SubTotal,
                                     header.NetTotal,
                                     header.PaidAmount,
                                     header.Balance,
                                     header.Status,
                                     Cashier = cashier.EmployeeName
                                 }).ToList();
                ReceiptHeader.DataSource = RptHeader;

                var RptBody = (from body in db.ReceiptBodies.Where(c => c.IsDeleted == false && c.ReceiptNo == ReceiptNo)
                               join item in db.Items
                               on body.ProductId equals item.Id
                               select new
                               {
                                   item.Id,
                                   item.Code,
                                   item.ItemName,
                                   body.UnitPrice,
                                   body.Quantity,
                                   body.SubTotal,
                                   body.Discount,
                                   body.NetTotal
                               }).ToList();

                ReceiptBody.DataSource = RptBody;

                BusinessInfo.DataSource = db.BusinessModels.ToList();

                var RptHeaderDataSource = new ReportDataSource
                {
                    Name = "Header",
                    Value = RptHeader
                };
                RVReceipt.LocalReport.DataSources.Add(RptHeaderDataSource);
                RVReceipt.LocalReport.ReportEmbeddedResource = "Receipt.rdlc";
                RVReceipt.RefreshReport();
            }
        }
    }
}