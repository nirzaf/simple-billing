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
                LblRed.Text = data.Red.ToString();
                LblGreen.Text = data.Green.ToString();
                LblBlue.Text = data.Blue.ToString();
                TBRed.Value = data.Red;
                TBGreen.Value = data.Green;
                TBBlue.Value = data.Blue;
                RDOBackColor.Checked = true;
            }
        }

        private void TBRed_Scroll(object sender, EventArgs e)
        {
            LblRed.Text = TBRed.Value.ToString();
            if (RDOBackColor.Checked)
            {
                BackColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
            }
            if (RDOForeColor.Checked)
            {
                ForeColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
            }
        }

        private void TBGreen_Scroll(object sender, EventArgs e)
        {
            LblGreen.Text = TBGreen.Value.ToString();
            if (RDOBackColor.Checked)
            {
                BackColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
            }
            if (RDOForeColor.Checked)
            {
                ForeColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
            }
        }

        private void TBBlue_Scroll(object sender, EventArgs e)
        {
            LblBlue.Text = TBBlue.Value.ToString();
            if (RDOBackColor.Checked)
            {
                BackColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
            }
            if (RDOForeColor.Checked)
            {
                ForeColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
                if (data != null)
                {
                    if (RDOBackColor.Checked)
                    {
                        data.Red = TBRed.Value;
                        data.Green = TBGreen.Value;
                        data.Blue = TBBlue.Value;
                    }
                    if (RDOForeColor.Checked)
                    {
                        data.ForeRed = TBRed.Value;
                        data.ForeGreen = TBGreen.Value;
                        data.ForeBlue = TBBlue.Value;
                    }
                    if (db.Entry(data).State == EntityState.Detached)
                        db.Set<Setting>().Attach(data);
                    data.UpdatedDate = DateTime.Now;
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    Info.Mes("Settings Saved Successfully");
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (RDOBackColor.Checked)
            {
                TBRed.Value = 105;
                TBGreen.Value = 105;
                TBBlue.Value = 105;
                LblRed.Text = "105";
                LblGreen.Text = "105";
                LblBlue.Text = "105";
                BackColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
            }
            if (RDOForeColor.Checked)
            {
                TBRed.Value = 0;
                TBGreen.Value = 0;
                TBBlue.Value = 0;
                LblRed.Text = "0";
                LblGreen.Text = "0";
                LblBlue.Text = "0";
                ForeColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
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