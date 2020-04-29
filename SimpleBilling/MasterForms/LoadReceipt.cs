using SimpleBilling.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class LoadReceipt : Form
    {
        public LoadReceipt()
        {
            InitializeComponent();
        }

        private void LoadReceipt_Load(object sender, EventArgs e)
        {

        }

        private void DGVLoad(string InvoiceNo)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from header in db.ReceiptHeaders.Where(c => c.Is_Deleted == false)
                            join cashier in db.Employee
                            on header.Cashier equals cashier.EmployeeId
                            select new
                            {
                                header.ReceiptNo,
                                header.Date,
                                header.Time,
                                cashier.EmployeeName,
                                header.SubTotal,
                                header.TotalDiscount,
                                header.PaidAmount,
                                header.Balance,
                                header.PaymentType
                            }).ToList();
            }
        }
    }
}
