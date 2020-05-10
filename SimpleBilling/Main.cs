using SimpleBilling.MasterForms;
using System;
using System.Windows.Forms;

namespace SimpleBilling
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
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

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}