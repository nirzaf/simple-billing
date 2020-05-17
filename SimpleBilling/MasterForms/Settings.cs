using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class Settings : Form
    {
        private readonly int UserId = 1;

        public Settings()
        {
            InitializeComponent();
        }

        private void BtnSetSavePath_Click(object sender, EventArgs e)
        {
            try
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

                        var r = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
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
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = db.Settings.FirstOrDefault(c => c.UserId == UserId);
                TxtDefaultPath.Text = data.DefaultPath;
                TxtDefaultGRN.Text = data.GRNPath;
                TxtDefaultExceptionFolder.Text = data.DefaultPath;
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
                if (data != null)
                {
                    if (db.Entry(data).State == EntityState.Detached)
                        db.Set<Setting>().Attach(data);
                    data.UpdatedDate = DateTime.Now;
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    Info.Mes("Settings Saved Successfully");
                }
            }
        }

        private void BtnDefaultGRNPath_Click(object sender, EventArgs e)
        {
            try
            {
                var folderBrowserDialog1 = new FolderBrowserDialog();

                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    TxtDefaultGRN.Text = folderName;
                    using (BillingContext db = new BillingContext())
                    {
                        Setting s = new Setting
                        {
                            GRNPath = folderName,
                            CreatedDate = DateTime.Now
                        };

                        var r = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
                        if (r == null)
                        {
                            if (db.Entry(s).State == EntityState.Detached)
                                db.Set<Setting>().Attach(s);
                            db.Entry(s).State = EntityState.Added;
                            db.SaveChanges();
                        }
                        else
                        {
                            r.GRNPath = folderName;
                            r.UpdatedDate = DateTime.Now;
                            if (db.Entry(r).State == EntityState.Detached)
                                db.Set<Setting>().Attach(r);
                            db.Entry(r).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }

        private void BtnSetDefaultExceptionFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var folderBrowserDialog1 = new FolderBrowserDialog();

                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    TxtDefaultExceptionFolder.Text = folderName;
                    using (BillingContext db = new BillingContext())
                    {
                        Setting s = new Setting
                        {
                            ExceptionPath = folderName,
                            CreatedDate = DateTime.Now
                        };

                        var r = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
                        if (r == null)
                        {
                            if (db.Entry(s).State == EntityState.Detached)
                                db.Set<Setting>().Attach(s);
                            db.Entry(s).State = EntityState.Added;
                            db.SaveChanges();
                        }
                        else
                        {
                            r.ExceptionPath = folderName;
                            r.UpdatedDate = DateTime.Now;
                            if (db.Entry(r).State == EntityState.Detached)
                                db.Set<Setting>().Attach(r);
                            db.Entry(r).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
            }
        }
    }
}