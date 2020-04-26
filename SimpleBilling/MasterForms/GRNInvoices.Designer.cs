namespace SimpleBilling.MasterForms
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
            this.DGVInvoices = new System.Windows.Forms.DataGridView();
            this.BtnLoadInvoice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVInvoices
            // 
            this.DGVInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVInvoices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVInvoices.Location = new System.Drawing.Point(3, 38);
            this.DGVInvoices.Name = "DGVInvoices";
            this.DGVInvoices.Size = new System.Drawing.Size(934, 317);
            this.DGVInvoices.TabIndex = 0;
            this.DGVInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVInvoices_CellClick);
            // 
            // BtnLoadInvoice
            // 
            this.BtnLoadInvoice.BackColor = System.Drawing.Color.White;
            this.BtnLoadInvoice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadInvoice.ForeColor = System.Drawing.Color.Black;
            this.BtnLoadInvoice.Location = new System.Drawing.Point(821, 361);
            this.BtnLoadInvoice.Name = "BtnLoadInvoice";
            this.BtnLoadInvoice.Size = new System.Drawing.Size(116, 37);
            this.BtnLoadInvoice.TabIndex = 1;
            this.BtnLoadInvoice.Text = "Load Invoice";
            this.BtnLoadInvoice.UseVisualStyleBackColor = false;
            this.BtnLoadInvoice.Click += new System.EventHandler(this.BtnLoadInvoice_Click);
            // 
            // GRNInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(939, 430);
            this.Controls.Add(this.BtnLoadInvoice);
            this.Controls.Add(this.DGVInvoices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GRNInvoices";
            this.Text = "GRNInvoices";
            this.Load += new System.EventHandler(this.GRNInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVInvoices;
        private System.Windows.Forms.Button BtnLoadInvoice;
    }
}