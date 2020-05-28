using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using SimpleBilling.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;

namespace SimpleBilling.MasterForms
{
    public partial class ManageGRN : Form
    {
        private int GRN_Id;
        private string GRN_Code;
        private float GrossTotal = 0;
        private float TotalDiscount = 0;
        private float NetTotal = 0;
        private float Returns = 0;
        private float PaidValue;
        private float BalanceValue;
        private float GivenValue;
        private float PendingValue;
        private DataTable dtGRN;
        private DataTable dtGRNReturn;

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
            LayoutCheque.Visible = false;
            BtnGRNReturn.Enabled = false;
            BtnAddToReturn.Visible = false;
            BtnRemoveReturn.Visible = false;
            int count = 0;
            foreach (RowStyle rs in DGVPanel.RowStyles)
            {
                count++;
                if (DGVGRNReturned.Rows.Count == 0)
                {
                    if (count == 2)
                    {
                        rs.SizeType = SizeType.Percent;
                        rs.Height = 0;
                    }
                    if (count == 1)
                    {
                        rs.SizeType = SizeType.Percent;
                        rs.Height = 100;
                    }
                }
            }
        }

        private void LoadDetails(string GRN_New_Code)
        {
            GRN_Code = GRN_New_Code;
            if (!string.IsNullOrEmpty(GRN_New_Code))
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = (from details in db.GRNDetails.Where(a => !a.IsDeleted && a.GRNCode == GRN_New_Code && !a.IsReturned)
                                join item in db.Items
                                on details.ProductId equals item.Id
                                select new
                                {
                                    details.GRN_Id,
                                    item.Code,
                                    Item_Name = item.ItemName,
                                    UnitPrice = details.UnitCost,
                                    details.Quantity,
                                    SubTotal = details.GrossTotal,
                                    details.Discount,
                                    NetTotal = details.SubTotal
                                }).ToList();
                    DGVGRNList.DataSource = data;
                    dtGRN = Info.ToDataTable(data);
                    var returned = (from details in db.GRNDetails.Where(a => !a.IsDeleted && a.GRNCode == GRN_New_Code && a.IsReturned)
                                    join item in db.Items
                                    on details.ProductId equals item.Id
                                    select new
                                    {
                                        details.GRN_Id,
                                        item.Code,
                                        Item_Name = item.ItemName,
                                        UnitPrice = details.UnitCost,
                                        details.Quantity,
                                        SubTotal = details.GrossTotal,
                                        details.Discount,
                                        NetTotal = details.SubTotal
                                    }).ToList();
                    DGVGRNReturned.DataSource = returned;
                    dtGRNReturn = Info.ToDataTable(returned);
                    if (returned.Count > 0)
                    {
                        foreach (RowStyle rs in DGVPanel.RowStyles)
                        {
                            rs.SizeType = SizeType.Percent;
                            rs.Height = 50;
                        }
                    }
                    else
                    {
                        int count = 0;
                        foreach (RowStyle rs in DGVPanel.RowStyles)
                        {
                            count++;
                            if (count == 1)
                            {
                                rs.SizeType = SizeType.Percent;
                                rs.Height = 100;
                            }
                            if (count == 2)
                            {
                                rs.SizeType = SizeType.Percent;
                                rs.Height = 0;
                            }
                        }
                        BtnRemoveReturn.Visible = false;
                    }

                    var header = db.GRNHeaders.FirstOrDefault(c => c.GRN_No == GRN_New_Code && !c.IsDeleted);
                    if (header != null)
                    {
                        TxtGRNNo.Text = GRN_New_Code;
                        TxtReference.Text = header.ReferenceNo;
                        LblNetTotal.Text = header.NetTotal.ToString();
                        DTPDate.Value = Convert.ToDateTime(header.GRN_Date, CultureInfo.InvariantCulture);
                        CMBSupplier.SelectedItem = header.Supplier;
                        LblStatus.Text = Invoice_Status(header.Status);
                        LblPaymentStatus.Text = PaymentStatus(header.IsPaid);
                        LblPaidAmount.Text = header.PaidAmount.ToString();
                        LblPendingAmount.Text = (Convert.ToSingle(LblNetTotal.Text) - Convert.ToSingle(LblPaidAmount.Text)).ToString();
                        TxtRemarks.Text = header.Remarks;
                        if (header.Status == 3)
                        {
                            BtnGRNReturn.Enabled = true;
                        }
                    }
                }

                TotalDiscount = Info.GetDGVSum(DGVGRNList, 6);
                NetTotal = Info.GetDGVSum(DGVGRNList, 7);
                Returns = Info.GetDGVSum(DGVGRNReturned, 7);
                GrossTotal = Info.GetDGVSum(DGVGRNList, 5) + Returns;

                LblTotalDiscount.Text = TotalDiscount.ToString();
                LblReturns.Text = Returns.ToString();
                LblNetTotal.Text = NetTotal.ToString();
                LblGrossTotal.Text = GrossTotal.ToString();
            }
            else
            {
                TxtGRNNo.Text = string.Empty;
                TxtReference.Text = string.Empty;
                LblStatus.Text = "Ready";
                CmbProduct.Text = string.Empty;
                TxtQuantity.Text = string.Empty;
                TxtUnitCost.Text = string.Empty;
                TxtDiscount.Text = string.Empty;
                LblTotalDiscount.Text = "0";
                LblReturns.Text = "0";
                LblNetTotal.Text = "0";
                LblGrossTotal.Text = "0";
                LblPaymentStatus.Text = "0";
                TxtGivenAmount.Text = string.Empty;
                LblBalanceAmount.Text = "0";
            }
        }

        private string PaymentStatus(bool isPaid)
        {
            if (isPaid)
                return "Paid";
            else
                return "Not Paid";
        }

        private string Invoice_Status(int Status)
        {
            string CurrentStatus;
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

        private void LoadCmb()
        {
            using (BillingContext db = new BillingContext())
            {
                itemBindingSource.DataSource = db.Items.ToList();
                supplierBindingSource.DataSource = db.Suppliers.ToList();

                CmbBank.ValueMember = "BankId";
                CmbBank.DisplayMember = "BankName";
                CmbBank.DataSource = db.Banks.Where(c => !c.IsDeleted).ToList();

                CmbChooseCheques.ValueMember = "ChequeNo";
                CmbChooseCheques.DisplayMember = "ChequeNo";
                CmbChooseCheques.DataSource = db.Cheques.Where(c => !c.IsDeleted).ToList();

                CmbPaidBy.ValueMember = "CodeNumber";
                CmbPaidBy.DisplayMember = "Name";
                CmbPaidBy.DataSource = db.Suppliers.Where(c => !c.IsDeleted).ToList();
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void AddItem()
        {
            bool IsGrnExist;
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    string GrnNo = TxtGRNNo.Text.Trim();
                    var grn = (from gh in db.GRNHeaders.Where(c => c.GRN_No == GrnNo && c.Status > 1 || c.IsPaid) select new { gh.GRN_No }).ToList();
                    if (grn.Count > 0)
                    {
                        Info.Mes("This GRN No already completed, Please enter some other value");
                        IsGrnExist = true;
                    }
                    else
                    {
                        IsGrnExist = false;
                    }

                    string RefNo = TxtReference.Text.Trim();
                    var RefNum = (from gh in db.GRNHeaders.Where(c => c.ReferenceNo == RefNo && c.Status > 1 || c.IsPaid) select new { gh.ReferenceNo }).ToList();
                    if (RefNum.Count > 0)
                    {
                        Info.Mes("This Reference No already completed, Please enter some other value");
                        IsGrnExist = true;
                    }
                    else
                    {
                        IsGrnExist = false;
                    }
                }

                if (!IsGrnExist)
                {
                    using (BillingContext db = new BillingContext())
                    {
                        var emp = db.Employee.FirstOrDefault(c => c.EmployeeId == Info.CashierId && !c.IsDeleted);
                        var grn = db.GRNHeaders.FirstOrDefault(c => c.GRN_No == TxtGRNNo.Text.Trim());
                        if (Info.IsEmpty(TxtGRNNo) && Info.IsEmpty(TxtQuantity) && Info.IsEmpty(TxtUnitCost))
                        {
                            try
                            {
                                if (grn == null)
                                {
                                    GrnHeader header = new GrnHeader
                                    {
                                        ReferenceNo = TxtReference.Text.Trim(),
                                        GRN_No = TxtGRNNo.Text.Trim(),
                                        GRN_Date = DTPDate.Value.ToShortDateString(),
                                        Time = DateTime.Now.ToShortTimeString(),
                                        Supplier = (Supplier)CMBSupplier.SelectedItem,
                                        GrossTotal = 0,
                                        NetTotal = 0,
                                        TotalDiscout = 0,
                                        Employee = emp,
                                        Status = 1
                                    };

                                    if (db.Entry(header).State == EntityState.Detached)
                                        db.Set<GrnHeader>().Attach(header);
                                    header.CreatedDate = DateTime.Now;
                                    db.Entry(header).State = EntityState.Added;
                                    db.SaveChanges();
                                    GRN_Id = header.GRN_Id;
                                    GRN_Code = TxtGRNNo.Text.Trim();
                                }
                                else
                                {
                                    if(!grn.IsPaid && grn.Status == 1) 
                                    { 
                                        if (db.Entry(grn).State == EntityState.Detached)
                                            db.Set<GrnHeader>().Attach(grn);
                                        grn.UpdatedDate = DateTime.Now;
                                        db.Entry(grn).State = EntityState.Modified;
                                        db.SaveChanges();
                                        GRN_Id = grn.GRN_Id;
                                        GRN_Code = TxtGRNNo.Text.Trim();

                                        int ProductId = Convert.ToInt32(CmbProduct.SelectedValue.ToString());
                                        var result = db.GRNDetails.FirstOrDefault(b => b.GRN_Id == GRN_Id
                                                    && b.GRNCode == GRN_Code
                                                    && b.ProductId == ProductId);
                                        if (result != null)
                                        {
                                            result.Quantity += Convert.ToInt32(TxtQuantity.Text.Trim());
                                            result.UnitCost = Convert.ToSingle(TxtUnitCost.Text.Trim());
                                            result.GrossTotal = result.Quantity * result.UnitCost;
                                            if (!string.IsNullOrWhiteSpace(TxtDiscount.Text))
                                                result.Discount = Convert.ToSingle(TxtDiscount.Text.Trim());
                                            else
                                                result.Discount = 0;

                                            result.SubTotal = result.GrossTotal - result.Discount;
                                            if (db.Entry(result).State == EntityState.Detached)
                                                db.Set<GrnDetails>().Attach(result);
                                            result.UpdatedDate = DateTime.Now;
                                            db.Entry(result).State = EntityState.Modified;
                                            db.SaveChanges();
                                            GRNItemReset();
                                            if (result.GRN_Id != 0)
                                            {
                                                LoadDetails(GRN_Code);
                                            }
                                        }
                                        else
                                        {
                                            GrnDetails details = new GrnDetails
                                            {
                                                GRN_Id = GRN_Id,
                                                GRNCode = GRN_Code,
                                                ProductId = Convert.ToInt32(CmbProduct.SelectedValue.ToString()),
                                                UnitCost = Convert.ToSingle(TxtUnitCost.Text.Trim()),
                                                Quantity = Convert.ToInt32(TxtQuantity.Text.Trim()),
                                                GrossTotal = Convert.ToSingle(TxtUnitCost.Text.Trim()) * Convert.ToInt32(TxtQuantity.Text.Trim())
                                            };
                                            if (!string.IsNullOrWhiteSpace(TxtDiscount.Text))
                                                details.Discount = Convert.ToSingle(TxtDiscount.Text.Trim());
                                            else
                                                details.Discount = 0;

                                            details.SubTotal = (details.UnitCost * Convert.ToSingle(details.Quantity)) - details.Discount;

                                            try
                                            {
                                                if (db.Entry(details).State == EntityState.Detached)
                                                    db.Set<GrnDetails>().Attach(details);
                                                details.CreatedDate = DateTime.Now;
                                                db.Entry(details).State = EntityState.Added;
                                                db.SaveChanges();
                                                GRNItemReset();
                                                if (details.GRN_Id != 0)
                                                {
                                                    LoadDetails(GRN_Code);
                                                }
                                            }
                                            catch (System.Data.Entity.Core.EntityException ex)
                                            {
                                                ExportJson.Add(ex);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Info.Mes("This Grn Invoice for given Invoice No Already Completed");
                                        LoadDetails(TxtGRNNo.Text.Trim());
                                    }
                                    Calculate();
                                }
                            }
                            catch (Exception ex)
                            {
                                ExportJson.Add(ex);
                                throw;
                            }
                        }
                        else
                        {
                            Info.Required();
                        }
                    }
                }
                else
                {
                    Info.Mes("This GRN Invoice seems to be entered already! please check and try again");
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Info.Mes(ex.Message);
            }
        }

        private void GRNItemReset()
        {
            CmbProduct.Text = string.Empty;
            TxtQuantity.Text = "0";
            TxtUnitCost.Text = "0";
            TxtDiscount.Text = "0";
        }

        private void Calculate()
        {
            TotalDiscount = Info.GetDGVSum(DGVGRNList, 6);
            NetTotal = Info.GetDGVSum(DGVGRNList, 7);
            Returns = Info.GetDGVSum(DGVGRNReturned, 7);
            GrossTotal = Info.GetDGVSum(DGVGRNList, 5) + Returns;

            LblTotalDiscount.Text = TotalDiscount.ToString();
            LblNetTotal.Text = NetTotal.ToString();
            float grossTotal = TotalDiscount + NetTotal;
            LblReturns.Text = Returns.ToString();
            LblGrossTotal.Text = grossTotal.ToString();
            BtnDelete.Enabled = true;
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
                    header.Remarks = TxtRemarks.Text.Trim();
                    if (db.Entry(header).State == EntityState.Detached)
                        db.Set<GrnHeader>().Attach(header);
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVGRNList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected Item?", "Confirmation delete", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (BillingContext db = new BillingContext())
                        {
                            var Result = db.GRNDetails.FirstOrDefault(c => c.GRNCode == GRN_Code && c.GRN_Id == GRN_Id);
                            if (db.Entry(Result).State == EntityState.Detached)
                                db.Set<GrnDetails>().Attach(Result);
                            db.Entry(Result).State = EntityState.Deleted;
                            db.SaveChanges();
                            LoadDetails(GRN_Code);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to approve this invoice?", "Confirmation Approve", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (BillingContext db = new BillingContext())
                {
                    foreach (GrnDetails details in db.GRNDetails)
                    {
                        if (details.GRNCode == GRN_Code && details.IsDeleted)
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
                    Result.Remarks = TxtRemarks.Text.Trim();
                    Result.Status = 3;
                    if (db.Entry(Result).State == EntityState.Detached)
                        db.Set<GrnHeader>().Attach(Result);
                    Result.UpdatedDate = DateTime.Now;
                    db.Entry(Result).State = EntityState.Modified;
                    db.SaveChanges();
                    LoadDetails(GRN_Code);
                }
            }
        }

        private void TxtChequeNo_Enter(object sender, EventArgs e)
        {
            Info.PlaceHolder(TxtChequeNo);
        }

        private void TxtChequeNo_Leave(object sender, EventArgs e)
        {
            Info.Leave(TxtChequeNo, "Cheque No");
        }

        private void TxtPayeeName_Enter(object sender, EventArgs e)
        {
            Info.PlaceHolder(TxtPayeeName);
        }

        private void TxtPayeeName_Leave(object sender, EventArgs e)
        {
            Info.Leave(TxtPayeeName, "Payee Name");
        }

        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            Info.PlaceHolder(TxtAmount);
        }

        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            Info.Leave(TxtAmount, "Amount");
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
                            PaidBy = CmbPaidBy.SelectedValue.ToString(),
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
                ExportJson.Add(ex);
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
                    TxtGivenAmount.Enabled = true;
                if (CmbPaymentOptions.SelectedItem.ToString() == "Cheque")
                {
                    LayoutCheque.Visible = true;
                    BtnAddCheque.Visible = true;
                    CmbChooseCheques.Visible = true;
                }
                else
                {
                    LayoutCheque.Visible = false;
                    BtnAddCheque.Visible = false;
                    CmbChooseCheques.Visible = false;
                }
            }
        }

        private void TxtGivenAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GRNPayment(TxtGRNNo.Text.Trim());
            }
        }

        private void GRNPayment(string GRNNo)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var grn = db.GRNHeaders.FirstOrDefault(c => !c.IsDeleted && c.GRN_No == GRNNo);
                    if (grn != null)
                    {
                        if (grn.Status == 3)
                        {
                            if (!grn.IsPaid)
                            {
                                if (BalanceValue < 0)
                                {
                                    grn.PaymentType = CmbPaymentOptions.Text;
                                    if (CmbChooseCheques.Text == "Cheque")
                                        grn.ChequeNo = CmbChooseCheques.Text;
                                    grn.PaidAmount += Convert.ToSingle(LblNetTotal.Text);
                                    grn.PendingAmount = 0;
                                    grn.IsPaid = true;
                                    if (db.Entry(grn).State == EntityState.Detached)
                                        db.Set<GrnHeader>().Attach(grn);
                                    grn.UpdatedDate = DateTime.Now;
                                    db.Entry(grn).State = EntityState.Modified;
                                    db.SaveChanges();
                                    Info.Mes("Payment Completed Successfully");
                                }
                                else
                                {
                                    grn.PaymentType = CmbPaymentOptions.Text;
                                    if (CmbChooseCheques.Text == "Cheque")
                                        grn.ChequeNo = CmbChooseCheques.Text;
                                    if (PaidValue + GivenValue > grn.NetTotal)
                                        grn.PaidAmount = grn.NetTotal;
                                    else
                                        grn.PaidAmount += GivenValue;
                                    grn.PendingAmount = grn.NetTotal - grn.PaidAmount;
                                    if (db.Entry(grn).State == EntityState.Detached)
                                        db.Set<GrnHeader>().Attach(grn);
                                    grn.UpdatedDate = DateTime.Now;
                                    db.Entry(grn).State = EntityState.Modified;
                                    db.SaveChanges();
                                    Info.Mes("Payment Added, Pending Amount is " + BalanceValue.ToString());
                                }
                            }
                            else
                            {
                                Info.Mes("This Invoice has been paid already");
                            }
                        }
                        else
                        {
                            Info.Mes("Cannot Pay before approve the Invoice");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
            finally
            {
                LoadDetails(TxtGRNNo.Text.Trim());
            }
        }

        private void BtnGRNReturn_Click(object sender, EventArgs e)
        {
            BtnAddToReturn.Visible = true;
            if (Info.IsEmpty(TxtGRNNo))
                LoadDetails(TxtGRNNo.Text.Trim());
            foreach (RowStyle rs in DGVPanel.RowStyles)
            {
                rs.SizeType = SizeType.Percent;
                rs.Height = 50;
            }
        }

        private void BtnAddToReturn_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (DGVGRNList.SelectedRows.Count > 0)
                    {
                        string GRNNo = TxtGRNNo.Text.Trim();
                        var GrnItem = db.GRNDetails.FirstOrDefault(c => c.GRN_Id == GRN_Id && c.GRNCode == GRNNo && !c.IsDeleted);
                        if (GrnItem != null)
                        {
                            GrnItem.IsReturned = true;
                            int id = GrnItem.ProductId;
                            int Qty = GrnItem.Quantity;
                            var item = db.Items.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
                            item.StockQty -= Qty;

                            if (db.Entry(item).State == EntityState.Detached)
                                db.Set<Item>().Attach(item);
                            item.UpdatedDate = DateTime.Now;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();

                            if (db.Entry(GrnItem).State == EntityState.Detached)
                                db.Set<GrnDetails>().Attach(GrnItem);
                            GrnItem.UpdatedDate = DateTime.Now;
                            db.Entry(GrnItem).State = EntityState.Modified;
                            db.SaveChanges();
                            LoadDetails(GRNNo);
                        }

                        var header = db.GRNHeaders.FirstOrDefault(c => c.GRN_No == GRNNo && !c.IsDeleted);

                        header.GrossTotal = NetTotal + TotalDiscount + Returns;
                        header.TotalDiscout = TotalDiscount;
                        header.NetTotal = NetTotal;
                        header.Returns = Convert.ToSingle(LblReturns.Text);

                        if (db.Entry(header).State == EntityState.Detached)
                            db.Set<GrnHeader>().Attach(header);
                        header.UpdatedDate = DateTime.Now;
                        db.Entry(header).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadDetails(GRN_Code);
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Info.Mes(ex.Message);
            }
        }

        private void DGVGRNList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVGRNList.SelectedRows.Count > 0)
            {
                GRN_Code = TxtGRNNo.Text.Trim();
                GRN_Id = Convert.ToInt32(DGVGRNList.SelectedRows[0].Cells[0].Value + string.Empty);
                CmbProduct.Text = DGVGRNList.SelectedRows[0].Cells[2].Value + string.Empty;
                TxtUnitCost.Text = DGVGRNList.SelectedRows[0].Cells[3].Value + string.Empty;
                TxtQuantity.Text = DGVGRNList.SelectedRows[0].Cells[4].Value + string.Empty;
                TxtDiscount.Text = DGVGRNList.SelectedRows[0].Cells[6].Value + string.Empty;
            }
        }

        private void DGVGRNReturned_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVGRNReturned.SelectedRows.Count > 0)
            {
                BtnRemoveReturn.Visible = true;
            }
        }

        private void BtnRemoveReturn_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (DGVGRNReturned.SelectedRows.Count > 0)
                    {
                        string GRNNo = TxtGRNNo.Text.Trim();
                        var GrnItem = db.GRNDetails.FirstOrDefault(c => c.GRNCode == GRNNo && c.GRN_Id == GRN_Id && !c.IsDeleted);
                        if (GrnItem != null)
                        {
                            GrnItem.IsReturned = false;
                            int id = GrnItem.ProductId;
                            int Qty = GrnItem.Quantity;
                            var item = db.Items.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
                            item.StockQty += Qty;
                            if (db.Entry(item).State == EntityState.Detached)
                                db.Set<Item>().Attach(item);
                            item.UpdatedDate = DateTime.Now;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();

                            if (db.Entry(GrnItem).State == EntityState.Detached)
                                db.Set<GrnDetails>().Attach(GrnItem);
                            GrnItem.UpdatedDate = DateTime.Now;
                            db.Entry(GrnItem).State = EntityState.Modified;
                            db.SaveChanges();
                        }

                        var header = db.GRNHeaders.FirstOrDefault(c => c.GRN_No.Equals(GRNNo) && !c.IsDeleted);
                        header.TotalDiscout = Convert.ToSingle(LblTotalDiscount.Text);
                        header.NetTotal = Convert.ToSingle(LblNetTotal.Text);
                        header.Returns = Convert.ToSingle(LblReturns.Text);
                        header.GrossTotal = header.TotalDiscout + header.NetTotal + header.Returns;
                        if (db.Entry(header).State == EntityState.Detached)
                            db.Set<GrnHeader>().Attach(header);
                        header.UpdatedDate = DateTime.Now;
                        db.Entry(header).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadDetails(GRN_Code);
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Info.Mes(ex.Message);
            }
        }

        private void BtnPrintGRN_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = db.Settings.Take(1).FirstOrDefault();
                GRNAsPDF(dtGRN, dtGRNReturn, TxtGRNNo.Text.Trim(), data.GRNPath);
            }
        }

        public void GRNAsPDF(DataTable dt, DataTable dt2, string RptNo, string Path)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    //Retrieve Data
                    var data = db.BusinessModels.FirstOrDefault(c => c.IsActive && !c.IsDeleted);
                    var header = db.GRNHeaders.FirstOrDefault(c => c.GRN_No == RptNo && !c.IsDeleted);
                    var supplier = db.Suppliers.FirstOrDefault(c => c.CodeNumber == CmbPaidBy.SelectedValue.ToString() && !c.IsDeleted);
                    var employee = db.Employee.FirstOrDefault(c => c.EmployeeId == Info.CashierId && !c.IsDeleted);

                    float returnsNetValue = Info.GetDGVSum(DGVGRNReturned, 7);
                    float grnNetValue = Info.GetDGVSum(DGVGRNList, 7);
                    float grnGrossValue = Info.GetDGVSum(DGVGRNReturned, 5) + Info.GetDGVSum(DGVGRNList, 5);

                    //Load Path
                    if (!Path.EndsWith(@"\"))
                        Path += @"\";
                    string fileName = Path + Info.RandomString(4) + ".pdf";

                    //Create PDF Document
                    PdfWriter writer = new PdfWriter(fileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf, iText.Kernel.Geom.PageSize.A4.Rotate());

                    //Assign Data and Page Designing
                    string Name = data.Name;
                    string Address = data.Address + ",   " + data.Contact;
                    Table bus = new Table(5, false);
                    string spc = ".                                        .";
                    bus.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(12).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(Name)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(12).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.JUSTIFIED).Add(new Paragraph(spc)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(Address)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(12).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.JUSTIFIED).Add(new Paragraph(spc)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("GRN Invoice No: " + RptNo)));

                    LineSeparator ls = new LineSeparator(new DashedLine()).SetFontSize(8);
                    Paragraph space = new Paragraph("       ");

                    Table RptDetails = new Table(7, false);
                    RptDetails.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Supplier Info: " + supplier.Name)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Payment Type")));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.PaymentType)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Date : ")));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.GRN_Date)));

                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(supplier.Address)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Payment Status")));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(PaymentStatus(header.IsPaid))));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Time : ")));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Time.ToString())));

                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(supplier.Contact)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Pending Amount")));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.PendingAmount.ToString())));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Received By : ")));
                    RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(employee.EmployeeName)));

                    Table table = new Table(13, false);
                    string gap = ".        .";
                    table.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Code")));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Item Name")));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Unit Price")));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Quantity")));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Gross Total")));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Discount")));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                    table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Net Total")));

                    foreach (DataRow d in dt.Rows)
                    {
                        table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(d[1].ToString())));
                        table.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                        table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(d[2].ToString())));
                        table.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                        table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(d[3].ToString())));
                        table.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                        table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(d[4].ToString())));
                        table.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                        table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[5].ToString())));
                        table.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                        table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[6].ToString())));
                        table.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                        table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[7].ToString())));
                    }
                    string devider = "_________________________________________";
                    table.AddFooterCell(new Cell(1, 9).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));

                    table.AddFooterCell(new Cell(1, 9).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(Info.GetDGVSum(DGVGRNList, 5).ToString())));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(Info.GetDGVSum(DGVGRNList, 6).ToString())));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(Info.GetDGVSum(DGVGRNList, 7).ToString())));

                    Table tblReturn = new Table(13, false);
                    tblReturn.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    Table ReturnTitle = new Table(13, false);
                    ReturnTitle.SetHorizontalAlignment(HorizontalAlignment.CENTER);

                    if (dt2.Rows.Count == 0)
                    {
                        table.AddFooterCell(new Cell(1, 12).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Paid Amount")));
                        table.AddFooterCell(new Cell(1, 13).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(header.NetTotal.ToString())));
                    }
                    else
                    {
                        ReturnTitle.AddCell(new Cell(1, 7).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("GRN Returns")));

                        tblReturn.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Code")));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Item Name")));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Unit Price")));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Quantity")));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Gross Total")));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Discount")));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.WHITE).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                        tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Net Total")));

                        foreach (DataRow d in dt2.Rows)
                        {
                            tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(d[1].ToString())));
                            tblReturn.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                            tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(d[2].ToString())));
                            tblReturn.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                            tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(d[3].ToString())));
                            tblReturn.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                            tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(d[4].ToString())));
                            tblReturn.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                            tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[5].ToString())));
                            tblReturn.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));

                            tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[6].ToString())));
                            tblReturn.AddCell(new Cell(1, 1).SetFontColor(ColorConstants.WHITE).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(gap)));
                            tblReturn.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[7].ToString())));
                        }

                        tblReturn.AddFooterCell(new Cell(1, 9).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));
                        tblReturn.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));
                        tblReturn.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));

                        tblReturn.AddFooterCell(new Cell(1, 9).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(Info.GetDGVSum(DGVGRNReturned, 5).ToString())));
                        tblReturn.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(Info.GetDGVSum(DGVGRNReturned, 6).ToString())));
                        tblReturn.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(Info.GetDGVSum(DGVGRNReturned, 7).ToString())));

                        tblReturn.AddFooterCell(new Cell(1, 12).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Returned Net Value")));
                        tblReturn.AddFooterCell(new Cell(1, 13).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(returnsNetValue.ToString())));

                        tblReturn.AddFooterCell(new Cell(2, 12).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("GRN Gross Value")));
                        tblReturn.AddFooterCell(new Cell(2, 13).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(grnGrossValue.ToString())));

                        tblReturn.AddFooterCell(new Cell(3, 12).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("GRN Net Value")));
                        tblReturn.AddFooterCell(new Cell(3, 13).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(grnNetValue.ToString())));

                    }
                    StringBuilder footerGap1 = new StringBuilder();
                    for (int i = 0; i < 240; i++) footerGap1.Append(" ");
                    StringBuilder footerGap2 = new StringBuilder();
                    for (int i = 0; i < 80; i++) footerGap2.Append(" ");
                    string footer1 = "........................................" + footerGap1 + "...........................";
                    string footer2 = "     Supplier Signature" + footerGap2 + "Please Note : Credit balance should be settled within 30 days" + footerGap2 + "Checked by";
                    iText.Kernel.Geom.PageSize ps = pdf.GetDefaultPageSize();
                    Paragraph foot1 = new Paragraph(footer1).SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin() + 20, ps.GetWidth() - document.GetLeftMargin() - document.GetRightMargin()).SetFontSize(8);
                    Paragraph foot2 = new Paragraph(footer2).SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin() + 10, ps.GetWidth() - document.GetLeftMargin() - document.GetRightMargin()).SetFontSize(8);

                    document.SetMargins(10, 40, 10, 40);
                    document.Add(bus);
                    document.Add(space);
                    document.Add(RptDetails);
                    document.Add(ls);
                    document.Add(table);
                    document.Add(ReturnTitle);
                    document.Add(tblReturn);
                    document.Add(foot1);
                    document.Add(foot2);
                    document.Close();
                    Info.StartProcess(fileName);
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Info.Mes(ex.Message);
            }
        }

        private void TxtGivenAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (Info.IsEmpty(TxtGivenAmount))
            {
                NetTotal = Convert.ToSingle(LblNetTotal.Text.Trim());
                PaidValue = Convert.ToSingle(LblPaidAmount.Text.Trim());
                GivenValue = Convert.ToSingle(TxtGivenAmount.Text.Trim());
                PendingValue = Convert.ToSingle(LblPendingAmount.Text.Trim());
                BalanceValue = PendingValue - GivenValue;
                LblBalanceAmount.Text = BalanceValue.ToString();
            }
        }

        private void BtnNewInvoice_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            LoadDetails(string.Empty);
        }

        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddItem();
            }
        }

        private void BaseLayout_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void tableLayoutPanel4_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVGRNList_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVGRNReturned_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void tableLayoutPanel5_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void TxtPayeeName_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtPayeeName);
        }

        private void CmbProduct_KeyUp(object sender, KeyEventArgs e)
        {
            Info.CmbToCapital(CmbProduct);
        }

        private void TxtRemarks_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtRemarks);
        }

        private void TxtReference_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtReference);
        }

        private void TxtGRNNo_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtGRNNo);
        }

        private void CmbChooseCheques_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ChkNo = CmbChooseCheques.Text;
            using (BillingContext db = new BillingContext()) 
            {
                var data = db.Cheques.FirstOrDefault(c => c.ChequeNo == ChkNo && !c.IsDeleted);
                if (data != null)
                {
                    TxtChequeNo.Text = ChkNo;
                    TxtPayeeName.Text = data.PayeeName;
                    TxtAmount.Text = data.Amount.ToString();
                    DTChequeDueDate.Value = Convert.ToDateTime(data.DueDate);
                    CmbPaidBy.Text = data.PaidBy;
                }
            }
        }

        private void TxtGRNNo_Leave(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                string GrnNo = TxtGRNNo.Text.Trim();
                var grn = (from gh in db.GRNHeaders.Where(c => c.GRN_No == GrnNo && c.Status > 1 || c.IsPaid) select new { gh.GRN_No }).ToList();
                if (grn.Count > 0)
                {
                    label8.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label8.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void TxtReference_Leave(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                string RefNo = TxtReference.Text.Trim();
                var RefNum = (from gh in db.GRNHeaders.Where(c => c.ReferenceNo == RefNo && c.Status > 1 || c.IsPaid) select new { gh.ReferenceNo }).ToList();
                if (RefNum.Count > 0)
                {
                    label3.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label3.ForeColor = System.Drawing.Color.White;
                }
            }
        }
    }
}