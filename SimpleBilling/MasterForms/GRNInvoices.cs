using SimpleBilling.Model;
using System;
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
    }
}
