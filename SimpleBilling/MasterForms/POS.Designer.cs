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
            this.CRUDPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TxtContact = new System.Windows.Forms.TextBox();
            this.LblReceiptNo = new System.Windows.Forms.Label();
            this.LblCustomer = new System.Windows.Forms.Label();
            this.TxtCustomer = new System.Windows.Forms.TextBox();
            this.CmbVehicles = new System.Windows.Forms.ComboBox();
            this.ChkVehicle = new System.Windows.Forms.CheckBox();
            this.TxtQuantity = new System.Windows.Forms.TextBox();
            this.TxtDiscount = new System.Windows.Forms.TextBox();
            this.TxtSubTotal = new System.Windows.Forms.TextBox();
            this.TxtNetTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtBarCode = new System.Windows.Forms.TextBox();
            this.TxtProductCode = new System.Windows.Forms.TextBox();
            this.TxtUnitPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.DGVReceiptBody = new System.Windows.Forms.DataGridView();
            this.DownLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TxtNextServiceDue = new System.Windows.Forms.TextBox();
            this.LblCashier = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LblReceiptStatus = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LblNetTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblTotalDiscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblSubTotal = new System.Windows.Forms.Label();
            this.CmbPaymentOption = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtCurrentMileage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.LblBalanceAmount = new System.Windows.Forms.Label();
            this.TxtGivenAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtChequeNo = new System.Windows.Forms.TextBox();
            this.TxtPayeeName = new System.Windows.Forms.TextBox();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.CmbBank = new System.Windows.Forms.ComboBox();
            this.CmbPaidBy = new System.Windows.Forms.ComboBox();
            this.DTDueDate = new System.Windows.Forms.DateTimePicker();
            this.BtnAddCheque = new System.Windows.Forms.Button();
            this.CmbChooseCheques = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TxtOverallDiscount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.LblPaidAmount = new System.Windows.Forms.Label();
            this.LblPendingAmount = new System.Windows.Forms.Label();
            this.LblPaymentStatus = new System.Windows.Forms.Label();
            this.BtnVoid = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.LstBoxPendingJobs = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnLoadReceipt = new System.Windows.Forms.Button();
            this.BtnNewReceipt = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnPrintQuotation = new System.Windows.Forms.Button();
            this.BtnSaveQuotation = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.BtnAddToPending = new System.Windows.Forms.Button();
            this.ToolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.CRUDPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiptBody)).BeginInit();
            this.DownLayout.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblDate.ForeColor = System.Drawing.Color.Lime;
            this.LblDate.Location = new System.Drawing.Point(3, 131);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(148, 19);
            this.LblDate.TabIndex = 0;
            this.LblDate.Text = "Date";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblTime.ForeColor = System.Drawing.Color.Lime;
            this.LblTime.Location = new System.Drawing.Point(157, 131);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(160, 19);
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
            this.CmbAddItem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAddItem.FormattingEnabled = true;
            this.CmbAddItem.Location = new System.Drawing.Point(399, 87);
            this.CmbAddItem.Name = "CmbAddItem";
            this.CmbAddItem.Size = new System.Drawing.Size(390, 22);
            this.CmbAddItem.TabIndex = 2;
            this.CmbAddItem.ValueMember = "Id";
            this.CmbAddItem.SelectedIndexChanged += new System.EventHandler(this.CmbAddItem_SelectedIndexChanged);
            this.CmbAddItem.Enter += new System.EventHandler(this.CmbAddItem_Enter);
            this.CmbAddItem.Leave += new System.EventHandler(this.CmbAddItem_Leave);
            // 
            // CRUDPanel
            // 
            this.CRUDPanel.ColumnCount = 5;
            this.CRUDPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.CRUDPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.CRUDPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.CRUDPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.CRUDPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.CRUDPanel.Controls.Add(this.TxtContact, 1, 1);
            this.CRUDPanel.Controls.Add(this.LblReceiptNo, 0, 0);
            this.CRUDPanel.Controls.Add(this.LblCustomer, 1, 0);
            this.CRUDPanel.Controls.Add(this.TxtCustomer, 2, 0);
            this.CRUDPanel.Controls.Add(this.CmbVehicles, 3, 0);
            this.CRUDPanel.Controls.Add(this.ChkVehicle, 4, 0);
            this.CRUDPanel.Controls.Add(this.TxtQuantity, 0, 5);
            this.CRUDPanel.Controls.Add(this.TxtDiscount, 1, 5);
            this.CRUDPanel.Controls.Add(this.TxtSubTotal, 2, 5);
            this.CRUDPanel.Controls.Add(this.TxtNetTotal, 3, 5);
            this.CRUDPanel.Controls.Add(this.label5, 0, 4);
            this.CRUDPanel.Controls.Add(this.label6, 1, 4);
            this.CRUDPanel.Controls.Add(this.label7, 2, 4);
            this.CRUDPanel.Controls.Add(this.label8, 3, 4);
            this.CRUDPanel.Controls.Add(this.TxtBarCode, 0, 3);
            this.CRUDPanel.Controls.Add(this.TxtProductCode, 1, 3);
            this.CRUDPanel.Controls.Add(this.CmbAddItem, 2, 3);
            this.CRUDPanel.Controls.Add(this.TxtUnitPrice, 3, 3);
            this.CRUDPanel.Controls.Add(this.label1, 0, 2);
            this.CRUDPanel.Controls.Add(this.label2, 1, 2);
            this.CRUDPanel.Controls.Add(this.label3, 2, 2);
            this.CRUDPanel.Controls.Add(this.label4, 3, 2);
            this.CRUDPanel.Controls.Add(this.TxtName, 0, 1);
            this.CRUDPanel.Controls.Add(this.TxtAddress, 2, 1);
            this.CRUDPanel.Controls.Add(this.TxtEmail, 3, 1);
            this.CRUDPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRUDPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRUDPanel.Location = new System.Drawing.Point(3, 3);
            this.CRUDPanel.Name = "CRUDPanel";
            this.CRUDPanel.RowCount = 6;
            this.CRUDPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.CRUDPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.CRUDPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.CRUDPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.CRUDPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.CRUDPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.CRUDPanel.Size = new System.Drawing.Size(1024, 173);
            this.CRUDPanel.TabIndex = 5;
            // 
            // TxtContact
            // 
            this.TxtContact.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtContact.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContact.ForeColor = System.Drawing.Color.DimGray;
            this.TxtContact.Location = new System.Drawing.Point(201, 31);
            this.TxtContact.Name = "TxtContact";
            this.TxtContact.Size = new System.Drawing.Size(192, 22);
            this.TxtContact.TabIndex = 22;
            this.TxtContact.Text = "Contact No";
            this.TxtContact.Enter += new System.EventHandler(this.TxtContact_Enter);
            this.TxtContact.Leave += new System.EventHandler(this.TxtContact_Leave);
            // 
            // LblReceiptNo
            // 
            this.LblReceiptNo.AutoSize = true;
            this.LblReceiptNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblReceiptNo.ForeColor = System.Drawing.Color.Wheat;
            this.LblReceiptNo.Location = new System.Drawing.Point(3, 0);
            this.LblReceiptNo.Name = "LblReceiptNo";
            this.LblReceiptNo.Size = new System.Drawing.Size(192, 19);
            this.LblReceiptNo.TabIndex = 18;
            this.LblReceiptNo.Text = "ReceiptNo";
            // 
            // LblCustomer
            // 
            this.LblCustomer.AutoSize = true;
            this.LblCustomer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblCustomer.ForeColor = System.Drawing.Color.Lime;
            this.LblCustomer.Location = new System.Drawing.Point(201, 0);
            this.LblCustomer.Name = "LblCustomer";
            this.LblCustomer.Size = new System.Drawing.Size(84, 19);
            this.LblCustomer.TabIndex = 17;
            this.LblCustomer.Text = "Customer";
            // 
            // TxtCustomer
            // 
            this.TxtCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCustomer.Location = new System.Drawing.Point(399, 3);
            this.TxtCustomer.Name = "TxtCustomer";
            this.TxtCustomer.Size = new System.Drawing.Size(390, 26);
            this.TxtCustomer.TabIndex = 1;
            this.TxtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCustomer_KeyDown);
            this.TxtCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCustomer_KeyUp);
            // 
            // CmbVehicles
            // 
            this.CmbVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVehicles.Enabled = false;
            this.CmbVehicles.FormattingEnabled = true;
            this.CmbVehicles.Location = new System.Drawing.Point(795, 3);
            this.CmbVehicles.Name = "CmbVehicles";
            this.CmbVehicles.Size = new System.Drawing.Size(192, 27);
            this.CmbVehicles.TabIndex = 19;
            // 
            // ChkVehicle
            // 
            this.ChkVehicle.AutoSize = true;
            this.ChkVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkVehicle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChkVehicle.Location = new System.Drawing.Point(993, 3);
            this.ChkVehicle.Name = "ChkVehicle";
            this.ChkVehicle.Size = new System.Drawing.Size(28, 22);
            this.ChkVehicle.TabIndex = 20;
            this.ChkVehicle.UseVisualStyleBackColor = true;
            this.ChkVehicle.CheckedChanged += new System.EventHandler(this.ChkVehicle_CheckedChanged);
            this.ChkVehicle.MouseHover += new System.EventHandler(this.ChkVehicle_MouseHover);
            // 
            // TxtQuantity
            // 
            this.TxtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtQuantity.Location = new System.Drawing.Point(3, 143);
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.Size = new System.Drawing.Size(192, 26);
            this.TxtQuantity.TabIndex = 3;
            this.TxtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantity_KeyDown);
            this.TxtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQuantity_KeyPress);
            this.TxtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtQuantity_KeyUp);
            // 
            // TxtDiscount
            // 
            this.TxtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDiscount.Location = new System.Drawing.Point(201, 143);
            this.TxtDiscount.Name = "TxtDiscount";
            this.TxtDiscount.Size = new System.Drawing.Size(192, 26);
            this.TxtDiscount.TabIndex = 4;
            this.TxtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDiscount_KeyDown);
            this.TxtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiscount_KeyPress);
            this.TxtDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtDiscount_KeyUp);
            // 
            // TxtSubTotal
            // 
            this.TxtSubTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtSubTotal.Location = new System.Drawing.Point(399, 143);
            this.TxtSubTotal.Name = "TxtSubTotal";
            this.TxtSubTotal.Size = new System.Drawing.Size(390, 26);
            this.TxtSubTotal.TabIndex = 7;
            // 
            // TxtNetTotal
            // 
            this.TxtNetTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtNetTotal.Location = new System.Drawing.Point(795, 143);
            this.TxtNetTotal.Name = "TxtNetTotal";
            this.TxtNetTotal.ReadOnly = true;
            this.TxtNetTotal.Size = new System.Drawing.Size(192, 26);
            this.TxtNetTotal.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(201, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Discount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(399, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(390, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Sub Total";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(795, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "Net Total";
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBarCode.Location = new System.Drawing.Point(3, 87);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(192, 26);
            this.TxtBarCode.TabIndex = 5;
            this.TxtBarCode.Enter += new System.EventHandler(this.TxtBarCode_Enter);
            this.TxtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyUp);
            // 
            // TxtProductCode
            // 
            this.TxtProductCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtProductCode.Location = new System.Drawing.Point(201, 87);
            this.TxtProductCode.Name = "TxtProductCode";
            this.TxtProductCode.Size = new System.Drawing.Size(192, 26);
            this.TxtProductCode.TabIndex = 6;
            // 
            // TxtUnitPrice
            // 
            this.TxtUnitPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUnitPrice.Location = new System.Drawing.Point(795, 87);
            this.TxtUnitPrice.Name = "TxtUnitPrice";
            this.TxtUnitPrice.ReadOnly = true;
            this.TxtUnitPrice.Size = new System.Drawing.Size(192, 26);
            this.TxtUnitPrice.TabIndex = 12;
            this.TxtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUnitPrice_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bar Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(201, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(399, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(390, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(795, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Unit Price";
            // 
            // TxtName
            // 
            this.TxtName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtName.ForeColor = System.Drawing.Color.DimGray;
            this.TxtName.Location = new System.Drawing.Point(3, 31);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(192, 22);
            this.TxtName.TabIndex = 21;
            this.TxtName.Text = "Customer Name";
            this.TxtName.Enter += new System.EventHandler(this.TxtName_Enter);
            this.TxtName.Leave += new System.EventHandler(this.TxtName_Leave);
            // 
            // TxtAddress
            // 
            this.TxtAddress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtAddress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddress.ForeColor = System.Drawing.Color.DimGray;
            this.TxtAddress.Location = new System.Drawing.Point(399, 31);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(390, 22);
            this.TxtAddress.TabIndex = 24;
            this.TxtAddress.Text = "Address";
            this.TxtAddress.Enter += new System.EventHandler(this.TxtAddress_Enter);
            this.TxtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddress_KeyDown);
            this.TxtAddress.Leave += new System.EventHandler(this.TxtAddress_Leave);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.ForeColor = System.Drawing.Color.DimGray;
            this.TxtEmail.Location = new System.Drawing.Point(795, 31);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(192, 22);
            this.TxtEmail.TabIndex = 23;
            this.TxtEmail.Text = "Email";
            this.TxtEmail.Enter += new System.EventHandler(this.TxtEmail_Enter);
            this.TxtEmail.Leave += new System.EventHandler(this.TxtEmail_Leave);
            // 
            // DGVReceiptBody
            // 
            this.DGVReceiptBody.AllowUserToAddRows = false;
            this.DGVReceiptBody.AllowUserToDeleteRows = false;
            this.DGVReceiptBody.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVReceiptBody.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVReceiptBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReceiptBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVReceiptBody.Location = new System.Drawing.Point(3, 182);
            this.DGVReceiptBody.MultiSelect = false;
            this.DGVReceiptBody.Name = "DGVReceiptBody";
            this.DGVReceiptBody.ReadOnly = true;
            this.DGVReceiptBody.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVReceiptBody.Size = new System.Drawing.Size(1024, 180);
            this.DGVReceiptBody.TabIndex = 6;
            // 
            // DownLayout
            // 
            this.DownLayout.ColumnCount = 6;
            this.DownLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.06849F));
            this.DownLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.24266F));
            this.DownLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.591F));
            this.DownLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.69928F));
            this.DownLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.69928F));
            this.DownLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.69928F));
            this.DownLayout.Controls.Add(this.TxtNextServiceDue, 1, 1);
            this.DownLayout.Controls.Add(this.LblDate, 0, 4);
            this.DownLayout.Controls.Add(this.LblTime, 1, 4);
            this.DownLayout.Controls.Add(this.LblCashier, 2, 4);
            this.DownLayout.Controls.Add(this.label11, 4, 4);
            this.DownLayout.Controls.Add(this.LblReceiptStatus, 5, 4);
            this.DownLayout.Controls.Add(this.label13, 4, 2);
            this.DownLayout.Controls.Add(this.LblNetTotal, 5, 2);
            this.DownLayout.Controls.Add(this.label10, 4, 1);
            this.DownLayout.Controls.Add(this.LblTotalDiscount, 5, 1);
            this.DownLayout.Controls.Add(this.label9, 4, 0);
            this.DownLayout.Controls.Add(this.LblSubTotal, 5, 0);
            this.DownLayout.Controls.Add(this.CmbPaymentOption, 3, 0);
            this.DownLayout.Controls.Add(this.label16, 2, 0);
            this.DownLayout.Controls.Add(this.label17, 0, 0);
            this.DownLayout.Controls.Add(this.label18, 0, 1);
            this.DownLayout.Controls.Add(this.TxtCurrentMileage, 1, 0);
            this.DownLayout.Controls.Add(this.label15, 2, 3);
            this.DownLayout.Controls.Add(this.LblBalanceAmount, 3, 3);
            this.DownLayout.Controls.Add(this.TxtGivenAmount, 3, 2);
            this.DownLayout.Controls.Add(this.label12, 2, 2);
            this.DownLayout.Controls.Add(this.TxtChequeNo, 0, 5);
            this.DownLayout.Controls.Add(this.TxtPayeeName, 1, 5);
            this.DownLayout.Controls.Add(this.TxtAmount, 2, 5);
            this.DownLayout.Controls.Add(this.CmbBank, 5, 5);
            this.DownLayout.Controls.Add(this.CmbPaidBy, 4, 5);
            this.DownLayout.Controls.Add(this.DTDueDate, 3, 5);
            this.DownLayout.Controls.Add(this.BtnAddCheque, 2, 1);
            this.DownLayout.Controls.Add(this.CmbChooseCheques, 3, 1);
            this.DownLayout.Controls.Add(this.label19, 4, 3);
            this.DownLayout.Controls.Add(this.TxtOverallDiscount, 5, 3);
            this.DownLayout.Controls.Add(this.label20, 0, 2);
            this.DownLayout.Controls.Add(this.label21, 0, 3);
            this.DownLayout.Controls.Add(this.LblPaidAmount, 1, 2);
            this.DownLayout.Controls.Add(this.LblPendingAmount, 1, 3);
            this.DownLayout.Controls.Add(this.LblPaymentStatus, 3, 4);
            this.DownLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownLayout.Location = new System.Drawing.Point(3, 368);
            this.DownLayout.Name = "DownLayout";
            this.DownLayout.RowCount = 6;
            this.DownLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DownLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DownLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DownLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DownLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DownLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DownLayout.Size = new System.Drawing.Size(1024, 186);
            this.DownLayout.TabIndex = 7;
            // 
            // TxtNextServiceDue
            // 
            this.TxtNextServiceDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtNextServiceDue.Location = new System.Drawing.Point(157, 33);
            this.TxtNextServiceDue.Name = "TxtNextServiceDue";
            this.TxtNextServiceDue.Size = new System.Drawing.Size(160, 26);
            this.TxtNextServiceDue.TabIndex = 20;
            // 
            // LblCashier
            // 
            this.LblCashier.AutoSize = true;
            this.LblCashier.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblCashier.ForeColor = System.Drawing.Color.Lime;
            this.LblCashier.Location = new System.Drawing.Point(323, 131);
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
            this.label11.Location = new System.Drawing.Point(684, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 19);
            this.label11.TabIndex = 10;
            this.label11.Text = "Receipt Status";
            // 
            // LblReceiptStatus
            // 
            this.LblReceiptStatus.AutoSize = true;
            this.LblReceiptStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblReceiptStatus.ForeColor = System.Drawing.Color.Yellow;
            this.LblReceiptStatus.Location = new System.Drawing.Point(855, 131);
            this.LblReceiptStatus.Name = "LblReceiptStatus";
            this.LblReceiptStatus.Size = new System.Drawing.Size(166, 19);
            this.LblReceiptStatus.TabIndex = 11;
            this.LblReceiptStatus.Text = "Ready";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(684, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 30);
            this.label13.TabIndex = 4;
            this.label13.Text = "Net Total";
            // 
            // LblNetTotal
            // 
            this.LblNetTotal.AutoSize = true;
            this.LblNetTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblNetTotal.ForeColor = System.Drawing.Color.White;
            this.LblNetTotal.Location = new System.Drawing.Point(855, 60);
            this.LblNetTotal.Name = "LblNetTotal";
            this.LblNetTotal.Size = new System.Drawing.Size(166, 30);
            this.LblNetTotal.TabIndex = 5;
            this.LblNetTotal.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(684, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 30);
            this.label10.TabIndex = 1;
            this.label10.Text = "Total Discount";
            // 
            // LblTotalDiscount
            // 
            this.LblTotalDiscount.AutoSize = true;
            this.LblTotalDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTotalDiscount.ForeColor = System.Drawing.Color.White;
            this.LblTotalDiscount.Location = new System.Drawing.Point(855, 30);
            this.LblTotalDiscount.Name = "LblTotalDiscount";
            this.LblTotalDiscount.Size = new System.Drawing.Size(166, 30);
            this.LblTotalDiscount.TabIndex = 3;
            this.LblTotalDiscount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(684, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 30);
            this.label9.TabIndex = 0;
            this.label9.Text = "Gross Total";
            // 
            // LblSubTotal
            // 
            this.LblSubTotal.AutoSize = true;
            this.LblSubTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblSubTotal.ForeColor = System.Drawing.Color.White;
            this.LblSubTotal.Location = new System.Drawing.Point(855, 0);
            this.LblSubTotal.Name = "LblSubTotal";
            this.LblSubTotal.Size = new System.Drawing.Size(166, 30);
            this.LblSubTotal.TabIndex = 2;
            this.LblSubTotal.Text = "0";
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
            this.CmbPaymentOption.Size = new System.Drawing.Size(165, 27);
            this.CmbPaymentOption.TabIndex = 15;
            this.CmbPaymentOption.SelectedIndexChanged += new System.EventHandler(this.CmbPaymentOption_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(323, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(184, 19);
            this.label16.TabIndex = 16;
            this.label16.Text = "Select Payment Option";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(3, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(148, 19);
            this.label17.TabIndex = 17;
            this.label17.Text = "Current Mileage";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label18.ForeColor = System.Drawing.Color.Snow;
            this.label18.Location = new System.Drawing.Point(3, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(148, 19);
            this.label18.TabIndex = 18;
            this.label18.Text = "Next Service Due";
            // 
            // TxtCurrentMileage
            // 
            this.TxtCurrentMileage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCurrentMileage.Location = new System.Drawing.Point(157, 3);
            this.TxtCurrentMileage.Name = "TxtCurrentMileage";
            this.TxtCurrentMileage.Size = new System.Drawing.Size(160, 26);
            this.TxtCurrentMileage.TabIndex = 19;
            this.TxtCurrentMileage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCurrentMileage_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(323, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 19);
            this.label15.TabIndex = 14;
            this.label15.Text = "Balance Amount";
            // 
            // LblBalanceAmount
            // 
            this.LblBalanceAmount.AutoSize = true;
            this.LblBalanceAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblBalanceAmount.ForeColor = System.Drawing.Color.White;
            this.LblBalanceAmount.Location = new System.Drawing.Point(513, 101);
            this.LblBalanceAmount.Name = "LblBalanceAmount";
            this.LblBalanceAmount.Size = new System.Drawing.Size(165, 19);
            this.LblBalanceAmount.TabIndex = 9;
            this.LblBalanceAmount.Text = "0";
            // 
            // TxtGivenAmount
            // 
            this.TxtGivenAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtGivenAmount.Location = new System.Drawing.Point(513, 63);
            this.TxtGivenAmount.Name = "TxtGivenAmount";
            this.TxtGivenAmount.Size = new System.Drawing.Size(165, 26);
            this.TxtGivenAmount.TabIndex = 9;
            this.TxtGivenAmount.Enter += new System.EventHandler(this.TxtGivenAmount_Enter);
            this.TxtGivenAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGivenAmount_KeyDown);
            this.TxtGivenAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtGivenAmount_KeyPress);
            this.TxtGivenAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtGivenAmount_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(323, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(184, 19);
            this.label12.TabIndex = 13;
            this.label12.Text = "Given Amount";
            // 
            // TxtChequeNo
            // 
            this.TxtChequeNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtChequeNo.ForeColor = System.Drawing.Color.DarkGray;
            this.TxtChequeNo.Location = new System.Drawing.Point(3, 153);
            this.TxtChequeNo.Name = "TxtChequeNo";
            this.TxtChequeNo.Size = new System.Drawing.Size(148, 26);
            this.TxtChequeNo.TabIndex = 24;
            this.TxtChequeNo.Text = "Cheque No";
            this.TxtChequeNo.Enter += new System.EventHandler(this.TxtChequeNo_Enter);
            this.TxtChequeNo.Leave += new System.EventHandler(this.TxtChequeNo_Leave);
            // 
            // TxtPayeeName
            // 
            this.TxtPayeeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPayeeName.ForeColor = System.Drawing.Color.DarkGray;
            this.TxtPayeeName.Location = new System.Drawing.Point(157, 153);
            this.TxtPayeeName.Name = "TxtPayeeName";
            this.TxtPayeeName.Size = new System.Drawing.Size(160, 26);
            this.TxtPayeeName.TabIndex = 25;
            this.TxtPayeeName.Text = "Payee Name";
            this.TxtPayeeName.Enter += new System.EventHandler(this.TxtPayeeName_Enter);
            this.TxtPayeeName.Leave += new System.EventHandler(this.TxtPayeeName_Leave);
            // 
            // TxtAmount
            // 
            this.TxtAmount.ForeColor = System.Drawing.Color.DarkGray;
            this.TxtAmount.Location = new System.Drawing.Point(323, 153);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(184, 26);
            this.TxtAmount.TabIndex = 26;
            this.TxtAmount.Text = "Amount";
            this.TxtAmount.Enter += new System.EventHandler(this.TxtAmount_Enter);
            this.TxtAmount.Leave += new System.EventHandler(this.TxtAmount_Leave);
            // 
            // CmbBank
            // 
            this.CmbBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbBank.FormattingEnabled = true;
            this.CmbBank.Location = new System.Drawing.Point(855, 153);
            this.CmbBank.Name = "CmbBank";
            this.CmbBank.Size = new System.Drawing.Size(166, 27);
            this.CmbBank.TabIndex = 28;
            // 
            // CmbPaidBy
            // 
            this.CmbPaidBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbPaidBy.FormattingEnabled = true;
            this.CmbPaidBy.Location = new System.Drawing.Point(684, 153);
            this.CmbPaidBy.Name = "CmbPaidBy";
            this.CmbPaidBy.Size = new System.Drawing.Size(165, 27);
            this.CmbPaidBy.TabIndex = 27;
            // 
            // DTDueDate
            // 
            this.DTDueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTDueDate.Location = new System.Drawing.Point(513, 153);
            this.DTDueDate.Name = "DTDueDate";
            this.DTDueDate.Size = new System.Drawing.Size(165, 26);
            this.DTDueDate.TabIndex = 29;
            // 
            // BtnAddCheque
            // 
            this.BtnAddCheque.BackColor = System.Drawing.Color.White;
            this.BtnAddCheque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddCheque.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCheque.Location = new System.Drawing.Point(323, 33);
            this.BtnAddCheque.Name = "BtnAddCheque";
            this.BtnAddCheque.Size = new System.Drawing.Size(184, 24);
            this.BtnAddCheque.TabIndex = 12;
            this.BtnAddCheque.Text = "Add Cheque";
            this.BtnAddCheque.UseVisualStyleBackColor = false;
            this.BtnAddCheque.Click += new System.EventHandler(this.BtnAddCheque_Click);
            // 
            // CmbChooseCheques
            // 
            this.CmbChooseCheques.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CmbChooseCheques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbChooseCheques.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbChooseCheques.FormattingEnabled = true;
            this.CmbChooseCheques.Location = new System.Drawing.Point(513, 33);
            this.CmbChooseCheques.Name = "CmbChooseCheques";
            this.CmbChooseCheques.Size = new System.Drawing.Size(165, 24);
            this.CmbChooseCheques.TabIndex = 30;
            this.CmbChooseCheques.SelectedIndexChanged += new System.EventHandler(this.CmbChooseCheques_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(684, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(165, 30);
            this.label19.TabIndex = 31;
            this.label19.Text = "Overall Discount";
            // 
            // TxtOverallDiscount
            // 
            this.TxtOverallDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtOverallDiscount.Location = new System.Drawing.Point(855, 93);
            this.TxtOverallDiscount.Name = "TxtOverallDiscount";
            this.TxtOverallDiscount.Size = new System.Drawing.Size(166, 26);
            this.TxtOverallDiscount.TabIndex = 32;
            this.TxtOverallDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtOverallDiscount_KeyDown);
            this.TxtOverallDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOverallDiscount_KeyPress);
            this.TxtOverallDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtOverallDiscount_KeyUp);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(3, 71);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(148, 19);
            this.label20.TabIndex = 33;
            this.label20.Text = "Paid Amount";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(3, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(148, 19);
            this.label21.TabIndex = 34;
            this.label21.Text = "Pending Amount";
            // 
            // LblPaidAmount
            // 
            this.LblPaidAmount.AutoSize = true;
            this.LblPaidAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblPaidAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LblPaidAmount.Location = new System.Drawing.Point(157, 71);
            this.LblPaidAmount.Name = "LblPaidAmount";
            this.LblPaidAmount.Size = new System.Drawing.Size(160, 19);
            this.LblPaidAmount.TabIndex = 35;
            this.LblPaidAmount.Text = "0";
            // 
            // LblPendingAmount
            // 
            this.LblPendingAmount.AutoSize = true;
            this.LblPendingAmount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblPendingAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LblPendingAmount.Location = new System.Drawing.Point(157, 101);
            this.LblPendingAmount.Name = "LblPendingAmount";
            this.LblPendingAmount.Size = new System.Drawing.Size(160, 19);
            this.LblPendingAmount.TabIndex = 36;
            this.LblPendingAmount.Text = "0";
            // 
            // LblPaymentStatus
            // 
            this.LblPaymentStatus.AutoSize = true;
            this.LblPaymentStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblPaymentStatus.ForeColor = System.Drawing.Color.White;
            this.LblPaymentStatus.Location = new System.Drawing.Point(513, 131);
            this.LblPaymentStatus.Name = "LblPaymentStatus";
            this.LblPaymentStatus.Size = new System.Drawing.Size(165, 19);
            this.LblPaymentStatus.TabIndex = 37;
            this.LblPaymentStatus.Text = "Payment Status";
            // 
            // BtnVoid
            // 
            this.BtnVoid.BackColor = System.Drawing.Color.White;
            this.BtnVoid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnVoid.Location = new System.Drawing.Point(3, 49);
            this.BtnVoid.Name = "BtnVoid";
            this.BtnVoid.Size = new System.Drawing.Size(103, 40);
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
            this.BtnPrint.Size = new System.Drawing.Size(103, 40);
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
            this.tableLayoutPanel3.Controls.Add(this.CRUDPanel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DownLayout, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.DGVReceiptBody, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.BtnAddToPending, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.13644F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.39318F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.47038F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1145, 593);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.BtnPrint, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnVoid, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.LstBoxPendingJobs, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1033, 368);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(109, 186);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // LstBoxPendingJobs
            // 
            this.LstBoxPendingJobs.BackColor = System.Drawing.Color.White;
            this.LstBoxPendingJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstBoxPendingJobs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstBoxPendingJobs.FormattingEnabled = true;
            this.LstBoxPendingJobs.ItemHeight = 14;
            this.LstBoxPendingJobs.Location = new System.Drawing.Point(3, 95);
            this.LstBoxPendingJobs.Name = "LstBoxPendingJobs";
            this.LstBoxPendingJobs.Size = new System.Drawing.Size(103, 88);
            this.LstBoxPendingJobs.TabIndex = 8;
            this.LstBoxPendingJobs.DoubleClick += new System.EventHandler(this.LstBoxPendingJobs_DoubleClick);
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(109, 173);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // BtnLoadReceipt
            // 
            this.BtnLoadReceipt.BackColor = System.Drawing.Color.White;
            this.BtnLoadReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoadReceipt.Location = new System.Drawing.Point(3, 3);
            this.BtnLoadReceipt.Name = "BtnLoadReceipt";
            this.BtnLoadReceipt.Size = new System.Drawing.Size(103, 80);
            this.BtnLoadReceipt.TabIndex = 20;
            this.BtnLoadReceipt.Text = "Load Receipt";
            this.BtnLoadReceipt.UseVisualStyleBackColor = false;
            this.BtnLoadReceipt.Click += new System.EventHandler(this.BtnLoadReceipt_Click);
            // 
            // BtnNewReceipt
            // 
            this.BtnNewReceipt.BackColor = System.Drawing.Color.White;
            this.BtnNewReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNewReceipt.Location = new System.Drawing.Point(3, 89);
            this.BtnNewReceipt.Name = "BtnNewReceipt";
            this.BtnNewReceipt.Size = new System.Drawing.Size(103, 81);
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
            this.tableLayoutPanel6.Controls.Add(this.BtnPrintQuotation, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.BtnSaveQuotation, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1033, 182);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(109, 180);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.White;
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Location = new System.Drawing.Point(3, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(103, 30);
            this.BtnDelete.TabIndex = 0;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnPrintQuotation
            // 
            this.BtnPrintQuotation.BackColor = System.Drawing.Color.White;
            this.BtnPrintQuotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPrintQuotation.ForeColor = System.Drawing.Color.Black;
            this.BtnPrintQuotation.Location = new System.Drawing.Point(3, 111);
            this.BtnPrintQuotation.Name = "BtnPrintQuotation";
            this.BtnPrintQuotation.Size = new System.Drawing.Size(103, 66);
            this.BtnPrintQuotation.TabIndex = 1;
            this.BtnPrintQuotation.Text = "Print Quotation";
            this.BtnPrintQuotation.UseVisualStyleBackColor = false;
            // 
            // BtnSaveQuotation
            // 
            this.BtnSaveQuotation.BackColor = System.Drawing.Color.White;
            this.BtnSaveQuotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveQuotation.Location = new System.Drawing.Point(3, 39);
            this.BtnSaveQuotation.Name = "BtnSaveQuotation";
            this.BtnSaveQuotation.Size = new System.Drawing.Size(103, 66);
            this.BtnSaveQuotation.TabIndex = 2;
            this.BtnSaveQuotation.Text = "Save Quotation";
            this.BtnSaveQuotation.UseVisualStyleBackColor = false;
            this.BtnSaveQuotation.Click += new System.EventHandler(this.BtnSaveQuotation_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.789063F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.21094F));
            this.tableLayoutPanel7.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.TxtRemarks, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 560);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1024, 30);
            this.tableLayoutPanel7.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Remarks";
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtRemarks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtRemarks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRemarks.Location = new System.Drawing.Point(93, 8);
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(928, 19);
            this.TxtRemarks.TabIndex = 1;
            // 
            // BtnAddToPending
            // 
            this.BtnAddToPending.BackColor = System.Drawing.Color.White;
            this.BtnAddToPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddToPending.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddToPending.Location = new System.Drawing.Point(1033, 560);
            this.BtnAddToPending.Name = "BtnAddToPending";
            this.BtnAddToPending.Size = new System.Drawing.Size(109, 30);
            this.BtnAddToPending.TabIndex = 12;
            this.BtnAddToPending.Text = "Add to Pending";
            this.BtnAddToPending.UseVisualStyleBackColor = false;
            this.BtnAddToPending.Click += new System.EventHandler(this.BtnAddToPending_Click);
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1145, 593);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "POS";
            this.Text = "POS";
            this.Load += new System.EventHandler(this.POS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.CRUDPanel.ResumeLayout(false);
            this.CRUDPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiptBody)).EndInit();
            this.DownLayout.ResumeLayout(false);
            this.DownLayout.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Timer SystemTimer;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private System.Windows.Forms.ComboBox CmbAddItem;
        private System.Windows.Forms.TableLayoutPanel CRUDPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtCustomer;
        private System.Windows.Forms.TextBox TxtBarCode;
        private System.Windows.Forms.TextBox TxtProductCode;
        private System.Windows.Forms.TextBox TxtUnitPrice;
        private System.Windows.Forms.TextBox TxtDiscount;
        private System.Windows.Forms.TextBox TxtSubTotal;
        private System.Windows.Forms.TextBox TxtNetTotal;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.DataGridView DGVReceiptBody;
        private System.Windows.Forms.Label LblReceiptNo;
        private System.Windows.Forms.TableLayoutPanel DownLayout;
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
        private System.Windows.Forms.Button BtnPrintQuotation;
        private System.Windows.Forms.ComboBox CmbVehicles;
        private System.Windows.Forms.CheckBox ChkVehicle;
        private System.Windows.Forms.ToolTip ToolTipHelp;
        private System.Windows.Forms.Button BtnNewReceipt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtNextServiceDue;
        private System.Windows.Forms.TextBox TxtCurrentMileage;
        private System.Windows.Forms.Label LblCustomer;
        private System.Windows.Forms.TextBox TxtChequeNo;
        private System.Windows.Forms.TextBox TxtPayeeName;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.ComboBox CmbPaidBy;
        private System.Windows.Forms.ComboBox CmbBank;
        private System.Windows.Forms.DateTimePicker DTDueDate;
        private System.Windows.Forms.Button BtnAddCheque;
        private System.Windows.Forms.ComboBox CmbChooseCheques;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtContact;
        private System.Windows.Forms.Button BtnSaveQuotation;
        private System.Windows.Forms.ListBox LstBoxPendingJobs;
        private System.Windows.Forms.Button BtnAddToPending;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxtOverallDiscount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label LblPaidAmount;
        private System.Windows.Forms.Label LblPendingAmount;
        private System.Windows.Forms.Label LblPaymentStatus;
    }
}