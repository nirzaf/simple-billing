using SimpleBilling.Model;
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
    public partial class ManageCheques : Form
    {
        public ManageCheques()
        {
            InitializeComponent();
        }

        private void ManageCheques_Load(object sender, EventArgs e)
        {
        }

        private void DGVLoad()
        {
            using (BillingContext db = new BillingContext())
            { 
               var data = (from ch in db.Cheques.Where(c=>c.IsDeleted ==false)
                          join cus in db.Customers
                          on ch.PaidBy equals cus.CustomerId
                          select new 
                          { 
                             ch.ChequeNo,
                             ch.
                          })
            }
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    Cheque ch = new Cheque();
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
        }
    }
}