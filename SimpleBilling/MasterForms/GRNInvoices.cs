using SimpleBilling.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class GRNInvoices : Form
    {
        public GRNInvoices()
        {
            InitializeComponent();
        }

        private void GRNInvoices_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            BtnLoadInvoice.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                var data = (from header in db.GRNHeaders
                            join supplier in db.Suppliers
                            on header.Supplier.SupplierId equals supplier.SupplierId
                            join employee in db.Employee
                            on header.Employee.EmployeeId equals employee.EmployeeId
                            select new
                            {
                                header.GRN_Id,
                                header.GRN_No,
                                Date = header.GRN_Date,
                                Supplier = supplier.Name,
                                Created_By = employee.EmployeeName,
                                Gross_Total = header.GrossTotal,
                                Total_Discount = header.TotalDiscout,
                                Net_Total = header.NetTotal
                            }).ToList();
                DGVInvoices.DataSource = data;
            }
        }

        private void DGVInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVInvoices.Rows.Count > 0)
            {
                BtnLoadInvoice.Enabled = true;
            }
        }

        private void BtnLoadInvoice_Click(object sender, EventArgs e)
        {
            LoadGRNInvoice();
        }

        private void LoadGRNInvoice()
        {
            string GRN_String = DGVInvoices.SelectedRows[0].Cells[1].Value + string.Empty;
            ManageGRN grn = new ManageGRN(GRN_String);
            grn.Show();
            Close();
        }

        private void DGVInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGRNInvoice();
        }

        private void BaseLayout_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVInvoices_MouseUp(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void TxtSearchGRNInvoices_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtSearchGRNInvoices.Text.Length > 0)
            {
                Info.ToCapital(TxtSearchGRNInvoices);
                SearchDGV(TxtSearchGRNInvoices.Text.Trim());
            }
            else
            {
                LoadDGV();
            }
        }

        private void SearchDGV(string Text)
        {
            BtnLoadInvoice.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                var data = (from header in db.GRNHeaders
                            join supplier in db.Suppliers
                            on header.Supplier.SupplierId equals supplier.SupplierId
                            join employee in db.Employee
                            on header.Employee.EmployeeId equals employee.EmployeeId
                            select new
                            {
                                header.GRN_Id,
                                header.GRN_No,
                                Date = header.GRN_Date,
                                Supplier = supplier.Name,
                                Created_By = employee.EmployeeName,
                                Gross_Total = header.GrossTotal,
                                Total_Discount = header.TotalDiscout,
                                Net_Total = header.NetTotal
                            }).Where(c => c.GRN_No.Contains(Text) || c.Date.Contains(Text) || c.Supplier.Contains(Text) || c.Created_By.Contains(Text)).ToList();
                DGVInvoices.DataSource = data;
            }
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            Info.ExportAsExcel(DGVInvoices);
        }

        private void BtnExportToPdf_Click(object sender, EventArgs e)
        {
            DataTable dt = Info.DGVToDataTable(DGVInvoices);
            Info.ExpPDF(dt);
        }
    }
}