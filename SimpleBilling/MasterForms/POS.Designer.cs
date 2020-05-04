namespace SimpleBilling.MasterForms
{
    partial class POS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POS));
            this.LblDate = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.SystemTimer = new System.Windows.Forms.Timer(this.components);
            this.CmbAddItem = new System.Windows.Forms.ComboBox();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtBarCode = new System.Windows.Forms.TextBox();
            this.TxtProductCode = new System.Windows.Forms.TextBox();
            this.TxtUnitPrice = new System.Windows.Forms.TextBox();
            this.TxtDiscount = new System.Windows.Forms.TextBox();
            this.TxtSubTotal = new System.Windows.Forms.TextBox();
            this.TxtNetTotal = new System.Windows.Forms.TextBox();
            this.LblReceiptNo = new System.Windows.Forms.Label();
            this.LblCustomer = new System.Windows.Forms.Label();
            this.TxtCustomer = new System.Windows.Forms.TextBox();
            this.CmbVehicles = new System.Windows.Forms.ComboBox();
            this.ChkVehicle = new System.Windows.Forms.CheckBox();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGVReceiptBody = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LblCashier = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LblReceiptStatus = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LblNetTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblTotalDiscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblSubTotal = new System.Windows.Forms.Label();
            this.TxtGivenAmount = new System.Windows.Forms.TextBox();
            this.LblBalanceAmount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CmbPaymentOption = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.BtnVoid = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnLoadReceipt = new System.Windows.Forms.Button();
            this.BtnNewReceipt = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSaveAsQutation = new System.Windows.Forms.Button();
            this.ToolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiptBody)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblDate.ForeColor = System.Drawing.Color.Lime;
            this.LblDate.Location = new System.Drawing.Point(3, 121);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(164, 19);
            this.LblDate.TabIndex = 0;
            this.LblDate.Text = "Date";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblTime.ForeColor = System.Drawing.Color.Lime;
            this.LblTime.Location = new System.Drawing.Point(173, 121);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(144, 19);
            this.LblTime.TabIndex = 1;
            this.LblTime.Text = "Time";
            // 
            // SystemTimer
            // 
            this.SystemTimer.Enabled = true;
            this.SystemTimer.Tick += new System.EventHandler(this.SystemTimer_Tick);
            // 
            // CmbAddItem
            // 
            this.CmbAddItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbAddItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbAddItem.DataSource = this.itemBindingSource;
            this.CmbAddItem.DisplayMember = "ItemName";
            this.CmbAddItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbAddItem.FormattingEnabled = true;
            this.CmbAddItem.Location = new System.Drawing.Point(499, 59);
            this.CmbAddItem.Name = "CmbAddItem";
            this.CmbAddItem.Size = new System.Drawing.Size(242, 27);
            this.CmbAddItem.TabIndex = 2;
            this.CmbAddItem.ValueMember = "Id";
            this.CmbAddItem.SelectedIndexChanged += new System.EventHandler(this.CmbAddItem_SelectedIndexChanged);
            this.CmbAddItem.Enter += new System.EventHandler(this.CmbAddItem_Enter);
            this.CmbAddItem.Leave += new System.EventHandler(this.CmbAddItem_Leave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Controls.Add(this.TxtQuantity, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.CmbAddItem, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.TxtBarCode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtProductCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtUnitPrice, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtDiscount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.TxtSubTotal, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.TxtNetTotal, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.LblReceiptNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblCustomer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtCustomer, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CmbVehicles, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ChkVehicle, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 140);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // TxtQuantity
            // 
            this.TxtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtQuantity.Location = new System.Drawing.Point(3, 115);
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.Size = new System.Drawing.Size(242, 26);
            this.TxtQuantity.TabIndex = 3;
            this.TxtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantity_KeyDown);
            this.TxtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantity_KeyPress);
            this.TxtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtQuantity_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bar Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(251, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(499, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(747, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Unit Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(3, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(251, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Discount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(499, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(242, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Sub Total";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(747, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(242, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "Net Total";
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBarCode.Location = new System.Drawing.Point(3, 59);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(242, 26);
            this.TxtBarCode.TabIndex = 5;
            this.TxtBarCode.Enter += new System.EventHandler(this.TxtBarCode_Enter);
            this.TxtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyUp);
            // 
            // TxtProductCode
            // 
            this.TxtProductCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtProductCode.Location = new System.Drawing.Point(251, 59);
            this.TxtProductCode.Name = "TxtProductCode";
            this.TxtProductCode.Size = new System.Drawing.Size(242, 26);
            this.TxtProductCode.TabIndex = 6;
            // 
            // TxtUnitPrice
            // 
            this.TxtUnitPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUnitPrice.Location = new System.Drawing.Point(747, 59);
            this.TxtUnitPrice.Name = "TxtUnitPrice";
            this.TxtUnitPrice.ReadOnly = true;
            this.TxtUnitPrice.Size = new System.Drawing.Size(242, 26);
            this.TxtUnitPrice.TabIndex = 12;
            this.TxtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUnitPrice_KeyPress);
            // 
            // TxtDiscount
            // 
            this.TxtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDiscount.Location = new System.Drawing.Point(251, 115);
            this.TxtDiscount.Name = "TxtDiscount";
            this.TxtDiscount.Size = new System.Drawing.Size(242, 26);
            this.TxtDiscount.TabIndex = 4;
            this.TxtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDiscount_KeyDown);
            this.TxtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiscount_KeyPress);
            this.TxtDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtDiscount_KeyUp);
            // 
            // TxtSubTotal
            // 
            this.TxtSubTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtSubTotal.Location = new System.Drawing.Point(499, 115);
            this.TxtSubTotal.Name = "TxtSubTotal";
            this.TxtSubTotal.Size = new System.Drawing.Size(242, 26);
            this.TxtSubTotal.TabIndex = 7;
            // 
            // TxtNetTotal
            // 
            this.TxtNetTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtNetTotal.Location = new System.Drawing.Point(747, 115);
            this.TxtNetTotal.Name = "TxtNetTotal";
            this.TxtNetTotal.ReadOnly = true;
            this.TxtNetTotal.Size = new System.Drawing.Size(242, 26);
            this.TxtNetTotal.TabIndex = 8;
            // 
            // LblReceiptNo
            // 
            this.LblReceiptNo.AutoSize = true;
            this.LblReceiptNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblReceiptNo.ForeColor = System.Drawing.Color.Wheat;
            this.LblReceiptNo.Location = new System.Drawing.Point(3, 0);
            this.LblReceiptNo.Name = "LblReceiptNo";
            this.LblReceiptNo.Size = new System.Drawing.Size(242, 19);
            this.LblReceiptNo.TabIndex = 18;
            this.LblReceiptNo.Text = "ReceiptNo";
            // 
            // LblCustomer
            // 
            this.LblCustomer.AutoSize = true;
            this.LblCustomer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblCustomer.ForeColor = System.Drawing.Color.Lime;
            this.LblCustomer.Location = new System.Drawing.Point(251, 0);
            this.LblCustomer.Name = "LblCustomer";
            this.LblCustomer.Size = new System.Drawing.Size(84, 19);
            this.LblCustomer.TabIndex = 17;
            this.LblCustomer.Text = "Customer";
            // 
            // TxtCustomer
            // 
            this.TxtCustomer.Location = new System.Drawing.Point(499, 3);
            this.TxtCustomer.Name = "TxtCustomer";
            this.TxtCustomer.Size = new System.Drawing.Size(242, 26);
            this.TxtCustomer.TabIndex = 1;
            this.TxtCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCustomer_KeyUp);
            // 
            // CmbVehicles
            // 
            this.CmbVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVehicles.Enabled = false;
            this.CmbVehicles.FormattingEnabled = true;
            this.CmbVehicles.Location = new System.Drawing.Point(747, 3);
            this.CmbVehicles.Name = "CmbVehicles";
            this.CmbVehicles.Size = new System.Drawing.Size(242, 27);
            this.CmbVehicles.TabIndex = 19;
            // 
            // ChkVehicle
            // 
            this.ChkVehicle.AutoSize = true;
            this.ChkVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkVehicle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChkVehicle.Location = new System.Drawing.Point(995, 3);
            this.ChkVehicle.Name = "ChkVehicle";
            this.ChkVehicle.Size = new System.Drawing.Size(26, 22);
            this.ChkVehicle.TabIndex = 20;
            this.ChkVehicle.UseVisualStyleBackColor = true;
            this.ChkVehicle.MouseHover += new System.EventHandler(this.ChkVehicle_MouseHover);
            // 
            // DGVReceiptBody
            // 
            this.DGVReceiptBody.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVReceiptBody.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVReceiptBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReceiptBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVReceiptBody.Location = new System.Drawing.Point(3, 149);
            this.DGVReceiptBody.MultiSelect = false;
            this.DGVReceiptBody.Name = "DGVReceiptBody";
            this.DGVReceiptBody.ReadOnly = true;
            this.DGVReceiptBody.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVReceiptBody.Size = new System.Drawing.Size(1024, 286);
            this.DGVReceiptBody.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.64844F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.55469F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.LblDate, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.LblTime, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.LblCashier, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label11, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.LblReceiptStatus, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.label13, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.LblNetTotal, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.LblTotalDiscount, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.LblSubTotal, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtGivenAmount, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.LblBalanceAmount, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.CmbPaymentOption, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label16, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 441);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1024, 140);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // LblCashier
            // 
            this.LblCashier.AutoSize = true;
            this.LblCashier.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblCashier.ForeColor = System.Drawing.Color.Lime;
            this.LblCashier.Location = new System.Drawing.Point(323, 121);
            this.LblCashier.Name = "LblCashier";
            this.LblCashier.Size = new System.Drawing.Size(184, 19);
            this.LblCashier.TabIndex = 12;
            this.LblCashier.Text = "Cashier";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(683, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 19);
            this.label11.TabIndex = 10;
            this.label11.Text = "Receipt Status";
            // 
            // LblReceiptStatus
            // 
            this.LblReceiptStatus.AutoSize = true;
            this.LblReceiptStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblReceiptStatus.ForeColor = System.Drawing.Color.Yellow;
            this.LblReceiptStatus.Location = new System.Drawing.Point(853, 121);
            this.LblReceiptStatus.Name = "LblReceiptStatus";
            this.LblReceiptStatus.Size = new System.Drawing.Size(168, 19);
            this.LblReceiptStatus.TabIndex = 11;
            this.LblReceiptStatus.Text = "Ready";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(683, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 28);
            this.label13.TabIndex = 4;
            this.label13.Text = "Net Total";
            // 
            // LblNetTotal
            // 
            this.LblNetTotal.AutoSize = true;
            this.LblNetTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblNetTotal.ForeColor = System.Drawing.Color.White;
            this.LblNetTotal.Location = new System.Drawing.Point(853, 56);
            this.LblNetTotal.Name = "LblNetTotal";
            this.LblNetTotal.Size = new System.Drawing.Size(168, 28);
            this.LblNetTotal.TabIndex = 5;
            this.LblNetTotal.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(683, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 28);
            this.label10.TabIndex = 1;
            this.label10.Text = "Total Discount";
            // 
            // LblTotalDiscount
            // 
            this.LblTotalDiscount.AutoSize = true;
            this.LblTotalDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTotalDiscount.ForeColor = System.Drawing.Color.White;
            this.LblTotalDiscount.Location = new System.Drawing.Point(853, 28);
            this.LblTotalDiscount.Name = "LblTotalDiscount";
            this.LblTotalDiscount.Size = new System.Drawing.Size(168, 28);
            this.LblTotalDiscount.TabIndex = 3;
            this.LblTotalDiscount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(683, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 28);
            this.label9.TabIndex = 0;
            this.label9.Text = "Gross Total";
            // 
            // LblSubTotal
            // 
            this.LblSubTotal.AutoSize = true;
            this.LblSubTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblSubTotal.ForeColor = System.Drawing.Color.White;
            this.LblSubTotal.Location = new System.Drawing.Point(853, 0);
            this.LblSubTotal.Name = "LblSubTotal";
            this.LblSubTotal.Size = new System.Drawing.Size(168, 28);
            this.LblSubTotal.TabIndex = 2;
            this.LblSubTotal.Text = "0";
            // 
            // TxtGivenAmount
            // 
            this.TxtGivenAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGivenAmount.Location = new System.Drawing.Point(513, 31);
            this.TxtGivenAmount.Name = "TxtGivenAmount";
            this.TxtGivenAmount.Size = new System.Drawing.Size(164, 26);
            this.TxtGivenAmount.TabIndex = 9;
            this.TxtGivenAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGivenAmount_KeyDown);
            this.TxtGivenAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtGivenAmount_KeyUp);
            // 
            // LblBalanceAmount
            // 
            this.LblBalanceAmount.AutoSize = true;
            this.LblBalanceAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblBalanceAmount.ForeColor = System.Drawing.Color.White;
            this.LblBalanceAmount.Location = new System.Drawing.Point(513, 65);
            this.LblBalanceAmount.Name = "LblBalanceAmount";
            this.LblBalanceAmount.Size = new System.Drawing.Size(164, 19);
            this.LblBalanceAmount.TabIndex = 9;
            this.LblBalanceAmount.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label12.Location = new System.Drawing.Point(323, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(184, 28);
            this.label12.TabIndex = 13;
            this.label12.Text = "Given Amount";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label15.Location = new System.Drawing.Point(323, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 19);
            this.label15.TabIndex = 14;
            this.label15.Text = "Balance Amount";
            // 
            // CmbPaymentOption
            // 
            this.CmbPaymentOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbPaymentOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPaymentOption.FormattingEnabled = true;
            this.CmbPaymentOption.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Cheque",
            "Credit"});
            this.CmbPaymentOption.Location = new System.Drawing.Point(513, 3);
            this.CmbPaymentOption.Name = "CmbPaymentOption";
            this.CmbPaymentOption.Size = new System.Drawing.Size(164, 27);
            this.CmbPaymentOption.TabIndex = 15;
            this.CmbPaymentOption.SelectedIndexChanged += new System.EventHandler(this.CmbPaymentOption_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label16.Location = new System.Drawing.Point(323, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(182, 19);
            this.label16.TabIndex = 16;
            this.label16.Text = "Select Payment Option";
            // 
            // BtnVoid
            // 
            this.BtnVoid.BackColor = System.Drawing.Color.White;
            this.BtnVoid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnVoid.Location = new System.Drawing.Point(3, 73);
            this.BtnVoid.Name = "BtnVoid";
            this.BtnVoid.Size = new System.Drawing.Size(103, 64);
            this.BtnVoid.TabIndex = 7;
            this.BtnVoid.Text = "Void";
            this.BtnVoid.UseVisualStyleBackColor = false;
            this.BtnVoid.Click += new System.EventHandler(this.BtnVoid_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackColor = System.Drawing.Color.White;
            this.BtnPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPrint.Location = new System.Drawing.Point(3, 3);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(103, 64);
            this.BtnPrint.TabIndex = 6;
            this.BtnPrint.Text = "Print";
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DGVReceiptBody, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1145, 584);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.BtnPrint, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnVoid, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1033, 441);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(109, 140);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.BtnLoadReceipt, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.BtnNewReceipt, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1033, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(109, 140);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // BtnLoadReceipt
            // 
            this.BtnLoadReceipt.BackColor = System.Drawing.Color.White;
            this.BtnLoadReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoadReceipt.Location = new System.Drawing.Point(3, 3);
            this.BtnLoadReceipt.Name = "BtnLoadReceipt";
            this.BtnLoadReceipt.Size = new System.Drawing.Size(103, 64);
            this.BtnLoadReceipt.TabIndex = 20;
            this.BtnLoadReceipt.Text = "Load Receipt";
            this.BtnLoadReceipt.UseVisualStyleBackColor = false;
            this.BtnLoadReceipt.Click += new System.EventHandler(this.BtnLoadReceipt_Click);
            // 
            // BtnNewReceipt
            // 
            this.BtnNewReceipt.BackColor = System.Drawing.Color.White;
            this.BtnNewReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNewReceipt.Location = new System.Drawing.Point(3, 73);
            this.BtnNewReceipt.Name = "BtnNewReceipt";
            this.BtnNewReceipt.Size = new System.Drawing.Size(103, 64);
            this.BtnNewReceipt.TabIndex = 21;
            this.BtnNewReceipt.Text = "New Receipt";
            this.BtnNewReceipt.UseVisualStyleBackColor = false;
            this.BtnNewReceipt.Click += new System.EventHandler(this.BtnNewReceipt_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.BtnDelete, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.BtnSaveAsQutation, 0, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1033, 149);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(109, 286);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.White;
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Location = new System.Drawing.Point(3, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(103, 65);
            this.BtnDelete.TabIndex = 0;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSaveAsQutation
            // 
            this.BtnSaveAsQutation.BackColor = System.Drawing.Color.White;
            this.BtnSaveAsQutation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveAsQutation.ForeColor = System.Drawing.Color.Black;
            this.BtnSaveAsQutation.Location = new System.Drawing.Point(3, 216);
            this.BtnSaveAsQutation.Name = "BtnSaveAsQutation";
            this.BtnSaveAsQutation.Size = new System.Drawing.Size(103, 67);
            this.BtnSaveAsQutation.TabIndex = 1;
            this.BtnSaveAsQutation.Text = "Print Quotation";
            this.BtnSaveAsQutation.UseVisualStyleBackColor = false;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1145, 584);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "POS";
            this.Text = "POS";
            this.Load += new System.EventHandler(this.POS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiptBody)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Timer SystemTimer;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private System.Windows.Forms.ComboBox CmbAddItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtCustomer;
        private System.Windows.Forms.Label LblCustomer;
        private System.Windows.Forms.TextBox TxtBarCode;
        private System.Windows.Forms.TextBox TxtProductCode;
        private System.Windows.Forms.TextBox TxtUnitPrice;
        private System.Windows.Forms.TextBox TxtDiscount;
        private System.Windows.Forms.TextBox TxtSubTotal;
        private System.Windows.Forms.TextBox TxtNetTotal;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.DataGridView DGVReceiptBody;
        private System.Windows.Forms.Label LblReceiptNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label LblBalanceAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblSubTotal;
        private System.Windows.Forms.Label LblTotalDiscount;
        private System.Windows.Forms.Label LblNetTotal;
        private System.Windows.Forms.Button BtnVoid;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.TextBox TxtGivenAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblReceiptStatus;
        private System.Windows.Forms.Label LblCashier;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button BtnLoadReceipt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtQuantity;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ComboBox CmbPaymentOption;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button BtnSaveAsQutation;
        private System.Windows.Forms.ComboBox CmbVehicles;
        private System.Windows.Forms.CheckBox ChkVehicle;
        private System.Windows.Forms.ToolTip ToolTipHelp;
        private System.Windows.Forms.Button BtnNewReceipt;
    }
}