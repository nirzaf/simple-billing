namespace SimpleBilling.Reports
{
    partial class VoidedReceipts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoidedReceipts));
            this.BaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DGVReport = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.BtnFilter = new System.Windows.Forms.Button();
            this.BaseLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReport)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseLayout
            // 
            this.BaseLayout.BackColor = System.Drawing.Color.DimGray;
            this.BaseLayout.ColumnCount = 1;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BaseLayout.Controls.Add(this.DGVReport, 0, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(0, 0);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 3;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.067437F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.86083F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.071736F));
            this.BaseLayout.Size = new System.Drawing.Size(833, 465);
            this.BaseLayout.TabIndex = 0;
            // 
            // DGVReport
            // 
            this.DGVReport.AllowUserToAddRows = false;
            this.DGVReport.AllowUserToDeleteRows = false;
            this.DGVReport.BackgroundColor = System.Drawing.Color.DimGray;
            this.DGVReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVReport.Location = new System.Drawing.Point(3, 40);
            this.DGVReport.Name = "DGVReport";
            this.DGVReport.ReadOnly = true;
            this.DGVReport.Size = new System.Drawing.Size(827, 388);
            this.DGVReport.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.DTPTo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DTPFrom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnFilter, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(827, 31);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // DTPFrom
            // 
            this.DTPFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFrom.Location = new System.Drawing.Point(3, 3);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(269, 22);
            this.DTPFrom.TabIndex = 0;
            // 
            // DTPTo
            // 
            this.DTPTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPTo.Location = new System.Drawing.Point(278, 3);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(269, 22);
            this.DTPTo.TabIndex = 1;
            // 
            // BtnFilter
            // 
            this.BtnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFilter.Location = new System.Drawing.Point(553, 3);
            this.BtnFilter.Name = "BtnFilter";
            this.BtnFilter.Size = new System.Drawing.Size(271, 25);
            this.BtnFilter.TabIndex = 2;
            this.BtnFilter.Text = "Filter";
            this.BtnFilter.UseVisualStyleBackColor = true;
            // 
            // VoidedReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 465);
            this.Controls.Add(this.BaseLayout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VoidedReceipts";
            this.Text = "VoidedReceipts";
            this.Load += new System.EventHandler(this.VoidedReceipts_Load);
            this.BaseLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReport)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.DataGridView DGVReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.Button BtnFilter;
    }
}