using SimpleBilling.MasterForms;
using SimpleBilling.Model;
using SimpleBilling.Reports;
using System;
using System.Windows.Forms;

namespace SimpleBilling
{
    public partial class Main : Form
    {
        public static int Count { get; set; }

        public Main()
        {
            InitializeComponent();
            LoadUserTypesPrevileges();
            Count = 0;
        }

        private void ManageItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageItems))
                {
                    form.Activate();
                    return;
                }
            }

            ManageItems manageItems = new ManageItems
            {
                MdiParent = this
            };
            manageItems.Show();
        }

        public void ManageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageCustomers))
                {
                    form.Activate();
                    return;
                }
            }

            ManageCustomers manageCustomers = new ManageCustomers
            {
                MdiParent = this
            };
            manageCustomers.Show();
        }

        private void ManageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageSupplier))
                {
                    form.Activate();
                    return;
                }
            }

            ManageSupplier manageSupplier = new ManageSupplier
            {
                MdiParent = this
            };
            manageSupplier.Show();
        }

        private void ManageEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageEmployees))
                {
                    form.Activate();
                    return;
                }
            }

            ManageEmployees manageEmployees = new ManageEmployees
            {
                MdiParent = this
            };
            manageEmployees.Show();
        }

        private void ManageShelvesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageShelves))
                {
                    form.Activate();
                    return;
                }
            }

            ManageShelves manageShelves = new ManageShelves
            {
                MdiParent = this
            };
            manageShelves.Show();
        }

        private void ManageCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageCategory))
                {
                    form.Activate();
                    return;
                }
            }

            ManageCategory manageCategory = new ManageCategory
            {
                MdiParent = this
            };
            manageCategory.Show();
        }

        private void ManageStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageGRN))
                {
                    form.Activate();
                    return;
                }
            }

            ManageGRN manageGRN = new ManageGRN(string.Empty)
            {
                MdiParent = this
            };
            manageGRN.Show();
        }

        private void gRNInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(GRNInvoices))
                {
                    form.Activate();
                    return;
                }
            }

            GRNInvoices InvoiceGRN = new GRNInvoices()
            {
                MdiParent = this
            };
            InvoiceGRN.Show();
        }

        private void quickSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(POS))
                {
                    form.Activate();
                    return;
                }
            }

            POS pos = new POS(string.Empty)
            {
                MdiParent = this
            };
            pos.Show();
        }

        private void ManageBusinessInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(BusinessInfo))
                {
                    form.Activate();
                    return;
                }
            }

            BusinessInfo BusinessInfo = new BusinessInfo()
            {
                MdiParent = this
            };
            BusinessInfo.Show();
        }

        private void ManageVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageVehicles))
                {
                    form.Activate();
                    return;
                }
            }

            ManageVehicles vehicle = new ManageVehicles()
            {
                MdiParent = this
            };
            vehicle.Show();
        }

        private void ManageBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageBanks))
                {
                    form.Activate();
                    return;
                }
            }

            ManageBanks mb = new ManageBanks()
            {
                MdiParent = this
            };
            mb.Show();
        }

        private void ConfigsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Settings))
                {
                    form.Activate();
                    return;
                }
            }

            Settings s = new Settings()
            {
                MdiParent = this
            };
            s.Show();
        }

        private void PurchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MasterForms.PurchaseOrder))
                {
                    form.Activate();
                    return;
                }
            }

            MasterForms.PurchaseOrder po = new MasterForms.PurchaseOrder()
            {
                MdiParent = this
            };
            po.Show();
        }

        private void AutoLogOut_Tick(object sender, EventArgs e)
        {
            Count++;
            LblAutoLogOut.Text = Count.ToString();
            if (Count == 900)
            {
                Login l = new Login();
                l.Show();
                Close();
            }
        }

        private void Main_MouseHover(object sender, EventArgs e)
        {
            Count = 0;
        }

        private void Main_MouseEnter(object sender, EventArgs e)
        {
            Count = 0;
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            Count = 0;
        }

        private void LoadUserTypesPrevileges()
        {
            using (BillingContext db = new BillingContext())
            {
                if (Info.UserType == 3)
                {
                    ManageItemsToolStripMenuItem.Enabled = true;
                    ManageSuppliersToolStripMenuItem.Enabled = true;
                    ManageCustomersToolStripMenuItem.Enabled = true;
                    ManageStockToolStripMenuItem.Enabled = false;
                    ManageEmployeesToolStripMenuItem.Enabled = false;
                    ManageShelvesToolStripMenuItem.Enabled = true;
                    ManageCategoryToolStripMenuItem.Enabled = true;
                    ManageBusinessInfoToolStripMenuItem.Enabled = false;
                    ManageVehicleToolStripMenuItem.Enabled = true;
                    ManageBankToolStripMenuItem.Enabled = true;
                    PurchaseOrderToolStripMenuItem.Enabled = true;
                    ConfigsToolStripMenuItem.Enabled = false;
                }
                if (Info.UserType == 2)
                {
                    ManageItemsToolStripMenuItem.Enabled = true;
                    ManageSuppliersToolStripMenuItem.Enabled = true;
                    ManageCustomersToolStripMenuItem.Enabled = true;
                    ManageStockToolStripMenuItem.Enabled = true;
                    ManageEmployeesToolStripMenuItem.Enabled = true;
                    ManageShelvesToolStripMenuItem.Enabled = true;
                    ManageCategoryToolStripMenuItem.Enabled = true;
                    ManageBusinessInfoToolStripMenuItem.Enabled = true;
                    ManageVehicleToolStripMenuItem.Enabled = true;
                    ManageBankToolStripMenuItem.Enabled = true;
                    PurchaseOrderToolStripMenuItem.Enabled = true;
                    ConfigsToolStripMenuItem.Enabled = false;
                }
                if (Info.UserType == 1)
                {
                    ManageItemsToolStripMenuItem.Enabled = true;
                    ManageSuppliersToolStripMenuItem.Enabled = true;
                    ManageCustomersToolStripMenuItem.Enabled = true;
                    ManageStockToolStripMenuItem.Enabled = true;
                    ManageEmployeesToolStripMenuItem.Enabled = true;
                    ManageShelvesToolStripMenuItem.Enabled = true;
                    ManageCategoryToolStripMenuItem.Enabled = true;
                    ManageBusinessInfoToolStripMenuItem.Enabled = true;
                    ManageVehicleToolStripMenuItem.Enabled = true;
                    ManageBankToolStripMenuItem.Enabled = true;
                    PurchaseOrderToolStripMenuItem.Enabled = true;
                    ConfigsToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadUserTypesPrevileges();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ManageStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ManageStock))
                {
                    form.Activate();
                    return;
                }
            }

            ManageStock ms = new ManageStock()
            {
                MdiParent = this
            };
            ms.Show();
        }

        private void VoidedReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(VoidedReceipts))
                {
                    form.Activate();
                    return;
                }
            }

            VoidedReceipts vr = new VoidedReceipts()
            {
                MdiParent = this
            };
            vr.Show();
        }
    }
}