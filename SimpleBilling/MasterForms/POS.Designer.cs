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
            this.LblDate = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.SystemTimer = new System.Windows.Forms.Timer(this.components);
            this.CmbAddItem = new System.Windows.Forms.ComboBox();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtCustomer = new System.Windows.Forms.TextBox();
            this.LblCustomer = new System.Windows.Forms.Label();
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
            this.TxtQuantity = new System.Windows.Forms.TextBox();
            this.TxtDiscount = new System.Windows.Forms.TextBox();
            this.TxtSubTotal = new System.Windows.Forms.TextBox();
            this.TxtNetTotal = new System.Windows.Forms.TextBox();
            this.LblReceiptNo = new System.Windows.Forms.Label();
            this.BtnLoadReceipt = new System.Windows.Forms.Button();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGVReceiptBody = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LblBalanceAmount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblSubTotal = new System.Windows.Forms.Label();
            this.LblTotalDiscount = new System.Windows.Forms.Label();
            this.LblNetTotal = new System.Windows.Forms.Label();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnPrintPreview = new System.Windows.Forms.Button();
            this.TxtGivenAmount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiptBody)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblDate.ForeColor = System.Drawing.Color.Lime;
            this.LblDate.Location = new System.Drawing.Point(3, 74);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(44, 19);
            this.LblDate.TabIndex = 0;
            this.LblDate.Text = "Date";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.ForeColor = System.Drawing.Color.Lime;
            this.LblTime.Location = new System.Drawing.Point(202, 74);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(46, 19);
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
            this.CmbAddItem.FormattingEnabled = true;
            this.CmbAddItem.Location = new System.Drawing.Point(503, 63);
            this.CmbAddItem.Name = "CmbAddItem";
            this.CmbAddItem.Size = new System.Drawing.Size(244, 27);
            this.CmbAddItem.TabIndex = 4;
            this.CmbAddItem.ValueMember = "Id";
            this.CmbAddItem.SelectedIndexChanged += new System.EventHandler(this.CmbAddItem_SelectedIndexChanged);
            this.CmbAddItem.Enter += new System.EventHandler(this.CmbAddItem_Enter);
            this.CmbAddItem.Leave += new System.EventHandler(this.CmbAddItem_Leave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.TxtCustomer, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CmbAddItem, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblCustomer, 2, 0);
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
            this.tableLayoutPanel1.Controls.Add(this.TxtQuantity, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.TxtDiscount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.TxtSubTotal, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.TxtNetTotal, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.LblReceiptNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnLoadReceipt, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 150);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // TxtCustomer
            // 
            this.TxtCustomer.Location = new System.Drawing.Point(753, 3);
            this.TxtCustomer.Name = "TxtCustomer";
            this.TxtCustomer.Size = new System.Drawing.Size(244, 26);
            this.TxtCustomer.TabIndex = 1;
            this.TxtCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCustomer_KeyUp);
            // 
            // LblCustomer
            // 
            this.LblCustomer.AutoSize = true;
            this.LblCustomer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblCustomer.ForeColor = System.Drawing.Color.Lime;
            this.LblCustomer.Location = new System.Drawing.Point(503, 0);
            this.LblCustomer.Name = "LblCustomer";
            this.LblCustomer.Size = new System.Drawing.Size(84, 19);
            this.LblCustomer.TabIndex = 17;
            this.LblCustomer.Text = "Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bar Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(253, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(503, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(753, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Unit Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(253, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Discount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(503, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Sub Total";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(753, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "Net Total";
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Location = new System.Drawing.Point(3, 63);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(244, 26);
            this.TxtBarCode.TabIndex = 10;
            this.TxtBarCode.Enter += new System.EventHandler(this.TxtBarCode_Enter);
            this.TxtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyUp);
            // 
            // TxtProductCode
            // 
            this.TxtProductCode.Location = new System.Drawing.Point(253, 63);
            this.TxtProductCode.Name = "TxtProductCode";
            this.TxtProductCode.Size = new System.Drawing.Size(244, 26);
            this.TxtProductCode.TabIndex = 11;
            // 
            // TxtUnitPrice
            // 
            this.TxtUnitPrice.Location = new System.Drawing.Point(753, 63);
            this.TxtUnitPrice.Name = "TxtUnitPrice";
            this.TxtUnitPrice.Size = new System.Drawing.Size(244, 26);
            this.TxtUnitPrice.TabIndex = 12;
            // 
            // TxtQuantity
            // 
            this.TxtQuantity.Location = new System.Drawing.Point(3, 123);
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.Size = new System.Drawing.Size(244, 26);
            this.TxtQuantity.TabIndex = 13;
            this.TxtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantity_KeyDown);
            this.TxtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtQuantity_KeyUp);
            // 
            // TxtDiscount
            // 
            this.TxtDiscount.Location = new System.Drawing.Point(253, 123);
            this.TxtDiscount.Name = "TxtDiscount";
            this.TxtDiscount.Size = new System.Drawing.Size(244, 26);
            this.TxtDiscount.TabIndex = 14;
            this.TxtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDiscount_KeyDown);
            this.TxtDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtDiscount_KeyUp);
            // 
            // TxtSubTotal
            // 
            this.TxtSubTotal.Location = new System.Drawing.Point(503, 123);
            this.TxtSubTotal.Name = "TxtSubTotal";
            this.TxtSubTotal.Size = new System.Drawing.Size(244, 26);
            this.TxtSubTotal.TabIndex = 15;
            // 
            // TxtNetTotal
            // 
            this.TxtNetTotal.Location = new System.Drawing.Point(753, 123);
            this.TxtNetTotal.Name = "TxtNetTotal";
            this.TxtNetTotal.ReadOnly = true;
            this.TxtNetTotal.Size = new System.Drawing.Size(244, 26);
            this.TxtNetTotal.TabIndex = 16;
            // 
            // LblReceiptNo
            // 
            this.LblReceiptNo.AutoSize = true;
            this.LblReceiptNo.ForeColor = System.Drawing.Color.Wheat;
            this.LblReceiptNo.Location = new System.Drawing.Point(3, 0);
            this.LblReceiptNo.Name = "LblReceiptNo";
            this.LblReceiptNo.Size = new System.Drawing.Size(89, 19);
            this.LblReceiptNo.TabIndex = 18;
            this.LblReceiptNo.Text = "ReceiptNo";
            // 
            // BtnLoadReceipt
            // 
            this.BtnLoadReceipt.BackColor = System.Drawing.Color.White;
            this.BtnLoadReceipt.Location = new System.Drawing.Point(253, 3);
            this.BtnLoadReceipt.Name = "BtnLoadReceipt";
            this.BtnLoadReceipt.Size = new System.Drawing.Size(244, 24);
            this.BtnLoadReceipt.TabIndex = 19;
            this.BtnLoadReceipt.Text = "Load Receipt";
            this.BtnLoadReceipt.UseVisualStyleBackColor = false;
            // 
            // DGVReceiptBody
            // 
            this.DGVReceiptBody.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVReceiptBody.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVReceiptBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReceiptBody.Location = new System.Drawing.Point(12, 185);
            this.DGVReceiptBody.Name = "DGVReceiptBody";
            this.DGVReceiptBody.Size = new System.Drawing.Size(997, 294);
            this.DGVReceiptBody.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.LblBalanceAmount, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.LblTime, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.LblDate, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LblSubTotal, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LblTotalDiscount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.LblNetTotal, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnPrint, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnPrintPreview, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtGivenAmount, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 485);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.43478F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.43478F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.13044F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(997, 93);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // LblBalanceAmount
            // 
            this.LblBalanceAmount.AutoSize = true;
            this.LblBalanceAmount.ForeColor = System.Drawing.Color.White;
            this.LblBalanceAmount.Location = new System.Drawing.Point(600, 37);
            this.LblBalanceAmount.Name = "LblBalanceAmount";
            this.LblBalanceAmount.Size = new System.Drawing.Size(18, 19);
            this.LblBalanceAmount.TabIndex = 9;
            this.LblBalanceAmount.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(401, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 19);
            this.label13.TabIndex = 4;
            this.label13.Text = "Net Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(202, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "Totsl Discount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sub Total";
            // 
            // LblSubTotal
            // 
            this.LblSubTotal.AutoSize = true;
            this.LblSubTotal.ForeColor = System.Drawing.Color.White;
            this.LblSubTotal.Location = new System.Drawing.Point(3, 37);
            this.LblSubTotal.Name = "LblSubTotal";
            this.LblSubTotal.Size = new System.Drawing.Size(18, 19);
            this.LblSubTotal.TabIndex = 2;
            this.LblSubTotal.Text = "0";
            // 
            // LblTotalDiscount
            // 
            this.LblTotalDiscount.AutoSize = true;
            this.LblTotalDiscount.ForeColor = System.Drawing.Color.White;
            this.LblTotalDiscount.Location = new System.Drawing.Point(202, 37);
            this.LblTotalDiscount.Name = "LblTotalDiscount";
            this.LblTotalDiscount.Size = new System.Drawing.Size(18, 19);
            this.LblTotalDiscount.TabIndex = 3;
            this.LblTotalDiscount.Text = "0";
            // 
            // LblNetTotal
            // 
            this.LblNetTotal.AutoSize = true;
            this.LblNetTotal.ForeColor = System.Drawing.Color.White;
            this.LblNetTotal.Location = new System.Drawing.Point(401, 37);
            this.LblNetTotal.Name = "LblNetTotal";
            this.LblNetTotal.Size = new System.Drawing.Size(18, 19);
            this.LblNetTotal.TabIndex = 5;
            this.LblNetTotal.Text = "0";
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackColor = System.Drawing.Color.White;
            this.BtnPrint.Location = new System.Drawing.Point(799, 40);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(193, 31);
            this.BtnPrint.TabIndex = 7;
            this.BtnPrint.Text = "Print";
            this.BtnPrint.UseVisualStyleBackColor = false;
            // 
            // BtnPrintPreview
            // 
            this.BtnPrintPreview.BackColor = System.Drawing.Color.White;
            this.BtnPrintPreview.Location = new System.Drawing.Point(799, 3);
            this.BtnPrintPreview.Name = "BtnPrintPreview";
            this.BtnPrintPreview.Size = new System.Drawing.Size(195, 31);
            this.BtnPrintPreview.TabIndex = 6;
            this.BtnPrintPreview.Text = "Print Preview";
            this.BtnPrintPreview.UseVisualStyleBackColor = false;
            // 
            // TxtGivenAmount
            // 
            this.TxtGivenAmount.Location = new System.Drawing.Point(600, 3);
            this.TxtGivenAmount.Name = "TxtGivenAmount";
            this.TxtGivenAmount.Size = new System.Drawing.Size(193, 26);
            this.TxtGivenAmount.TabIndex = 8;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1027, 584);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.DGVReceiptBody);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "POS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS";
            this.Load += new System.EventHandler(this.POS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiptBody)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.TextBox TxtQuantity;
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
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnPrintPreview;
        private System.Windows.Forms.TextBox TxtGivenAmount;
        private System.Windows.Forms.Button BtnLoadReceipt;
    }
}