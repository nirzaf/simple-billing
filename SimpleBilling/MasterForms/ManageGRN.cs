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
        private int GRN_Id = int.MaxValue;
        private string GRN_Code = string.Empty;
        private float TotalDiscount = 0;
        private float NetTotal = 0;
        public ManageGRN(string GRN_Init_Code)
        {
            InitializeComponent();
            GRN_Code = GRN_Init_Code; 
        }

        private void ManageGRN_Load(object sender, EventArgs e)
        {
            LoadCmb();
            if (!string.IsNullOrEmpty(GRN_Code))
            {
                LoadDetails(GRN_Code);
            }
        }

        private void LoadDetails(string GRN_New_Code)
        {
            GRN_New_Code = GRN_Code;
            if (!string.IsNullOrEmpty(GRN_New_Code))
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = (from details in db.GRNDetails
                                join item in db.Items
                                on details.ProductId equals item.Id
                                select new
                                {
                                    GRN_Code = details.GRNCode,
                                    Line_No = details.LineId,
                                    Item_Name = item.ItemName,
                                    details.Quantity,
                                    Unit_Cost = details.UnitCost,
                                    details.Discount,
                                    Sub_Total = details.SubTotal
                                }).Where(c => c.GRN_Code == GRN_New_Code).ToList();
                    DGVGRNList.DataSource = data;
                }
            }

            TotalDiscount = (from DataGridViewRow row in DGVGRNList.Rows
                             where row.Cells[0].FormattedValue.ToString() != string.Empty
                             select Convert.ToInt32(row.Cells[5].FormattedValue)).Sum();
            NetTotal = (from DataGridViewRow row in DGVGRNList.Rows
                        where row.Cells[0].FormattedValue.ToString() != string.Empty
                        select Convert.ToInt32(row.Cells[6].FormattedValue)).Sum();
            LblTotalDiscount.Text = TotalDiscount.ToString();
            LblNetTotal.Text = NetTotal.ToString();
            float GrossTotal = TotalDiscount + NetTotal;
            LblGrossTotal.Text = GrossTotal.ToString();
        }

        private void LoadCmb()
        {
            using (BillingContext db = new BillingContext()) 
            {
                itemBindingSource.DataSource = db.Items.ToList();
                supplierBindingSource.DataSource = db.Suppliers.ToList();
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

                    var isGRNExist = db.GRNHeaders.FirstOrDefault(c => c.GRN_No == header.GRN_No);

                    if(isGRNExist == null)
                    {
                        if (db.Entry(header).State == EntityState.Detached)
                            db.Set<GRNHeader>().Attach(header);
                        db.Entry(header).State = EntityState.Added;
                        db.SaveChanges();
                        GRN_Id = header.GRN_Id;
                        GRN_Code = header.GRN_No;
                    }

                    int LineCount = Convert.ToInt32(DGVGRNList.Rows.Count.ToString());

                    GRNDetails details = new GRNDetails
                    {
                        GRN_Id = GRN_Id,
                        GRNCode = GRN_Code,
                        LineId = ++LineCount,
                        ProductId = Convert.ToInt32(CmbProduct.SelectedValue.ToString()),
                        UnitCost = Convert.ToSingle(TxtUnitCost.Text.Trim()),
                        Quantity = Convert.ToInt32(TxtQuantity.Text.Trim())
                    };
                    if (!string.IsNullOrWhiteSpace(TxtDiscount.Text))
                        details.Discount = Convert.ToSingle(TxtDiscount.Text.Trim());
                    else
                        details.Discount = 0;

                    details.SubTotal = (details.UnitCost * Convert.ToSingle(details.Quantity)) - details.Discount;

                    if (db.Entry(details).State == EntityState.Detached)
                        db.Set<GRNDetails>().Attach(details);

                    var result = db.GRNDetails.SingleOrDefault(b => b.GRN_Id == details.GRN_Id
                    && b.GRNCode == details.GRNCode
                    && b.ProductId == details.ProductId);

                    if (result != null)
                    {
                        result.Quantity += Convert.ToInt32(TxtQuantity.Text.Trim());
                        result.UnitCost = Convert.ToSingle(TxtUnitCost.Text.Trim());
                        if (!string.IsNullOrWhiteSpace(TxtDiscount.Text))
                            result.Discount = Convert.ToSingle(TxtDiscount.Text.Trim());
                        else
                            result.Discount = 0;

                        result.SubTotal = (result.UnitCost * Convert.ToSingle(result.Quantity)) - result.Discount;
                        db.Entry(result).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(details).State = EntityState.Added;
                    }
                    db.SaveChanges();
                    if (details.GRN_Id != 0)
                    {
                        LoadDetails(GRN_Code);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TotalDiscount = (from DataGridViewRow row in DGVGRNList.Rows 
                                         where row.Cells[0].FormattedValue.ToString() != string.Empty
                                         select Convert.ToInt32(row.Cells[5].FormattedValue)).Sum();
                NetTotal = (from DataGridViewRow row in DGVGRNList.Rows
                                      where row.Cells[0].FormattedValue.ToString() != string.Empty
                                      select Convert.ToInt32(row.Cells[6].FormattedValue)).Sum();
                LblTotalDiscount.Text = TotalDiscount.ToString();
                LblNetTotal.Text = NetTotal.ToString();
                float GrossTotal = TotalDiscount + NetTotal;
                LblGrossTotal.Text = GrossTotal.ToString();
            }
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var header = db.GRNHeaders.FirstOrDefault(c => c.GRN_No == TxtGRNNo.Text.Trim());

                    header.GrossTotal = NetTotal + TotalDiscount;
                    header.TotalDiscout = TotalDiscount;
                    header.NetTotal = NetTotal;
                    header.Status = 2;
      

                    if (db.Entry(header).State == EntityState.Detached)
                        db.Set<GRNHeader>().Attach(header);
                    db.Entry(header).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
            finally
            {
                DGVGRNList.DataSource = null;
                MessageBox.Show($"Invoice {TxtGRNNo.Text.Trim()} Created Successfully");
            }
        }

        private void BtnLoadInvoice_Click(object sender, EventArgs e)
        {
            GRNInvoices inv = new GRNInvoices();
            inv.Show();
            Hide();
        }

        private void CmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ItemId = Convert.ToInt32(CmbProduct.SelectedValue.ToString());
            using (BillingContext db = new BillingContext())
            {
                var result = db.Items.FirstOrDefault(c => c.Id == ItemId);
                TxtUnitCost.Text = result.UnitCost.ToString();
            }
        }
    }
}
