using SimpleBilling.Model;
using SimpleBilling.Report;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

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
        private readonly int CashierId = 1;
        private readonly string PaymentType = string.Empty;
        private readonly string ReceiptNo = string.Empty;
        private float ReceiptTotalDiscount;
        private float ReceiptSubTotal;
        private float ReceiptNetTotal;
        private float GivenAmount;
        private float BalanceAmount;
        private int ReceiptStatus;

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private readonly Random random = new Random();

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
            DGVLoad(ReceiptNo);
            PrintAndVoid();
            TxtCustomer.Focus();
        }

        private void PrintAndVoid()
        {
            if (ReceiptStatus != 2 || LblReceiptStatus.Text != "Completed")
            {
                BtnPrint.Enabled = true;
                BtnVoid.Enabled = false;
            }
            else if (ReceiptStatus == 2 || LblReceiptStatus.Text == "Completed")
            {
                BtnPrint.Enabled = true;
                BtnVoid.Enabled = true;
            }
        }

        private void DGVLoad(string ReceiptNo)
        {
            if (!string.IsNullOrEmpty(ReceiptNo))
            {
                using (BillingContext db = new BillingContext())
                {
                    customersBindingSource.DataSource = db.Customers.ToList();
                    itemBindingSource.DataSource = db.Items.ToList();
                    var RptBody = (from body in db.ReceiptBodies.Where(c => c.Is_Deleted == false && c.ReceiptNo == ReceiptNo)
                                   join item in db.Items
                                   on body.ProductId equals item.Id
                                   select new
                                   {
                                       item.Id,
                                       item.Code,
                                       item.ItemName,
                                       body.UnitPrice,
                                       body.Quantity,
                                       body.SubTotal,
                                       body.Discount,
                                       body.NetTotal
                                   }).ToList();
                    DGVReceiptBody.DataSource = RptBody;

                    var RptHeader = (from header in db.ReceiptHeaders.Where(c => c.Is_Deleted == false && c.ReceiptNo == ReceiptNo && c.IsQuotation == false)
                                     join cashier in db.Employee
                                     on header.Cashier equals cashier.EmployeeId
                                     select new
                                     {
                                         header.Date,
                                         header.Time,
                                         header.TotalDiscount,
                                         header.SubTotal,
                                         header.NetTotal,
                                         header.PaidAmount,
                                         header.Balance,
                                         header.Status,
                                         Cashier = cashier.EmployeeName
                                     }).ToList();
                    foreach (var a in RptHeader)
                    {
                        LblCashier.Text = a.Cashier;
                        LblBalanceAmount.Text = a.Balance.ToString();
                        TxtGivenAmount.Text = a.PaidAmount.ToString();
                        ReceiptStatus = a.Status;
                        LblReceiptStatus.Text = GetReceiptStatus(ReceiptStatus);
                        LblReceiptNo.Text = ReceiptNo;
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
                }
                LblReceiptNo.Text = (RandomString(5) + LblDate.Text + LblTime.Text).Replace(" ", string.Empty).Replace("/", string.Empty).Replace(":", string.Empty);
            }
        }

        private string GetReceiptStatus(int Status)
        {
            if (Status == 1)
            {
                return "On Process";
            }
            else if (Status == 2)
            {
                return "Completed";
            }
            else
            {
                return "Canceled";
            }
        }

        private void SystemTimer_Tick(object sender, EventArgs e)
        {
            LblDate.Text = DateTime.Now.ToShortDateString();
            LblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void TxtCustomer_KeyUp(object sender, KeyEventArgs e)
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
                    }
                }
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
                    if (data != null)
                    {
                        TxtUnitPrice.Text = data.SellingPrice.ToString();
                        TxtBarCode.Text = data.Barcode;
                        TxtProductCode.Text = data.Code;
                        TxtDiscount.Text = "0";
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
                        Status = 1
                    };

                    var result = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == header.ReceiptNo);

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
                        return result.ReceiptNo;
                    }
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
                throw;
            }
        }

        private void LoadDGV(string ReceiptNo)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from body in db.ReceiptBodies.Where(c => c.ReceiptNo == ReceiptNo && c.Is_Deleted == false)
                            join item in db.Items
                            on body.ProductId equals item.Id
                            select new
                            {
                                item.Id,
                                item.Code,
                                item.ItemName,
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
            string ReceiptNo = AddReceiptHeader();
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    ReceiptBody body = new ReceiptBody
                    {
                        ReceiptNo = ReceiptNo,
                        ProductId = ItemId,
                        UnitPrice = UnitPrice,
                        Quantity = Convert.ToInt32(Qty),
                        Discount = Discount,
                        SubTotal = Total,
                        NetTotal = NetTotal
                    };
                    var Result = db.ReceiptBodies.FirstOrDefault(c => c.ReceiptNo == ReceiptNo && c.ProductId == ItemId);
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
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
            }
            finally
            {
                LoadDGV(ReceiptNo);
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
            ReceiptTotalDiscount = (from DataGridViewRow row in DGVReceiptBody.Rows
                                    where row.Cells[0].FormattedValue.ToString() != string.Empty
                                    select Convert.ToSingle(row.Cells[6].FormattedValue)).Sum();
            ReceiptNetTotal = (from DataGridViewRow row in DGVReceiptBody.Rows
                               where row.Cells[0].FormattedValue.ToString() != string.Empty
                               select Convert.ToSingle(row.Cells[7].FormattedValue)).Sum();
            LblTotalDiscount.Text = ReceiptTotalDiscount.ToString();
            LblNetTotal.Text = ReceiptNetTotal.ToString();
            ReceiptSubTotal = ReceiptTotalDiscount + ReceiptNetTotal;
            LblSubTotal.Text = ReceiptSubTotal.ToString();
        }

        private void CompleteReceipt()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(TxtGivenAmount.Text))
                {
                    GivenAmount = Convert.ToSingle(TxtGivenAmount.Text.Trim());
                    BalanceAmount = GivenAmount - ReceiptNetTotal;
                    if (BalanceAmount >= 0)
                    {
                        using (BillingContext db = new BillingContext())
                        {
                            var Result = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == ReceiptNo && c.Is_Deleted == false);
                            if (Result != null)
                            {
                                if (Result.Status == 1)
                                {
                                    Result.NetTotal = ReceiptNetTotal;
                                    Result.TotalDiscount = ReceiptTotalDiscount;
                                    Result.SubTotal = ReceiptSubTotal;
                                    Result.PaidAmount = GivenAmount;
                                    Result.Balance = BalanceAmount;
                                    Result.PaymentType = GetPaymentType();
                                    Result.Status = 2;
                                    if (db.Entry(Result).State == EntityState.Detached)
                                        db.Set<ReceiptHeader>().Attach(Result);
                                    db.Entry(Result).State = EntityState.Modified;
                                    db.SaveChanges();
                                    LblReceiptStatus.Text = GetReceiptStatus(Result.Status);
                                    ReduceStock(true);
                                    MessageBox.Show($"Receipt {LblReceiptNo.Text} Created Successfully");
                                }
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
                PrintAndVoid();
            }
        }

        private void ReduceStock(bool value)
        {
            foreach (DataGridViewRow dgv in DGVReceiptBody.Rows)
            {
                using (BillingContext db = new BillingContext())
                {
                    int ItemId = Convert.ToInt32(dgv.Cells[0].Value);
                    int Qty = Convert.ToInt32(dgv.Cells[4].Value);
                    var Result = db.Items.FirstOrDefault(c => c.Id == ItemId);
                    if (Result != null)
                    {
                        if (value)
                        {
                            Result.StockQty -= Qty;
                        }
                        if (!value)
                        {
                            Result.StockQty += Qty;
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
            if (Info.IsEmpty(TxtDiscount)
                && Info.IsEmpty(TxtQuantity) && Info.IsEmpty(TxtUnitPrice))
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

        private void TxtGivenAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtGivenAmount.Text.Length > 0)
            {
                float GivenAmount = Convert.ToSingle(TxtGivenAmount.Text.Trim());
                BalanceAmount = GivenAmount - Convert.ToSingle(LblNetTotal.Text);
                LblBalanceAmount.Text = BalanceAmount.ToString();
            }
        }

        private void TxtGivenAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BalanceAmount >= 0)
                {
                    CompleteReceipt();
                }
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
                var result = db.ReceiptHeaders.FirstOrDefault(c => c.ReceiptNo == ReceiptNo && c.Is_Deleted == false && c.Status == 2);
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
                    TxtDiscount_KeyUp(sender, e);
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
                string ReceiptNo = LblReceiptNo.Text.Trim();
                using (BillingContext db = new BillingContext())
                {
                    var Item = db.ReceiptBodies.FirstOrDefault(c => c.ProductId == Id && c.ReceiptNo == ReceiptNo && c.Is_Deleted == false);
                    if (Item != null)
                    {
                        Item.Is_Deleted = true;
                        if (db.Entry(Item).State == EntityState.Detached)
                            db.Set<ReceiptBody>().Attach(Item);
                        db.Entry(Item).State = EntityState.Modified;
                        db.SaveChanges();
                        DGVLoad(ReceiptNo);
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
            Receipt rpt = new Receipt(LblReceiptNo.Text);
            rpt.Show();
        }

        private void CmbPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CmbPaymentOption.Text))
            {
                TxtGivenAmount.Enabled = true;
            }
        }
    }
}