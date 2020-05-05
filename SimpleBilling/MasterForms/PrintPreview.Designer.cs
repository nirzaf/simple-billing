namespace SimpleBilling.MasterForms
{
    partial class PrintPreview
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
            this.BaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pdfExport1 = new Spire.DataExport.PDF.PDFExport();
            this.SuspendLayout();
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 2;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(0, 0);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 2;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BaseLayout.Size = new System.Drawing.Size(800, 450);
            this.BaseLayout.TabIndex = 0;
            // 
            // pdfExport1
            // 
            this.pdfExport1.DataFormats.CultureName = "en-US";
            this.pdfExport1.DataFormats.Currency = "c";
            this.pdfExport1.DataFormats.DateTime = "M/d/yyyy h:mm tt";
            this.pdfExport1.DataFormats.Float = "g";
            this.pdfExport1.DataFormats.Integer = "g";
            this.pdfExport1.DataFormats.Time = "h:mm tt";
            this.pdfExport1.PDFOptions.DataFont.CustomFont = new System.Drawing.Font("Arial", 10F);
            this.pdfExport1.PDFOptions.FooterFont.CustomFont = new System.Drawing.Font("Arial", 10F);
            this.pdfExport1.PDFOptions.HeaderFont.CustomFont = new System.Drawing.Font("Arial", 10F);
            this.pdfExport1.PDFOptions.PageOptions.Height = 11.68D;
            this.pdfExport1.PDFOptions.PageOptions.MarginBottom = 0.78D;
            this.pdfExport1.PDFOptions.PageOptions.MarginLeft = 1.17D;
            this.pdfExport1.PDFOptions.PageOptions.MarginRight = 0.58D;
            this.pdfExport1.PDFOptions.PageOptions.MarginTop = 0.78D;
            this.pdfExport1.PDFOptions.PageOptions.Width = 8.26D;
            this.pdfExport1.PDFOptions.TitleFont.CustomFont = new System.Drawing.Font("Arial", 10F);
            // 
            // PreviewPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BaseLayout);
            this.Name = "PreviewPDF";
            this.Text = "PreviewPDF";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private Spire.DataExport.PDF.PDFExport pdfExport1;
    }
}