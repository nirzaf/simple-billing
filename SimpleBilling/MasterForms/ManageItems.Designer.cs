namespace SimpleBilling.MasterForms
{
    partial class ManageItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageItems));
            this.DGVItems = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelCRUD = new System.Windows.Forms.TableLayoutPanel();
            this.TxtItemId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtItemCode = new System.Windows.Forms.TextBox();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.TxtUnit = new System.Windows.Forms.TextBox();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUnitCost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbShelf = new System.Windows.Forms.ComboBox();
            this.CmbCategories = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnAddShelf = new System.Windows.Forms.Button();
            this.BtnAddCategory = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ChkBoxIsService = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblMessage = new System.Windows.Forms.Label();
            this.TimerMessage = new System.Windows.Forms.Timer(this.components);
            this.BaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.PanelCRUD.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.BaseLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVItems
            // 
            this.DGVItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVItems.Location = new System.Drawing.Point(4, 54);
            this.DGVItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DGVItems.Name = "DGVItems";
            this.DGVItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVItems.Size = new System.Drawing.Size(713, 347);
            this.DGVItems.TabIndex = 0;
            this.DGVItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVItems_CellClick);
            this.DGVItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DGVItems_DataError);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item Code";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanelCRUD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(724, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 351);
            this.panel1.TabIndex = 2;
            // 
            // PanelCRUD
            // 
            this.PanelCRUD.ColumnCount = 3;
            this.PanelCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.54968F));
            this.PanelCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.43692F));
            this.PanelCRUD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0134F));
            this.PanelCRUD.Controls.Add(this.TxtItemId, 1, 0);
            this.PanelCRUD.Controls.Add(this.label6, 0, 0);
            this.PanelCRUD.Controls.Add(this.label2, 0, 2);
            this.PanelCRUD.Controls.Add(this.label1, 0, 1);
            this.PanelCRUD.Controls.Add(this.label3, 0, 3);
            this.PanelCRUD.Controls.Add(this.TxtItemCode, 1, 1);
            this.PanelCRUD.Controls.Add(this.TxtItemName, 1, 2);
            this.PanelCRUD.Controls.Add(this.TxtUnit, 1, 3);
            this.PanelCRUD.Controls.Add(this.TxtBarcode, 1, 5);
            this.PanelCRUD.Controls.Add(this.label4, 0, 5);
            this.PanelCRUD.Controls.Add(this.TxtUnitCost, 1, 4);
            this.PanelCRUD.Controls.Add(this.label7, 0, 4);
            this.PanelCRUD.Controls.Add(this.CmbShelf, 1, 9);
            this.PanelCRUD.Controls.Add(this.label8, 0, 9);
            this.PanelCRUD.Controls.Add(this.label5, 0, 8);
            this.PanelCRUD.Controls.Add(this.CmbCategories, 1, 8);
            this.PanelCRUD.Controls.Add(this.BtnAddShelf, 2, 9);
            this.PanelCRUD.Controls.Add(this.BtnAddCategory, 2, 8);
            this.PanelCRUD.Controls.Add(this.ChkBoxIsService, 1, 7);
            this.PanelCRUD.Controls.Add(this.label9, 0, 7);
            this.PanelCRUD.Controls.Add(this.label10, 0, 6);
            this.PanelCRUD.Controls.Add(this.textBox1, 1, 6);
            this.PanelCRUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCRUD.Location = new System.Drawing.Point(0, 0);
            this.PanelCRUD.Name = "PanelCRUD";
            this.PanelCRUD.RowCount = 10;
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelCRUD.Size = new System.Drawing.Size(523, 351);
            this.PanelCRUD.TabIndex = 2;
            // 
            // TxtItemId
            // 
            this.TxtItemId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtItemId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtItemId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemId.Location = new System.Drawing.Point(126, 3);
            this.TxtItemId.Name = "TxtItemId";
            this.TxtItemId.ReadOnly = true;
            this.TxtItemId.Size = new System.Drawing.Size(341, 26);
            this.TxtItemId.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 35);
            this.label6.TabIndex = 11;
            this.label6.Text = "Item Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(3, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unit";
            // 
            // TxtItemCode
            // 
            this.TxtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtItemCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtItemCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemCode.Location = new System.Drawing.Point(126, 38);
            this.TxtItemCode.Name = "TxtItemCode";
            this.TxtItemCode.Size = new System.Drawing.Size(341, 26);
            this.TxtItemCode.TabIndex = 6;
            // 
            // TxtItemName
            // 
            this.TxtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtItemName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemName.Location = new System.Drawing.Point(126, 73);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(341, 26);
            this.TxtItemName.TabIndex = 7;
            // 
            // TxtUnit
            // 
            this.TxtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUnit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUnit.Location = new System.Drawing.Point(126, 108);
            this.TxtUnit.Name = "TxtUnit";
            this.TxtUnit.Size = new System.Drawing.Size(341, 26);
            this.TxtUnit.TabIndex = 8;
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBarcode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBarcode.Location = new System.Drawing.Point(126, 178);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Size = new System.Drawing.Size(341, 26);
            this.TxtBarcode.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(3, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 35);
            this.label4.TabIndex = 4;
            this.label4.Text = "Barcode";
            // 
            // TxtUnitCost
            // 
            this.TxtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUnitCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUnitCost.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUnitCost.Location = new System.Drawing.Point(126, 143);
            this.TxtUnitCost.Name = "TxtUnitCost";
            this.TxtUnitCost.Size = new System.Drawing.Size(341, 26);
            this.TxtUnitCost.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(3, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 35);
            this.label7.TabIndex = 15;
            this.label7.Text = "Unit Cost";
            // 
            // CmbShelf
            // 
            this.CmbShelf.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.categoryBindingSource, "Items", true));
            this.CmbShelf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbShelf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbShelf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbShelf.FormattingEnabled = true;
            this.CmbShelf.Location = new System.Drawing.Point(126, 318);
            this.CmbShelf.Name = "CmbShelf";
            this.CmbShelf.Size = new System.Drawing.Size(341, 28);
            this.CmbShelf.TabIndex = 17;
            // 
            // CmbCategories
            // 
            this.CmbCategories.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.categoryBindingSource, "Items", true));
            this.CmbCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategories.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbCategories.FormattingEnabled = true;
            this.CmbCategories.Location = new System.Drawing.Point(126, 283);
            this.CmbCategories.Name = "CmbCategories";
            this.CmbCategories.Size = new System.Drawing.Size(341, 28);
            this.CmbCategories.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(3, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 36);
            this.label8.TabIndex = 16;
            this.label8.Text = "Shelf";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(3, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 35);
            this.label5.TabIndex = 5;
            this.label5.Text = "Categories";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // BtnAddShelf
            // 
            this.BtnAddShelf.BackColor = System.Drawing.Color.White;
            this.BtnAddShelf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddShelf.Location = new System.Drawing.Point(473, 318);
            this.BtnAddShelf.Name = "BtnAddShelf";
            this.BtnAddShelf.Size = new System.Drawing.Size(47, 30);
            this.BtnAddShelf.TabIndex = 18;
            this.BtnAddShelf.Text = "+";
            this.BtnAddShelf.UseVisualStyleBackColor = false;
            this.BtnAddShelf.Click += new System.EventHandler(this.BtnAddShelf_Click);
            // 
            // BtnAddCategory
            // 
            this.BtnAddCategory.BackColor = System.Drawing.Color.White;
            this.BtnAddCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddCategory.Location = new System.Drawing.Point(473, 283);
            this.BtnAddCategory.Name = "BtnAddCategory";
            this.BtnAddCategory.Size = new System.Drawing.Size(47, 29);
            this.BtnAddCategory.TabIndex = 13;
            this.BtnAddCategory.Text = "+";
            this.BtnAddCategory.UseVisualStyleBackColor = false;
            this.BtnAddCategory.Click += new System.EventHandler(this.BtnAddCategory_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 35);
            this.label9.TabIndex = 19;
            this.label9.Text = "Is Service";
            // 
            // ChkBoxIsService
            // 
            this.ChkBoxIsService.AutoSize = true;
            this.ChkBoxIsService.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.itemBindingSource, "IsService", true));
            this.ChkBoxIsService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkBoxIsService.ForeColor = System.Drawing.Color.White;
            this.ChkBoxIsService.Location = new System.Drawing.Point(126, 248);
            this.ChkBoxIsService.Name = "ChkBoxIsService";
            this.ChkBoxIsService.Size = new System.Drawing.Size(341, 29);
            this.ChkBoxIsService.TabIndex = 20;
            this.ChkBoxIsService.Text = "Check If Yes";
            this.ChkBoxIsService.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.BtnSave, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnDelete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnEdit, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnAdd, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(724, 409);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(523, 45);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSave.Location = new System.Drawing.Point(419, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(101, 39);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.White;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCancel.Location = new System.Drawing.Point(315, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(98, 39);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.White;
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Location = new System.Drawing.Point(211, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(98, 39);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.White;
            this.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnEdit.Location = new System.Drawing.Point(107, 3);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(98, 39);
            this.BtnEdit.TabIndex = 12;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.White;
            this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAdd.Location = new System.Drawing.Point(3, 3);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(98, 39);
            this.BtnAdd.TabIndex = 11;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblMessage
            // 
            this.LblMessage.AutoSize = true;
            this.LblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMessage.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMessage.ForeColor = System.Drawing.Color.LawnGreen;
            this.LblMessage.Location = new System.Drawing.Point(3, 406);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(715, 51);
            this.LblMessage.TabIndex = 3;
            this.LblMessage.Text = "Message";
            // 
            // TimerMessage
            // 
            this.TimerMessage.Enabled = true;
            this.TimerMessage.Interval = 6000;
            this.TimerMessage.Tick += new System.EventHandler(this.TimerMessage_Tick);
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 2;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.76F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.24F));
            this.BaseLayout.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.BaseLayout.Controls.Add(this.panel1, 1, 1);
            this.BaseLayout.Controls.Add(this.LblMessage, 0, 2);
            this.BaseLayout.Controls.Add(this.DGVItems, 0, 1);
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(0, 0);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 3;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.90909F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.18182F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.90909F));
            this.BaseLayout.Size = new System.Drawing.Size(1250, 457);
            this.BaseLayout.TabIndex = 4;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(SimpleBilling.Model.Category);
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(SimpleBilling.Model.Item);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 35);
            this.label10.TabIndex = 21;
            this.label10.Text = "Printable Name";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(126, 213);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(341, 26);
            this.textBox1.TabIndex = 22;
            // 
            // ManageItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1250, 457);
            this.Controls.Add(this.BaseLayout);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ManageItems";
            this.Text = "Manage Items";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.PanelCRUD.ResumeLayout(false);
            this.PanelCRUD.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.BaseLayout.ResumeLayout(false);
            this.BaseLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel PanelCRUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtItemCode;
        private System.Windows.Forms.TextBox TxtItemName;
        private System.Windows.Forms.TextBox TxtUnit;
        private System.Windows.Forms.TextBox TxtBarcode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ComboBox CmbCategories;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.TextBox TxtItemId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.Timer TimerMessage;
        private System.Windows.Forms.Button BtnAddCategory;
        private System.Windows.Forms.TextBox TxtUnitCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbShelf;
        private System.Windows.Forms.Button BtnAddShelf;
        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ChkBoxIsService;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
    }
}