namespace SimpleBilling.MasterForms
{
    partial class ManageEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageEmployees));
            this.DGVEmployees = new System.Windows.Forms.DataGridView();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CRUDPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtSecretCode = new System.Windows.Forms.TextBox();
            this.employeeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtContact = new System.Windows.Forms.TextBox();
            this.TxtEmployeeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtEmployeeId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtSearchEmployees = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.CRUDPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVEmployees
            // 
            this.DGVEmployees.AllowUserToAddRows = false;
            this.DGVEmployees.AllowUserToDeleteRows = false;
            this.DGVEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVEmployees.Location = new System.Drawing.Point(3, 38);
            this.DGVEmployees.Name = "DGVEmployees";
            this.DGVEmployees.ReadOnly = true;
            this.DGVEmployees.Size = new System.Drawing.Size(1053, 251);
            this.DGVEmployees.TabIndex = 0;
            this.DGVEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployees_CellClick);
            // 
            // CRUDPanel
            // 
            this.CRUDPanel.Controls.Add(this.tableLayoutPanel1);
            this.CRUDPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRUDPanel.Location = new System.Drawing.Point(3, 295);
            this.CRUDPanel.Name = "CRUDPanel";
            this.CRUDPanel.Size = new System.Drawing.Size(1053, 128);
            this.CRUDPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.TxtSecretCode, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtEmail, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.TxtAddress, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TxtContact, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtEmployeeName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtEmployeeId, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.44444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.40741F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.88889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1050, 135);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtSecretCode
            // 
            this.TxtSecretCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource1, "SecretCode", true));
            this.TxtSecretCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtSecretCode.Location = new System.Drawing.Point(703, 97);
            this.TxtSecretCode.Name = "TxtSecretCode";
            this.TxtSecretCode.Size = new System.Drawing.Size(344, 26);
            this.TxtSecretCode.TabIndex = 12;
            // 
            // employeeBindingSource1
            // 
            this.employeeBindingSource1.DataSource = typeof(SimpleBilling.Model.Employee);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(703, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(344, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Secret Code";
            // 
            // TxtEmail
            // 
            this.TxtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource1, "Email", true));
            this.TxtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEmail.Location = new System.Drawing.Point(353, 97);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(344, 26);
            this.TxtEmail.TabIndex = 10;
            // 
            // TxtAddress
            // 
            this.TxtAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource1, "Address", true));
            this.TxtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtAddress.Location = new System.Drawing.Point(3, 97);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(344, 26);
            this.TxtAddress.TabIndex = 9;
            this.TxtAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtAddress_KeyUp);
            // 
            // TxtContact
            // 
            this.TxtContact.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource1, "Contact", true));
            this.TxtContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtContact.Location = new System.Drawing.Point(703, 36);
            this.TxtContact.Name = "TxtContact";
            this.TxtContact.Size = new System.Drawing.Size(344, 26);
            this.TxtContact.TabIndex = 8;
            // 
            // TxtEmployeeName
            // 
            this.TxtEmployeeName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource1, "EmployeeName", true));
            this.TxtEmployeeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEmployeeName.Location = new System.Drawing.Point(353, 36);
            this.TxtEmployeeName.Name = "TxtEmployeeName";
            this.TxtEmployeeName.Size = new System.Drawing.Size(344, 26);
            this.TxtEmployeeName.TabIndex = 7;
            this.TxtEmployeeName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtEmployeeName_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(703, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contact";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(353, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(353, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // TxtEmployeeId
            // 
            this.TxtEmployeeId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource1, "EmployeeId", true));
            this.TxtEmployeeId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEmployeeId.Location = new System.Drawing.Point(3, 36);
            this.TxtEmployeeId.Name = "TxtEmployeeId";
            this.TxtEmployeeId.ReadOnly = true;
            this.TxtEmployeeId.Size = new System.Drawing.Size(344, 26);
            this.TxtEmployeeId.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 429);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1053, 51);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSave.Location = new System.Drawing.Point(843, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(207, 45);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.White;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCancel.Location = new System.Drawing.Point(633, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(204, 45);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.White;
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Location = new System.Drawing.Point(423, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(204, 45);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.White;
            this.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnEdit.Location = new System.Drawing.Point(213, 3);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(204, 45);
            this.BtnEdit.TabIndex = 1;
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
            this.BtnAdd.Size = new System.Drawing.Size(204, 45);
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.DGVEmployees, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.CRUDPanel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.246377F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.20911F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.74327F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5942F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1059, 483);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.61918F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.38081F));
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.TxtSearchEmployees, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1053, 29);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(19, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Search Employees";
            // 
            // TxtSearchEmployees
            // 
            this.TxtSearchEmployees.Dock = System.Windows.Forms.DockStyle.Left;
            this.TxtSearchEmployees.Location = new System.Drawing.Point(177, 3);
            this.TxtSearchEmployees.Name = "TxtSearchEmployees";
            this.TxtSearchEmployees.Size = new System.Drawing.Size(440, 26);
            this.TxtSearchEmployees.TabIndex = 1;
            this.TxtSearchEmployees.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSearchEmployees_KeyUp);
            // 
            // ManageEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1059, 483);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ManageEmployees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Employees";
            this.Load += new System.EventHandler(this.ManageEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.CRUDPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVEmployees;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.FlowLayoutPanel CRUDPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtContact;
        private System.Windows.Forms.TextBox TxtEmployeeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtEmployeeId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TxtSecretCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource employeeBindingSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtSearchEmployees;
    }
}