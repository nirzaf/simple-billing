using SimpleBilling.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class POS : Form
    {
        private int ItemId;
        private string BarCode;
        public POS()
        {
            InitializeComponent();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            SystemTimer_Tick(sender, e);
            LoadDateAndTime();
        }

        private void LoadDateAndTime()
        {
            using (BillingContext db = new BillingContext())
            {
                customersBindingSource.DataSource = db.Customers.ToList();
                itemBindingSource.DataSource = db.Items.ToList();
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
                    TxtUnitPrice.Text = data.UnitCost.ToString();
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
                        TxtUnitPrice.Text = data.UnitCost.ToString();
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

        private void TxtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtQuantity.Text.Trim()))
            {
                float UnitCost = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                float Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                float Total = UnitCost * Qty;
                TxtSubTotal.Text = Total.ToString();
                TxtDiscount_KeyUp(sender, e);
            }
        }

        private void TxtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtDiscount.Text.Trim()))
            {
                float UnitCost = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                float Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                float Total = UnitCost * Qty;
                TxtSubTotal.Text = Total.ToString();
                float Discount = Convert.ToSingle(TxtDiscount.Text.Trim());
                float NetTotal = Total - Discount;
                TxtNetTotal.Text = NetTotal.ToString();
            }
            else
            {
                float UnitCost = Convert.ToSingle(TxtUnitPrice.Text.Trim());
                float Qty = Convert.ToSingle(TxtQuantity.Text.Trim());
                float Total = UnitCost * Qty;
                TxtSubTotal.Text = Total.ToString();
                TxtNetTotal.Text = Total.ToString();
                TxtSubTotal.Text = Total.ToString();
            }
        }
    }
}
