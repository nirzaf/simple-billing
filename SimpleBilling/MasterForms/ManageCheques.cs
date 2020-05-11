using SimpleBilling.Model;
using System;
using System.Data;
using System.Linq;
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
            DGVLoad();
        }

        private void DGVLoad()
        {
            BtnSave.Enabled = false;
            BtnDelete.Enabled = false;
            BtnCancel.Enabled = false;
            CRUDPanel.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                var data = (from ch in db.Cheques.Where(c => c.IsDeleted == false)
                            join cus in db.Customers
                            on ch.PaidBy equals cus.CustomerId
                            join bk in db.Banks
                            on ch.Bank equals bk.BankId
                            select new
                            {
                                ch.ChequeNo,
                                ch.Amount,
                                ch.PayeeName,
                                ch.DueDate,
                                PaidBy = cus.Name,
                                Bank = bk.BankName
                            }).ToList();
                DGVChequeDetails.DataSource = data;
                CmbPaidBy.ValueMember = "CustomerId";
                CmbPaidBy.DisplayMember = "Name";
                CmbPaidBy.DataSource = db.Customers.ToList();

                CmbBankName.ValueMember = "BankId";
                CmbBankName.DisplayMember = "BankName";
                CmbBankName.DataSource = db.Banks.ToList();
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
                    var chd = db.Cheques.FirstOrDefault(c => c.IsDeleted == false && c.ChequeNo == TxtChequeNumber.Text);

                    if (chd != null)
                    {
                        chd.PayeeName = TxtPayeeName.Text.Trim();
                        chd.Amount = Convert.ToSingle(TxtChequeAmount.Text.Trim());
                        chd.DueDate = DTDueDate.Value.ToShortDateString();
                        chd.PaidBy = Convert.ToInt32(CmbPaidBy.SelectedValue.ToString());
                        chd.Bank = Convert.ToInt32(CmbBankName.SelectedValue.ToString());
                        chd.UpdatedDate = DateTime.Today;
                        if (db.Entry(chd).State == System.Data.Entity.EntityState.Detached)
                            db.Set<Cheque>().Attach(chd);
                        db.Entry(chd).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        Cheque ch = new Cheque
                        {
                            ChequeNo = TxtChequeNumber.Text.Trim(),
                            PayeeName = TxtPayeeName.Text.Trim(),
                            Amount = Convert.ToSingle(TxtChequeAmount.Text.Trim()),
                            DueDate = DTDueDate.Value.ToShortDateString(),
                            PaidBy = Convert.ToInt32(CmbPaidBy.SelectedValue.ToString()),
                            Bank = Convert.ToInt32(CmbBankName.SelectedValue.ToString()),
                            CreatedDate = DateTime.Today
                        };
                        if (db.Entry(ch).State == System.Data.Entity.EntityState.Detached)
                            db.Set<Cheque>().Attach(ch);
                        db.Entry(ch).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex); Info.Mes(ex.Message);
            }
            finally
            {
                DGVLoad();
            }
        }

        private void BtnAddBanks_Click(object sender, EventArgs e)
        {
            ManageBanks mb = new ManageBanks();
            mb.Show();
            Hide();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (DGVChequeDetails.SelectedRows.Count > 0)
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
        }

        private void ManageCheques_Activated(object sender, EventArgs e)
        {
            DGVLoad();
        }
    }
}