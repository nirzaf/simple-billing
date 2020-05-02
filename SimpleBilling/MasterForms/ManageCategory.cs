﻿using SimpleBilling.Model;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageCategory : Form
    {
        public ManageCategory()
        {
            InitializeComponent();
        }

        private void ManageCategory_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            LblMessage.Text = "";
            PanelCRUD.Enabled = false;
            using (BillingContext db = new BillingContext())
            {
                categoryBindingSource.DataSource = db.Categories.ToList();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = true;
            BtnSave.Enabled = true;
            categoryBindingSource.Add(new Category());
            categoryBindingSource.MoveLast();
            TxtCategoryName.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PanelCRUD.Enabled = true;
            BtnSave.Enabled = true;
            TxtCategoryName.Focus();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected Item?", "Confirmation delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (BillingContext db = new BillingContext())
                    {
                        if (categoryBindingSource.Current is Category cat)
                        {
                            if (db.Entry(cat).State == EntityState.Detached)
                                db.Set<Category>().Attach(cat);
                            db.Entry(cat).State = EntityState.Deleted;
                            db.SaveChanges();
                            Info("Category Deleted Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
            finally
            {
                DGVCategories.Refresh();
                LoadDGV();
            }
        }

        private void Info(string Message)
        {
            LblMessage.Text = Message;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (categoryBindingSource.Current is Category cat)
                    {
                        if (db.Entry(cat).State == EntityState.Detached)
                            db.Set<Category>().Attach(cat);
                        if (cat.CategoryId == 0)
                        {
                            db.Entry(cat).State = EntityState.Added;
                            Info("Category Added");
                        }
                        else
                        {
                            db.Entry(cat).State = EntityState.Modified;
                            Info("Category Modified");
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Info(ex.ToString());
            }
            finally
            {
                DGVCategories.Refresh();
                LoadDGV();
            }
        }

        private void TimerLabel_Tick(object sender, EventArgs e)
        {
            LblMessage.Text = "";
        }
    }
}
