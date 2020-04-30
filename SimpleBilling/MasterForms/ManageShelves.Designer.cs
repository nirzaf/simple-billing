namespace SimpleBilling.MasterForms
{
    partial class ManageShelves
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
            this.DGVShelf = new System.Windows.Forms.DataGridView();
            this.PanelCRUD = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.TxtShelfName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblMessage = new System.Windows.Forms.Label();
            this.MessageTimer = new System.Windows.Forms.Timer(this.components);
            this.shelfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shelfIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shelfNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVShelf)).BeginInit();
            this.PanelCRUD.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shelfBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVShelf
            // 
            this.DGVShelf.AutoGenerateColumns = false;
            this.DGVShelf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVShelf.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVShelf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVShelf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shelfIdDataGridViewTextBoxColumn,
            this.shelfNameDataGridViewTextBoxColumn});
            this.DGVShelf.DataSource = this.shelfBindingSource;
            this.DGVShelf.Location = new System.Drawing.Point(5, 38);
            this.DGVShelf.Name = "DGVShelf";
            this.DGVShelf.Size = new System.Drawing.Size(302, 371);
            this.DGVShelf.TabIndex = 0;
            this.DGVShelf.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVShelf_CellClick);
            // 
            // PanelCRUD
            // 
            this.PanelCRUD.Controls.Add(this.tableLayoutPanel1);
            this.PanelCRUD.Location = new System.Drawing.Point(311, 37);
            this.PanelCRUD.Name = "PanelCRUD";
            this.PanelCRUD.Size = new System.Drawing.Size(277, 133);
            this.PanelCRUD.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.16049F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtId, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtShelfName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.87302F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.19048F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.30159F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 126);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // TxtId
            // 
            this.TxtId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shelfBindingSource, "ShelfId", true));
            this.TxtId.Location = new System.Drawing.Point(3, 23);
            this.TxtId.Name = "TxtId";
            this.TxtId.ReadOnly = true;
            this.TxtId.Size = new System.Drawing.Size(267, 26);
            this.TxtId.TabIndex = 2;
            // 
            // TxtShelfName
            // 
            this.TxtShelfName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shelfBindingSource, "ShelfName", true));
            this.TxtShelfName.Location = new System.Drawing.Point(3, 80);
            this.TxtShelfName.Name = "TxtShelfName";
            this.TxtShelfName.Size = new System.Drawing.Size(267, 26);
            this.TxtShelfName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Shelf Name";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BtnDelete, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.BtnEdit, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnAdd, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnSave, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(369, 177);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(163, 232);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(3, 119);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(157, 52);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(3, 61);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(157, 52);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(3, 3);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(157, 52);
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(3, 177);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(157, 52);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblMessage
            // 
            this.LblMessage.AutoSize = true;
            this.LblMessage.ForeColor = System.Drawing.Color.Lime;
            this.LblMessage.Location = new System.Drawing.Point(1, 422);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(101, 19);
            this.LblMessage.TabIndex = 3;
            this.LblMessage.Text = "LblMessage";
            // 
            // MessageTimer
            // 
            this.MessageTimer.Enabled = true;
            this.MessageTimer.Interval = 6000;
            this.MessageTimer.Tick += new System.EventHandler(this.MessageTimer_Tick);
            // 
            // shelfBindingSource
            // 
            this.shelfBindingSource.DataSource = typeof(SimpleBilling.Model.Shelf);
            // 
            // shelfIdDataGridViewTextBoxColumn
            // 
            this.shelfIdDataGridViewTextBoxColumn.DataPropertyName = "ShelfId";
            this.shelfIdDataGridViewTextBoxColumn.HeaderText = "Shelf Id";
            this.shelfIdDataGridViewTextBoxColumn.Name = "shelfIdDataGridViewTextBoxColumn";
            // 
            // shelfNameDataGridViewTextBoxColumn
            // 
            this.shelfNameDataGridViewTextBoxColumn.DataPropertyName = "ShelfName";
            this.shelfNameDataGridViewTextBoxColumn.HeaderText = "Shelf Name";
            this.shelfNameDataGridViewTextBoxColumn.Name = "shelfNameDataGridViewTextBoxColumn";
            // 
            // ManageShelves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(594, 465);
            this.Controls.Add(this.LblMessage);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.PanelCRUD);
            this.Controls.Add(this.DGVShelf);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ManageShelves";
            this.Text = "ManageShelves";
            this.Load += new System.EventHandler(this.ManageShelves_Load);
            this.Click += new System.EventHandler(this.ManageShelves_Click);
            ((System.ComponentModel.ISupportInitialize)(this.DGVShelf)).EndInit();
            this.PanelCRUD.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shelfBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVShelf;
        private System.Windows.Forms.Panel PanelCRUD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtShelfName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.BindingSource shelfBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.Timer MessageTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn shelfIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shelfNameDataGridViewTextBoxColumn;
    }
}