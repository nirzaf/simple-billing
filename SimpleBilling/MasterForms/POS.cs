using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using SimpleBilling.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;

namespace SimpleBilling.MasterForms
{
    public partial class POS : Form
    {
        private int ItemId;
        private string BarCode;
        private float UnitPrice;
        private float Qty;
        private float Total;
        private float NetTotal;
        private float Discount;
        private readonly int CashierId = Info.CashierId;
        private readonly string PaymentType = string.Empty;
        private readonly string ReceiptNo;
        private float ReceiptTotalDiscount;
        private float ReceiptSubTotal;
        private float ReceiptNetTotal;
        private float PaidValue;
        private float PendingValue;
        private float GivenAmount;
        private float BalanceAmount;
        private int ReceiptStatus;
        private DataTable rptBody;

        public POS(string Receipt)
        {
            InitializeComponent();
            ReceiptNo = Receipt;
            DGVLoad(ReceiptNo);
            TxtGivenAmount.Enabled = false;
        }

        private void POS_Load(object sender, EventArgs e)
        {
            SystemTimer_Tick(sender, e);
            FormLoad();
        }

        private void FormLoad()
        {
            BtnAddCheque.Visible = false;
            CmbChooseCheques.Visible = false;
            BtnPrint.Enabled = false;
            BtnPrintQuotation.Enabled = false;
            ChkVehicle.Enabled = false;
            TxtCurrentMileage.Enabled = false;
            TxtNextServiceDue.Enabled = false;
            DGVLoad(ReceiptNo);
            PrintAndVoid();
            TxtCustomer.Focus();
            HideCheque();
            HideAddCustomer();
            CustomersAutocomplete();
            BarCodeAutocomplete();
            ProductCodeAutocomplete();
        }

        private void LoabCMB()
        {
            using (BillingContext db = new BillingContext())
            {
                CmbPaidBy.ValueMember = "CustomerId";
                CmbPaidBy.DisplayMember = "Name";
                CmbPaidBy.DataSource = db.Customers.Where(c => !c.IsDeleted).ToList();

                CmbBank.ValueMember = "BankId";
                CmbBank.DisplayMember = "BankName";
                CmbBank.DataSource = db.Banks.Where(c => !c.IsDeleted).ToList();

                CmbChooseCheques.ValueMember = "ChequeNo";
                CmbChooseCheques.DisplayMember = "ChequeNo";
                CmbChooseCheques.DataSource = db.Cheques.Where(c => !c.IsDeleted).ToList();
            }
        }

        private void PrintAndVoid()
        {
            if (ReceiptStatus != 2 || LblReceiptStatus.Text != "Completed")
            {
                BtnPrint.Enabled = false;
                BtnVoid.Enabled = false;
                CRUDPanel.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (ReceiptStatus == 2 || LblReceiptStatus.Text == "Completed")
            {
                BtnPrint.Enabled = true;
                BtnVoid.Enabled = true;
                CRUDPanel.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void Reset()
        {
            try
            {
                FormLoad();
                TxtCustomer.Text = string.Empty;
                TxtBarCode.Text = string.Empty;
                TxtProductCode.Text = string.Empty;
                TxtUnitPrice.Text = string.Empty;
                TxtQuantity.Text = string.Empty;
                TxtDiscount.Text = string.Empty;
                TxtSubTotal.Text = string.Empty;
                TxtNetTotal.Text = string.Empty;
                LblReceiptStatus.Text = "Idle";
                LblSubTotal.Text = "0";
                LblNetTotal.Text = "0";
                LblBalanceAmount.Text = "0";
                TxtGivenAmount.Text = string.Empty;
                LblTotalDiscount.Text = "0";
                LblPaidAmount.Text = "0";
                LblPendingAmount.Text = "0";
                LblPaymentStatus.Text = "Payment Status";
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
            finally
            {
                LblReceiptNo.Text = GenReceiptNo();
                DGVReceiptBody.DataSource = null;
                PrintAndVoid();
            }
        }

        private void DGVLoad(string ReceiptNo)
        {
            try
            {
                if (!string.IsNullOrEmpty(ReceiptNo))
                {
                    using (BillingContext db = new BillingContext())
                    {
                        customersBindingSource.DataSource = db.Customers.ToList();
                        itemBindingSource.DataSource = db.Items.ToList();
                        var RptBody = (from body in db.ReceiptBodies.Where(c => !c.IsDeleted && c.ReceiptNo == ReceiptNo)
                                       join item in db.Items
                                       on body.ProductId equals item.Id
                                       select new
                                       {
                                           item.Id,
                                           item.Code,
                                           item.PrintableName,
                                           body.UnitPrice,
                                           body.Quantity,
                                           body.SubTotal,
                                           body.Discount,
                                           body.NetTotal
                                       }).ToList();
                        DGVReceiptBody.DataSource = RptBody;
                        rptBody = Info.ToDataTable(RptBody);

                        var RptHeader = (from header in db.ReceiptHeaders.Where(c => !c.IsDeleted && c.ReceiptNo == ReceiptNo && !c.IsQuotation)
                                         join cashier in db.Employee.Where(c => !c.IsDeleted)
                                         on header.Cashier equals cashier.EmployeeId
                                         join customer in db.Customers.Where(c => !c.IsDeleted)
                                         on header.CustomerId equals customer.CustomerId
                                         select new
                                         {
                                             header.ReceiptNo,
                                             header.Date,
                                             header.Time,
                                             header.TotalDiscount,
                                             header.SubTotal,
                                             header.NetTotal,
                                             header.PaidAmount,
                                             header.Balance,
                                             header.Status,
                                             header.VehicleNumber,
                                             header.PaymentType,
                                             header.IsPaid,
                                             header.PendingValue,
                                             header.PaidValue,
                                             header.IsQuotation,
                                             Cashier = cashier.EmployeeName,
                                             header.Remarks,
                                             customer.Name,
                                             customer.Address,
                                             customer.Contact
                                         }).ToList();

                        var Mileage = db.MileTracking.FirstOrDefault(c => !c.IsDeleted && c.ReceiptNo == ReceiptNo);
                        if (Mileage != null)
                        {
                            TxtCurrentMileage.Text = Mileage.Mileage.ToString();
                            TxtNextServiceDue.Text = Mileage.NextServiceDue.ToString();
                        }
                        foreach (var a in RptHeader)
                        {
                            PaidValue = a.PaidValue;
                            PendingValue = a.PendingValue;
                            LblPaidAmount.Text = PaidValue.ToString();
                            LblPendingAmount.Text = PendingValue.ToString();
                            LblCashier.Text = a.Cashier;
                            LblBalanceAmount.Text = a.Balance.ToString();
                            TxtGivenAmount.Text = a.PaidAmount.ToString();
                            ReceiptStatus = a.Status;
                            LblReceiptStatus.Text = GetReceiptStatus(a.Status);
                            LblReceiptNo.Text = a.ReceiptNo;
                            TxtRemarks.Text = a.Remarks;
                            TxtCustomer.Text = a.Contact;

                            LblPaymentStatus.Text = GetPaymentStatus(a.IsPaid);
                            CmbPaymentOption.Text = a.PaymentType;
                            if (!string.IsNullOrWhiteSpace(a.VehicleNumber))
                                CmbVehicles.Text = a.VehicleNumber;
                        }

                        TotalCalculator();
                    }
                }
                else
                {
                    using (BillingContext db = new BillingContext())
                    {
                        customersBindingSource.DataSource = db.Customers.ToList();
                        itemBindingSource.DataSource = db.Items.ToList();
                        var cs = db.Employee.FirstOrDefault(c => c.EmployeeId == Info.CashierId);
                        LblCashier.Text = cs.EmployeeName;
                    }
                    LblReceiptNo.Text = GenReceiptNo();
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private string GetPaymentStatus(bool status)
        {
            if (status)
                return "Paid";
            else
                return "Pending";
        }

        private string GenReceiptNo()
        {
            using (BillingContext db = new BillingContext())
            {
                var data = db.ReceiptHeaders.Select(c => c.ReceiptNo).ToList();
                List<int> intList = new List<int>();
                if (data.Count > 0)
                {
                    int RptNo;
                    foreach (var i in data)
                    {
                        Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                        Match result = re.Match(i);
                        string num = result.Groups[2].Value;
                        intList.Add(Convert.ToInt32(num));
                    }
                    RptNo = intList.Max();
                    RptNo++;
                    return ("CW" + RptNo.ToString());
                }
                else
                {
                    return ("CW" + "1000");
                }
            }
        }

        private string GetReceiptStatus(int Status)
        {
            if (Status == 1)
            {
                CRUDPanel.Enabled = true;
                BtnDelete.Enabled = true;
                BtnPrint.Enabled = false;
                BtnPrintQuotation.Enabled = false;
                BtnVoid.Enabled = false;
                return "On Process";
            }
            if (Status == 2)
            {
                CRUDPanel.Enabled = false;
                BtnDelete.Enabled = false;
                BtnPrint.Enabled = true;
                BtnPrintQuotation.Enabled = false;
                BtnVoid.Enabled = true;
                return "Completed";
            }
            if (Status == 0)
            {
                CRUDPanel.Enabled = false;
                BtnDelete.Enabled = false;
                BtnPrint.Enabled = true;
                BtnPrintQuotation.Enabled = false;
                BtnVoid.Enabled = true;
                return "Canceled";
            }
            else
            {
                CRUDPanel.Enabled = false;
                BtnDelete.Enabled = false;
                BtnPrint.Enabled = false;
                BtnPrintQuotation.Enabled = true;
                BtnVoid.Enabled = false;
                return "Quotation";
            }
        }

        private void SystemTimer_Tick(object sender, EventArgs e)
        {
            LblDate.Text = DateTime.Now.ToShortDateString();
            LblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void TxtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            LoadCustomer();
        }

        private void CmbAddItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemDetailsById();
        }

        private void GetItemDetailsById()
        {
            if (CmbAddItem.SelectedValue != null)
            {
                ItemId = Convert.ToInt32(CmbAddItem.SelectedValue.ToString());
                using (BillingContext db = new BillingContext())
                {
                    var data = db.Items.FirstOrDefault(c => c.Id == ItemId);
                    if (data != null)
                    {
                        TxtUnitPrice.Text = data.UnitCost.ToString();
                        TxtBarCode.Text = data.Barcode;
                        TxtProductCode.Text = data.Code;
                        LblStockOnHand.Text = data.StockQty.ToString();
                        if (data.StockQty < 10)
                            LblStockOnHand.ForeColor = System.Drawing.Color.Red;
                        else
                            LblStockOnHand.ForeColor = System.Drawing.Color.Lime;
                        TxtDiscount.Text = "0";
                    }
                    try
                    {
                        if (Info.IsEmpty(TxtUnitPrice) && Info.IsEmpty(TxtQuantity))
                        {
                            UnitPrice = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                            Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                            Total = UnitPrice * Qty;
                            TxtSubTotal.Text = Total.ToString();
                            CalculateItemPrices();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExportJson.Add(ex);
                    }
                }
            }
        }

        private void GetItemDetailsByBarCode()
        {
            if (!string.IsNullOrWhiteSpace(TxtBarCode.Text.Trim()))
            {
                BarCode = TxtBarCode.Text.Trim();
                using (BillingContext db = new BillingContext())
                {
                    var data = db.Items.FirstOrDefault(c => c.Barcode == BarCode);
                    if (data != null)
                    {
                        TxtUnitPrice.Text = data.SellingPrice.ToString();
                        CmbAddItem.Text = data.ItemName;
                        TxtProductCode.Text = data.Code;
                        TxtDiscount.Text = "0";
                    }
                }
            }
        }

        private void CmbAddItem_Enter(object sender, EventArgs e)
        {
            GetItemDetailsById();
        }

        private void CmbAddItem_Leave(object sender, EventArgs e)
        {
            GetItemDetailsById();
        }

        private void TxtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            GetItemDetailsByBarCode();
        }

        private void TxtBarCode_Enter(object sender, EventArgs e)
        {
            GetItemDetailsByBarCode();
        }

        private string AddReceiptHeader()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var customer = db.Customers.FirstOrDefault(c => !c.IsDeleted && c.Contact == TxtCustomer.Text.Trim());
                    ReceiptHeader header = new ReceiptHeader
                    {
                        ReceiptNo = LblReceiptNo.Text.ToString(),
                        Date = LblDate.Text,
                        Time = LblTime.Text,
                        Cashier = CashierId,
                        TotalDiscount = 0,
                        SubTotal = 0,
                        NetTotal = 0,
                        PaymentType = PaymentType,
                        PaidAmount = 0,
                        Balance = 0,
                        Status = 1,
                        CreatedDate = DateTime.Now
                    };
                    if (customer != null)
                        header.CustomerId = customer.CustomerId;
                    if (ChkVehicle.Checked)
                        header.VehicleNumber = CmbVehicles.SelectedValue.ToString();

                    var result = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == header.ReceiptNo && !c.IsDeleted);

                    if (result == null)
                    {
                        if (db.Entry(header).State == EntityState.Detached)
                            db.Set<ReceiptHeader>().Attach(header);
                        db.Entry(header).State = EntityState.Added;
                        db.SaveChanges();
                        return header.ReceiptNo;
                    }
                    else
                    {
                        result.ReceiptNo = LblReceiptNo.Text.ToString();
                        result.Date = LblDate.Text;
                        result.Time = LblTime.Text;
                        result.TotalDiscount = Convert.ToSingle(LblTotalDiscount.Text);
                        result.SubTotal = Convert.ToSingle(LblSubTotal.Text);
                        result.NetTotal = Convert.ToSingle(LblNetTotal.Text);
                        result.UpdatedDate = DateTime.Now;
                        if (db.Entry(result).State == EntityState.Detached)
                            db.Set<ReceiptHeader>().Attach(result);
                        db.Entry(result).State = EntityState.Modified;
                        db.SaveChanges();
                        return result.ReceiptNo;
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                return ex.Message;
            }
        }

        private void LoadDGV(string ReceiptNo)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from body in db.ReceiptBodies.Where(c => c.ReceiptNo == ReceiptNo && !c.IsDeleted)
                            join item in db.Items
                            on body.ProductId equals item.Id
                            select new
                            {
                                item.Id,
                                item.Code,
                                item.PrintableName,
                                body.UnitPrice,
                                body.Quantity,
                                body.SubTotal,
                                body.Discount,
                                body.NetTotal
                            }).ToList();
                DGVReceiptBody.DataSource = data;
            }
        }

        private void AddReceiptBody()
        {
            string RptNo = AddReceiptHeader();
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    ReceiptBody body = new ReceiptBody
                    {
                        ReceiptNo = RptNo,
                        ProductId = ItemId,
                        UnitPrice = UnitPrice,
                        Quantity = Convert.ToInt32(Qty),
                        Discount = Discount,
                        SubTotal = Total,
                        NetTotal = NetTotal
                    };
                    var Result = db.ReceiptBodies.FirstOrDefault(c => c.ReceiptNo == RptNo && c.ProductId == ItemId);
                    if (Result == null)
                    {
                        if (db.Entry(body).State == EntityState.Detached)
                            db.Set<ReceiptBody>().Attach(body);
                        db.Entry(body).State = EntityState.Added;
                    }
                    else
                    {
                        if (Info.IsEmpty(TxtDiscount) && Info.IsEmpty(TxtQuantity)
                            && Info.IsEmpty(TxtSubTotal) && Info.IsEmpty(TxtNetTotal))
                        {
                            Result.Quantity += Convert.ToInt32(TxtQuantity.Text.Trim());
                            Result.Discount += Convert.ToSingle(TxtDiscount.Text.Trim());
                            Result.SubTotal += Convert.ToSingle(TxtSubTotal.Text.Trim());
                            Result.NetTotal += Convert.ToSingle(TxtNetTotal.Text.Trim());
                        }
                        if (db.Entry(Result).State == EntityState.Detached)
                            db.Set<ReceiptBody>().Attach(Result);
                        db.Entry(Result).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    ReceiptStatus = 1;
                    LblReceiptStatus.Text = GetReceiptStatus(ReceiptStatus);
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
            }
            finally
            {
                LoadDGV(RptNo);
                TotalCalculator();
            }
        }

        private void TxtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AddReceiptBody();
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
            }
        }

        private void TotalCalculator()
        {
            ReceiptTotalDiscount = Info.GetDGVSum(DGVReceiptBody, 6);
            ReceiptNetTotal = Info.GetDGVSum(DGVReceiptBody, 7);

            if (Info.IsEmpty(TxtOverallDiscount))
                ReceiptTotalDiscount += Convert.ToSingle(TxtOverallDiscount.Text.Trim());

            LblTotalDiscount.Text = ReceiptTotalDiscount.ToString();
            LblNetTotal.Text = ReceiptNetTotal.ToString();
            ReceiptSubTotal = ReceiptTotalDiscount + ReceiptNetTotal;
            LblSubTotal.Text = ReceiptSubTotal.ToString();
        }

        private void InsertMileage()
        {
            using (BillingContext db = new BillingContext())
            {
                var mlt = db.MileTracking.FirstOrDefault(c => c.ReceiptNo == LblReceiptNo.Text.Trim() && !c.IsDeleted);
                if (mlt == null)
                {
                    MileageTracking mt = new MileageTracking
                    {
                        ReceiptNo = LblReceiptNo.Text.Trim(),
                        VehicleNo = CmbVehicles.SelectedValue.ToString(),
                        Mileage = Convert.ToInt32(TxtCurrentMileage.Text.Trim()),
                        NextServiceDue = Convert.ToInt32(TxtNextServiceDue.Text.Trim()),
                        CreatedDate = DateTime.Now
                    };
                    if (db.Entry(mt).State == EntityState.Detached)
                        db.Set<MileageTracking>().Attach(mt);
                    db.Entry(mt).State = EntityState.Added;
                    db.SaveChanges();
                }
                else
                {
                    mlt.VehicleNo = CmbVehicles.Text;
                    mlt.ReceiptNo = LblReceiptNo.Text.Trim();
                    mlt.Mileage = Convert.ToInt32(TxtCurrentMileage.Text.Trim());
                    mlt.NextServiceDue = Convert.ToInt32(TxtNextServiceDue.Text.Trim());
                    mlt.UpdatedDate = DateTime.Now;
                    if (db.Entry(mlt).State == EntityState.Detached)
                        db.Set<MileageTracking>().Attach(mlt);
                    db.Entry(mlt).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void CompleteReceipt(int Type)
        {
            try
            {
                if (Info.IsEmpty(TxtGivenAmount) || Type == 2)
                {
                    if (!Info.IsEmpty(TxtGivenAmount))
                        TxtGivenAmount.Text = "0";
                    GivenAmount = Convert.ToSingle(TxtGivenAmount.Text.Trim());
                    BalanceAmount = GivenAmount - ReceiptNetTotal;
                    using (BillingContext db = new BillingContext())
                    {
                        var Result = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == LblReceiptNo.Text && !c.IsDeleted);
                        if (Result != null)
                        {
                            if (!Result.IsPaid && !Result.IsQuotation)
                            {
                                if (!string.IsNullOrWhiteSpace(Result.VehicleNumber) && Info.IsEmpty(TxtCurrentMileage) && Info.IsEmpty(TxtNextServiceDue))
                                {
                                    InsertMileage();
                                }
                                Result.NetTotal = ReceiptNetTotal;
                                Result.TotalDiscount = ReceiptTotalDiscount;
                                Result.SubTotal = ReceiptSubTotal;

                                if (Type == 1)
                                {
                                    if (Result.PaymentType == "Cheque")
                                    {
                                        Result.ChequeNo = CmbChooseCheques.Text;
                                    }
                                    if ((Result.PaidValue + GivenAmount) > ReceiptNetTotal)
                                        Result.PaidValue = ReceiptNetTotal;
                                    else
                                        Result.PaidValue += GivenAmount;
                                    Result.Balance = BalanceAmount;
                                    Result.PendingValue = PendingValue;
                                    Result.PaymentType = GetPaymentType();
                                    Result.Status = 2;
                                    Result.IsQuotation = false;
                                    if (PendingValue == 0)
                                        Result.IsPaid = true;
                                    Result.PaidAmount = GivenAmount;
                                }
                                if (Type == 2)
                                {
                                    Result.Status = 3;
                                    Result.IsQuotation = true;
                                }
                                Result.UpdatedDate = DateTime.Now;
                                Result.Remarks = TxtRemarks.Text.Trim();
                                if (db.Entry(Result).State == EntityState.Detached)
                                    db.Set<ReceiptHeader>().Attach(Result);
                                db.Entry(Result).State = EntityState.Modified;
                                db.SaveChanges();
                                ReceiptStatus = Result.Status;
                                LblReceiptStatus.Text = GetReceiptStatus(Result.Status);
                                if (Type == 1)
                                {
                                    ReduceStock(true);
                                    MessageBox.Show($"Receipt {LblReceiptNo.Text} Created Successfully");
                                    BtnPrint.Enabled = true;
                                }
                                else if (Type == 2)
                                {
                                    MessageBox.Show($"Quotation {LblReceiptNo.Text} Created Successfully");
                                    BtnPrintQuotation.Enabled = true;
                                }
                            }
                            else
                            {
                                Info.Mes("This receipt had been paid already");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
            }
            finally
            {
                DGVLoad(LblReceiptNo.Text.Trim());
                PrintAndVoid();
            }
        }

        private void ReduceStock(bool value)
        {
            foreach (DataGridViewRow dgv in DGVReceiptBody.Rows)
            {
                using (BillingContext db = new BillingContext())
                {
                    int itemId = Convert.ToInt32(dgv.Cells[0].Value);
                    int quantity = Convert.ToInt32(dgv.Cells[4].Value);
                    var Result = db.Items.FirstOrDefault(c => c.Id == itemId);
                    if (Result != null)
                    {
                        if (value)
                        {
                            Result.StockQty -= quantity;
                        }
                        if (!value)
                        {
                            Result.StockQty += quantity;
                        }
                        if (db.Entry(Result).State == EntityState.Detached)
                            db.Set<Item>().Attach(Result);
                        db.Entry(Result).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }

        private string GetPaymentType()
        {
            if (!string.IsNullOrWhiteSpace(CmbPaymentOption.Text))
                return CmbPaymentOption.Text.Trim();
            else
                return string.Empty;
        }

        private void Exp(Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }

        private void TxtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateItemPrices();
        }

        private void CalculateItemPrices()
        {
            try
            {
                if (Info.IsEmpty(TxtDiscount) && Info.IsEmpty(TxtQuantity)
                    && Info.IsEmpty(TxtUnitPrice))
                {
                    UnitPrice = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                    Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                    Total = UnitPrice * Qty;
                    TxtSubTotal.Text = Total.ToString();
                    Discount = Convert.ToSingle(TxtDiscount.Text.Trim());
                    NetTotal = Total - Discount;
                    TxtNetTotal.Text = NetTotal.ToString();
                }
                else if (Info.IsEmpty(TxtQuantity) && Info.IsEmpty(TxtUnitPrice))
                {
                    UnitPrice = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                    Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                    Total = UnitPrice * Qty;
                    TxtSubTotal.Text = Total.ToString();
                    TxtNetTotal.Text = Total.ToString();
                    TxtSubTotal.Text = Total.ToString();
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex); Info.Mes(ex.Message);
            }
        }

        private void TxtGivenAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtGivenAmount.Text.Length > 0)
            {
                GivenAmount = Convert.ToSingle(TxtGivenAmount.Text.Trim());
                ReceiptNetTotal = Convert.ToSingle(LblNetTotal.Text);
                ReceiptSubTotal = Convert.ToSingle(LblSubTotal.Text);
                ReceiptTotalDiscount = Convert.ToSingle(LblTotalDiscount.Text);

                BalanceAmount = GivenAmount - ReceiptNetTotal;
                LblBalanceAmount.Text = BalanceAmount.ToString();
                PendingValue = ReceiptNetTotal - GivenAmount;
                if (PendingValue > 0)
                {
                    LblPendingAmount.Text = PendingValue.ToString();
                }
                else
                {
                    PendingValue = 0;
                    LblPendingAmount.Text = PendingValue.ToString();
                }
                PaidValue = Convert.ToSingle(TxtGivenAmount.Text.Trim());
            }
        }

        private void TxtGivenAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CompleteReceipt(1);
            }
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            Void();
        }

        private void CancelReceipt()
        {
            using (BillingContext db = new BillingContext())
            {
                var result = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == ReceiptNo && !c.IsDeleted && c.Status == 2);
                if (result != null)
                {
                    result.Status = 0;
                    if (db.Entry(result).State == EntityState.Detached)
                        db.Set<ReceiptHeader>().Attach(result);
                    db.Entry(result).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        private void Void()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to void this receipt?", "Confirmation Void", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CancelReceipt();
                    ReduceStock(false);
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
            }
            finally
            {
                LblReceiptStatus.Text = "Voided";
                ReceiptStatus = 0;
            }
        }

        private void TxtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Info.IsDecimal(e, TxtUnitPrice);
        }

        private void BtnLoadReceipt_Click(object sender, EventArgs e)
        {
            LoadReceipt receiptLoader = new LoadReceipt();
            receiptLoader.Show();
            Hide();
        }

        private void TxtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Info.IsEmpty(TxtUnitPrice) && Info.IsEmpty(TxtQuantity))
                {
                    UnitPrice = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                    Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                    Total = UnitPrice * Qty;
                    TxtSubTotal.Text = Total.ToString();
                    CalculateItemPrices();
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
            }
        }

        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AddReceiptBody();
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
            }
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Info.IsInt(e);
        }

        private void TxtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Info.IsDecimal(e, TxtDiscount);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DGVReceiptBody.SelectedRows.Count > 0)
            {
                int Id = Convert.ToInt32(DGVReceiptBody.SelectedRows[0].Cells[0].Value + string.Empty);
                string RptNo = LblReceiptNo.Text.Trim();
                using (BillingContext db = new BillingContext())
                {
                    var Item = db.ReceiptBodies.FirstOrDefault(c => c.ProductId == Id && c.ReceiptNo == RptNo && !c.IsDeleted);
                    if (Item != null)
                    {
                        Item.IsDeleted = true;
                        if (db.Entry(Item).State == EntityState.Detached)
                            db.Set<ReceiptBody>().Attach(Item);
                        db.Entry(Item).State = EntityState.Modified;
                        db.SaveChanges();
                        DGVLoad(RptNo);
                    }
                }
            }
            else
            {
                Info.Mes("Please Select an item to delete");
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                try
                {
                    var path = db.Settings.Take(1).FirstOrDefault();
                    if (path != null)
                    {
                        if (path.DefaultPath == null)
                        {
                            return;
                        }
                        SalesReceiptAsPDF(rptBody, LblReceiptNo.Text, path.DefaultPath);
                    }
                }
                catch (Exception ex)
                {
                    Info.Mes(ex.InnerException.Message);
                }
            }
        }

        private void CmbPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CmbPaymentOption.Text))
            {
                TxtGivenAmount.Enabled = true;
                if (CmbPaymentOption.SelectedItem.ToString() == "Cheque")
                {
                    ShowCheque();
                    BtnAddCheque.Visible = true;
                    CmbChooseCheques.Visible = true;
                    LoabCMB();
                }
                else
                {
                    HideCheque();
                }
            }
        }

        private void ShowCheque()
        {
            TxtChequeNo.Visible = true;
            TxtPayeeName.Visible = true;
            TxtAmount.Visible = true;
            DTDueDate.Visible = true;
            CmbPaidBy.Visible = true;
            CmbBank.Visible = true;
            BtnAddCheque.Visible = true;
        }

        private void HideCheque()
        {
            TxtChequeNo.Visible = false;
            TxtPayeeName.Visible = false;
            TxtAmount.Visible = false;
            DTDueDate.Visible = false;
            CmbPaidBy.Visible = false;
            CmbBank.Visible = false;
            BtnAddCheque.Visible = false;
        }

        private void ToolTip()
        {
            ToolTipHelp.SetToolTip(ChkVehicle, "Include this vehicle in receipt");
        }

        private void ChkVehicle_MouseHover(object sender, EventArgs e)
        {
            ToolTip();
        }

        private void BtnNewReceipt_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void SalesReceiptAsPDF(DataTable dt, string RptNo, string Path)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.BusinessModels.FirstOrDefault(c => c.IsActive && !c.IsDeleted);
                    var header = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == RptNo && !c.IsDeleted);
                    var customerDetails = db.Customers.FirstOrDefault(c => c.Contact == TxtCustomer.Text.Trim() && !c.IsDeleted);
                    var mlt = (from ml in db.MileTracking.Where(c => !c.IsDeleted && c.ReceiptNo == RptNo)
                               join vl in db.Vehicles.Where(c => !c.IsDeleted)
                               on ml.VehicleNo equals vl.VehicleNo
                               join hr in db.ReceiptHeaders.Where(c => !c.IsDeleted)
                               on ml.ReceiptNo equals hr.ReceiptNo
                               select new
                               {
                                   ml.Mileage,
                                   vl.ServiceMileageDue,
                                   hr.ReceiptNo,
                                   vl.VehicleNo
                               }).ToList();
                    if (!Path.EndsWith(@"\"))
                        Path += @"\";
                    string fileName = Path + Info.RandomString(4) + ".pdf";
                    PdfWriter writer = new PdfWriter(fileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf, iText.Kernel.Geom.PageSize.A5.Rotate());
                    document.SetMargins(10, 40, 10, 40);
                    string sb = data.Name;
                    string Address = data.Address + ",   " + data.Contact;
                    Table bus = new Table(3, false);
                    string spc = ".                                      .";
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(12).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(sb)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(12).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.JUSTIFIED).Add(new Paragraph(spc)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(Address)));
                    bus.AddCell(new Cell(1, 3).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Receipt No: " + LblReceiptNo.Text)));

                    LineSeparator ls = new LineSeparator(new DashedLine()).SetFontSize(8);
                    Paragraph space = new Paragraph("    ");
                    Paragraph billingTo = new Paragraph("Billing To: ").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                    document.Add(bus);
                    Table RptDetails = new Table(7, false);

                    foreach (var ml in mlt)
                    {
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Name)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Vehicle Number :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(ml.VehicleNo)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Date : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Date)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Address)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Current Mileage :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(ml.Mileage.ToString() + " km")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Time : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Time)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Contact)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Next Service Due :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph((ml.ServiceMileageDue + ml.Mileage + " km").ToString())));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Cashier : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(LblCashier.Text)));
                    }

                    if (mlt.Count == 0)
                    {
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Name)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Vehicle Number :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("N/A")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Date : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Date)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Address)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Current Mileage :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("N/A")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Time : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Time)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Contact)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Next Service Due :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("N/A")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Cashier : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(LblCashier.Text)));
                    }

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

                    document.Add(space);
                    string devider = "_________________________________________";
                    table.AddFooterCell(new Cell(1, 9).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));

                    table.AddFooterCell(new Cell(1, 9).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblSubTotal.Text)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblTotalDiscount.Text)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblNetTotal.Text)));

                    table.AddFooterCell(new Cell(1, 12).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Paid Amount")));
                    table.AddFooterCell(new Cell(1, 13).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(header.PaidValue.ToString())));

                    table.AddFooterCell(new Cell(2, 12).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Balance Amount")));
                    table.AddFooterCell(new Cell(2, 13).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(header.Balance.ToString())));

                    table.AddFooterCell(new Cell(2, 12).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Pending Amount")));
                    table.AddFooterCell(new Cell(2, 13).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(header.PendingValue.ToString())));

                    string footer1 = "........................................                                                                                                                                                                ...........................";
                    string footer2 = "     Customer Signature                                Please Note : Credit balance should be settled within 30 days                                          Checked by";
                    iText.Kernel.Geom.PageSize ps = pdf.GetDefaultPageSize();
                    Paragraph foot1 = new Paragraph(footer1).SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin() + 20, ps.GetWidth() - document.GetLeftMargin() - document.GetRightMargin()).SetFontSize(8);
                    Paragraph foot2 = new Paragraph(footer2).SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin() + 10, ps.GetWidth() - document.GetLeftMargin() - document.GetRightMargin()).SetFontSize(8);

                    document.Add(billingTo);
                    document.Add(RptDetails);
                    document.Add(ls);
                    document.Add(table);
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

        private void ChkVehicle_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkVehicle.Checked)
            {
                TxtCurrentMileage.Enabled = true;
                TxtNextServiceDue.Enabled = true;
            }
            else
            {
                TxtCurrentMileage.Enabled = false;
                TxtNextServiceDue.Enabled = false;
            }
        }

        private void TxtCurrentMileage_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtCurrentMileage.Text.Length > 0)
            {
                int cm = Convert.ToInt32(TxtCurrentMileage.Text.Trim());
                using (BillingContext db = new BillingContext())
                {
                    var data = db.Vehicles.FirstOrDefault(c => c.VehicleNo == CmbVehicles.Text.Trim());
                    int nsd = data.ServiceMileageDue;
                    TxtNextServiceDue.Text = (cm + nsd).ToString();
                }
            }
        }

        private void TxtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && LblCustomer.Text == "Customer")
            {
                ShowAddCustomer();
                TxtName.Focus();
                TxtContact.Text = TxtCustomer.Text.Trim();
            }
        }

        private void TxtChequeNumber_TextChanged(object sender, EventArgs e)
        {
            ManageCheques mc = new ManageCheques();
            mc.ShowDialog();
        }

        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddCustomer();
            }
        }

        private void AddCustomer()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (Info.IsEmpty(TxtName) && Info.IsEmpty(TxtContact) && Info.IsEmpty(TxtAddress))
                    {
                        Customers cu = new Customers
                        {
                            Name = TxtName.Text.Trim(),
                            Contact = TxtContact.Text.Trim(),
                            Email = TxtEmail.Text.Trim(),
                            Address = TxtAddress.Text.Trim(),
                            CreatedDate = DateTime.Today
                        };

                        if (db.Entry(cu).State == EntityState.Detached)
                            db.Set<Customers>().Attach(cu);
                        db.Entry(cu).State = EntityState.Added;
                        db.SaveChanges();
                        Info.Mes("Customer Added Successfully");
                        TxtCustomer.Text = cu.Contact;
                        HideAddCustomer();
                        TxtCustomer.Focus();
                    }
                    else
                    {
                        Info.Required();
                    }
                }

            }
            catch (Exception ex)
            {
                ExportJson.Add(ex); Info.Mes(ex.Message);
            }
        }

        private void HideAddCustomer()
        {
            TxtName.Visible = false;
            TxtContact.Visible = false;
            TxtEmail.Visible = false;
            TxtAddress.Visible = false;
            TxtCustomer.Focus();
        }

        private void ShowAddCustomer()
        {
            TxtName.Visible = true;
            TxtContact.Visible = true;
            TxtEmail.Visible = true;
            TxtAddress.Visible = true;
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            Info.PlaceHolder(TxtName);
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            Info.Leave(TxtName, "Customer Name");
        }

        private void TxtContact_Enter(object sender, EventArgs e)
        {
            Info.PlaceHolder(TxtContact);
        }

        private void TxtContact_Leave(object sender, EventArgs e)
        {
            Info.Leave(TxtContact, "Contact No");
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            Info.PlaceHolder(TxtEmail);
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            Info.Leave(TxtEmail, "Email");
        }

        private void TxtAddress_Enter(object sender, EventArgs e)
        {
            Info.PlaceHolder(TxtAddress);
        }

        private void TxtAddress_Leave(object sender, EventArgs e)
        {
            Info.Leave(TxtAddress, "Address");
        }

        private void TxtChequeNo_Enter(object sender, EventArgs e)
        {
            Info.PlaceHolder(TxtChequeNo);
        }

        private void TxtChequeNo_Leave(object sender, EventArgs e)
        {
            Info.Leave(TxtChequeNo, "Cheque Number");
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
                            DueDate = DTDueDate.Value.ToShortDateString(),
                            PaidBy = CmbPaidBy.SelectedValue.ToString(),
                            Bank = Convert.ToInt32(CmbBank.SelectedValue.ToString()),
                            CreatedDate = DateTime.Today
                        };
                        if (db.Entry(ch).State == EntityState.Detached)
                            db.Set<Cheque>().Attach(ch);
                        db.Entry(ch).State = EntityState.Added;
                        db.SaveChanges();
                        LoabCMB();
                        HideCheque();
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
                ExportJson.Add(ex); Info.Mes(ex.Message);
            }
        }

        private void CmbChooseCheques_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                string ChequeNo = CmbChooseCheques.SelectedValue.ToString();
                var data = db.Cheques.FirstOrDefault(c => c.ChequeNo == ChequeNo && !c.IsDeleted);
                if (data != null)
                {
                    TxtGivenAmount.Text = data.Amount.ToString();
                    TxtGivenAmount.Focus();
                }
            }
        }

        private void TxtGivenAmount_Enter(object sender, EventArgs e)
        {
            if (TxtGivenAmount.Text.Length > 0)
            {
                GivenAmount = Convert.ToSingle(TxtGivenAmount.Text.Trim());
                BalanceAmount = GivenAmount - Convert.ToSingle(LblNetTotal.Text);
                LblBalanceAmount.Text = BalanceAmount.ToString();
            }
        }

        private void BtnAddToPending_Click(object sender, EventArgs e)
        {
            try
            {
                string RcptNo = LblReceiptNo.Text;
                string VehicleNo = CmbVehicles.Text;
                using (BillingContext db = new BillingContext())
                {
                    PendingJob pj = new PendingJob
                    {
                        ReceiptNo = RcptNo,
                        VehicleNumber = VehicleNo,
                        Date = LblDate.Text.Trim(),
                        CreatedDate = DateTime.Today
                    };
                    if (db.Entry(pj).State == EntityState.Detached)
                        db.Set<PendingJob>().Attach(pj);
                    db.Entry(pj).State = EntityState.Added;
                    db.SaveChanges();

                    var data = db.PendingJobs.Where(s => s.ReceiptNo == RcptNo && s.VehicleNumber == VehicleNo && s.Date == LblDate.Text.Trim() && !s.IsDeleted).Select(c => c.VehicleNumber + "   " + c.ReceiptNo).ToList();
                    foreach (var item in data)
                    {
                        LstBoxPendingJobs.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private void LstBoxPendingJobs_DoubleClick(object sender, EventArgs e)
        {
            string RcptNo = LstBoxPendingJobs.SelectedItem.ToString();
            string RptNo = RcptNo.Split(' ').Last();
            SystemTimer_Tick(sender, e);
            DGVLoad(RptNo);
            PrintAndVoid();
            TxtCustomer.Focus();
            HideCheque();
            ChkVehicle.Enabled = false;
            TxtCurrentMileage.Enabled = false;
            TxtNextServiceDue.Enabled = false;
            HideAddCustomer();
            BtnAddCheque.Visible = false;
            CmbChooseCheques.Visible = false;
        }

        private void BtnSaveQuotation_Click(object sender, EventArgs e)
        {
            CompleteReceipt(2);
        }

        private void TxtOverallDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtOverallDiscount.Text.Length > 0)
            {
                TotalCalculator();
            }
        }

        private void TxtOverallDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Info.IsDecimal(e, TxtOverallDiscount);
        }

        private void TxtOverallDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CompleteReceipt(1);
            }
        }

        private void TxtGivenAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Info.IsDecimal(e, TxtGivenAmount);
        }

        private void CustomersAutocomplete()
        {
            AutoCompleteStringCollection Customers = new AutoCompleteStringCollection();

            using (BillingContext db = new BillingContext())
            {
                var data = db.Customers.Select(c => c.Contact).ToList();
                Customers.AddRange(data.ToArray());
                TxtCustomer.AutoCompleteCustomSource = Customers;
            }
        }

        private void BarCodeAutocomplete()
        {
            AutoCompleteStringCollection Barcode = new AutoCompleteStringCollection();

            using (BillingContext db = new BillingContext())
            {
                var data = db.Items.Select(c => c.Barcode).ToList();
                Barcode.AddRange(data.ToArray());
                TxtBarCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                TxtBarCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                TxtBarCode.AutoCompleteCustomSource = Barcode;
            }
        }

        private void ProductCodeAutocomplete()
        {
            AutoCompleteStringCollection Code = new AutoCompleteStringCollection();

            using (BillingContext db = new BillingContext())
            {
                var data = db.Items.Select(c => c.Code).ToList();
                Code.AddRange(data.ToArray());
                TxtProductCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                TxtProductCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                TxtProductCode.AutoCompleteCustomSource = Code;
            }
        }

        private void CRUDPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DownLayout_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void tableLayoutPanel5_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void tableLayoutPanel3_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void BtnPrintQuotation_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                var path = db.Settings.Take(1).FirstOrDefault();
                SalesQuotationAsPDF(rptBody, LblReceiptNo.Text, path.QuotationPath);
            }
        }

        public void SalesQuotationAsPDF(DataTable dt, string RptNo, string Path)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.BusinessModels.FirstOrDefault(c => c.IsActive && !c.IsDeleted);
                    var header = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == RptNo && c.IsQuotation && !c.IsDeleted);
                    var customerDetails = db.Customers.FirstOrDefault(c => c.Contact == TxtCustomer.Text.Trim() && !c.IsDeleted);
                    var mlt = (from ml in db.MileTracking.Where(c => !c.IsDeleted && c.ReceiptNo == RptNo)
                               join vl in db.Vehicles.Where(c => !c.IsDeleted)
                               on ml.VehicleNo equals vl.VehicleNo
                               join hr in db.ReceiptHeaders.Where(c => !c.IsDeleted)
                               on ml.ReceiptNo equals hr.ReceiptNo
                               select new
                               {
                                   ml.Mileage,
                                   vl.ServiceMileageDue,
                                   hr.ReceiptNo,
                                   vl.VehicleNo
                               }).ToList();
                    if (!Path.EndsWith(@"\"))
                        Path += @"\";
                    string fileName = Path + Info.RandomString(4) + ".pdf";
                    PdfWriter writer = new PdfWriter(fileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf, iText.Kernel.Geom.PageSize.A5.Rotate());
                    document.SetMargins(10, 40, 10, 40);
                    string sb = data.Name;
                    string Address = data.Address + ",   " + data.Contact;
                    Table bus = new Table(3, false);
                    string spc = ".                                      .";
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(12).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(sb)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(12).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.JUSTIFIED).Add(new Paragraph(spc)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(Address)));
                    bus.AddCell(new Cell(1, 3).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Quotation No: " + LblReceiptNo.Text)));

                    LineSeparator ls = new LineSeparator(new DashedLine()).SetFontSize(8);
                    Paragraph space = new Paragraph("    ");
                    Paragraph billingTo = new Paragraph("Quotation To: ").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                    document.Add(bus);
                    Table RptDetails = new Table(7, false);

                    foreach (var ml in mlt)
                    {
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Name)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Vehicle Number :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(ml.VehicleNo)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Date : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Date)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Address)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Current Mileage :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(ml.Mileage.ToString() + " km")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Time : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Time)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Contact)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Next Service Due :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph((ml.ServiceMileageDue + ml.Mileage + " km").ToString())));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Cashier : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(LblCashier.Text)));
                    }

                    if (mlt.Count == 0)
                    {
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Name)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Vehicle Number :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("N/A")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Date : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Date)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Address)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Current Mileage :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("N/A")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Time : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Time)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Contact)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Next Service Due :")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("N/A")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetFontColor(ColorConstants.WHITE, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(spc)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Cashier : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(LblCashier.Text)));
                    }

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

                    document.Add(space);
                    string devider = "_________________________________________";
                    table.AddFooterCell(new Cell(1, 9).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(2).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(devider)));

                    table.AddFooterCell(new Cell(1, 9).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblSubTotal.Text)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblTotalDiscount.Text)));
                    table.AddFooterCell(new Cell(1, 2).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblNetTotal.Text)));


                    string footer1 = "........................................                                                                                                                                                                ...........................";
                    string footer2 = "     Customer Signature                                    Please Note : Quotation is only valid for up to 7 days                                               Checked by";
                    iText.Kernel.Geom.PageSize ps = pdf.GetDefaultPageSize();
                    Paragraph foot1 = new Paragraph(footer1).SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin() + 20, ps.GetWidth() - document.GetLeftMargin() - document.GetRightMargin()).SetFontSize(8);
                    Paragraph foot2 = new Paragraph(footer2).SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin() + 10, ps.GetWidth() - document.GetLeftMargin() - document.GetRightMargin()).SetFontSize(8);

                    document.Add(billingTo);
                    document.Add(RptDetails);
                    document.Add(ls);
                    document.Add(table);
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

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Info.IsDecimal(e, TxtAmount);
        }

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddCustomer();
            }
        }

        private void LoadCustomer()
        {
            if (!string.IsNullOrWhiteSpace(TxtCustomer.Text.Trim()))
            {
                string MobileNumber = TxtCustomer.Text.Trim();
                using (BillingContext db = new BillingContext())
                {
                    var data = db.Customers.FirstOrDefault(c => c.Contact == MobileNumber);
                    if (data != null)
                    {
                        LblCustomer.Text = data.Name;

                        var vehicles = db.Vehicles.Where(c => c.OwnerId == data.CustomerId).ToList();
                        if (vehicles != null)
                        {
                            CmbVehicles.Enabled = true;
                            CmbVehicles.ValueMember = "VehicleNo";
                            CmbVehicles.DisplayMember = "VehicleNo";
                            CmbVehicles.DataSource = vehicles;
                            ChkVehicle.Enabled = true;
                        }
                        else
                        {
                            ChkVehicle.Enabled = false;
                            CmbVehicles.Enabled = false;
                            ChkVehicle.Checked = false;
                        }
                    }
                    else
                    {
                        LblCustomer.Text = "Customer";
                        CmbVehicles.Enabled = false;
                    }
                }
            }
        }

        private void TxtCustomer_Leave(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}