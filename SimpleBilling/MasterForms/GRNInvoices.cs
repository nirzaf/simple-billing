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
    }
}
