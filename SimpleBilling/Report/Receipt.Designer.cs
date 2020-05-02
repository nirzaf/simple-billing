namespace SimpleBilling.Report
{
    partial class Receipt
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receipt));
            this.ReceiptBody = new System.Windows.Forms.BindingSource(this.components);
            this.RVReceipt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReceiptHeader = new System.Windows.Forms.BindingSource(this.components);
            this.BusinessInfo = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ReceiptBody
            // 
            this.ReceiptBody.DataSource = typeof(SimpleBilling.Model.ReceiptBody);
            // 
            // RVReceipt
            // 
            this.RVReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Receipt";
            reportDataSource1.Value = this.ReceiptBody;
            this.RVReceipt.LocalReport.DataSources.Add(reportDataSource1);
            this.RVReceipt.LocalReport.ReportEmbeddedResource = "SimpleBilling.Report.Receipt.rdlc";
            this.RVReceipt.Location = new System.Drawing.Point(0, 0);
            this.RVReceipt.Name = "RVReceipt";
            this.RVReceipt.ServerReport.BearerToken = null;
            this.RVReceipt.Size = new System.Drawing.Size(721, 494);
            this.RVReceipt.TabIndex = 0;
            // 
            // ReceiptHeader
            // 
            this.ReceiptHeader.DataSource = typeof(SimpleBilling.Model.ReceiptHeader);
            // 
            // BusinessInfo
            // 
            this.BusinessInfo.DataSource = typeof(SimpleBilling.Model.BusinessModel);
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(721, 494);
            this.Controls.Add(this.RVReceipt);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt";
            this.Load += new System.EventHandler(this.Receipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RVReceipt;
        private System.Windows.Forms.BindingSource ReceiptBody;
        private System.Windows.Forms.BindingSource ReceiptHeader;
        private System.Windows.Forms.BindingSource BusinessInfo;
    }
}