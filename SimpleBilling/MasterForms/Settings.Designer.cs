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
            this.BaseLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 3;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel2, 1, 0);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(291, 107);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnSetSavePath
            // 
            this.BtnSetSavePath.BackColor = System.Drawing.Color.White;
            this.BtnSetSavePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetSavePath.Location = new System.Drawing.Point(3, 3);
            this.BtnSetSavePath.Name = "BtnSetSavePath";
            this.BtnSetSavePath.Size = new System.Drawing.Size(285, 29);
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
            this.TxtDefaultPath.Size = new System.Drawing.Size(285, 26);
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(291, 107);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // BtnDefaultGRNPath
            // 
            this.BtnDefaultGRNPath.BackColor = System.Drawing.Color.White;
            this.BtnDefaultGRNPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDefaultGRNPath.Location = new System.Drawing.Point(3, 3);
            this.BtnDefaultGRNPath.Name = "BtnDefaultGRNPath";
            this.BtnDefaultGRNPath.Size = new System.Drawing.Size(285, 29);
            this.BtnDefaultGRNPath.TabIndex = 0;
            this.BtnDefaultGRNPath.Text = "Set Default GRN Folder";
            this.BtnDefaultGRNPath.UseVisualStyleBackColor = false;
            this.BtnDefaultGRNPath.Click += new System.EventHandler(this.BtnDefaultGRNPath_Click);
            // 
            // TxtDefaultGRN
            // 
            this.TxtDefaultGRN.Location = new System.Drawing.Point(3, 38);
            this.TxtDefaultGRN.Name = "TxtDefaultGRN";
            this.TxtDefaultGRN.ReadOnly = true;
            this.TxtDefaultGRN.Size = new System.Drawing.Size(285, 26);
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
            this.tableLayoutPanel6.Size = new System.Drawing.Size(291, 107);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // BtnSetDefaultExceptionFolder
            // 
            this.BtnSetDefaultExceptionFolder.BackColor = System.Drawing.Color.White;
            this.BtnSetDefaultExceptionFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetDefaultExceptionFolder.Location = new System.Drawing.Point(3, 3);
            this.BtnSetDefaultExceptionFolder.Name = "BtnSetDefaultExceptionFolder";
            this.BtnSetDefaultExceptionFolder.Size = new System.Drawing.Size(285, 29);
            this.BtnSetDefaultExceptionFolder.TabIndex = 0;
            this.BtnSetDefaultExceptionFolder.Text = "Set Default Exception Folder";
            this.BtnSetDefaultExceptionFolder.UseVisualStyleBackColor = false;
            this.BtnSetDefaultExceptionFolder.Click += new System.EventHandler(this.BtnSetDefaultExceptionFolder_Click);
            // 
            // TxtDefaultExceptionFolder
            // 
            this.TxtDefaultExceptionFolder.Location = new System.Drawing.Point(3, 38);
            this.TxtDefaultExceptionFolder.Name = "TxtDefaultExceptionFolder";
            this.TxtDefaultExceptionFolder.ReadOnly = true;
            this.TxtDefaultExceptionFolder.Size = new System.Drawing.Size(285, 26);
            this.TxtDefaultExceptionFolder.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.20618F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.79382F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtMinReorderValue, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnSave, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(300, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(291, 107);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set Minimum Reorder Value";
            // 
            // TxtMinReorderValue
            // 
            this.TxtMinReorderValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMinReorderValue.Location = new System.Drawing.Point(119, 3);
            this.TxtMinReorderValue.Name = "TxtMinReorderValue";
            this.TxtMinReorderValue.Size = new System.Drawing.Size(169, 26);
            this.TxtMinReorderValue.TabIndex = 1;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSave.ForeColor = System.Drawing.Color.Black;
            this.BtnSave.Location = new System.Drawing.Point(119, 56);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(169, 48);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click_1);
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
    }
}