using SimpleBilling.MasterForms;
using SimpleBilling.Model;
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
    }
}
