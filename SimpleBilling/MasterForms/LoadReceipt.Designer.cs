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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadReceipt));
            this.DGVLoadReceipt = new System.Windows.Forms.DataGridView();
            this.BtnLoadReceipt = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFilterReceipts = new System.Windows.Forms.TextBox();
            this.BtnGetTodaysReceipts = new System.Windows.Forms.Button();
            this.BtnViewAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnExportAsExcel = new System.Windows.Forms.Button();
            this.BtnExportAsPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoadReceipt)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVLoadReceipt
            // 
            this.DGVLoadReceipt.AllowUserToAddRows = false;
            this.DGVLoadReceipt.AllowUserToDeleteRows = false;
            this.DGVLoadReceipt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVLoadReceipt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVLoadReceipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVLoadReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLoadReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVLoadReceipt.Location = new System.Drawing.Point(3, 77);
            this.DGVLoadReceipt.MultiSelect = false;
            this.DGVLoadReceipt.Name = "DGVLoadReceipt";
            this.DGVLoadReceipt.ReadOnly = true;
            this.DGVLoadReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVLoadReceipt.Size = new System.Drawing.Size(1227, 379);
            this.DGVLoadReceipt.TabIndex = 0;
            this.DGVLoadReceipt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLoadReceipt_CellDoubleClick);
            // 
            // BtnLoadReceipt
            // 
            this.BtnLoadReceipt.BackColor = System.Drawing.Color.White;
            this.BtnLoadReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoadReceipt.Location = new System.Drawing.Point(1023, 3);
            this.BtnLoadReceipt.Name = "BtnLoadReceipt";
            this.BtnLoadReceipt.Size = new System.Drawing.Size(201, 40);
            this.BtnLoadReceipt.TabIndex = 1;
            this.BtnLoadReceipt.Text = "Load Receipt";
            this.BtnLoadReceipt.UseVisualStyleBackColor = false;
            this.BtnLoadReceipt.Click += new System.EventHandler(this.BtnLoadReceipt_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DGVLoadReceipt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.48141F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.34247F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1233, 511);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.25653F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.77584F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.02366F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.19733F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.74665F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtFilterReceipts, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnGetTodaysReceipts, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnViewAll, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1227, 68);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Receipts";
            // 
            // TxtFilterReceipts
            // 
            this.TxtFilterReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtFilterReceipts.Location = new System.Drawing.Point(141, 3);
            this.TxtFilterReceipts.Name = "TxtFilterReceipts";
            this.TxtFilterReceipts.Size = new System.Drawing.Size(310, 26);
            this.TxtFilterReceipts.TabIndex = 1;
            this.TxtFilterReceipts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtFilterReceipts_KeyUp);
            // 
            // BtnGetTodaysReceipts
            // 
            this.BtnGetTodaysReceipts.BackColor = System.Drawing.Color.White;
            this.BtnGetTodaysReceipts.Location = new System.Drawing.Point(457, 3);
            this.BtnGetTodaysReceipts.Name = "BtnGetTodaysReceipts";
            this.BtnGetTodaysReceipts.Size = new System.Drawing.Size(264, 28);
            this.BtnGetTodaysReceipts.TabIndex = 2;
            this.BtnGetTodaysReceipts.Text = "Todays Receipts";
            this.BtnGetTodaysReceipts.UseVisualStyleBackColor = false;
            this.BtnGetTodaysReceipts.Click += new System.EventHandler(this.BtnGetTodaysReceipts_Click);
            // 
            // BtnViewAll
            // 
            this.BtnViewAll.BackColor = System.Drawing.Color.White;
            this.BtnViewAll.Location = new System.Drawing.Point(727, 3);
            this.BtnViewAll.Name = "BtnViewAll";
            this.BtnViewAll.Size = new System.Drawing.Size(217, 28);
            this.BtnViewAll.TabIndex = 3;
            this.BtnViewAll.Text = "View All Receipts";
            this.BtnViewAll.UseVisualStyleBackColor = false;
            this.BtnViewAll.Click += new System.EventHandler(this.BtnViewAll_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Controls.Add(this.BtnLoadReceipt, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnExportAsExcel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnExportAsPDF, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 462);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1227, 46);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // BtnExportAsExcel
            // 
            this.BtnExportAsExcel.BackColor = System.Drawing.Color.White;
            this.BtnExportAsExcel.Location = new System.Drawing.Point(3, 3);
            this.BtnExportAsExcel.Name = "BtnExportAsExcel";
            this.BtnExportAsExcel.Size = new System.Drawing.Size(198, 40);
            this.BtnExportAsExcel.TabIndex = 2;
            this.BtnExportAsExcel.Text = "Export to Excel";
            this.BtnExportAsExcel.UseVisualStyleBackColor = false;
            this.BtnExportAsExcel.Click += new System.EventHandler(this.BtnExportAsExcel_Click);
            // 
            // BtnExportAsPDF
            // 
            this.BtnExportAsPDF.BackColor = System.Drawing.Color.White;
            this.BtnExportAsPDF.Location = new System.Drawing.Point(207, 3);
            this.BtnExportAsPDF.Name = "BtnExportAsPDF";
            this.BtnExportAsPDF.Size = new System.Drawing.Size(198, 40);
            this.BtnExportAsPDF.TabIndex = 3;
            this.BtnExportAsPDF.Text = "Export to PDF";
            this.BtnExportAsPDF.UseVisualStyleBackColor = false;
            this.BtnExportAsPDF.Click += new System.EventHandler(this.BtnExportAsPDF_Click);
            // 
            // LoadReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1233, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "LoadReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Receipt";
            this.Load += new System.EventHandler(this.LoadReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoadReceipt)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVLoadReceipt;
        private System.Windows.Forms.Button BtnLoadReceipt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFilterReceipts;
        private System.Windows.Forms.Button BtnGetTodaysReceipts;
        private System.Windows.Forms.Button BtnViewAll;
        private System.Windows.Forms.Button BtnExportAsExcel;
        private System.Windows.Forms.Button BtnExportAsPDF;
    }
}