namespace SimpleBilling.MasterForms
{
    partial class Login
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BaseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.TxtLogin = new System.Windows.Forms.TextBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnAdminLogin = new System.Windows.Forms.Button();
            this.BtnAdminExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.BaseLayout.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 252);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Controls.Add(this.BaseLayout);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cashier Login";
            // 
            // BaseLayout
            // 
            this.BaseLayout.ColumnCount = 3;
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.BaseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.BaseLayout.Controls.Add(this.BtnLogin, 1, 2);
            this.BaseLayout.Controls.Add(this.TxtLogin, 1, 1);
            this.BaseLayout.Controls.Add(this.BtnExit, 1, 3);
            this.BaseLayout.Controls.Add(this.label1, 1, 0);
            this.BaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayout.Location = new System.Drawing.Point(3, 3);
            this.BaseLayout.Name = "BaseLayout";
            this.BaseLayout.RowCount = 4;
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.BaseLayout.Size = new System.Drawing.Size(621, 214);
            this.BaseLayout.TabIndex = 2;
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.White;
            this.BtnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLogin.Location = new System.Drawing.Point(127, 109);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(366, 47);
            this.BtnLogin.TabIndex = 1;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // TxtLogin
            // 
            this.TxtLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtLogin.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogin.Location = new System.Drawing.Point(127, 56);
            this.TxtLogin.Name = "TxtLogin";
            this.TxtLogin.PasswordChar = '*';
            this.TxtLogin.Size = new System.Drawing.Size(366, 39);
            this.TxtLogin.TabIndex = 0;
            this.TxtLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLogin_KeyDown);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.White;
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExit.Location = new System.Drawing.Point(127, 162);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(366, 49);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(127, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Version 1.0.0.2";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(627, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Admin Login";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.TxtUsername, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnAdminLogin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtnAdminExit, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 214);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtUsername
            // 
            this.TxtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtUsername.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.Location = new System.Drawing.Point(127, 3);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(366, 39);
            this.TxtUsername.TabIndex = 0;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPassword.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(127, 45);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(366, 39);
            this.TxtPassword.TabIndex = 1;
            this.TxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // BtnAdminLogin
            // 
            this.BtnAdminLogin.BackColor = System.Drawing.Color.White;
            this.BtnAdminLogin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdminLogin.Location = new System.Drawing.Point(127, 87);
            this.BtnAdminLogin.Name = "BtnAdminLogin";
            this.BtnAdminLogin.Size = new System.Drawing.Size(366, 36);
            this.BtnAdminLogin.TabIndex = 2;
            this.BtnAdminLogin.Text = "Login";
            this.BtnAdminLogin.UseVisualStyleBackColor = false;
            this.BtnAdminLogin.Click += new System.EventHandler(this.BtnAdminLogin_Click);
            // 
            // BtnAdminExit
            // 
            this.BtnAdminExit.BackColor = System.Drawing.Color.White;
            this.BtnAdminExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAdminExit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdminExit.Location = new System.Drawing.Point(127, 129);
            this.BtnAdminExit.Name = "BtnAdminExit";
            this.BtnAdminExit.Size = new System.Drawing.Size(366, 36);
            this.BtnAdminExit.TabIndex = 3;
            this.BtnAdminExit.Text = "Exit";
            this.BtnAdminExit.UseVisualStyleBackColor = false;
            this.BtnAdminExit.Click += new System.EventHandler(this.BtnAdminExit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(639, 255);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.BaseLayout.ResumeLayout(false);
            this.BaseLayout.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox TxtLogin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.TableLayoutPanel BaseLayout;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnAdminLogin;
        private System.Windows.Forms.Button BtnAdminExit;
        private System.Windows.Forms.Label label1;
    }
}