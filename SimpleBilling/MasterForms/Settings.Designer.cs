namespace SimpleBilling.MasterForms
{
    partial class Settings
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSetSavePath = new System.Windows.Forms.Button();
            this.TxtDefaultPath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDefaultGRNPath = new System.Windows.Forms.Button();
            this.TxtDefaultGRN = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSetDefaultExceptionFolder = new System.Windows.Forms.Button();
            this.TxtDefaultExceptionFolder = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMinReorderValue = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.TxtServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDbName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSaveConnectionString = new System.Windows.Forms.Button();
            this.ChkTrustedConnection = new System.Windows.Forms.CheckBox();
            this.TlpDefaultQuotationPath = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSetDefaultQuotationPath = new System.Windows.Forms.Button();
            this.TxtDefaultQuotationPath = new System.Windows.Forms.TextBox();
            this.BaseLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.TlpDefaultQuotationPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 2;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.BaseLayout.Controls.Add(this.TlpDefaultQuotationPath, 0, 3);
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(0, 0);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 4;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.Size = new System.Drawing.Size(891, 454);
            this.BaseLayout.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BtnSetSavePath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtDefaultPath, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 107);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnSetSavePath
            // 
            this.BtnSetSavePath.BackColor = System.Drawing.Color.White;
            this.BtnSetSavePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetSavePath.Location = new System.Drawing.Point(3, 3);
            this.BtnSetSavePath.Name = "BtnSetSavePath";
            this.BtnSetSavePath.Size = new System.Drawing.Size(433, 29);
            this.BtnSetSavePath.TabIndex = 0;
            this.BtnSetSavePath.Text = "Set Default Receipt Folder";
            this.BtnSetSavePath.UseVisualStyleBackColor = false;
            this.BtnSetSavePath.Click += new System.EventHandler(this.BtnSetSavePath_Click);
            // 
            // TxtDefaultPath
            // 
            this.TxtDefaultPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDefaultPath.Location = new System.Drawing.Point(3, 38);
            this.TxtDefaultPath.Name = "TxtDefaultPath";
            this.TxtDefaultPath.ReadOnly = true;
            this.TxtDefaultPath.Size = new System.Drawing.Size(433, 26);
            this.TxtDefaultPath.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.BtnDefaultGRNPath, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.TxtDefaultGRN, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 116);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(439, 107);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // BtnDefaultGRNPath
            // 
            this.BtnDefaultGRNPath.BackColor = System.Drawing.Color.White;
            this.BtnDefaultGRNPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDefaultGRNPath.Location = new System.Drawing.Point(3, 3);
            this.BtnDefaultGRNPath.Name = "BtnDefaultGRNPath";
            this.BtnDefaultGRNPath.Size = new System.Drawing.Size(433, 29);
            this.BtnDefaultGRNPath.TabIndex = 0;
            this.BtnDefaultGRNPath.Text = "Set Default GRN Folder";
            this.BtnDefaultGRNPath.UseVisualStyleBackColor = false;
            this.BtnDefaultGRNPath.Click += new System.EventHandler(this.BtnDefaultGRNPath_Click);
            // 
            // TxtDefaultGRN
            // 
            this.TxtDefaultGRN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDefaultGRN.Location = new System.Drawing.Point(3, 38);
            this.TxtDefaultGRN.Name = "TxtDefaultGRN";
            this.TxtDefaultGRN.ReadOnly = true;
            this.TxtDefaultGRN.Size = new System.Drawing.Size(433, 26);
            this.TxtDefaultGRN.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.BtnSetDefaultExceptionFolder, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.TxtDefaultExceptionFolder, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 229);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(439, 107);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // BtnSetDefaultExceptionFolder
            // 
            this.BtnSetDefaultExceptionFolder.BackColor = System.Drawing.Color.White;
            this.BtnSetDefaultExceptionFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetDefaultExceptionFolder.Location = new System.Drawing.Point(3, 3);
            this.BtnSetDefaultExceptionFolder.Name = "BtnSetDefaultExceptionFolder";
            this.BtnSetDefaultExceptionFolder.Size = new System.Drawing.Size(433, 29);
            this.BtnSetDefaultExceptionFolder.TabIndex = 0;
            this.BtnSetDefaultExceptionFolder.Text = "Set Default Exception Folder";
            this.BtnSetDefaultExceptionFolder.UseVisualStyleBackColor = false;
            this.BtnSetDefaultExceptionFolder.Click += new System.EventHandler(this.BtnSetDefaultExceptionFolder_Click);
            // 
            // TxtDefaultExceptionFolder
            // 
            this.TxtDefaultExceptionFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDefaultExceptionFolder.Location = new System.Drawing.Point(3, 38);
            this.TxtDefaultExceptionFolder.Name = "TxtDefaultExceptionFolder";
            this.TxtDefaultExceptionFolder.ReadOnly = true;
            this.TxtDefaultExceptionFolder.Size = new System.Drawing.Size(433, 26);
            this.TxtDefaultExceptionFolder.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtMinReorderValue, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnSave, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(448, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(440, 107);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set Minimum Reorder Value";
            // 
            // TxtMinReorderValue
            // 
            this.TxtMinReorderValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMinReorderValue.Location = new System.Drawing.Point(223, 3);
            this.TxtMinReorderValue.Name = "TxtMinReorderValue";
            this.TxtMinReorderValue.Size = new System.Drawing.Size(214, 26);
            this.TxtMinReorderValue.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSave.ForeColor = System.Drawing.Color.Black;
            this.BtnSave.Location = new System.Drawing.Point(223, 56);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(214, 48);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click_1);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.27273F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.72727F));
            this.tableLayoutPanel3.Controls.Add(this.TxtPassword, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.TxtUsername, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.TxtServerName, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.TxtDbName, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(448, 116);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(440, 107);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(145, 81);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(292, 22);
            this.TxtPassword.TabIndex = 7;
            // 
            // TxtUsername
            // 
            this.TxtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUsername.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.Location = new System.Drawing.Point(145, 55);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(292, 22);
            this.TxtUsername.TabIndex = 6;
            // 
            // TxtServerName
            // 
            this.TxtServerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtServerName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtServerName.Location = new System.Drawing.Point(145, 29);
            this.TxtServerName.Name = "TxtServerName";
            this.TxtServerName.Size = new System.Drawing.Size(292, 22);
            this.TxtServerName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date Base Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Server Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password";
            // 
            // TxtDbName
            // 
            this.TxtDbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDbName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDbName.Location = new System.Drawing.Point(145, 3);
            this.TxtDbName.Name = "TxtDbName";
            this.TxtDbName.Size = new System.Drawing.Size(292, 22);
            this.TxtDbName.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.BtnSaveConnectionString, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.ChkTrustedConnection, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(448, 229);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(440, 107);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // BtnSaveConnectionString
            // 
            this.BtnSaveConnectionString.BackColor = System.Drawing.Color.White;
            this.BtnSaveConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveConnectionString.Location = new System.Drawing.Point(223, 3);
            this.BtnSaveConnectionString.Name = "BtnSaveConnectionString";
            this.BtnSaveConnectionString.Size = new System.Drawing.Size(214, 47);
            this.BtnSaveConnectionString.TabIndex = 0;
            this.BtnSaveConnectionString.Text = "Save";
            this.BtnSaveConnectionString.UseVisualStyleBackColor = false;
            this.BtnSaveConnectionString.Click += new System.EventHandler(this.BtnSaveConnectionString_Click);
            // 
            // ChkTrustedConnection
            // 
            this.ChkTrustedConnection.AutoSize = true;
            this.ChkTrustedConnection.ForeColor = System.Drawing.Color.White;
            this.ChkTrustedConnection.Location = new System.Drawing.Point(3, 3);
            this.ChkTrustedConnection.Name = "ChkTrustedConnection";
            this.ChkTrustedConnection.Size = new System.Drawing.Size(213, 23);
            this.ChkTrustedConnection.TabIndex = 1;
            this.ChkTrustedConnection.Text = "Windows Authentication";
            this.ChkTrustedConnection.UseVisualStyleBackColor = true;
            // 
            // TlpDefaultQuotationPath
            // 
            this.TlpDefaultQuotationPath.ColumnCount = 1;
            this.TlpDefaultQuotationPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpDefaultQuotationPath.Controls.Add(this.BtnSetDefaultQuotationPath, 0, 0);
            this.TlpDefaultQuotationPath.Controls.Add(this.TxtDefaultQuotationPath, 0, 1);
            this.TlpDefaultQuotationPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpDefaultQuotationPath.Location = new System.Drawing.Point(3, 342);
            this.TlpDefaultQuotationPath.Name = "TlpDefaultQuotationPath";
            this.TlpDefaultQuotationPath.RowCount = 3;
            this.TlpDefaultQuotationPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpDefaultQuotationPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpDefaultQuotationPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpDefaultQuotationPath.Size = new System.Drawing.Size(439, 109);
            this.TlpDefaultQuotationPath.TabIndex = 9;
            // 
            // BtnSetDefaultQuotationPath
            // 
            this.BtnSetDefaultQuotationPath.BackColor = System.Drawing.Color.White;
            this.BtnSetDefaultQuotationPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetDefaultQuotationPath.Location = new System.Drawing.Point(3, 3);
            this.BtnSetDefaultQuotationPath.Name = "BtnSetDefaultQuotationPath";
            this.BtnSetDefaultQuotationPath.Size = new System.Drawing.Size(433, 30);
            this.BtnSetDefaultQuotationPath.TabIndex = 0;
            this.BtnSetDefaultQuotationPath.Text = "Set Default Quotation Path";
            this.BtnSetDefaultQuotationPath.UseVisualStyleBackColor = false;
            this.BtnSetDefaultQuotationPath.Click += new System.EventHandler(this.BtnSetDefaultQuotationPath_Click);
            // 
            // TxtDefaultQuotationPath
            // 
            this.TxtDefaultQuotationPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtDefaultQuotationPath.Location = new System.Drawing.Point(3, 39);
            this.TxtDefaultQuotationPath.Name = "TxtDefaultQuotationPath";
            this.TxtDefaultQuotationPath.ReadOnly = true;
            this.TxtDefaultQuotationPath.Size = new System.Drawing.Size(433, 26);
            this.TxtDefaultQuotationPath.TabIndex = 1;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(891, 454);
            this.Controls.Add(this.BaseLayout);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.BaseLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.TlpDefaultQuotationPath.ResumeLayout(false);
            this.TlpDefaultQuotationPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnSetSavePath;
        private System.Windows.Forms.TextBox TxtDefaultPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button BtnDefaultGRNPath;
        private System.Windows.Forms.TextBox TxtDefaultGRN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button BtnSetDefaultExceptionFolder;
        private System.Windows.Forms.TextBox TxtDefaultExceptionFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtMinReorderValue;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.TextBox TxtServerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDbName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button BtnSaveConnectionString;
        private System.Windows.Forms.CheckBox ChkTrustedConnection;
        private System.Windows.Forms.TableLayoutPanel TlpDefaultQuotationPath;
        private System.Windows.Forms.Button BtnSetDefaultQuotationPath;
        private System.Windows.Forms.TextBox TxtDefaultQuotationPath;
    }
}