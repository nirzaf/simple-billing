using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageBanks : Form
    {
        public ManageBanks()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = false;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnAdd.Enabled = true;
            BtnEdit.Enabled = true;
        }

        private void DGVBanks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVBanks.SelectedRows.Count > 0)
            {
                TxtBankId.Text = DGVBanks.SelectedRows[0].Cells[0].Value + string.Empty;
                TxtBankName.Text = DGVBanks.SelectedRows[0].Cells[1].Value + string.Empty;
            }
        }
    }
}