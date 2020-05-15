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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TBBlue = new System.Windows.Forms.TrackBar();
            this.TBGreen = new System.Windows.Forms.TrackBar();
            this.TBRed = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.LblRed = new System.Windows.Forms.Label();
            this.LblGreen = new System.Windows.Forms.Label();
            this.LblBlue = new System.Windows.Forms.Label();
            this.RDOBackColor = new System.Windows.Forms.RadioButton();
            this.RDOForeColor = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDefaultGRNPath = new System.Windows.Forms.Button();
            this.TxtDefaultGRN = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSetDefaultExceptionFolder = new System.Windows.Forms.Button();
            this.TxtDefaultExceptionFolder = new System.Windows.Forms.TextBox();
            this.BaseLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBRed)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 3;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel4, 2, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.BaseLayout.Controls.Add(this.tableLayoutPanel6, 0, 2);
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.TBBlue, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.TBGreen, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.TBRed, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(597, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(291, 107);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // TBBlue
            // 
            this.TBBlue.Location = new System.Drawing.Point(3, 73);
            this.TBBlue.Maximum = 255;
            this.TBBlue.Name = "TBBlue";
            this.TBBlue.Size = new System.Drawing.Size(285, 31);
            this.TBBlue.TabIndex = 2;
            this.TBBlue.Scroll += new System.EventHandler(this.TBBlue_Scroll);
            // 
            // TBGreen
            // 
            this.TBGreen.Location = new System.Drawing.Point(3, 38);
            this.TBGreen.Maximum = 255;
            this.TBGreen.Name = "TBGreen";
            this.TBGreen.Size = new System.Drawing.Size(285, 29);
            this.TBGreen.TabIndex = 1;
            this.TBGreen.Scroll += new System.EventHandler(this.TBGreen_Scroll);
            // 
            // TBRed
            // 
            this.TBRed.Location = new System.Drawing.Point(3, 3);
            this.TBRed.Maximum = 255;
            this.TBRed.Name = "TBRed";
            this.TBRed.Size = new System.Drawing.Size(285, 29);
            this.TBRed.TabIndex = 0;
            this.TBRed.Scroll += new System.EventHandler(this.TBRed_Scroll);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.LblRed, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.LblGreen, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.LblBlue, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.RDOBackColor, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.RDOForeColor, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(300, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(291, 107);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // LblRed
            // 
            this.LblRed.AutoSize = true;
            this.LblRed.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblRed.ForeColor = System.Drawing.Color.White;
            this.LblRed.Location = new System.Drawing.Point(234, 0);
            this.LblRed.Name = "LblRed";
            this.LblRed.Size = new System.Drawing.Size(54, 35);
            this.LblRed.TabIndex = 0;
            this.LblRed.Text = "label1";
            // 
            // LblGreen
            // 
            this.LblGreen.AutoSize = true;
            this.LblGreen.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblGreen.ForeColor = System.Drawing.Color.White;
            this.LblGreen.Location = new System.Drawing.Point(234, 35);
            this.LblGreen.Name = "LblGreen";
            this.LblGreen.Size = new System.Drawing.Size(54, 35);
            this.LblGreen.TabIndex = 1;
            this.LblGreen.Text = "label2";
            // 
            // LblBlue
            // 
            this.LblBlue.AutoSize = true;
            this.LblBlue.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblBlue.ForeColor = System.Drawing.Color.White;
            this.LblBlue.Location = new System.Drawing.Point(234, 70);
            this.LblBlue.Name = "LblBlue";
            this.LblBlue.Size = new System.Drawing.Size(54, 37);
            this.LblBlue.TabIndex = 2;
            this.LblBlue.Text = "label3";
            // 
            // RDOBackColor
            // 
            this.RDOBackColor.AutoSize = true;
            this.RDOBackColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.RDOBackColor.ForeColor = System.Drawing.Color.White;
            this.RDOBackColor.Location = new System.Drawing.Point(30, 3);
            this.RDOBackColor.Name = "RDOBackColor";
            this.RDOBackColor.Size = new System.Drawing.Size(112, 29);
            this.RDOBackColor.TabIndex = 3;
            this.RDOBackColor.TabStop = true;
            this.RDOBackColor.Text = "Back Color";
            this.RDOBackColor.UseVisualStyleBackColor = true;
            // 
            // RDOForeColor
            // 
            this.RDOForeColor.AutoSize = true;
            this.RDOForeColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.RDOForeColor.ForeColor = System.Drawing.Color.White;
            this.RDOForeColor.Location = new System.Drawing.Point(34, 73);
            this.RDOForeColor.Name = "RDOForeColor";
            this.RDOForeColor.Size = new System.Drawing.Size(108, 31);
            this.RDOForeColor.TabIndex = 4;
            this.RDOForeColor.TabStop = true;
            this.RDOForeColor.Text = "Fore Color";
            this.RDOForeColor.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.BtnReset, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnSave, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(597, 116);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(291, 107);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.White;
            this.BtnReset.Location = new System.Drawing.Point(148, 3);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(139, 29);
            this.BtnReset.TabIndex = 1;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(3, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(139, 29);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBRed)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnSetSavePath;
        private System.Windows.Forms.TextBox TxtDefaultPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TrackBar TBRed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label LblBlue;
        private System.Windows.Forms.Label LblGreen;
        private System.Windows.Forms.Label LblRed;
        private System.Windows.Forms.TrackBar TBBlue;
        private System.Windows.Forms.TrackBar TBGreen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.RadioButton RDOBackColor;
        private System.Windows.Forms.RadioButton RDOForeColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button BtnDefaultGRNPath;
        private System.Windows.Forms.TextBox TxtDefaultGRN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button BtnSetDefaultExceptionFolder;
        private System.Windows.Forms.TextBox TxtDefaultExceptionFolder;
    }
}