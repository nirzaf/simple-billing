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
        private DataTable Rpt;

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
                var data = (from header in db.ReceiptHeaders.Where(c => !c.IsDeleted && !c.IsQuotation)
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
                                header.NetTotal,
                                header.PaymentType
                            }).ToList();
                DGVLoadReceipt.DataSource = data;
                Rpt = Info.ToDataTable(data);
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
            try
            {
                POS pos = new POS(ReceiptNo);
                pos.Show();
                Hide();
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private void DGVLoadReceipt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadReceiptFromDGV();
            OpenOPS();
        }

        private void TxtFilterReceipts_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string FilterByReceipt = TxtFilterReceipts.Text.Trim();
                using (BillingContext db = new BillingContext())
                {
                    if (FilterByReceipt.Length > 0)
                    {
                        var data = (from header in db.ReceiptHeaders
                                    .Where(c => !c.IsDeleted && !c.IsQuotation
                                    && c.ReceiptNo.Contains(FilterByReceipt))
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
                                        header.NetTotal,
                                        header.PaymentType
                                    }).ToList();
                        DGVLoadReceipt.DataSource = data;
                    }
                    else
                    {
                        var data = (from header in db.ReceiptHeaders
                                    .Where(c => !c.IsDeleted && !c.IsQuotation)
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
                                        header.NetTotal,
                                        header.PaymentType
                                    }).ToList();
                        DGVLoadReceipt.DataSource = data;
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex); Info.Mes(ex.Message);
            }
        }

        private void BtnGetTodaysReceipts_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    string date = DateTime.Today.ToShortDateString();
                    if (date.Length > 0)
                    {
                        var data = (from header in db.ReceiptHeaders
                                    .Where(c => !c.IsDeleted && !c.IsQuotation
                                    && c.Date == date)
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
                                        header.NetTotal,
                                        header.PaymentType
                                    }).ToList();
                        DGVLoadReceipt.DataSource = data;
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex); Info.Mes(ex.Message);
            }
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from header in db.ReceiptHeaders
                .Where(c => !c.IsDeleted && !c.IsQuotation)
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
                                header.NetTotal,
                                header.PaymentType
                            }).ToList();
                DGVLoadReceipt.DataSource = data;
            }
        }

        private void BtnExportAsExcel_Click(object sender, EventArgs e)
        {
            Info.ExportAsExcel(DGVLoadReceipt);
        }

        private void BtnExportAsPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Info.ExportReceiptsAsPDF(Rpt);
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex); Info.Mes(ex.Message);
            }
        }
    }
}