namespace SimpleBilling.MasterForms
{
    partial class PurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseOrder));
            this.BaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGVItemsToOrder = new System.Windows.Forms.DataGridView();
            this.TxtFilterItems = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnAddToOrder = new System.Windows.Forms.Button();
            this.LblOrderStatus = new System.Windows.Forms.Label();
            this.DtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.BtnCreateOrder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtOrderQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbUnitType = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.LstBoxPendingOrders = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnMarkReceived = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.LstReceivedOrders = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.DTReceivedOrder = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnViewAll = new System.Windows.Forms.Button();
            this.LblDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.DGVOrderedItems = new System.Windows.Forms.DataGridView();
            this.DGVReceivedItems = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnExportPDF = new System.Windows.Forms.Button();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.CmbSuppliers = new System.Windows.Forms.ComboBox();
            this.BaseLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVItemsToOrder)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrderedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceivedItems)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 3;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.17139F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.82861F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 401F));
            this.BaseLayout.Controls.Add(this.label2, 1, 0);
            this.BaseLayout.Controls.Add(this.label1, 0, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.BaseLayout.Controls.Add(this.tabControl1, 2, 1);
            this.BaseLayout.Controls.Add(this.LblDate, 2, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(0, 0);
            this.BaseLayout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 3;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.922912F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.07709F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.BaseLayout.Size = new System.Drawing.Size(1201, 512);
            this.BaseLayout.TabIndex = 0;
            this.BaseLayout.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BaseLayout_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(413, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Items to order";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ordered items";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DGVItemsToOrder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtFilterItems, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(412, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.912442F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.08755F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 434);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // DGVItemsToOrder
            // 
            this.DGVItemsToOrder.AllowUserToAddRows = false;
            this.DGVItemsToOrder.AllowUserToDeleteRows = false;
            this.DGVItemsToOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVItemsToOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVItemsToOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVItemsToOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVItemsToOrder.Location = new System.Drawing.Point(4, 33);
            this.DGVItemsToOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVItemsToOrder.Name = "DGVItemsToOrder";
            this.DGVItemsToOrder.ReadOnly = true;
            this.DGVItemsToOrder.Size = new System.Drawing.Size(376, 398);
            this.DGVItemsToOrder.TabIndex = 5;
            this.DGVItemsToOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVItemsToOrder_CellClick);
            this.DGVItemsToOrder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DGVItemsToOrder_MouseUp);
            // 
            // TxtFilterItems
            // 
            this.TxtFilterItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtFilterItems.Location = new System.Drawing.Point(3, 3);
            this.TxtFilterItems.Name = "TxtFilterItems";
            this.TxtFilterItems.Size = new System.Drawing.Size(378, 26);
            this.TxtFilterItems.TabIndex = 0;
            this.TxtFilterItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtFilterItems_KeyUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(802, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(396, 434);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseMove);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(388, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Order";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BtnRemove, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.BtnAddToOrder, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.LblOrderStatus, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.BtnCreateOrder, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.TxtOrderQuantity, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.CmbUnitType, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.564232F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.07557F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.823678F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.33501F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.060453F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.83123F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.57934F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(382, 397);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BtnRemove
            // 
            this.BtnRemove.BackColor = System.Drawing.Color.White;
            this.BtnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRemove.Location = new System.Drawing.Point(3, 335);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(376, 34);
            this.BtnRemove.TabIndex = 9;
            this.BtnRemove.Text = "Remove from Order";
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnAddToOrder
            // 
            this.BtnAddToOrder.BackColor = System.Drawing.Color.White;
            this.BtnAddToOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddToOrder.Location = new System.Drawing.Point(3, 294);
            this.BtnAddToOrder.Name = "BtnAddToOrder";
            this.BtnAddToOrder.Size = new System.Drawing.Size(376, 35);
            this.BtnAddToOrder.TabIndex = 8;
            this.BtnAddToOrder.Text = "Add To Order";
            this.BtnAddToOrder.UseVisualStyleBackColor = false;
            this.BtnAddToOrder.Click += new System.EventHandler(this.BtnAddToOrder_Click);
            // 
            // LblOrderStatus
            // 
            this.LblOrderStatus.AutoSize = true;
            this.LblOrderStatus.ForeColor = System.Drawing.Color.White;
            this.LblOrderStatus.Location = new System.Drawing.Point(3, 106);
            this.LblOrderStatus.Name = "LblOrderStatus";
            this.LblOrderStatus.Size = new System.Drawing.Size(53, 18);
            this.LblOrderStatus.TabIndex = 3;
            this.LblOrderStatus.Text = "Ready";
            // 
            // DtpOrderDate
            // 
            this.DtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpOrderDate.Location = new System.Drawing.Point(3, 3);
            this.DtpOrderDate.Name = "DtpOrderDate";
            this.DtpOrderDate.Size = new System.Drawing.Size(182, 26);
            this.DtpOrderDate.TabIndex = 0;
            this.DtpOrderDate.ValueChanged += new System.EventHandler(this.DtpOrderDate_ValueChanged);
            // 
            // BtnCreateOrder
            // 
            this.BtnCreateOrder.BackColor = System.Drawing.Color.White;
            this.BtnCreateOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCreateOrder.Location = new System.Drawing.Point(3, 40);
            this.BtnCreateOrder.Name = "BtnCreateOrder";
            this.BtnCreateOrder.Size = new System.Drawing.Size(376, 31);
            this.BtnCreateOrder.TabIndex = 1;
            this.BtnCreateOrder.Text = "Create Order";
            this.BtnCreateOrder.UseVisualStyleBackColor = false;
            this.BtnCreateOrder.Click += new System.EventHandler(this.BtnCreateOrder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Order Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Enter Order Quantity";
            // 
            // TxtOrderQuantity
            // 
            this.TxtOrderQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtOrderQuantity.Location = new System.Drawing.Point(3, 184);
            this.TxtOrderQuantity.Name = "TxtOrderQuantity";
            this.TxtOrderQuantity.Size = new System.Drawing.Size(376, 26);
            this.TxtOrderQuantity.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(376, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Unit Type";
            // 
            // CmbUnitType
            // 
            this.CmbUnitType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbUnitType.FormattingEnabled = true;
            this.CmbUnitType.Items.AddRange(new object[] {
            "PCS",
            "DRUM",
            "PAIL",
            "PCKT",
            "FEET",
            "INCHES",
            "LITRE",
            "KILO GRAM",
            "GRAM",
            "MILLI LITRE"});
            this.CmbUnitType.Location = new System.Drawing.Point(3, 257);
            this.CmbUnitType.Name = "CmbUnitType";
            this.CmbUnitType.Size = new System.Drawing.Size(376, 26);
            this.CmbUnitType.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DimGray;
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(387, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pending Orders";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.LstBoxPendingOrders, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.5592F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.44081F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(381, 397);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // LstBoxPendingOrders
            // 
            this.LstBoxPendingOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstBoxPendingOrders.FormattingEnabled = true;
            this.LstBoxPendingOrders.ItemHeight = 18;
            this.LstBoxPendingOrders.Location = new System.Drawing.Point(3, 3);
            this.LstBoxPendingOrders.Name = "LstBoxPendingOrders";
            this.LstBoxPendingOrders.Size = new System.Drawing.Size(375, 289);
            this.LstBoxPendingOrders.TabIndex = 0;
            this.LstBoxPendingOrders.Click += new System.EventHandler(this.LstBoxPendingOrders_Click);
            this.LstBoxPendingOrders.DoubleClick += new System.EventHandler(this.LstBoxPendingOrders_DoubleClick);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.BtnMarkReceived, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 298);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.58333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.29167F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.16667F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(375, 96);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // BtnMarkReceived
            // 
            this.BtnMarkReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnMarkReceived.Location = new System.Drawing.Point(3, 3);
            this.BtnMarkReceived.Name = "BtnMarkReceived";
            this.BtnMarkReceived.Size = new System.Drawing.Size(369, 31);
            this.BtnMarkReceived.TabIndex = 0;
            this.BtnMarkReceived.Text = "Mark As Received";
            this.BtnMarkReceived.UseVisualStyleBackColor = true;
            this.BtnMarkReceived.Click += new System.EventHandler(this.BtnMarkReceived_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DimGray;
            this.tabPage3.Controls.Add(this.tableLayoutPanel7);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(387, 403);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Received Orders";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.LstReceivedOrders, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.BtnViewAll, 0, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.340659F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.65934F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(387, 403);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // LstReceivedOrders
            // 
            this.LstReceivedOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstReceivedOrders.FormattingEnabled = true;
            this.LstReceivedOrders.ItemHeight = 18;
            this.LstReceivedOrders.Location = new System.Drawing.Point(3, 37);
            this.LstReceivedOrders.Name = "LstReceivedOrders";
            this.LstReceivedOrders.Size = new System.Drawing.Size(381, 324);
            this.LstReceivedOrders.TabIndex = 0;
            this.LstReceivedOrders.DoubleClick += new System.EventHandler(this.LstReceivedOrders_DoubleClick);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.DTReceivedOrder, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(381, 28);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // DTReceivedOrder
            // 
            this.DTReceivedOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTReceivedOrder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTReceivedOrder.Location = new System.Drawing.Point(193, 3);
            this.DTReceivedOrder.Name = "DTReceivedOrder";
            this.DTReceivedOrder.Size = new System.Drawing.Size(185, 26);
            this.DTReceivedOrder.TabIndex = 1;
            this.DTReceivedOrder.ValueChanged += new System.EventHandler(this.DTReceivedOrder_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Filter by Date";
            // 
            // BtnViewAll
            // 
            this.BtnViewAll.BackColor = System.Drawing.Color.White;
            this.BtnViewAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnViewAll.Location = new System.Drawing.Point(3, 367);
            this.BtnViewAll.Name = "BtnViewAll";
            this.BtnViewAll.Size = new System.Drawing.Size(381, 33);
            this.BtnViewAll.TabIndex = 3;
            this.BtnViewAll.Text = "View All";
            this.BtnViewAll.UseVisualStyleBackColor = false;
            this.BtnViewAll.Click += new System.EventHandler(this.BtnViewAll_Click);
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.ForeColor = System.Drawing.Color.Lime;
            this.LblDate.Location = new System.Drawing.Point(802, 0);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(50, 18);
            this.LblDate.TabIndex = 6;
            this.LblDate.Text = "label6";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 40);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(403, 434);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.DGVOrderedItems, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.DGVReceivedItems, 0, 2);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(397, 428);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(4, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(389, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Received items";
            // 
            // DGVOrderedItems
            // 
            this.DGVOrderedItems.AllowUserToAddRows = false;
            this.DGVOrderedItems.AllowUserToDeleteRows = false;
            this.DGVOrderedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVOrderedItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVOrderedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOrderedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVOrderedItems.Location = new System.Drawing.Point(4, 3);
            this.DGVOrderedItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVOrderedItems.Name = "DGVOrderedItems";
            this.DGVOrderedItems.ReadOnly = true;
            this.DGVOrderedItems.Size = new System.Drawing.Size(389, 208);
            this.DGVOrderedItems.TabIndex = 1;
            this.DGVOrderedItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVOrderedItems_CellClick);
            this.DGVOrderedItems.DoubleClick += new System.EventHandler(this.DGVOrderedItems_DoubleClick);
            this.DGVOrderedItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DGVOrderedItems_MouseMove);
            // 
            // DGVReceivedItems
            // 
            this.DGVReceivedItems.AllowUserToAddRows = false;
            this.DGVReceivedItems.AllowUserToDeleteRows = false;
            this.DGVReceivedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVReceivedItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVReceivedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReceivedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVReceivedItems.Location = new System.Drawing.Point(3, 234);
            this.DGVReceivedItems.Name = "DGVReceivedItems";
            this.DGVReceivedItems.ReadOnly = true;
            this.DGVReceivedItems.Size = new System.Drawing.Size(391, 191);
            this.DGVReceivedItems.TabIndex = 2;
            this.DGVReceivedItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGVReceivedItems_MouseClick);
            this.DGVReceivedItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DGVReceivedItems_MouseMove);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.BtnExportPDF, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 480);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(403, 29);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // BtnExportPDF
            // 
            this.BtnExportPDF.BackColor = System.Drawing.Color.White;
            this.BtnExportPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExportPDF.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportPDF.Location = new System.Drawing.Point(3, 3);
            this.BtnExportPDF.Name = "BtnExportPDF";
            this.BtnExportPDF.Size = new System.Drawing.Size(195, 23);
            this.BtnExportPDF.TabIndex = 0;
            this.BtnExportPDF.Text = "Export As PDF";
            this.BtnExportPDF.UseVisualStyleBackColor = false;
            this.BtnExportPDF.Click += new System.EventHandler(this.BtnExportPDF_Click);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.DtpOrderDate, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.CmbSuppliers, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(376, 31);
            this.tableLayoutPanel10.TabIndex = 11;
            // 
            // CmbSuppliers
            // 
            this.CmbSuppliers.FormattingEnabled = true;
            this.CmbSuppliers.Location = new System.Drawing.Point(191, 3);
            this.CmbSuppliers.Name = "CmbSuppliers";
            this.CmbSuppliers.Size = new System.Drawing.Size(182, 26);
            this.CmbSuppliers.TabIndex = 1;
            // 
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1201, 512);
            this.Controls.Add(this.BaseLayout);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.PurchaseOrder_Load);
            this.BaseLayout.ResumeLayout(false);
            this.BaseLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVItemsToOrder)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrderedItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceivedItems)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVOrderedItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DGVItemsToOrder;
        private System.Windows.Forms.TextBox TxtFilterItems;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker DtpOrderDate;
        private System.Windows.Forms.Button BtnCreateOrder;
        private System.Windows.Forms.Label LblOrderStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtOrderQuantity;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnAddToOrder;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListBox LstBoxPendingOrders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button BtnExportPDF;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button BtnMarkReceived;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.ListBox LstReceivedOrders;
        private System.Windows.Forms.DateTimePicker DTReceivedOrder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnViewAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.DataGridView DGVReceivedItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbUnitType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.ComboBox CmbSuppliers;
    }
}