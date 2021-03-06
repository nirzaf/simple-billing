﻿using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
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
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;

namespace SimpleBilling.MasterForms
{
    public partial class POS : Form
    {
        private int ItemId;
        private int CustomerId;
        private int ReceiptStatus;
        private int CashierId = Info.CashierId;

        private string PaymentType = string.Empty;
        private string ReceiptNo;

        private float UnitPrice;
        private float Qty;
        private float Total;
        private float NetTotal;
        private float Discount;
        private float ReceiptTotalDiscount;
        private float ReceiptSubTotal;
        private float ReceiptNetTotal;
        private float PaidValue;
        private float PendingValue;
        private float GivenAmount;
        private float BalanceAmount;
        private float TotalReturns;
        private float PendingAfterReturn;

        private DataTable rptBody;
        private DataTable rptReturned;

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
            try
            {
                BtnAddCheque.Visible = false;
                CmbChooseCheques.Visible = false;
                BtnPrint.Enabled = false;
                BtnPrintQuotation.Enabled = false;
                ChkVehicle.Enabled = false;
                TxtCurrentMileage.Enabled = false;
                TxtNextServiceDue.Enabled = false;
                BtnRemoveReturn.Visible = false;
                BtnAddtoReturn.Visible = false;
                BtnReturn.Enabled = false;
                DGVLoad(ReceiptNo);
                PrintAndVoid();
                TxtCustomer.Focus();
                HideCheque();
                HideAddCustomer();
                CustomersAutocomplete();
                ProductCodeAutocomplete();
                PayeeAutocomplete();
                VehicleNumberAutoComplete();
                LoadDGVLayout();
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }

        private void LoadDGVLayout()
        {
            int count = 0;
            try
            {
                foreach (RowStyle rs in RptBodyLayout.RowStyles)
                {
                    count++;
                    if (DGVReturned.Rows.Count == 0)
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
                        BtnAddtoReturn.Visible = false;
                        BtnRemoveReturn.Visible = false;
                    }
                    else
                    {
                        foreach (RowStyle s in RptBodyLayout.RowStyles)
                        {
                            s.SizeType = SizeType.Percent;
                            s.Height = 50;
                        }
                        BtnAddtoReturn.Visible = true;
                        BtnRemoveReturn.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }

        private void LoabCMB()
        {
            try
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
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
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
                TxtProductCode.Text = string.Empty;
                TxtUnitPrice.Text = string.Empty;
                TxtQuantity.Text = string.Empty;
                TxtDiscount.Text = string.Empty;
                TxtSubTotal.Text = string.Empty;
                TxtNetTotal.Text = string.Empty;
                TxtCurrentMileage.Text = string.Empty;
                TxtNextServiceDue.Text = string.Empty;
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
                DGVReceiptBody.Refresh();
                DGVReturned.DataSource = null;
                DGVReturned.Refresh();
                using (BillingContext db = new BillingContext())
                {
                    customersBindingSource.DataSource = db.Customers.ToList();
                    itemBindingSource.DataSource = db.Items.ToList();
                    var cs = db.Employee.FirstOrDefault(c => c.EmployeeId == Info.CashierId);
                    LblCashier.Text = cs.EmployeeName;
                }
                PrintAndVoid();
                LoadDGVLayout();
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
                        var RptBody = (from body in db.ReceiptBodies.Where(c => c.ReceiptNo == ReceiptNo && !c.IsReturned && !c.IsDeleted)
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

                        var Returned = (from body in db.ReceiptBodies.Where(c => c.ReceiptNo == ReceiptNo && c.IsReturned && !c.IsDeleted)
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
                        DGVReturned.DataSource = Returned;
                        rptReturned = Info.ToDataTable(Returned);

                        if (Returned.Count > 0)
                        {
                            foreach (RowStyle rs in RptBodyLayout.RowStyles)
                            {
                                rs.SizeType = SizeType.Percent;
                                rs.Height = 50;
                            }
                            BtnRemoveReturn.Visible = true;
                        }
                        else
                        {
                            int count = 0;
                            foreach (RowStyle rs in RptBodyLayout.RowStyles)
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
                            if(ReceiptStatus == 2)
                            {
                                BtnReturn.Enabled = true;
                            }
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
            try
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
                            if (Info.IsAllDigits(num))
                            {
                                intList.Add(Convert.ToInt32(num));
                            }
                        }
                        if (intList.Count > 0)
                            RptNo = intList.Max();
                        else
                            RptNo = 1000; 
                        RptNo++;
                        return ("CW" + RptNo.ToString());
                    }
                    else
                    {
                        return ("CW" + "1000");
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
                return string.Empty;
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

        private void LoadCustomer()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(TxtCustomer.Text.Trim()))
                {
                    string MobileNumber = TxtCustomer.Text.Trim();
                    using (BillingContext db = new BillingContext())
                    {
                        var data = db.Customers.FirstOrDefault(c => c.Contact == MobileNumber && !c.IsDeleted);
                        if (data != null)
                        {
                            LblCustomer.Text = data.Name;

                            var vehicles = db.Vehicles.Where(c => c.OwnerId == data.CustomerId && !c.IsDeleted).ToList();
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
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
           
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
                    var stock = db.Settings.Take(1).FirstOrDefault();
                    if (data != null)
                    {
                        TxtUnitPrice.Text = data.SellingPrice.ToString();
                        TxtProductCode.Text = data.Code;
                        LblStockOnHand.Text = data.StockQty.ToString();
                        if (data.StockQty < stock.SetMinValue)
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

        private void CmbAddItem_Enter(object sender, EventArgs e)
        {
            GetItemDetailsById();
        }

        private void CmbAddItem_Leave(object sender, EventArgs e)
        {
            GetItemDetailsById();
        }

        private string AddReceiptHeader()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
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
                        CustomerId = CustomerId,
                        Balance = 0,
                        Status = 1,
                        CreatedDate = DateTime.Now
                    };

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
            try
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
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
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
            try
            {
                ReceiptTotalDiscount = Info.GetDGVSum(DGVReceiptBody, 6);
                ReceiptNetTotal = Info.GetDGVSum(DGVReceiptBody, 7);
                if (DGVReturned.Rows.Count > 0)
                {
                    TotalReturns = Info.GetDGVSum(DGVReturned, 7);
                }

                if (Info.IsEmpty(TxtOverallDiscount))
                {
                    ReceiptTotalDiscount += Convert.ToSingle(TxtOverallDiscount.Text.Trim());
                    ReceiptNetTotal -= ReceiptTotalDiscount;
                }

                LblTotalDiscount.Text = ReceiptTotalDiscount.ToString();
                LblNetTotal.Text = ReceiptNetTotal.ToString();
                ReceiptSubTotal = ReceiptTotalDiscount + ReceiptNetTotal;
                LblSubTotal.Text = ReceiptSubTotal.ToString();
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }

        private void InsertMileage()
        {
            try
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
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
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

                                if (ChkVehicle.Checked)
                                    Result.VehicleNumber = CmbVehicles.SelectedValue.ToString();
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
            try
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
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }            
        }

        private void IncreaseStock()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    int itemId = Convert.ToInt32(DGVReceiptBody.SelectedRows[0].Cells[0].Value + string.Empty);
                    int quantity = Convert.ToInt32(DGVReceiptBody.SelectedRows[0].Cells[3].Value + string.Empty);
                    var Result = db.Items.FirstOrDefault(c => c.Id == itemId);
                    if (Result != null)
                    {
                        Result.StockQty += quantity;
                        if (db.Entry(Result).State == EntityState.Detached)
                            db.Set<Item>().Attach(Result);
                        db.Entry(Result).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }

        private void DecreaseStock()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    int itemId = Convert.ToInt32(DGVReturned.SelectedRows[0].Cells[0].Value + string.Empty);
                    int quantity = Convert.ToInt32(DGVReturned.SelectedRows[0].Cells[3].Value + string.Empty);
                    var Result = db.Items.FirstOrDefault(c => c.Id == itemId);
                    if (Result != null)
                    {
                        Result.StockQty -= quantity;
                        if (db.Entry(Result).State == EntityState.Detached)
                            db.Set<Item>().Attach(Result);
                        db.Entry(Result).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
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
            try
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
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
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
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var result = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == ReceiptNo && !c.IsDeleted && c.Status == 2);
                    var item = db.ReceiptBodies.Where(c => c.ReceiptNo == ReceiptNo && !c.IsReturned && !c.IsDeleted).ToList();
                    foreach (var i in item)
                    {
                        i.IsReturned = true;
                        i.UpdatedDate = DateTime.Today;
                        if (db.Entry(i).State == EntityState.Detached)
                            db.Set<ReceiptBody>().Attach(i);
                        db.Entry(i).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    if (result != null)
                    {
                        result.Status = 0;
                        result.UpdatedDate = DateTime.Today;
                        if (db.Entry(result).State == EntityState.Detached)
                            db.Set<ReceiptHeader>().Attach(result);
                        db.Entry(result).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
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
            try
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
                            if (db.Entry(Item).State == EntityState.Detached)
                                db.Set<ReceiptBody>().Attach(Item);
                            db.Entry(Item).State = EntityState.Deleted;
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
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                try
                {
                    var path = db.Settings.Take(1).FirstOrDefault();
                    if (path.EnableSMS)
                    {
                        if (rptReturned.Rows.Count == 0)
                        {
                            if (PendingValue >= 0)
                            {
                                string sms = "Thank you for choosing Car West Auto Service. Your total bill amount is Rs." + LblNetTotal.Text.Trim() + " Thank you, Come Again.";
                                SMS.Sender.Send(TxtCustomer.Text.Trim(), sms);
                            }
                            else
                            {
                                string sms = "Thank you for choosing Car West Auto Service. Your pending outstanding balance amount is Rs." + PendingValue.ToString() + " Please pay your due as soon as possible";
                                SMS.Sender.Send(TxtCustomer.Text.Trim(), sms);
                            }
                        }
                    }
                    if (path != null)
                    {
                        if (path.DefaultPath == null)
                        {
                            return;
                        }
                        SalesReceiptAsPDF(rptBody, rptReturned, LblReceiptNo.Text, path.DefaultPath);
                    }
                }
                catch (Exception ex)
                {
                    Info.Mes(ex.InnerException.Message);
                }
                finally
                { 
                    Reset(); 
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

        public void SalesReceiptAsPDF(DataTable dt, DataTable dtReturn, string RptNo, string Path)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.BusinessModels.FirstOrDefault(c => c.IsActive && !c.IsDeleted);
                    var header = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == RptNo && !c.IsDeleted);
                    var customerDetails = db.Customers.FirstOrDefault(c => c.Contact == TxtCustomer.Text.Trim() && !c.IsDeleted);
                    if (customerDetails == null)
                    {
                        var OwnerId = db.Vehicles.FirstOrDefault(c => c.VehicleNo == TxtCustomer.Text.Trim() && !c.IsDeleted);
                        if (OwnerId != null)
                        {
                            customerDetails = db.Customers.FirstOrDefault(c => c.CustomerId == OwnerId.OwnerId && !c.IsDeleted);
                        }
                    }
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
                    float pageWidth = PageSize.A4.GetWidth();
                    float pageHeight = 100;

                    float paidAmount = header.PaidAmount;
                    float balanceAmount = header.Balance;
                    float pendingValue = header.PendingValue;

                    PendingAfterReturn = pendingValue - TotalReturns;

                    string sb = data.Name;
                    PdfFont f = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.COURIER_BOLD);
                    Paragraph title = new Paragraph(sb).SetTextAlignment(TextAlignment.LEFT).SetFont(f).SetFontSize(20).SetBold();
                    string Address = data.Address + ",   " + data.Contact;
                    string ReceiptInfo = "RECEIPT NO: " + LblReceiptNo.Text.Trim();
                    Table bus = new Table(UnitValue.CreatePercentArray(new float[] { 15, 5 })).SetVerticalAlignment(VerticalAlignment.TOP).SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    bus.SetWidth(UnitValue.CreatePercentValue(100));
                    bus.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    bus.SetFixedLayout();
                    PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.COURIER_BOLD);
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetFont(font).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(Address)));
                    bus.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetFont(font).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(ReceiptInfo)));

                    Table RptDetails = new Table(UnitValue.CreatePercentArray(new float[] { 20, 10, 5, 5, 5 })).SetVerticalAlignment(VerticalAlignment.TOP).SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    RptDetails.SetWidth(UnitValue.CreatePercentValue(100));
                    RptDetails.SetHorizontalAlignment(HorizontalAlignment.CENTER).SetFontSize(8);
                    RptDetails.SetFixedLayout();
                    pageHeight += 100;
                    foreach (var ml in mlt)
                    {
                        pageHeight += 12;
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("BILLING TO : " + customerDetails.Name)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("VEHICLE NUMBER : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(ml.VehicleNo)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("DATE : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Date)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Address)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("CURRENT MILEAGE : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(ml.Mileage.ToString() + " KM")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("TIME : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Time)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Contact)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("NEXT SERVICE ON : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph((ml.ServiceMileageDue + ml.Mileage + " KM").ToString())));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("CASHIER : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(LblCashier.Text)));
                    }

                    if (mlt.Count == 0)
                    {
                        pageHeight += 12;
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("BILLING TO : " + customerDetails.Name)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(string.Empty)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(string.Empty)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("DATE : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Date)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Address)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(string.Empty)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(string.Empty)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("TIME : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(header.Time)));

                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(customerDetails.Contact)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(string.Empty)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(string.Empty)));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("CASHIER : ")));
                        RptDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(LblCashier.Text)));
                    }

                    Table table = new Table(UnitValue.CreatePercentArray(new float[] { 5,18, 4, 3, 4, 4, 4 })).SetVerticalAlignment(VerticalAlignment.TOP).SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    table.SetWidth(UnitValue.CreatePercentValue(100));
                    table.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    table.SetFixedLayout();

                    pageHeight += 20;

                    table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("CODE")));
                    table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("IITEM NAME")));
                    table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("UNIT PRICE")));
                    table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("QTY")));
                    table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("GROSS")));
                    table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("DISC")));
                    table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("NET TOTAL")));

                    foreach (DataRow d in dt.Rows)
                    {
                        pageHeight += 16;
                        string item;
                        if (d[2].ToString().Length > 40)
                            item = d[2].ToString().Substring(0, 40);
                        else
                            item = d[2].ToString();
                        table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(d[1].ToString())));
                        table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(item)));
                        table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(d[3].ToString())));
                        table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(d[4].ToString())));
                        table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[5].ToString())));
                        table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[6].ToString())));
                        table.AddCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(d[7].ToString())));
                    }

                    if (dtReturn.Rows.Count > 0)
                    {
                        table.AddCell(new Cell(1,7).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("RETURNED ITEMS")));
                        foreach (DataRow dr in dtReturn.Rows)
                        {
                            string item;
                            int x = 1;
                            pageHeight += 16;
                            if (dr[2].ToString().Length > 40)
                                item = dr[2].ToString().Substring(0, 40);
                            else
                                item = dr[2].ToString();
                            table.AddCell(new Cell(x, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(dr[1].ToString())));
                            table.AddCell(new Cell(x, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(item)));
                            table.AddCell(new Cell(x, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(dr[3].ToString())));
                            table.AddCell(new Cell(x, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(dr[4].ToString())));
                            table.AddCell(new Cell(x, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(dr[5].ToString())));
                            table.AddCell(new Cell(x, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(dr[6].ToString())));
                            table.AddCell(new Cell(x, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(dr[7].ToString())));
                        }
                    }
                    if (dtReturn.Rows.Count == 0)
                    {
                        pageHeight += 50;
                        table.AddFooterCell(new Cell(1, 5).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblSubTotal.Text)));
                        table.AddFooterCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblTotalDiscount.Text)));
                        table.AddFooterCell(new Cell(1, 1).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblNetTotal.Text)));

                        table.AddFooterCell(new Cell(1, 6).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("PAID AMOUNT")));
                        table.AddFooterCell(new Cell(1, 7).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(paidAmount.ToString())));

                        table.AddFooterCell(new Cell(2, 6).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("BALANCE AMOUNT")));
                        table.AddFooterCell(new Cell(2, 7).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(balanceAmount.ToString())));

                        table.AddFooterCell(new Cell(2, 6).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("PENDING AMOUNT")));
                        table.AddFooterCell(new Cell(2, 7).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(pendingValue.ToString())));
                    }
                    else
                    {
                        pageHeight += 100;
                        table.AddFooterCell(new Cell(1, 7).SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 1)).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(TotalReturns.ToString())));

                        table.AddFooterCell(new Cell(1, 6).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("RETURNED AMOUNT")));
                        table.AddFooterCell(new Cell(1, 7).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(TotalReturns.ToString())));

                        table.AddFooterCell(new Cell(2, 6).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("TOTAL VALUE")));
                        table.AddFooterCell(new Cell(2, 7).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph((Convert.ToSingle(LblNetTotal.Text) + TotalReturns).ToString())));

                        table.AddFooterCell(new Cell(2, 6).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("NET TOTAL")));
                        table.AddFooterCell(new Cell(2, 7).SetBorder(Border.NO_BORDER).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph(LblNetTotal.Text)));
                    }
                    LineSeparator ls = new LineSeparator(new DashedLine()).SetFontSize(12);
                    StringBuilder footer = new StringBuilder();
                    Paragraph space = new Paragraph("                  ").SetTextAlignment(TextAlignment.JUSTIFIED_ALL);
                    footer.AppendLine("........................................                                                                                                                                                                ........................................");
                    footer.AppendLine("CUSTOMER SIGNATURE                  PLEASE NOTE : CREDIT BALANCE SHOULD BE SETTLED WITHIN 30 DAYS                CHECKED BY");
                    Paragraph foot = new Paragraph(footer.ToString()).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT);
                    PageSize ps = new PageSize(pageWidth, pageHeight);
                    Document document = new Document(pdf, ps);
                    document.SetMargins(10, 30, 10, 30);
                    document.Add(title);
                    document.Add(bus);
                    document.Add(RptDetails);
                    document.Add(ls);
                    document.Add(table);
                    document.Add(space);
                    document.Add(foot);
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
                foreach (var c in data)
                {
                    Customers.Add(c);
                }
                TxtCustomer.AutoCompleteCustomSource = Customers;
            }
        }

        private void VehicleNumberAutoComplete()
        {
            AutoCompleteStringCollection Vehicles = new AutoCompleteStringCollection();

            using (BillingContext db = new BillingContext())
            {
                var vehicles = db.Vehicles.Select(c => c.VehicleNo).ToList();
                Vehicles.AddRange(vehicles.ToArray());
                TxtSearchByVehicleNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
                TxtSearchByVehicleNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
                TxtSearchByVehicleNumber.AutoCompleteCustomSource = Vehicles;
            }
        }

        private void PayeeAutocomplete()
        {
            AutoCompleteStringCollection Payee = new AutoCompleteStringCollection();

            using (BillingContext db = new BillingContext())
            {
                var data = db.Cheques.Select(c => c.PayeeName).ToList();
                Payee.AddRange(data.ToArray());
                TxtPayeeName.AutoCompleteMode = AutoCompleteMode.Suggest;
                TxtPayeeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                TxtPayeeName.AutoCompleteCustomSource = Payee;
            }
        }

        private void ProductCodeAutocomplete()
        {
            AutoCompleteStringCollection Code = new AutoCompleteStringCollection();

            using (BillingContext db = new BillingContext())
            {
                var data = db.Items.Select(c => c.Code).ToList();
                Code.AddRange(data.ToArray());
                TxtProductCode.AutoCompleteMode = AutoCompleteMode.Suggest;
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
                    Document document = new Document(pdf, PageSize.A5.Rotate());
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
                    PageSize ps = pdf.GetDefaultPageSize();
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

        private void TxtCustomer_Leave(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void TxtName_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtName);
        }

        private void TxtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtAddress);
        }

        private void TxtProductCode_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void CmbAddItem_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TxtChequeNo_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtChequeNo);
        }

        private void TxtPayeeName_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtPayeeName);
        }

        private void TxtRemarks_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtRemarks);
        }

        private void TxtCustomer_MouseClick(object sender, MouseEventArgs e)
        {
            TxtSearchByVehicleNumber.Text = string.Empty;
        }

        private void TxtSearchByVehicleNumber_MouseClick(object sender, MouseEventArgs e)
        {
            TxtCustomer.Text = string.Empty;
        }

        private void TxtSearchByVehicleNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtSearchByVehicleNumber.Text.Trim()))
            {
                string VehicleNumber = TxtSearchByVehicleNumber.Text.Trim();
                using (BillingContext db = new BillingContext())
                {
                    try
                    {
                        var data = db.Vehicles.FirstOrDefault(c => c.VehicleNo == VehicleNumber && !c.IsDeleted);
                        if (data != null)
                        {
                            var Customer = db.Customers.FirstOrDefault(c => c.CustomerId == data.OwnerId);

                            if (Customer != null)
                            {
                                LblCustomer.Text = Customer.Name;
                                TxtCustomer.Text = Customer.Contact;
                                var vehicles = db.Vehicles.Where(c => c.OwnerId == Customer.CustomerId && !c.IsDeleted).ToList();
                                if (vehicles.Count > 0)
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
                        }
                        else
                        {
                            LblCustomer.Text = "Customer";
                            CmbVehicles.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Info.Mes(ex.Message);
                    }                   
                }
            }
        }

        private void TxtSearchByVehicleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && LblCustomer.Text == "Customer")
            {
                ShowAddCustomer();
                TxtName.Focus();
                TxtContact.Text = TxtCustomer.Text.Trim();
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if (BtnReturn.Text == "Return Receipt")
            {
                BtnAddtoReturn.Visible = true;
                BtnRemoveReturn.Visible = true;
                BtnReturn.Text = "Complete Return";
            }
            else if (BtnReturn.Text == "Complete Return")
            {
                BtnAddtoReturn.Visible = false;
                BtnRemoveReturn.Visible = false;
                BtnReturn.Text = "Return Receipt";
            }
        }

        private void BtnAddtoReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVReceiptBody.SelectedRows.Count > 0)
                {
                    using (BillingContext db = new BillingContext())
                    {
                        var Item = db.ReceiptBodies.FirstOrDefault(c => c.ProductId == ItemId && c.ReceiptNo == ReceiptNo && !c.IsReturned && !c.IsDeleted);
                        if (Item != null)
                        {
                            Item.IsReturned = true;
                            Item.UpdatedDate = DateTime.Today;
                            if (db.Entry(Item).State == EntityState.Detached)
                                db.Set<ReceiptBody>().Attach(Item);
                            db.Entry(Item).State = EntityState.Modified;
                            db.SaveChanges();
                            IncreaseStock();
                            DGVLoad(ReceiptNo);
                        }
                    }
                }
                else
                {
                    BtnAddtoReturn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
            finally
            {
                TotalCalculator();
            }
        }

        private void DGVReceiptBody_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVReceiptBody.SelectedRows.Count > 0)
            {
                ReceiptNo = LblReceiptNo.Text.Trim();
                ItemId = Convert.ToInt32(DGVReceiptBody.SelectedRows[0].Cells[0].Value + string.Empty);
            }
        }

        private void BtnRemoveReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVReturned.SelectedRows.Count > 0)
                {
                    using (BillingContext db = new BillingContext())
                    {
                        var Item = db.ReceiptBodies.FirstOrDefault(c => c.ProductId == ItemId && c.ReceiptNo == ReceiptNo && c.IsReturned && !c.IsDeleted);
                        if (Item != null)
                        {
                            Item.IsReturned = false;
                            Item.UpdatedDate = DateTime.Today;
                            if (db.Entry(Item).State == EntityState.Detached)
                                db.Set<ReceiptBody>().Attach(Item);
                            db.Entry(Item).State = EntityState.Modified;
                            db.SaveChanges();
                            DecreaseStock();
                            DGVLoad(ReceiptNo);
                        }
                    }
                }
                else
                {
                    BtnAddtoReturn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
            finally
            {
                TotalCalculator();
            }
        }

        private void DGVReturned_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVReturned.SelectedRows.Count > 0)
            {
                ReceiptNo = LblReceiptNo.Text.Trim();
                ItemId = Convert.ToInt32(DGVReturned.SelectedRows[0].Cells[0].Value + string.Empty);
            }
        }

        private void POS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.J)
            {
                ItemLookup ilu = new ItemLookup();
                ilu.Show();
            }
        }

        private void CmbAddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.J)
            {
                try
                {
                    using (ItemLookup frm = new ItemLookup())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            TxtProductCode.Text = frm.Code;
                            CmbAddItem.Text = frm.ItemName;
                            GetItemDetailsById();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Info.Mes(ex.Message);
                }
            }
        }

        private void POS_Enter(object sender, EventArgs e)
        {
        }
    }
}