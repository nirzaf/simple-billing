namespace SimpleBilling.MasterForms
{
    partial class LoadReceipt
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
            this.DGVLoadReceipt = new System.Windows.Forms.DataGridView();
            this.BtnLoadReceipt = new System.Windows.Forms.Button();
            this.receiptHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receiptNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDiscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoadReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptHeaderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVLoadReceipt
            // 
            this.DGVLoadReceipt.AutoGenerateColumns = false;
            this.DGVLoadReceipt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVLoadReceipt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVLoadReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLoadReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receiptNoDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.totalDiscountDataGridViewTextBoxColumn,
            this.subTotalDataGridViewTextBoxColumn,
            this.netTotalDataGridViewTextBoxColumn,
            this.paidAmountDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn});
            this.DGVLoadReceipt.DataSource = this.receiptHeaderBindingSource;
            this.DGVLoadReceipt.Location = new System.Drawing.Point(2, 29);
            this.DGVLoadReceipt.Name = "DGVLoadReceipt";
            this.DGVLoadReceipt.Size = new System.Drawing.Size(1230, 438);
            this.DGVLoadReceipt.TabIndex = 0;
            // 
            // BtnLoadReceipt
            // 
            this.BtnLoadReceipt.BackColor = System.Drawing.Color.White;
            this.BtnLoadReceipt.Location = new System.Drawing.Point(810, 473);
            this.BtnLoadReceipt.Name = "BtnLoadReceipt";
            this.BtnLoadReceipt.Size = new System.Drawing.Size(157, 33);
            this.BtnLoadReceipt.TabIndex = 1;
            this.BtnLoadReceipt.Text = "Load Receipt";
            this.BtnLoadReceipt.UseVisualStyleBackColor = false;
            // 
            // receiptHeaderBindingSource
            // 
            this.receiptHeaderBindingSource.DataSource = typeof(SimpleBilling.Model.ReceiptHeader);
            // 
            // receiptNoDataGridViewTextBoxColumn
            // 
            this.receiptNoDataGridViewTextBoxColumn.DataPropertyName = "ReceiptNo";
            this.receiptNoDataGridViewTextBoxColumn.HeaderText = "Receipt No";
            this.receiptNoDataGridViewTextBoxColumn.Name = "receiptNoDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // totalDiscountDataGridViewTextBoxColumn
            // 
            this.totalDiscountDataGridViewTextBoxColumn.DataPropertyName = "TotalDiscount";
            this.totalDiscountDataGridViewTextBoxColumn.HeaderText = "Total Discount";
            this.totalDiscountDataGridViewTextBoxColumn.Name = "totalDiscountDataGridViewTextBoxColumn";
            // 
            // subTotalDataGridViewTextBoxColumn
            // 
            this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
            this.subTotalDataGridViewTextBoxColumn.HeaderText = "Sub Total";
            this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
            // 
            // netTotalDataGridViewTextBoxColumn
            // 
            this.netTotalDataGridViewTextBoxColumn.DataPropertyName = "NetTotal";
            this.netTotalDataGridViewTextBoxColumn.HeaderText = "Net Total";
            this.netTotalDataGridViewTextBoxColumn.Name = "netTotalDataGridViewTextBoxColumn";
            // 
            // paidAmountDataGridViewTextBoxColumn
            // 
            this.paidAmountDataGridViewTextBoxColumn.DataPropertyName = "PaidAmount";
            this.paidAmountDataGridViewTextBoxColumn.HeaderText = "Paid Amount";
            this.paidAmountDataGridViewTextBoxColumn.Name = "paidAmountDataGridViewTextBoxColumn";
            // 
            // balanceDataGridViewTextBoxColumn
            // 
            this.balanceDataGridViewTextBoxColumn.DataPropertyName = "Balance";
            this.balanceDataGridViewTextBoxColumn.HeaderText = "Balance";
            this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
            // 
            // LoadReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1233, 511);
            this.Controls.Add(this.BtnLoadReceipt);
            this.Controls.Add(this.DGVLoadReceipt);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "LoadReceipt";
            this.Text = "Load Receipt";
            this.Load += new System.EventHandler(this.LoadReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoadReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptHeaderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVLoadReceipt;
        private System.Windows.Forms.Button BtnLoadReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDiscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn netTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource receiptHeaderBindingSource;
    }
}