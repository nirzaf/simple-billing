﻿using SimpleBilling.Model;
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
        private float TotalDiscount = 0;
        private float NetTotal = 0;
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
                            }).Where(c=>c.GRN_Code == GRN_Code).ToList();
                DGVGRNList.DataSource = data;
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
            finally
            {
                BtnAddItem.Enabled = true;
                BtnCreateGRN.Enabled = false;
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
                        LineNo++;
                        LoadDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                foreach (DataGridViewRow r in DGVGRNList.Rows)
                {
                    {
                        TotalDiscount += Convert.ToSingle(r.Cells[5].Value);
                        NetTotal += Convert.ToSingle(r.Cells[6].Value);
                    }
                }
                LblTotalDiscount.Text = TotalDiscount.ToString();
                LblNetTotal.Text = NetTotal.ToString();
                LblGrossTotal.Text = (TotalDiscount + NetTotal).ToString();
            }
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = (from details in db.GRNDetails 
                                select new
                                {
                                    GRN_Code = details.GRNCode,
                                    Line_No = details.LineId,
                                    details.Quantity,
                                    Unit_Cost = details.UnitCost,
                                    details.Discount,
                                    Sub_Total = details.SubTotal
                                }).Where(c => c.GRN_Code == GRN_Code).ToList();
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
            finally
            {
                BtnAddItem.Enabled = true;
                BtnCreateGRN.Enabled = false;
            }
        }
    }
}
