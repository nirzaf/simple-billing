using iText.Kernel.Colors;
using iText.Kernel.Geom;
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
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class PurchaseOrder : Form
    {
        private int SupplierId;
        private string PurchaseOrderId;
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            FormLoad(string.Empty);
        }

        private void FormLoad(string OrderId)
        {
            LoabCMB();
            LblDate.Text = DateTime.Today.ToShortDateString();
            FormLoadAll(OrderId);       
        }


        private void LoabCMB()
        {
            using (BillingContext db = new BillingContext())
            {
                CmbSuppliers.ValueMember = "SupplierId";
                CmbSuppliers.DisplayMember = "Name";
                CmbSuppliers.DataSource = db.Suppliers.Where(c => !c.IsDeleted).ToList();
            }
        }

        private void BtnAddToOrder_Click(object sender, EventArgs e)
        {
            AddToOrder();
        }

        private void AddToOrder()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (DGVItemsToOrder.SelectedRows.Count > 0)
                    {
                        string Code = DGVItemsToOrder.SelectedRows[0].Cells[0].Value + string.Empty;
                        var OrdererdItem = db.OrderedItems.FirstOrDefault(c => c.ItemCode == Code && c.OrderId == PurchaseOrderId);
                        if (Info.IsEmpty(TxtOrderQuantity))
                        {
                            if (OrdererdItem == null)
                            {
                                OrderedItem oi = new OrderedItem
                                {
                                    OrderId = PurchaseOrderId,
                                    ItemCode = Code,
                                    Quantity = Info.ToInt(TxtOrderQuantity),
                                    UnitType = CmbUnitType.Text,
                                    CreatedDate = DateTime.Today,
                                };
                                if (db.Entry(oi).State == EntityState.Detached)
                                    db.Set<OrderedItem>().Attach(oi);
                                db.Entry(oi).State = EntityState.Added;
                                db.SaveChanges();
                                FormLoadAll(PurchaseOrderId);
                            }
                            else
                            {
                                OrdererdItem.Quantity = Info.ToInt(TxtOrderQuantity);
                                OrdererdItem.UnitType = CmbUnitType.Text;
                                OrdererdItem.UpdatedDate = DateTime.Today;
                                if (db.Entry(OrdererdItem).State == EntityState.Detached)
                                    db.Set<OrderedItem>().Attach(OrdererdItem);
                                db.Entry(OrdererdItem).State = EntityState.Modified;
                                db.SaveChanges();
                                FormLoadAll(PurchaseOrderId);
                            }
                        }
                        else
                        {
                            Info.Mes("Quantity Cannot be Empty");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string PurchaseOrderDate = DtpOrderDate.Value.ToShortDateString();
                SupplierId = Convert.ToInt32(CmbSuppliers.SelectedValue.ToString());
                string SupplierName = CmbSuppliers.Text;
                using (BillingContext db = new BillingContext())
                {
                    Model.PurchaseOrder po = new Model.PurchaseOrder
                    {
                        OrderUniqueId = GeneratePurchaseOrderId(SupplierId.ToString(), SupplierName),
                        OrderedDate = PurchaseOrderDate,
                        SupplierId = SupplierId,
                        CreatedDate = DateTime.Today
                    };
                    if (db.Entry(po).State == EntityState.Detached)
                        db.Set<Model.PurchaseOrder>().Attach(po);
                    db.Entry(po).State = EntityState.Added;
                    db.SaveChanges();
                    LblPurchaseOrderId.Text = po.OrderUniqueId;
                    LblOrderStatus.Text = "Order " + po.OrderUniqueId + " is created";
                    PurchaseOrderId = po.OrderUniqueId;
                    BtnAddToOrder.Enabled = true;
                    BtnRemove.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
                ExportJson.Add(ex);
            }
        }

        private string GeneratePurchaseOrderId(string SupplierId, string SupplierName)
        {
            string PurchaseOrderDate = DtpOrderDate.Value.ToShortDateString();
            string poId = (Info.RandomString(4) + "-" + PurchaseOrderDate + "-" + SupplierId + "-" + SupplierName).Replace("/", string.Empty).Replace(" ", string.Empty);
            return poId;
        }

        private void DGVItemsToOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVItemsToOrder.SelectedRows.Count > 0)
            {
                string Code = DGVItemsToOrder.SelectedRows[0].Cells[0].Value + string.Empty;
                using (BillingContext db = new BillingContext())
                {
                    bool ioc = db.PurchaseOrders.FirstOrDefault(c => c.OrderUniqueId == PurchaseOrderId && !c.IsDeleted).IsOrderCompleted;
                    if (!ioc)
                    {
                        TxtOrderQuantity.Enabled = true;
                        CmbUnitType.Enabled = true;
                    }
                    else
                    {
                        TxtOrderQuantity.Enabled = false;
                        CmbUnitType.Enabled = false;
                        BtnCompleteOrdering.Text = "Add Some More Items";
                        BtnCompleteOrdering.Enabled = true;
                    }
                    var item = db.Items.FirstOrDefault(c => c.Code == Code);
                    if (item != null)
                    {
                        CmbUnitType.Text = item.Unit;
                    }
                }
            }
            else
            {
                TxtOrderQuantity.Enabled = false;
                CmbUnitType.Enabled = false;
            }
        }

        private void DGVOrderedItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVOrderedItems.SelectedRows.Count > 0)
            {
                BtnRemove.Enabled = true;
            }
        }

        private void DtpOrderDate_ValueChanged(object sender, EventArgs e)
        {
            //string PurchaseOrderDate = DtpOrderDate.Value.ToShortDateString();
            //FormLoad(OrderId);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                if (DGVOrderedItems.SelectedRows.Count > 0)
                {
                    string code = DGVOrderedItems.SelectedRows[0].Cells[0].Value + string.Empty;
                    var item = db.OrderedItems.FirstOrDefault(c => c.ItemCode == code && c.OrderId == PurchaseOrderId);
                    if (item != null)
                    {
                        if (db.Entry(item).State == EntityState.Detached)
                            db.Set<OrderedItem>().Attach(item);
                        db.Entry(item).State = EntityState.Deleted;
                        db.SaveChanges();
                        FormLoadAll(PurchaseOrderId);
                    }
                }
            }
        }

        private void LstBoxPendingOrders_DoubleClick(object sender, EventArgs e)
        {
            PurchaseOrderId = LstBoxPendingOrders.SelectedItem.ToString();
            RefreshList(PurchaseOrderId);
            LblPurchaseOrderId.Text = PurchaseOrderId;
        }

        private void RefreshList(string OrderId)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    //Load Data grid view of Ordered Items 
                    var orderedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == OrderId && !c.IsDeleted)
                                        join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                        on po.OrderUniqueId equals oi.OrderId
                                        join it in db.Items.Where(c => !c.IsDeleted)
                                        on oi.ItemCode equals it.Code
                                        select new
                                        {
                                            oi.ItemCode,
                                            it.PrintableName,
                                            oi.Quantity
                                        }).ToList();
                    DGVOrderedItems.DataSource = orderedItems;
                    //Load Data grid view of Received Items 
                    var receivedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == OrderId && !c.IsDeleted)
                                         join oi in db.OrderedItems.Where(c => c.IsReceived && !c.IsDeleted)
                                         on po.OrderUniqueId equals oi.OrderId
                                         join it in db.Items.Where(c => !c.IsDeleted)
                                         on oi.ItemCode equals it.Code
                                         select new
                                         {
                                             oi.ItemCode,
                                             it.PrintableName,
                                             oi.Quantity
                                         }).ToList();
                    DGVReceivedItems.DataSource = receivedItems;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnMarkReceived_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PurchaseOrderId))
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.PurchaseOrders.FirstOrDefault(c => c.OrderUniqueId == PurchaseOrderId);
                    if (data != null)
                    {
                        data.IsReceived = true;
                        if (db.Entry(data).State == EntityState.Detached)
                            db.Set<Model.PurchaseOrder>().Attach(data);
                        db.Entry(data).State = EntityState.Modified;
                        db.SaveChanges();
                        FormLoadAll(PurchaseOrderId);
                    }
                }
            }
        }

        private void LstBoxPendingOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrderId = LstBoxPendingOrders.SelectedItem.ToString();
            LblPurchaseOrderId.Text = PurchaseOrderId;
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            FormLoadAll(string.Empty);
        }

        private void LoadItems(string Input)
        {
            using (BillingContext db = new BillingContext())
            {
                //Load All Items with on hand Stock Qty
                if (string.IsNullOrWhiteSpace(Input))
                {
                    var data = (from item in db.Items.Where(c => !c.IsDeleted)
                                select new
                                {
                                    item.Code,
                                    item.PrintableName,
                                    item.StockQty
                                }).OrderBy(c => c.StockQty).ToList();
                    DGVItemsToOrder.DataSource = data;
                }
                else
                {
                    var data = (from item in db.Items.Where(c =>(c.Code.Contains(Input) || c.ItemName.Contains(Input)) && !c.IsDeleted)
                                select new
                                {
                                    item.Code,
                                    item.PrintableName,
                                    item.StockQty
                                }).OrderBy(c => c.StockQty).ToList();
                    DGVItemsToOrder.DataSource = data;
                }
            }
        }

        private void FormLoadAll(string OrderId)
        {
            try
            {
                LoadItems(string.Empty);
                using (BillingContext db = new BillingContext())
                {
                    //Load Data grid view of Ordered Items 
                    var orderedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == OrderId && !c.IsDeleted)
                                        join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                        on po.OrderUniqueId equals oi.OrderId
                                        join it in db.Items.Where(c => !c.IsDeleted)
                                        on oi.ItemCode equals it.Code
                                        select new
                                        {
                                            oi.ItemCode,
                                            it.PrintableName,
                                            oi.Quantity
                                        }).ToList();
                    DGVOrderedItems.DataSource = orderedItems;
                    //Load Data grid view of Received Items 
                    var receivedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == OrderId && !c.IsDeleted)
                                         join oi in db.OrderedItems.Where(c => c.IsReceived && !c.IsDeleted)
                                         on po.OrderUniqueId equals oi.OrderId
                                         join it in db.Items.Where(c => !c.IsDeleted)
                                         on oi.ItemCode equals it.Code
                                         select new
                                         {
                                             oi.ItemCode,
                                             it.PrintableName,
                                             oi.Quantity
                                         }).ToList();
                    DGVReceivedItems.DataSource = receivedItems;

                    //Fetch List of Received Orders List 
                    var ReceivedOrders = db.PurchaseOrders.Where(c => c.IsReceived && !c.IsDeleted).Select(c => c.OrderUniqueId).ToList();
                    LstReceivedOrders.DataSource = ReceivedOrders;

                    //Fetch List of Pending Orders List 
                    var pendingOrders = db.PurchaseOrders.Where(c => !c.IsReceived && !c.IsDeleted).Select(c => c.OrderUniqueId).ToList();
                    LstBoxPendingOrders.DataSource = pendingOrders;

                    LblDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(OrderId))
                {
                    using (BillingContext db = new BillingContext())
                    {
                        var PurchaseOrderItems = db.PurchaseOrders.FirstOrDefault(c => c.OrderUniqueId == OrderId && !c.IsDeleted);
                        if (PurchaseOrderItems != null)
                        {
                            if (PurchaseOrderItems.IsOrderCompleted)
                            {
                                BtnAddToOrder.Enabled = false;
                                BtnRemove.Enabled = false;
                                TxtOrderQuantity.Enabled = false;
                                CmbUnitType.Enabled = false;
                                BtnCompleteOrdering.Enabled = false;
                            }
                            else
                            {
                                BtnAddToOrder.Enabled = true;
                                BtnRemove.Enabled = true;
                                TxtOrderQuantity.Enabled = false;
                                CmbUnitType.Enabled = false;
                                BtnCompleteOrdering.Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    BtnAddToOrder.Enabled = false;
                    BtnRemove.Enabled = false;
                    TxtOrderQuantity.Enabled = false;
                    CmbUnitType.Enabled = false;
                    BtnCompleteOrdering.Enabled = false;
                }
            }
        }

        private void DTReceivedOrder_ValueChanged(object sender, EventArgs e)
        {
            string Date = DTReceivedOrder.Value.ToShortDateString();
            FormLoadAll(Date);
        }

        private void LstReceivedOrders_DoubleClick(object sender, EventArgs e)
        {
            PurchaseOrderId = LstReceivedOrders.SelectedItem.ToString();
            LblPurchaseOrderId.Text = PurchaseOrderId;
            RefreshList(PurchaseOrderId);
        }

        private void DGVOrderedItems_DoubleClick(object sender, EventArgs e)
        {
            string Code = DGVOrderedItems.SelectedRows[0].Cells[0].Value + string.Empty;
            string PurchaseId = LblPurchaseOrderId.Text.Trim();
            using (BillingContext db = new BillingContext())
            {
                var data = db.OrderedItems.FirstOrDefault(c => c.OrderId == PurchaseId && c.ItemCode == Code && !c.IsReceived && !c.IsDeleted);
                if (data != null)
                {
                    data.IsReceived = true;
                    if (db.Entry(data).State == EntityState.Detached)
                        db.Set<OrderedItem>().Attach(data);
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();

                    var receivedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == PurchaseId && !c.IsDeleted)
                                         join oi in db.OrderedItems.Where(c => c.IsReceived && !c.IsDeleted)
                                         on po.OrderUniqueId equals oi.OrderId
                                         join it in db.Items.Where(c => !c.IsDeleted)
                                         on oi.ItemCode equals it.Code
                                         select new
                                         {
                                             oi.ItemCode,
                                             it.PrintableName,
                                             oi.Quantity
                                         }).ToList();
                    DGVReceivedItems.DataSource = receivedItems;


                    var orderedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == PurchaseId && !c.IsDeleted)
                                        join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                        on po.OrderUniqueId equals oi.OrderId
                                        join it in db.Items.Where(c => !c.IsDeleted)
                                        on oi.ItemCode equals it.Code
                                        select new
                                        {
                                            oi.ItemCode,
                                            it.PrintableName,
                                            oi.Quantity
                                        }).ToList();
                    DGVOrderedItems.DataSource = orderedItems;

                }
            }
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                ExportPurchaseOrderPDF();
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }

        private void ExportPurchaseOrderPDF()
        {

            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = Info.CleanString(LblPurchaseOrderId.Text.Trim())
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    int pageHeight = 0;
                    float pageWidth = PageSize.A4.GetWidth();
                    using (BillingContext db = new BillingContext())
                    {
                        var orderedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == PurchaseOrderId && !c.IsDeleted)
                                            join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                            on po.OrderUniqueId equals oi.OrderId
                                            join it in db.Items.Where(c => !c.IsDeleted)
                                            on oi.ItemCode equals it.Code
                                            select new
                                            {
                                                oi.ItemCode,
                                                it.PrintableName,
                                                oi.Quantity
                                            }).ToList();
                        if (orderedItems.Count > 0)
                        {
                            var data = db.BusinessModels.FirstOrDefault(c => c.IsActive && !c.IsDeleted);
                            string SupplierName = db.Suppliers.FirstOrDefault(a => a.SupplierId == db.PurchaseOrders.FirstOrDefault(c => c.OrderUniqueId == LblPurchaseOrderId.Text.Trim() && !c.IsDeleted).SupplierId && !a.IsDeleted).Name;
                            string orderFrom = data.Name;
                            Table titleDetails = new Table(UnitValue.CreatePercentArray(new float[] { 5, 13 })).SetVerticalAlignment(VerticalAlignment.TOP).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            titleDetails.SetWidth(UnitValue.CreatePercentValue(100));
                            titleDetails.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            titleDetails.SetFixedLayout();

                            titleDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("P.O ID : ")));
                            titleDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(LblPurchaseOrderId.Text.Trim())));

                            titleDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("ORDER TO : ")));
                            titleDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(SupplierName)));

                            titleDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("ORDER FROM : ")));
                            titleDetails.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(orderFrom)));

                            Table orderTable = new Table(UnitValue.CreatePercentArray(new float[] { 5, 15, 5 })).SetVerticalAlignment(VerticalAlignment.TOP).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            orderTable.SetWidth(UnitValue.CreatePercentValue(100));
                            orderTable.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            orderTable.SetFixedLayout();

                            orderTable.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetFontSize(10).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph("ITEM CODE")));
                            orderTable.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetFontSize(10).Add(new Paragraph("IIEM NAME")));
                            orderTable.AddCell(new Cell(1, 1).SetTextAlignment(TextAlignment.CENTER).SetFontSize(10).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph("QTY")));

                            pageHeight += 120;
                            foreach (var ot in orderedItems)
                            {
                                pageHeight += 14;
                                orderTable.AddCell(new Cell(1, 1).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph(ot.ItemCode)));
                                orderTable.AddCell(new Cell(1, 1).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(ot.PrintableName)));
                                orderTable.AddCell(new Cell(1, 1).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph(ot.Quantity.ToString())));
                            }
                            orderTable.AddCell(new Cell(1, 2).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph("TOTAL ORDERED ITEMS")));
                            orderTable.AddCell(new Cell(1, 1).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(ColorConstants.LIGHT_GRAY).Add(new Paragraph(orderedItems.Count.ToString())));
                            pageHeight += 40;
                            LineSeparator ls = new LineSeparator(new DashedLine()).SetFontSize(10);
                            PageSize ps = new PageSize(pageWidth, pageHeight);
                            Document document = new Document(pdf, ps);
                            document.SetMargins(10, 30, 10, 30);
                            document.Add(titleDetails);
                            document.Add(ls);
                            document.Add(orderTable);
                            document.Close();
                            Info.StartProcess(sfd.FileName);
                        }
                        else
                        {
                            Info.Mes("Cannot print the empty purchase order");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Info.Mes(ex.Message);
            }
        }

        private void BaseLayout_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVItemsToOrder_MouseUp(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVOrderedItems_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void DGVReceivedItems_MouseMove(object sender, MouseEventArgs e)
        {
            Main.Count = 0;
        }

        private void TxtFilterItems_KeyUp(object sender, KeyEventArgs e)
        {
            LoadItems(TxtFilterItems.Text.Trim());
            Info.ToCapital(TxtFilterItems);
        }

        private void CmbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupplierId = Convert.ToInt32(CmbSuppliers.SelectedValue.ToString());
        }

        private void BtnCompleteOrdering_Click(object sender, EventArgs e)
        {
            if (BtnCompleteOrdering.Text == "Add Some More Items")
            {
                TxtOrderQuantity.Enabled = true;
                CmbUnitType.Enabled = true;
                BtnAddToOrder.Enabled = true;
                BtnRemove.Enabled = true;
                BtnCompleteOrdering.Text = "Complete Ordering";
            }
            else if (BtnCompleteOrdering.Text == "Complete Ordering")
            {
                using (BillingContext db = new BillingContext())
                {
                    var po = db.PurchaseOrders.FirstOrDefault(c => c.OrderUniqueId == PurchaseOrderId && !c.IsDeleted);
                    if (po != null)
                    {
                        po.IsOrderCompleted = true;
                        po.UpdatedDate = DateTime.Today;
                        if (db.Entry(po).State == EntityState.Detached)
                            db.Set<Model.PurchaseOrder>().Attach(po);
                        db.Entry(po).State = EntityState.Modified;
                        db.SaveChanges();
                        LblOrderStatus.Text = "Order Completed";
                        BtnAddToOrder.Enabled = false;
                        BtnRemove.Enabled = false;
                        BtnExportPDF.Enabled = true;
                        BtnCompleteOrdering.Text = "Add Some More Items";
                    }
                }
            }
        }

        private void DGVReceivedItems_DoubleClick(object sender, EventArgs e)
        {
            if (DGVReceivedItems.SelectedRows.Count > 0)
            {
                string Code = DGVReceivedItems.SelectedRows[0].Cells[0].Value + string.Empty;
                string PurchaseId = LblPurchaseOrderId.Text.Trim();
                using (BillingContext db = new BillingContext())
                {
                    var data = db.OrderedItems.FirstOrDefault(c => c.OrderId == PurchaseOrderId && c.ItemCode == Code && c.IsReceived && !c.IsDeleted);
                    if (data != null)
                    {
                        data.IsReceived = false;
                        if (db.Entry(data).State == EntityState.Detached)
                            db.Set<OrderedItem>().Attach(data);
                        db.Entry(data).State = EntityState.Modified;
                        db.SaveChanges();

                        var orderedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == PurchaseId && !c.IsDeleted)
                                             join oi in db.OrderedItems.Where(c => !c.IsReceived && !c.IsDeleted)
                                             on po.OrderUniqueId equals oi.OrderId
                                             join it in db.Items.Where(c => !c.IsDeleted)
                                             on oi.ItemCode equals it.Code
                                             select new
                                             {
                                                 oi.ItemCode,
                                                 it.PrintableName,
                                                 oi.Quantity
                                             }).ToList();
                        DGVOrderedItems.DataSource = orderedItems;

                        var receivedItems = (from po in db.PurchaseOrders.Where(c => c.OrderUniqueId == PurchaseId && !c.IsDeleted)
                                             join oi in db.OrderedItems.Where(c => c.IsReceived && !c.IsDeleted)
                                             on po.OrderUniqueId equals oi.OrderId
                                             join it in db.Items.Where(c => !c.IsDeleted)
                                             on oi.ItemCode equals it.Code
                                             select new
                                             {
                                                 oi.ItemCode,
                                                 it.PrintableName,
                                                 oi.Quantity
                                             }).ToList();
                        DGVReceivedItems.DataSource = receivedItems;
                    }
                }
            }
        }

        private void LstReceivedOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrderId = LstReceivedOrders.SelectedItem.ToString();
            LblPurchaseOrderId.Text = PurchaseOrderId;
        }
    }
}
