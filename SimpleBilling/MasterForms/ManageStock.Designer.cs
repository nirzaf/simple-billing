namespace SimpleBilling.MasterForms
{
    partial class ManageStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageStock));
            this.BaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DGVManageStocks = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtUpdateStockCount = new System.Windows.Forms.TextBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtFilterProducts = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BaseLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVManageStocks)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 2;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.16666F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
            this.BaseLayout.Controls.Add(this.DGVManageStocks, 0, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(0, 0);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 2;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.352941F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.64706F));
            this.BaseLayout.Size = new System.Drawing.Size(696, 476);
            this.BaseLayout.TabIndex = 0;
            // 
            // DGVManageStocks
            // 
            this.DGVManageStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVManageStocks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVManageStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVManageStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVManageStocks.Location = new System.Drawing.Point(3, 37);
            this.DGVManageStocks.Name = "DGVManageStocks";
            this.DGVManageStocks.Size = new System.Drawing.Size(544, 436);
            this.DGVManageStocks.TabIndex = 0;
            this.DGVManageStocks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVManageStocks_CellClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TxtUpdateStockCount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnUpdate, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(553, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(140, 436);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TxtUpdateStockCount
            // 
            this.TxtUpdateStockCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUpdateStockCount.Location = new System.Drawing.Point(3, 3);
            this.TxtUpdateStockCount.Name = "TxtUpdateStockCount";
            this.TxtUpdateStockCount.Size = new System.Drawing.Size(134, 26);
            this.TxtUpdateStockCount.TabIndex = 0;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.White;
            this.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnUpdate.Location = new System.Drawing.Point(3, 57);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(134, 48);
            this.BtnUpdate.TabIndex = 1;
            this.BtnUpdate.Text = "Update Stock ";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.17399F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.82601F));
            this.tableLayoutPanel2.Controls.Add(this.TxtFilterProducts, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(544, 28);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // TxtFilterProducts
            // 
            this.TxtFilterProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtFilterProducts.Location = new System.Drawing.Point(161, 3);
            this.TxtFilterProducts.Name = "TxtFilterProducts";
            this.TxtFilterProducts.Size = new System.Drawing.Size(380, 26);
            this.TxtFilterProducts.TabIndex = 0;
            this.TxtFilterProducts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtFilterProducts_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter Products";
            // 
            // ManageStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(696, 476);
            this.Controls.Add(this.BaseLayout);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ManageStock";
            this.Text = "ManageStock";
            this.Load += new System.EventHandler(this.ManageStock_Load);
            this.BaseLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVManageStocks)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.DataGridView DGVManageStocks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtUpdateStockCount;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox TxtFilterProducts;
        private System.Windows.Forms.Label label1;
    }
}