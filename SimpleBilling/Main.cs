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
                // If frmHome is Opened, set focus to it and exit subroutine.
                if (form.GetType() == typeof(ManageItems))
                {

                    form.Activate();
                    return;
                }
            }

            ManageItems manageItems = new ManageItems();
            manageItems.MdiParent = this;
            manageItems.Show();
        }
    }
}
