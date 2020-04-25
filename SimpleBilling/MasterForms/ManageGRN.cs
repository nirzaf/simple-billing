using SimpleBilling.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageGRN : Form
    {
        private int GRN_Id= int.MinValue;
        private string GRN_Code = string.Empty;
        private int LineNo = 1;
        public ManageGRN()
        {
            InitializeComponent();
        }

        private void ManageGRN_Load(object sender, EventArgs e)
        {
            LoadCmb();
        }

        private void LoadDetails()
        {
            using (BillingContext db = new BillingContext()) 
            {
                gRNDetailsBindingSource.DataSource = db.GRNDetails.Where(c => c.GRN_Id == GRN_Id).ToList();
            }
        }

        private void LoadCmb()
        {
            using (BillingContext db = new BillingContext()) 
            {
                itemBindingSource.DataSource = db.Items.ToList();
                supplierBindingSource.DataSource = db.Suppliers.ToList();
            }
        }

        private void BtnCreateGRN_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    GRNHeader header = new GRNHeader
                    {
                        ReferenceNo = TxtReference.Text.Trim(),
                        GRN_No = TxtGRNNo.Text.Trim(),
                        GRN_Date = DTPDate.Value.ToShortDateString(),
                        Supplier = (Supplier)CMBSupplier.SelectedItem,
                        GrossTotal = 0,
                        NetTotal = 0,
                        TotalDiscout = 0,
                        Employee = null,
                        Status = 1
                    };

                    if (db.Entry(header).State == EntityState.Detached)
                        db.Set<GRNHeader>().Attach(header);
                    db.Entry(header).State = EntityState.Added;
                    db.SaveChanges();
                    GRN_Id = header.GRN_Id;
                    GRN_Code = header.GRN_No;
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
        }
        private void Info(string Message)
        {
            LblMessage.Text = Message;
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            LblMessage.Text = string.Empty;
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    GRNDetails details = new GRNDetails
                    {
                        GRN_Id = GRN_Id,
                        GRNCode = GRN_Code,
                        LineId = LineNo,
                        ProductId = Convert.ToInt32(CmbProduct.SelectedValue.ToString()),
                        UnitCost = Convert.ToSingle(TxtUnitCost.Text.Trim()),
                        Quantity = Convert.ToInt32(TxtQuantity.Text.Trim())
                    };
                    if (!string.IsNullOrWhiteSpace(TxtDiscount.Text)) details.Discount = Convert.ToSingle(TxtDiscount.Text.Trim());
                    details.SubTotal = (details.UnitCost * Convert.ToSingle(details.Quantity)) - details.Discount;
                    if (db.Entry(details).State == EntityState.Detached) db.Set<GRNDetails>().Attach(details);
                    db.Entry(details).State = EntityState.Added;
                    db.SaveChanges();
                    MessageBox.Show(details.GRN_Id.ToString());
                    if (details.GRN_Id != 0)
                    {
                        LineNo++;
                        LoadDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
