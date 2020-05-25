﻿namespace SimpleBilling.MasterForms
{
    partial class GRNInvoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GRNInvoices));
            this.DGVInvoices = new System.Windows.Forms.DataGridView();
            this.BtnLoadInvoice = new System.Windows.Forms.Button();
            this.BaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSearchGRNInvoices = new System.Windows.Forms.TextBox();
            this.BtnExportPDF = new System.Windows.Forms.Button();
            this.BtnExportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInvoices)).BeginInit();
            this.BaseLayout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVInvoices
            // 
            this.DGVInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVInvoices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVInvoices.Location = new System.Drawing.Point(3, 40);
            this.DGVInvoices.Name = "DGVInvoices";
            this.DGVInvoices.Size = new System.Drawing.Size(933, 322);
            this.DGVInvoices.TabIndex = 0;
            this.DGVInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVInvoices_CellClick);
            this.DGVInvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVInvoices_CellDoubleClick);
            this.DGVInvoices.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DGVInvoices_MouseUp);
            // 
            // BtnLoadInvoice
            // 
            this.BtnLoadInvoice.BackColor = System.Drawing.Color.White;
            this.BtnLoadInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoadInvoice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadInvoice.ForeColor = System.Drawing.Color.Black;
            this.BtnLoadInvoice.Location = new System.Drawing.Point(778, 3);
            this.BtnLoadInvoice.Name = "BtnLoadInvoice";
            this.BtnLoadInvoice.Size = new System.Drawing.Size(152, 31);
            this.BtnLoadInvoice.TabIndex = 1;
            this.BtnLoadInvoice.Text = "Load Invoice";
            this.BtnLoadInvoice.UseVisualStyleBackColor = false;
            this.BtnLoadInvoice.Click += new System.EventHandler(this.BtnLoadInvoice_Click);
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 1;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BaseLayout.Controls.Add(this.DGVInvoices, 0, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(0, 0);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 3;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.068627F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.39216F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.30928F));
            this.BaseLayout.Size = new System.Drawing.Size(939, 408);
            this.BaseLayout.TabIndex = 2;
            this.BaseLayout.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BaseLayout_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.BtnExportExcel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnLoadInvoice, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnExportPDF, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 368);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(933, 37);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.57556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.37192F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.29153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.72026F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.46945F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtSearchGRNInvoices, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(933, 31);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // TxtSearchGRNInvoices
            // 
            this.TxtSearchGRNInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtSearchGRNInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearchGRNInvoices.Location = new System.Drawing.Point(110, 3);
            this.TxtSearchGRNInvoices.Name = "TxtSearchGRNInvoices";
            this.TxtSearchGRNInvoices.Size = new System.Drawing.Size(378, 26);
            this.TxtSearchGRNInvoices.TabIndex = 1;
            this.TxtSearchGRNInvoices.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSearchGRNInvoices_KeyUp);
            // 
            // BtnExportPDF
            // 
            this.BtnExportPDF.BackColor = System.Drawing.Color.White;
            this.BtnExportPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExportPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportPDF.Location = new System.Drawing.Point(3, 3);
            this.BtnExportPDF.Name = "BtnExportPDF";
            this.BtnExportPDF.Size = new System.Drawing.Size(149, 31);
            this.BtnExportPDF.TabIndex = 2;
            this.BtnExportPDF.Text = "Export as PDF";
            this.BtnExportPDF.UseVisualStyleBackColor = false;
            // 
            // BtnExportExcel
            // 
            this.BtnExportExcel.BackColor = System.Drawing.Color.White;
            this.BtnExportExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportExcel.Location = new System.Drawing.Point(158, 3);
            this.BtnExportExcel.Name = "BtnExportExcel";
            this.BtnExportExcel.Size = new System.Drawing.Size(149, 31);
            this.BtnExportExcel.TabIndex = 3;
            this.BtnExportExcel.Text = "Export as Excel";
            this.BtnExportExcel.UseVisualStyleBackColor = false;
            // 
            // GRNInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(939, 408);
            this.Controls.Add(this.BaseLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GRNInvoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRN Invoices";
            this.Load += new System.EventHandler(this.GRNInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVInvoices)).EndInit();
            this.BaseLayout.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVInvoices;
        private System.Windows.Forms.Button BtnLoadInvoice;
        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSearchGRNInvoices;
        private System.Windows.Forms.Button BtnExportPDF;
        private System.Windows.Forms.Button BtnExportExcel;
    }
}