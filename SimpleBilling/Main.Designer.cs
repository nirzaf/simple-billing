namespace SimpleBilling
{
    partial class Main
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
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mASTERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageShelvesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageBusinessInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PurchaseOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gRNInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voidReceiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingReceiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblAutoLogOut = new System.Windows.Forms.Label();
            this.AutoLogOut = new System.Windows.Forms.Timer(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mASTERToolStripMenuItem,
            this.toolStripMenuItem1,
            this.pOSToolStripMenuItem,
            this.TSM2});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(12, 3, 0, 3);
            this.MenuStrip1.Size = new System.Drawing.Size(1354, 29);
            this.MenuStrip1.TabIndex = 1;
            this.MenuStrip1.Text = "menuStrip1";
            // 
            // mASTERToolStripMenuItem
            // 
            this.mASTERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageItemsToolStripMenuItem,
            this.ManageSuppliersToolStripMenuItem,
            this.ManageCustomersToolStripMenuItem,
            this.ManageStockToolStripMenuItem,
            this.ManageEmployeesToolStripMenuItem,
            this.ManageShelvesToolStripMenuItem,
            this.ManageCategoryToolStripMenuItem,
            this.ManageBusinessInfoToolStripMenuItem,
            this.ManageVehicleToolStripMenuItem,
            this.ManageBankToolStripMenuItem,
            this.PurchaseOrderToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mASTERToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mASTERToolStripMenuItem.Name = "mASTERToolStripMenuItem";
            this.mASTERToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.mASTERToolStripMenuItem.Text = "Master ";
            // 
            // ManageItemsToolStripMenuItem
            // 
            this.ManageItemsToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageItemsToolStripMenuItem.Name = "ManageItemsToolStripMenuItem";
            this.ManageItemsToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageItemsToolStripMenuItem.Text = "Manage Items";
            this.ManageItemsToolStripMenuItem.Click += new System.EventHandler(this.ManageItemsToolStripMenuItem_Click);
            // 
            // ManageSuppliersToolStripMenuItem
            // 
            this.ManageSuppliersToolStripMenuItem.Name = "ManageSuppliersToolStripMenuItem";
            this.ManageSuppliersToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageSuppliersToolStripMenuItem.Text = "Manage Suppliers";
            this.ManageSuppliersToolStripMenuItem.Click += new System.EventHandler(this.ManageSuppliersToolStripMenuItem_Click);
            // 
            // ManageCustomersToolStripMenuItem
            // 
            this.ManageCustomersToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageCustomersToolStripMenuItem.Name = "ManageCustomersToolStripMenuItem";
            this.ManageCustomersToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageCustomersToolStripMenuItem.Text = "Manage Customers";
            this.ManageCustomersToolStripMenuItem.Click += new System.EventHandler(this.ManageCustomersToolStripMenuItem_Click);
            // 
            // ManageStockToolStripMenuItem
            // 
            this.ManageStockToolStripMenuItem.Name = "ManageStockToolStripMenuItem";
            this.ManageStockToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageStockToolStripMenuItem.Text = "Manage GRN";
            this.ManageStockToolStripMenuItem.Click += new System.EventHandler(this.ManageStockToolStripMenuItem_Click);
            // 
            // ManageEmployeesToolStripMenuItem
            // 
            this.ManageEmployeesToolStripMenuItem.Name = "ManageEmployeesToolStripMenuItem";
            this.ManageEmployeesToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageEmployeesToolStripMenuItem.Text = "Manage Employees";
            this.ManageEmployeesToolStripMenuItem.Click += new System.EventHandler(this.ManageEmployeesToolStripMenuItem_Click);
            // 
            // ManageShelvesToolStripMenuItem
            // 
            this.ManageShelvesToolStripMenuItem.Name = "ManageShelvesToolStripMenuItem";
            this.ManageShelvesToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageShelvesToolStripMenuItem.Text = "Manage Shelves";
            this.ManageShelvesToolStripMenuItem.Click += new System.EventHandler(this.ManageShelvesToolStripMenuItem_Click);
            // 
            // ManageCategoryToolStripMenuItem
            // 
            this.ManageCategoryToolStripMenuItem.Name = "ManageCategoryToolStripMenuItem";
            this.ManageCategoryToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageCategoryToolStripMenuItem.Text = "Manage Category";
            this.ManageCategoryToolStripMenuItem.Click += new System.EventHandler(this.ManageCategoryToolStripMenuItem_Click);
            // 
            // ManageBusinessInfoToolStripMenuItem
            // 
            this.ManageBusinessInfoToolStripMenuItem.Name = "ManageBusinessInfoToolStripMenuItem";
            this.ManageBusinessInfoToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageBusinessInfoToolStripMenuItem.Text = "Manage Business Info";
            this.ManageBusinessInfoToolStripMenuItem.Click += new System.EventHandler(this.ManageBusinessInfoToolStripMenuItem_Click);
            // 
            // ManageVehicleToolStripMenuItem
            // 
            this.ManageVehicleToolStripMenuItem.Name = "ManageVehicleToolStripMenuItem";
            this.ManageVehicleToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageVehicleToolStripMenuItem.Text = "Manage Vehicle";
            this.ManageVehicleToolStripMenuItem.Click += new System.EventHandler(this.ManageVehicleToolStripMenuItem_Click);
            // 
            // ManageBankToolStripMenuItem
            // 
            this.ManageBankToolStripMenuItem.Name = "ManageBankToolStripMenuItem";
            this.ManageBankToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.ManageBankToolStripMenuItem.Text = "Manage Bank";
            this.ManageBankToolStripMenuItem.Click += new System.EventHandler(this.ManageBankToolStripMenuItem_Click);
            // 
            // PurchaseOrderToolStripMenuItem
            // 
            this.PurchaseOrderToolStripMenuItem.Name = "PurchaseOrderToolStripMenuItem";
            this.PurchaseOrderToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.PurchaseOrderToolStripMenuItem.Text = "Purchase Order";
            this.PurchaseOrderToolStripMenuItem.Click += new System.EventHandler(this.PurchaseOrderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gRNInvoicesToolStripMenuItem,
            this.receiptsToolStripMenuItem,
            this.voidReceiptsToolStripMenuItem,
            this.pendingReceiptsToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(99, 23);
            this.toolStripMenuItem1.Text = "Load Data";
            // 
            // gRNInvoicesToolStripMenuItem
            // 
            this.gRNInvoicesToolStripMenuItem.Name = "gRNInvoicesToolStripMenuItem";
            this.gRNInvoicesToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.gRNInvoicesToolStripMenuItem.Text = "GRN Invoices";
            this.gRNInvoicesToolStripMenuItem.Click += new System.EventHandler(this.gRNInvoicesToolStripMenuItem_Click);
            // 
            // receiptsToolStripMenuItem
            // 
            this.receiptsToolStripMenuItem.Name = "receiptsToolStripMenuItem";
            this.receiptsToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.receiptsToolStripMenuItem.Text = "Receipts";
            // 
            // voidReceiptsToolStripMenuItem
            // 
            this.voidReceiptsToolStripMenuItem.Name = "voidReceiptsToolStripMenuItem";
            this.voidReceiptsToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.voidReceiptsToolStripMenuItem.Text = "Void Receipts";
            // 
            // pendingReceiptsToolStripMenuItem
            // 
            this.pendingReceiptsToolStripMenuItem.Name = "pendingReceiptsToolStripMenuItem";
            this.pendingReceiptsToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.pendingReceiptsToolStripMenuItem.Text = "Pending Receipts";
            // 
            // pOSToolStripMenuItem
            // 
            this.pOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickSaleToolStripMenuItem});
            this.pOSToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pOSToolStripMenuItem.Name = "pOSToolStripMenuItem";
            this.pOSToolStripMenuItem.Size = new System.Drawing.Size(55, 23);
            this.pOSToolStripMenuItem.Text = "POS";
            // 
            // quickSaleToolStripMenuItem
            // 
            this.quickSaleToolStripMenuItem.Name = "quickSaleToolStripMenuItem";
            this.quickSaleToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.quickSaleToolStripMenuItem.Text = "Quick Sale";
            this.quickSaleToolStripMenuItem.Click += new System.EventHandler(this.quickSaleToolStripMenuItem_Click);
            // 
            // TSM2
            // 
            this.TSM2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigsToolStripMenuItem});
            this.TSM2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSM2.Name = "TSM2";
            this.TSM2.Size = new System.Drawing.Size(84, 23);
            this.TSM2.Text = "Settings";
            // 
            // ConfigsToolStripMenuItem
            // 
            this.ConfigsToolStripMenuItem.Name = "ConfigsToolStripMenuItem";
            this.ConfigsToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.ConfigsToolStripMenuItem.Text = "Configs";
            this.ConfigsToolStripMenuItem.Click += new System.EventHandler(this.ConfigsToolStripMenuItem_Click);
            // 
            // LblAutoLogOut
            // 
            this.LblAutoLogOut.AutoSize = true;
            this.LblAutoLogOut.BackColor = System.Drawing.Color.Transparent;
            this.LblAutoLogOut.ForeColor = System.Drawing.Color.Lime;
            this.LblAutoLogOut.Location = new System.Drawing.Point(1278, 40);
            this.LblAutoLogOut.Name = "LblAutoLogOut";
            this.LblAutoLogOut.Size = new System.Drawing.Size(64, 22);
            this.LblAutoLogOut.TabIndex = 3;
            this.LblAutoLogOut.Text = "Timer";
            this.LblAutoLogOut.Visible = false;
            // 
            // AutoLogOut
            // 
            this.AutoLogOut.Enabled = true;
            this.AutoLogOut.Interval = 1000;
            this.AutoLogOut.Tick += new System.EventHandler(this.AutoLogOut_Tick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.LblAutoLogOut);
            this.Controls.Add(this.MenuStrip1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Window";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            this.MouseEnter += new System.EventHandler(this.Main_MouseEnter);
            this.MouseHover += new System.EventHandler(this.Main_MouseHover);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mASTERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageShelvesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gRNInvoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voidReceiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingReceiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageBusinessInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSM2;
        private System.Windows.Forms.ToolStripMenuItem ConfigsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PurchaseOrderToolStripMenuItem;
        private System.Windows.Forms.Label LblAutoLogOut;
        private System.Windows.Forms.Timer AutoLogOut;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}