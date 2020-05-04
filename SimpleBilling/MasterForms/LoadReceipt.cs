using SimpleBilling.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class LoadReceipt : Form
    {
        private string ReceiptNo;

        public LoadReceipt()
        {
            InitializeComponent();
        }

        private void LoadReceipt_Load(object sender, EventArgs e)
        {
            DGVLoad();
        }

        private void DGVLoad()
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from header in db.ReceiptHeaders.Where(c => c.IsDeleted == false)
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
                DGVLoadReceipt.DataSource = data;
            }
        }

        private void LoadReceiptFromDGV()
        {
            if (DGVLoadReceipt.SelectedRows.Count > 0)
            {
                ReceiptNo = DGVLoadReceipt.SelectedRows[0].Cells[0].Value + string.Empty;
            }
        }

        private void BtnLoadReceipt_Click(object sender, EventArgs e)
        {
            LoadReceiptFromDGV();
            OpenOPS();
        }

        private void OpenOPS()
        {
            POS pos = new POS(ReceiptNo);
            pos.Show();
            Hide();
        }

        private void DGVLoadReceipt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadReceiptFromDGV();
            OpenOPS();
        }
    }
}