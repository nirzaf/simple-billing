using SimpleBilling.Migrations;
using SimpleBilling.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Globalization;
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
        private int LineNo;

        public ManageGRN(string GRN_Init_Code)
        {
            InitializeComponent();
            GRN_Code = GRN_Init_Code;
        }

        private void ManageGRN_Load(object sender, EventArgs e)
        {
            BtnApprove.Enabled = false;
            LoadCmb();
            GRNLoad();
            if (!string.IsNullOrEmpty(GRN_Code))
            {
                LoadDetails(GRN_Code);
            }
        }

        private void GRNLoad()
        {
            BtnAddCheque.Visible = false;
            CmbChooseCheques.Visible = false;
            TxtGivenAmount.Enabled = false;
            LayoutCheque.Visible = false;
        }

        private void LoadDetails(string GRN_New_Code)
        {
            GRN_New_Code = GRN_Code;
            if (!string.IsNullOrEmpty(GRN_New_Code))
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = (from details in db.GRNDetails.Where(a => a.IsDeleted == true && a.GRNCode == GRN_New_Code)
                                join item in db.Items
                                on details.ProductId equals item.Id
                                select new
                                {
                                    Line_No = details.LineId,
                                    Item_Name = item.ItemName,
                                    details.Quantity,
                                    Unit_Cost = details.UnitCost,
                                    details.Discount,
                                    Sub_Total = details.SubTotal
                                }).ToList();
                    DGVGRNList.DataSource = data;
                }

                TotalDiscount = (from DataGridViewRow row in DGVGRNList.Rows
                                 where row.Cells[0].FormattedValue.ToString() != string.Empty
                                 select Convert.ToSingle(row.Cells[4].FormattedValue)).Sum();
                NetTotal = (from DataGridViewRow row in DGVGRNList.Rows
                            where row.Cells[0].FormattedValue.ToString() != string.Empty
                            select Convert.ToSingle(row.Cells[5].FormattedValue)).Sum();
                LblTotalDiscount.Text = TotalDiscount.ToString();
                LblNetTotal.Text = NetTotal.ToString();
                float GrossTotal = TotalDiscount + NetTotal;
                LblGrossTotal.Text = GrossTotal.ToString();

                using (BillingContext db = new BillingContext())
                {
                    GRNHeader header = db.GRNHeaders.FirstOrDefault(c => c.GRN_No == GRN_New_Code);
                    TxtGRNNo.Text = GRN_New_Code;
                    TxtReference.Text = header.ReferenceNo;
                    DTPDate.Value = Convert.ToDateTime(header.GRN_Date, CultureInfo.InvariantCulture);
                    CMBSupplier.SelectedItem = header.Supplier;
                    LblStatus.Text = Invoice_Status(GRN_New_Code);
                    LblPaymentStatus.Text = PaymentStatus(header.IsPaid);
                }
            }
        }

        private string PaymentStatus(bool isPaid)
        {
            if (isPaid)
                return "Paid";
            else
                return "Not Paid";
        }

        private string Invoice_Status(string GRN_New_Code)
        {
            try
            {
                string CurrentStatus = string.Empty;
                int Status;
                using (BillingContext db = new BillingContext())
                {
                    GRNHeader header = db.GRNHeaders.FirstOrDefault(c => c.GRN_No == GRN_New_Code);
                    Status = header.Status;
                    if (Status == 1)
                    {
                        CurrentStatus = "Created";
                        BtnApprove.Enabled = false;
                        return CurrentStatus;
                    }
                    else if (Status == 2)
                    {
                        CurrentStatus = "Completed";
                        BtnApprove.Enabled = true;
                        return CurrentStatus;
                    }
                    else
                    {
                        CurrentStatus = "Approved";
                        BtnApprove.Enabled = false;
                        return CurrentStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info.Mes(ex.Message);
                return ex.ToString();
            }
        }

        private void LoadCmb()
        {
            using (BillingContext db = new BillingContext())
            {
                itemBindingSource.DataSource = db.Items.ToList();
                supplierBindingSource.DataSource = db.Suppliers.ToList();

                CmbBank.ValueMember = "BankId";
                CmbBank.DisplayMember = "BankName";
                CmbBank.DataSource = db.Banks.Where(c => c.IsDeleted == false).ToList();

                CmbChooseCheques.ValueMember = "ChequeNo";
                CmbChooseCheques.DisplayMember = "ChequeNo";
                CmbChooseCheques.DataSource = db.Cheques.Where(c => c.IsDeleted == false).ToList();

                CmbPaidBy.ValueMember = "CustomerId";
                CmbPaidBy.DisplayMember = "Name";
                CmbPaidBy.DataSource = db.Customers.Where(c => c.IsDeleted == false).ToList();
            }
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

                    if (isGRNExist == null)
                    {
                        if (db.Entry(header).State == EntityState.Detached)
                            db.Set<GRNHeader>().Attach(header);
                        db.Entry(header).State = EntityState.Added;
                        db.SaveChanges();
                        GRN_Id = header.GRN_Id;
                        GRN_Code = header.GRN_No;
                    }

                    int LineCount = DGVGRNList.Rows.Count;

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
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(details).State = EntityState.Added;
                        db.SaveChanges();
                    }
                    if (details.GRN_Id != 0)
                    {
                        LoadDetails(GRN_Code);
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info.Mes(ex.Message);
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
                    header.UpdatedDate = DateTime.Now;
                    db.Entry(header).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.ToString());
            }
            finally
            {
                MessageBox.Show($"Invoice {TxtGRNNo.Text.Trim()} Completed Successfully! Pending for Approval");
                LoadDetails(GRN_Code);
                BtnApprove.Enabled = true;
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
            if (CmbProduct.SelectedValue != null)
            {
                int ItemId = Convert.ToInt32(CmbProduct.SelectedValue.ToString());
                using (BillingContext db = new BillingContext())
                {
                    var result = db.Items.FirstOrDefault(c => c.Id == ItemId);
                    TxtUnitCost.Text = result.UnitCost.ToString();
                }
            }
        }

        private void DGVGRNList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVGRNList.SelectedRows.Count > 0)
            {
                GRN_Code = DGVGRNList.SelectedRows[0].Cells[0].Value + string.Empty;
                LineNo = Convert.ToInt32(DGVGRNList.SelectedRows[0].Cells[1].Value + string.Empty);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DGVGRNList.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected Item?", "Confirmation delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (BillingContext db = new BillingContext())
                    {
                        var Result = db.GRNDetails.FirstOrDefault(c => c.GRNCode.Equals(GRN_Code) && c.LineId.Equals(LineNo));
                        Result.IsDeleted = false;
                        if (db.Entry(Result).State == EntityState.Detached)
                            db.Set<GRNDetails>().Attach(Result);
                        Result.UpdatedDate = DateTime.Now;
                        db.Entry(Result).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadDetails(GRN_Code);
                    }
                }
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to approve this invoice?", "Confirmation Approve", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (BillingContext db = new BillingContext())
                {
                    foreach (GRNDetails details in db.GRNDetails)
                    {
                        if (details.GRNCode == GRN_Code && details.IsDeleted == true)
                        {
                            using (BillingContext db1 = new BillingContext())
                            {
                                int Item = details.ProductId;
                                int Qty = details.Quantity;
                                Item item = db1.Items.FirstOrDefault(c => c.Id.Equals(Item));
                                item.StockQty += Qty;
                                if (db1.Entry(item).State == EntityState.Detached)
                                    db1.Set<Item>().Attach(item);
                                item.UpdatedDate = DateTime.Now;
                                db1.Entry(item).State = EntityState.Modified;
                                db1.SaveChanges();
                            }
                        }
                    }

                    var Result = db.GRNHeaders.FirstOrDefault(c => c.GRN_No.Equals(GRN_Code));
                    Result.Status = 3;
                    if (db.Entry(Result).State == EntityState.Detached)
                        db.Set<GRNHeader>().Attach(Result);
                    Result.UpdatedDate = DateTime.Now;
                    db.Entry(Result).State = EntityState.Modified;
                    db.SaveChanges();
                    LoadDetails(GRN_Code);
                }
            }
        }

        private void TxtChequeNo_Enter(object sender, EventArgs e)
        {
            Info.Enter(TxtChequeNo, "Cheque No");
        }

        private void TxtChequeNo_Leave(object sender, EventArgs e)
        {
            Info.Enter(TxtChequeNo, "Cheque No");
        }

        private void TxtPayeeName_Enter(object sender, EventArgs e)
        {
            Info.Enter(TxtPayeeName, "Payee Name");
        }

        private void TxtPayeeName_Leave(object sender, EventArgs e)
        {
            Info.Enter(TxtPayeeName, "Payee Name");
        }

        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            Info.Enter(TxtAmount, "Amount");
        }

        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            Info.Enter(TxtAmount, "Amount");
        }

        private void BtnAddCheque_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (Info.IsEmpty(TxtChequeNo) && Info.IsEmpty(TxtPayeeName) && Info.IsEmpty(TxtAmount))
                    {
                        Cheque ch = new Cheque
                        {
                            ChequeNo = TxtChequeNo.Text.Trim(),
                            PayeeName = TxtPayeeName.Text.Trim(),
                            Amount = Convert.ToSingle(TxtAmount.Text.Trim()),
                            DueDate = DTChequeDueDate.Value.ToShortDateString(),
                            PaidBy = Convert.ToInt32(CmbPaidBy.SelectedValue.ToString()),
                            Bank = Convert.ToInt32(CmbBank.SelectedValue.ToString()),
                            CreatedDate = DateTime.Today
                        };
                        if (db.Entry(ch).State == EntityState.Detached)
                            db.Set<Cheque>().Attach(ch);
                        db.Entry(ch).State = EntityState.Added;
                        db.SaveChanges();
                        CmbChooseCheques.SelectedValue = ch.ChequeNo;
                    }
                    else
                    {
                        Info.Required();
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info.Mes(ex.Message);
            }
            finally
            {
                GRNLoad();
            }
        }

        private void CmbPaymentOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CmbPaymentOptions.Text))
            {
                if (CmbPaymentOptions.SelectedItem.ToString() == "Cheque")
                {
                    TxtGivenAmount.Enabled = true;
                    LayoutCheque.Visible = true;
                    BtnAddCheque.Visible = true;
                    CmbChooseCheques.Visible = true;
                    TxtPayeeName.Focus();
                    TxtAmount.Focus();
                    TxtChequeNo.Focus();
                }
                else
                {
                    GRNLoad();
                }
            }
        }

        private void TxtGivenAmount_KeyDown(object sender, KeyEventArgs e)
        {
            GRNPayment(TxtGRNNo.Text.Trim());
        }

        private void GRNPayment(string GRNNo)
        {
            using (BillingContext db = new BillingContext())
            {
                var grn = db.GRNHeaders.FirstOrDefault(c => c.IsDeleted == false && c.GRN_No == GRNNo);
                if (grn != null)
                {
                    if (grn.Status == 3 && grn.IsPaid == false)
                    {
                        grn.IsPaid = true;
                        grn.PaymentType = CmbPaymentOptions.Text;
                        if (CmbChooseCheques.Text != null)
                            grn.ChequeNo = CmbChooseCheques.Text;
                        if (db.Entry(grn).State == EntityState.Detached)
                            db.Set<GRNHeader>().Attach(grn);
                        db.Entry(grn).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        Info.Mes("Cannot Pay before approve the Invoice");
                    }
                }
            }
        }
    }
}