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

        private void manageItemsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void manageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
