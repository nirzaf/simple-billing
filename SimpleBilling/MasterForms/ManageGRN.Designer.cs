namespace SimpleBilling.MasterForms
{
    partial class ManageGRN
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
            this.DGVGRNList = new System.Windows.Forms.DataGridView();
            this.CRUDPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbProduct = new System.Windows.Forms.ComboBox();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtUnitCost = new System.Windows.Forms.TextBox();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtReference = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CMBSupplier = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnCreateGRN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGRNList)).BeginInit();
            this.CRUDPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVGRNList
            // 
            this.DGVGRNList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGRNList.Location = new System.Drawing.Point(-4, 130);
            this.DGVGRNList.Name = "DGVGRNList";
            this.DGVGRNList.Size = new System.Drawing.Size(909, 254);
            this.DGVGRNList.TabIndex = 0;
            // 
            // CRUDPanel
            // 
            this.CRUDPanel.Controls.Add(this.tableLayoutPanel1);
            this.CRUDPanel.Location = new System.Drawing.Point(-4, 0);
            this.CRUDPanel.Name = "CRUDPanel";
            this.CRUDPanel.Size = new System.Drawing.Size(909, 110);
            this.CRUDPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DTPDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CmbProduct, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtUnitCost, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.BtnAddItem, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtReference, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CMBSupplier, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnCreateGRN, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.23932F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.64103F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.65812F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.17094F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(183, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // DTPDate
            // 
            this.DTPDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDate.Location = new System.Drawing.Point(183, 21);
            this.DTPDate.Name = "DTPDate";
            this.DTPDate.Size = new System.Drawing.Size(174, 26);
            this.DTPDate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product";
            // 
            // CmbProduct
            // 
            this.CmbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbProduct.DataSource = this.itemBindingSource;
            this.CmbProduct.DisplayMember = "ItemName";
            this.CmbProduct.FormattingEnabled = true;
            this.CmbProduct.Location = new System.Drawing.Point(3, 72);
            this.CmbProduct.Name = "CmbProduct";
            this.CmbProduct.Size = new System.Drawing.Size(174, 27);
            this.CmbProduct.TabIndex = 9;
            this.CmbProduct.ValueMember = "Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(183, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quantity";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(183, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(174, 26);
            this.textBox3.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(363, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Unit Cost";
            // 
            // TxtUnitCost
            // 
            this.TxtUnitCost.Location = new System.Drawing.Point(363, 72);
            this.TxtUnitCost.Name = "TxtUnitCost";
            this.TxtUnitCost.Size = new System.Drawing.Size(174, 26);
            this.TxtUnitCost.TabIndex = 11;
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.BackColor = System.Drawing.Color.White;
            this.BtnAddItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddItem.Location = new System.Drawing.Point(543, 72);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(174, 26);
            this.BtnAddItem.TabIndex = 15;
            this.BtnAddItem.Text = "Add Item";
            this.BtnAddItem.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reference No";
            // 
            // TxtReference
            // 
            this.TxtReference.Location = new System.Drawing.Point(3, 21);
            this.TxtReference.Name = "TxtReference";
            this.TxtReference.Size = new System.Drawing.Size(174, 26);
            this.TxtReference.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(363, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Supplier";
            // 
            // CMBSupplier
            // 
            this.CMBSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CMBSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMBSupplier.DataSource = this.supplierBindingSource;
            this.CMBSupplier.DisplayMember = "Name";
            this.CMBSupplier.FormattingEnabled = true;
            this.CMBSupplier.Location = new System.Drawing.Point(363, 21);
            this.CMBSupplier.Name = "CMBSupplier";
            this.CMBSupplier.Size = new System.Drawing.Size(174, 27);
            this.CMBSupplier.TabIndex = 13;
            this.CMBSupplier.ValueMember = "SupplierId";
            // 
            // BtnCreateGRN
            // 
            this.BtnCreateGRN.BackColor = System.Drawing.Color.White;
            this.BtnCreateGRN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnCreateGRN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCreateGRN.FlatAppearance.BorderSize = 0;
            this.BtnCreateGRN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnCreateGRN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnCreateGRN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateGRN.Location = new System.Drawing.Point(543, 21);
            this.BtnCreateGRN.Name = "BtnCreateGRN";
            this.BtnCreateGRN.Size = new System.Drawing.Size(174, 23);
            this.BtnCreateGRN.TabIndex = 14;
            this.BtnCreateGRN.Text = "Create GRN";
            this.BtnCreateGRN.UseVisualStyleBackColor = false;
            this.BtnCreateGRN.Click += new System.EventHandler(this.BtnCreateGRN_Click);
            // 
            // ManageGRN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(904, 451);
            this.Controls.Add(this.CRUDPanel);
            this.Controls.Add(this.DGVGRNList);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ManageGRN";
            this.Text = "Good Received Note";
            this.Load += new System.EventHandler(this.ManageGRN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVGRNList)).EndInit();
            this.CRUDPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVGRNList;
        private System.Windows.Forms.Panel CRUDPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTPDate;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox TxtReference;
        private System.Windows.Forms.ComboBox CmbProduct;
        private System.Windows.Forms.TextBox TxtUnitCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CMBSupplier;
        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.Button BtnCreateGRN;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.BindingSource supplierBindingSource;
    }
}