using SimpleBilling.Migrations;
using SimpleBilling.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void BtnSetSavePath_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                TxtDefaultPath.Text = folderName;
                using (BillingContext db = new BillingContext())
                {
                    Setting s = new Setting
                    {
                        DefaultPath = folderName,
                        CreatedDate = DateTime.Now
                    };

                    var r = db.Settings.FirstOrDefault(c => c.UserId == Info.CashierId && !c.IsDeleted);
                    if (r == null)
                    {
                        if (db.Entry(s).State == EntityState.Detached)
                            db.Set<Setting>().Attach(s);
                        db.Entry(s).State = EntityState.Added;
                        db.SaveChanges();
                    }
                    else
                    {
                        r.DefaultPath = folderName;
                        r.UpdatedDate = DateTime.Now;
                        if (db.Entry(r).State == EntityState.Detached)
                            db.Set<Setting>().Attach(r);
                        db.Entry(r).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = db.Settings.FirstOrDefault(c => c.UserId == Info.CashierId);
                TxtDefaultPath.Text = data.DefaultPath;
            }
        }
    }
}