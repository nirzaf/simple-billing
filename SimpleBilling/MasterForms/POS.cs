using SimpleBilling.Model;
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
        private int CashierId = 1;
        private string PaymentType = string.Empty;
        private string ReceiptNo = string.Empty;
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
        }

        private void POS_Load(object sender, EventArgs e)
        {
            SystemTimer_Tick(sender, e);
            DGVLoad(ReceiptNo);
        }

        private void DGVLoad(string ReceiptNo)
        {
            if (!string.IsNullOrEmpty(ReceiptNo))
            {
                using (BillingContext db = new BillingContext())
                {
                    customersBindingSource.DataSource = db.Customers.ToList();
                    itemBindingSource.DataSource = db.Items.ToList();
                }
            }
            else
            {
                using (BillingContext db = new BillingContext())
                {
                    customersBindingSource.DataSource = db.Customers.ToList();
                    itemBindingSource.DataSource = db.Items.ToList();
                }
               LblReceiptNo.Text = (RandomString(5) + LblDate.Text + LblTime.Text).Replace(" ", string.Empty).Replace("/",string.Empty).Replace(":",string.Empty);
            }
        }

        private void SystemTimer_Tick(object sender, EventArgs e)
        {           
            LblDate.Text = DateTime.Now.ToShortDateString();
            LblTime.Text = DateTime.Now.ToLongTimeString();
        }


        private void TxtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
        }

        private void CmbAddItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemDetailsById();
        }

        private void GetItemDetailsById()
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

        private int AddReceiptHeader()
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
                        return header.ReceiptId;
                    }
                    else
                    {
                        return result.ReceiptId;
                    }
                }
            }
            catch (Exception ex)
            {
                Exp(ex);
                throw;
            }
        }


        private void LoadDGV(int ReceiptNo)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from body in db.ReceiptBodies.Where(c =>c.ReceiptNo == ReceiptNo &&  c.Is_Deleted == false)
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
            int ReceiptNo = AddReceiptHeader();
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
                        Result.Quantity += Convert.ToInt32(TxtQuantity.Text.Trim());
                        Result.Discount += Convert.ToSingle(TxtDiscount.Text.Trim());
                        Result.SubTotal += Convert.ToSingle(TxtSubTotal.Text.Trim());
                        Result.NetTotal += Convert.ToSingle(TxtNetTotal.Text.Trim());
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

        private void Exp(Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }

        private void TxtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtDiscount.Text.Trim()))
            {
                UnitPrice = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                Total = UnitPrice * Qty;
                TxtSubTotal.Text = Total.ToString();
                Discount = Convert.ToSingle(TxtDiscount.Text.Trim());
                NetTotal = Total - Discount;
                TxtNetTotal.Text = NetTotal.ToString();
            }
            else
            {
                UnitPrice = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                Total = UnitPrice * Qty;
                TxtSubTotal.Text = Total.ToString();
                TxtNetTotal.Text = Total.ToString();
                TxtSubTotal.Text = Total.ToString();
            }
        }

        private void TxtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(TxtQuantity.Text.Trim()))
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
    }
}
