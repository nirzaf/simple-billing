namespace SimpleBilling.MasterForms
{
    partial class ManageGRN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageGRN));
            this.DGVGRNList = new System.Windows.Forms.DataGridView();
            this.gRNDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CRUDPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbProduct = new System.Windows.Forms.ComboBox();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.TxtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtUnitCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDiscount = new System.Windows.Forms.TextBox();
            this.CMBSupplier = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.DTPDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtReference = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtGRNNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.itemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.MessageTimer = new System.Windows.Forms.Timer(this.components);
            this.BtnComplete = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LblGrossTotal = new System.Windows.Forms.Label();
            this.LblTotalDiscount = new System.Windows.Forms.Label();
            this.LblNetTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnApprove = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnLoadInvoice = new System.Windows.Forms.Button();
            this.BaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnGRNReturn = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.PaymentLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TxtGivenAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CmbPaymentOptions = new System.Windows.Forms.ComboBox();
            this.LblBalanceAmount = new System.Windows.Forms.Label();
            this.CmbChooseCheques = new System.Windows.Forms.ComboBox();
            this.BtnAddCheque = new System.Windows.Forms.Button();
            this.LayoutCheque = new System.Windows.Forms.TableLayoutPanel();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.TxtPayeeName = new System.Windows.Forms.TextBox();
            this.TxtChequeNo = new System.Windows.Forms.TextBox();
            this.DTChequeDueDate = new System.Windows.Forms.DateTimePicker();
            this.CmbPaidBy = new System.Windows.Forms.ComboBox();
            this.CmbBank = new System.Windows.Forms.ComboBox();
            this.LblPaymentStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGRNList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRNDetailsBindingSource)).BeginInit();
            this.CRUDPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.BaseLayout.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.PaymentLayout.SuspendLayout();
            this.LayoutCheque.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVGRNList
            // 
            this.DGVGRNList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVGRNList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGRNList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVGRNList.Location = new System.Drawing.Point(3, 128);
            this.DGVGRNList.Name = "DGVGRNList";
            this.DGVGRNList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVGRNList.Size = new System.Drawing.Size(1056, 197);
            this.DGVGRNList.TabIndex = 0;
            this.DGVGRNList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVGRNList_CellClick);
            // 
            // CRUDPanel
            // 
            this.CRUDPanel.Controls.Add(this.tableLayoutPanel1);
            this.CRUDPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRUDPanel.Location = new System.Drawing.Point(3, 3);
            this.CRUDPanel.Name = "CRUDPanel";
            this.CRUDPanel.Size = new System.Drawing.Size(1056, 119);
            this.CRUDPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CmbProduct, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtQuantity, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtUnitCost, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtDiscount, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.CMBSupplier, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.DTPDate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtReference, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtGRNNo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblStatus, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnAddItem, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.23932F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.64103F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.65812F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.17094F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1056, 119);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product";
            // 
            // CmbProduct
            // 
            this.CmbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbProduct.DataSource = this.itemBindingSource;
            this.CmbProduct.DisplayMember = "ItemName";
            this.CmbProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbProduct.FormattingEnabled = true;
            this.CmbProduct.Location = new System.Drawing.Point(3, 74);
            this.CmbProduct.Name = "CmbProduct";
            this.CmbProduct.Size = new System.Drawing.Size(205, 27);
            this.CmbProduct.TabIndex = 9;
            this.CmbProduct.ValueMember = "Id";
            this.CmbProduct.SelectedIndexChanged += new System.EventHandler(this.CmbProduct_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(214, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quantity";
            // 
            // TxtQuantity
            // 
            this.TxtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtQuantity.Location = new System.Drawing.Point(214, 74);
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.Size = new System.Drawing.Size(205, 26);
            this.TxtQuantity.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(425, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Unit Cost";
            // 
            // TxtUnitCost
            // 
            this.TxtUnitCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUnitCost.Location = new System.Drawing.Point(425, 74);
            this.TxtUnitCost.Name = "TxtUnitCost";
            this.TxtUnitCost.Size = new System.Drawing.Size(205, 26);
            this.TxtUnitCost.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(636, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Discount";
            // 
            // TxtDiscount
            // 
            this.TxtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDiscount.Location = new System.Drawing.Point(636, 74);
            this.TxtDiscount.Name = "TxtDiscount";
            this.TxtDiscount.Size = new System.Drawing.Size(205, 26);
            this.TxtDiscount.TabIndex = 5;
            // 
            // CMBSupplier
            // 
            this.CMBSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CMBSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMBSupplier.DataSource = this.supplierBindingSource;
            this.CMBSupplier.DisplayMember = "Name";
            this.CMBSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CMBSupplier.FormattingEnabled = true;
            this.CMBSupplier.Location = new System.Drawing.Point(636, 22);
            this.CMBSupplier.Name = "CMBSupplier";
            this.CMBSupplier.Size = new System.Drawing.Size(205, 27);
            this.CMBSupplier.TabIndex = 13;
            this.CMBSupplier.ValueMember = "SupplierId";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(636, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Supplier";
            // 
            // DTPDate
            // 
            this.DTPDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTPDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDate.Location = new System.Drawing.Point(425, 22);
            this.DTPDate.Name = "DTPDate";
            this.DTPDate.Size = new System.Drawing.Size(205, 26);
            this.DTPDate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(425, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // TxtReference
            // 
            this.TxtReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtReference.Location = new System.Drawing.Point(214, 22);
            this.TxtReference.Name = "TxtReference";
            this.TxtReference.Size = new System.Drawing.Size(205, 26);
            this.TxtReference.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(214, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reference No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "GRN No";
            // 
            // TxtGRNNo
            // 
            this.TxtGRNNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGRNNo.Location = new System.Drawing.Point(3, 22);
            this.TxtGRNNo.Name = "TxtGRNNo";
            this.TxtGRNNo.Size = new System.Drawing.Size(205, 26);
            this.TxtGRNNo.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(847, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(206, 19);
            this.label12.TabIndex = 19;
            this.label12.Text = "Status";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblStatus.ForeColor = System.Drawing.Color.Yellow;
            this.LblStatus.Location = new System.Drawing.Point(847, 19);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(206, 30);
            this.LblStatus.TabIndex = 20;
            this.LblStatus.Text = "Invoice Status";
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.BackColor = System.Drawing.Color.White;
            this.BtnAddItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddItem.Location = new System.Drawing.Point(847, 74);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(206, 42);
            this.BtnAddItem.TabIndex = 15;
            this.BtnAddItem.Text = "Add";
            this.BtnAddItem.UseVisualStyleBackColor = false;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // MessageTimer
            // 
            this.MessageTimer.Enabled = true;
            this.MessageTimer.Interval = 10000;
            // 
            // BtnComplete
            // 
            this.BtnComplete.BackColor = System.Drawing.Color.White;
            this.BtnComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnComplete.Location = new System.Drawing.Point(3, 159);
            this.BtnComplete.Name = "BtnComplete";
            this.BtnComplete.Size = new System.Drawing.Size(161, 35);
            this.BtnComplete.TabIndex = 3;
            this.BtnComplete.Text = "Done";
            this.BtnComplete.UseVisualStyleBackColor = false;
            this.BtnComplete.Click += new System.EventHandler(this.BtnComplete_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.LblGrossTotal, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.LblTotalDiscount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.LblNetTotal, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(636, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(417, 125);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "Total Discount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 19);
            this.label11.TabIndex = 2;
            this.label11.Text = "Net Total";
            // 
            // LblGrossTotal
            // 
            this.LblGrossTotal.AutoSize = true;
            this.LblGrossTotal.Location = new System.Drawing.Point(212, 1);
            this.LblGrossTotal.Name = "LblGrossTotal";
            this.LblGrossTotal.Size = new System.Drawing.Size(18, 19);
            this.LblGrossTotal.TabIndex = 3;
            this.LblGrossTotal.Text = "0";
            // 
            // LblTotalDiscount
            // 
            this.LblTotalDiscount.AutoSize = true;
            this.LblTotalDiscount.Location = new System.Drawing.Point(212, 32);
            this.LblTotalDiscount.Name = "LblTotalDiscount";
            this.LblTotalDiscount.Size = new System.Drawing.Size(18, 19);
            this.LblTotalDiscount.TabIndex = 4;
            this.LblTotalDiscount.Text = "0";
            // 
            // LblNetTotal
            // 
            this.LblNetTotal.AutoSize = true;
            this.LblNetTotal.Location = new System.Drawing.Point(212, 63);
            this.LblNetTotal.Name = "LblNetTotal";
            this.LblNetTotal.Size = new System.Drawing.Size(18, 19);
            this.LblNetTotal.TabIndex = 5;
            this.LblNetTotal.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Gross Total";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.BtnApprove, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.BtnDelete, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnComplete, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1065, 128);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(167, 197);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // BtnApprove
            // 
            this.BtnApprove.BackColor = System.Drawing.Color.White;
            this.BtnApprove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnApprove.Location = new System.Drawing.Point(3, 120);
            this.BtnApprove.Name = "BtnApprove";
            this.BtnApprove.Size = new System.Drawing.Size(161, 33);
            this.BtnApprove.TabIndex = 17;
            this.BtnApprove.Text = "Approve";
            this.BtnApprove.UseVisualStyleBackColor = false;
            this.BtnApprove.Click += new System.EventHandler(this.BtnApprove_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.White;
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Location = new System.Drawing.Point(3, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(161, 33);
            this.BtnDelete.TabIndex = 16;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnLoadInvoice
            // 
            this.BtnLoadInvoice.BackColor = System.Drawing.Color.White;
            this.BtnLoadInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnLoadInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoadInvoice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnLoadInvoice.FlatAppearance.BorderSize = 0;
            this.BtnLoadInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnLoadInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnLoadInvoice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadInvoice.Location = new System.Drawing.Point(3, 3);
            this.BtnLoadInvoice.Name = "BtnLoadInvoice";
            this.BtnLoadInvoice.Size = new System.Drawing.Size(161, 53);
            this.BtnLoadInvoice.TabIndex = 15;
            this.BtnLoadInvoice.Text = "Load Invoice";
            this.BtnLoadInvoice.UseVisualStyleBackColor = false;
            this.BtnLoadInvoice.Click += new System.EventHandler(this.BtnLoadInvoice_Click);
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 2;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.BaseLayout.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.BaseLayout.Controls.Add(this.DGVGRNList, 0, 1);
            this.BaseLayout.Controls.Add(this.CRUDPanel, 0, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.BaseLayout.Controls.Add(this.LayoutCheque, 0, 3);
            this.BaseLayout.Controls.Add(this.LblPaymentStatus, 1, 3);
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(0, 0);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 4;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.63745F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.49004F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.171315F));
            this.BaseLayout.Size = new System.Drawing.Size(1235, 502);
            this.BaseLayout.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.BtnLoadInvoice, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnGRNReturn, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1065, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(167, 119);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // BtnGRNReturn
            // 
            this.BtnGRNReturn.BackColor = System.Drawing.Color.White;
            this.BtnGRNReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGRNReturn.Location = new System.Drawing.Point(3, 62);
            this.BtnGRNReturn.Name = "BtnGRNReturn";
            this.BtnGRNReturn.Size = new System.Drawing.Size(161, 54);
            this.BtnGRNReturn.TabIndex = 16;
            this.BtnGRNReturn.Text = "Return Invoice";
            this.BtnGRNReturn.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.PaymentLayout, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 331);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1056, 131);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // PaymentLayout
            // 
            this.PaymentLayout.ColumnCount = 2;
            this.PaymentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PaymentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PaymentLayout.Controls.Add(this.TxtGivenAmount, 1, 2);
            this.PaymentLayout.Controls.Add(this.label13, 0, 0);
            this.PaymentLayout.Controls.Add(this.label14, 0, 2);
            this.PaymentLayout.Controls.Add(this.label15, 0, 3);
            this.PaymentLayout.Controls.Add(this.CmbPaymentOptions, 1, 0);
            this.PaymentLayout.Controls.Add(this.LblBalanceAmount, 1, 3);
            this.PaymentLayout.Controls.Add(this.CmbChooseCheques, 1, 1);
            this.PaymentLayout.Controls.Add(this.BtnAddCheque, 0, 1);
            this.PaymentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaymentLayout.Location = new System.Drawing.Point(3, 3);
            this.PaymentLayout.Name = "PaymentLayout";
            this.PaymentLayout.RowCount = 4;
            this.PaymentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PaymentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PaymentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PaymentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PaymentLayout.Size = new System.Drawing.Size(627, 125);
            this.PaymentLayout.TabIndex = 5;
            // 
            // TxtGivenAmount
            // 
            this.TxtGivenAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGivenAmount.Location = new System.Drawing.Point(316, 65);
            this.TxtGivenAmount.Name = "TxtGivenAmount";
            this.TxtGivenAmount.Size = new System.Drawing.Size(308, 26);
            this.TxtGivenAmount.TabIndex = 6;
            this.TxtGivenAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGivenAmount_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 19);
            this.label13.TabIndex = 0;
            this.label13.Text = "Payment Options";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 19);
            this.label14.TabIndex = 1;
            this.label14.Text = "Given Amount";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 19);
            this.label15.TabIndex = 2;
            this.label15.Text = "Balance Amount";
            // 
            // CmbPaymentOptions
            // 
            this.CmbPaymentOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbPaymentOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPaymentOptions.FormattingEnabled = true;
            this.CmbPaymentOptions.Items.AddRange(new object[] {
            "Cheque",
            "Cash",
            "Credit"});
            this.CmbPaymentOptions.Location = new System.Drawing.Point(316, 3);
            this.CmbPaymentOptions.Name = "CmbPaymentOptions";
            this.CmbPaymentOptions.Size = new System.Drawing.Size(308, 27);
            this.CmbPaymentOptions.TabIndex = 3;
            this.CmbPaymentOptions.SelectedIndexChanged += new System.EventHandler(this.CmbPaymentOptions_SelectedIndexChanged);
            // 
            // LblBalanceAmount
            // 
            this.LblBalanceAmount.AutoSize = true;
            this.LblBalanceAmount.ForeColor = System.Drawing.Color.White;
            this.LblBalanceAmount.Location = new System.Drawing.Point(316, 93);
            this.LblBalanceAmount.Name = "LblBalanceAmount";
            this.LblBalanceAmount.Size = new System.Drawing.Size(18, 19);
            this.LblBalanceAmount.TabIndex = 7;
            this.LblBalanceAmount.Text = "0";
            // 
            // CmbChooseCheques
            // 
            this.CmbChooseCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbChooseCheques.FormattingEnabled = true;
            this.CmbChooseCheques.Location = new System.Drawing.Point(316, 34);
            this.CmbChooseCheques.Name = "CmbChooseCheques";
            this.CmbChooseCheques.Size = new System.Drawing.Size(308, 27);
            this.CmbChooseCheques.TabIndex = 8;
            // 
            // BtnAddCheque
            // 
            this.BtnAddCheque.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAddCheque.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCheque.Location = new System.Drawing.Point(164, 34);
            this.BtnAddCheque.Name = "BtnAddCheque";
            this.BtnAddCheque.Size = new System.Drawing.Size(146, 25);
            this.BtnAddCheque.TabIndex = 4;
            this.BtnAddCheque.Text = "Add Cheque";
            this.BtnAddCheque.UseVisualStyleBackColor = true;
            this.BtnAddCheque.Click += new System.EventHandler(this.BtnAddCheque_Click);
            // 
            // LayoutCheque
            // 
            this.LayoutCheque.ColumnCount = 6;
            this.LayoutCheque.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.LayoutCheque.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.LayoutCheque.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.LayoutCheque.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.LayoutCheque.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.LayoutCheque.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.LayoutCheque.Controls.Add(this.TxtAmount, 2, 0);
            this.LayoutCheque.Controls.Add(this.TxtPayeeName, 1, 0);
            this.LayoutCheque.Controls.Add(this.TxtChequeNo, 0, 0);
            this.LayoutCheque.Controls.Add(this.DTChequeDueDate, 3, 0);
            this.LayoutCheque.Controls.Add(this.CmbPaidBy, 4, 0);
            this.LayoutCheque.Controls.Add(this.CmbBank, 5, 0);
            this.LayoutCheque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutCheque.Location = new System.Drawing.Point(3, 468);
            this.LayoutCheque.Name = "LayoutCheque";
            this.LayoutCheque.RowCount = 1;
            this.LayoutCheque.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutCheque.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.LayoutCheque.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.LayoutCheque.Size = new System.Drawing.Size(1056, 31);
            this.LayoutCheque.TabIndex = 8;
            // 
            // TxtAmount
            // 
            this.TxtAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtAmount.Location = new System.Drawing.Point(353, 3);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(169, 26);
            this.TxtAmount.TabIndex = 2;
            this.TxtAmount.Enter += new System.EventHandler(this.TxtAmount_Enter);
            this.TxtAmount.Leave += new System.EventHandler(this.TxtAmount_Leave);
            // 
            // TxtPayeeName
            // 
            this.TxtPayeeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPayeeName.Location = new System.Drawing.Point(178, 3);
            this.TxtPayeeName.Name = "TxtPayeeName";
            this.TxtPayeeName.Size = new System.Drawing.Size(169, 26);
            this.TxtPayeeName.TabIndex = 1;
            this.TxtPayeeName.Enter += new System.EventHandler(this.TxtPayeeName_Enter);
            this.TxtPayeeName.Leave += new System.EventHandler(this.TxtPayeeName_Leave);
            // 
            // TxtChequeNo
            // 
            this.TxtChequeNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtChequeNo.Location = new System.Drawing.Point(3, 3);
            this.TxtChequeNo.Name = "TxtChequeNo";
            this.TxtChequeNo.Size = new System.Drawing.Size(169, 26);
            this.TxtChequeNo.TabIndex = 0;
            this.TxtChequeNo.Enter += new System.EventHandler(this.TxtChequeNo_Enter);
            this.TxtChequeNo.Leave += new System.EventHandler(this.TxtChequeNo_Leave);
            // 
            // DTChequeDueDate
            // 
            this.DTChequeDueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTChequeDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTChequeDueDate.Location = new System.Drawing.Point(528, 3);
            this.DTChequeDueDate.Name = "DTChequeDueDate";
            this.DTChequeDueDate.Size = new System.Drawing.Size(169, 26);
            this.DTChequeDueDate.TabIndex = 3;
            // 
            // CmbPaidBy
            // 
            this.CmbPaidBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbPaidBy.FormattingEnabled = true;
            this.CmbPaidBy.Location = new System.Drawing.Point(703, 3);
            this.CmbPaidBy.Name = "CmbPaidBy";
            this.CmbPaidBy.Size = new System.Drawing.Size(169, 27);
            this.CmbPaidBy.TabIndex = 4;
            // 
            // CmbBank
            // 
            this.CmbBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbBank.FormattingEnabled = true;
            this.CmbBank.Location = new System.Drawing.Point(878, 3);
            this.CmbBank.Name = "CmbBank";
            this.CmbBank.Size = new System.Drawing.Size(175, 27);
            this.CmbBank.TabIndex = 5;
            // 
            // LblPaymentStatus
            // 
            this.LblPaymentStatus.AutoSize = true;
            this.LblPaymentStatus.ForeColor = System.Drawing.Color.White;
            this.LblPaymentStatus.Location = new System.Drawing.Point(1065, 465);
            this.LblPaymentStatus.Name = "LblPaymentStatus";
            this.LblPaymentStatus.Size = new System.Drawing.Size(129, 19);
            this.LblPaymentStatus.TabIndex = 9;
            this.LblPaymentStatus.Text = "Payment Status";
            // 
            // ManageGRN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1235, 502);
            this.Controls.Add(this.BaseLayout);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ManageGRN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Good Received Note";
            this.Load += new System.EventHandler(this.ManageGRN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVGRNList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRNDetailsBindingSource)).EndInit();
            this.CRUDPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.BaseLayout.ResumeLayout(false);
            this.BaseLayout.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.PaymentLayout.ResumeLayout(false);
            this.PaymentLayout.PerformLayout();
            this.LayoutCheque.ResumeLayout(false);
            this.LayoutCheque.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVGRNList;
        private System.Windows.Forms.Panel CRUDPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTPDate;
        private System.Windows.Forms.TextBox TxtQuantity;
        private System.Windows.Forms.TextBox TxtReference;
        private System.Windows.Forms.ComboBox CmbProduct;
        private System.Windows.Forms.TextBox TxtUnitCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CMBSupplier;
        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDiscount;
        private System.Windows.Forms.Timer MessageTimer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtGRNNo;
        private System.Windows.Forms.BindingSource gRNDetailsBindingSource;
        private System.Windows.Forms.Button BtnComplete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblGrossTotal;
        private System.Windows.Forms.Label LblTotalDiscount;
        private System.Windows.Forms.Label LblNetTotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button BtnLoadInvoice;
        private System.Windows.Forms.BindingSource itemBindingSource1;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Button BtnApprove;
        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button BtnGRNReturn;
        private System.Windows.Forms.TableLayoutPanel PaymentLayout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CmbPaymentOptions;
        private System.Windows.Forms.Button BtnAddCheque;
        private System.Windows.Forms.TextBox TxtGivenAmount;
        private System.Windows.Forms.Label LblBalanceAmount;
        private System.Windows.Forms.TableLayoutPanel LayoutCheque;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.TextBox TxtPayeeName;
        private System.Windows.Forms.TextBox TxtChequeNo;
        private System.Windows.Forms.DateTimePicker DTChequeDueDate;
        private System.Windows.Forms.ComboBox CmbPaidBy;
        private System.Windows.Forms.ComboBox CmbBank;
        private System.Windows.Forms.ComboBox CmbChooseCheques;
        private System.Windows.Forms.Label LblPaymentStatus;
    }
}