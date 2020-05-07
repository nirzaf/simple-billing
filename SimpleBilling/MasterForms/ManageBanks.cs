﻿using SimpleBilling.Migrations;
using SimpleBilling.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
            TxtBankId.Text = "0";
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

        private void ManageBanks_Load(object sender, EventArgs e)
        {
            DGVLoad();
        }

        private void DGVLoad()
        {
            CRUDPanel.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                var data = (from bank in db.Banks.Where(c => c.IsDeleted == false)
                            select new
                            {
                                bank.BankId,
                                bank.BankName
                            }).ToList();
                DGVBanks.DataSource = data;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (TxtBankId.Text.Length > 0)
                    {
                        if (TxtBankId.Text == "0" && Info.IsEmpty(TxtBankName))
                        {
                            Bank b = new Bank
                            {
                                BankName = TxtBankName.Text.Trim()
                            };
                            if (db.Entry(b).State == EntityState.Detached)
                                db.Set<Bank>().Attach(b);
                            db.Entry(b).State = EntityState.Added;
                            db.SaveChanges();
                        }
                        else if (Info.IsEmpty(TxtBankName))
                        {
                            if (Info.IsEmpty(TxtBankId) && TxtBankId.Text.Trim() != "0")
                            {
                                var b = db.Banks.FirstOrDefault(c => c.BankId == Convert.ToInt32(TxtBankId.Text.Trim()) && c.IsDeleted == false);
                                if (b != null)
                                {
                                    b.BankName = TxtBankName.Text.Trim();
                                    if (db.Entry(b).State == EntityState.Detached)
                                        db.Set<Bank>().Attach(b);
                                    db.Entry(b).State = EntityState.Modified;
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }
            finally
            {
                DGVLoad();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                if (Info.IsEmpty(TxtBankId) && TxtBankId.Text.Trim() != "0")
                {
                    var b = db.Banks.FirstOrDefault(c => c.BankId == Convert.ToInt32(TxtBankId.Text.Trim()) && c.IsDeleted == false);
                    if (b != null)
                    {
                        b.IsDeleted = true;
                        if (db.Entry(b).State == EntityState.Detached)
                            db.Set<Bank>().Attach(b);
                        db.Entry(b).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}