using Newtonsoft.Json;
using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
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
                TxtMinReorderValue.Text = data.SetMinValue.ToString();
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

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            if (Info.IsEmpty(TxtMinReorderValue))
            {
                using (BillingContext db = new BillingContext())
                {
                    var s = db.Settings.FirstOrDefault(c => c.UserId == 1);
                    if (s != null)
                    {
                        s.SetMinValue = Convert.ToInt32(TxtMinReorderValue.Text.Trim());
                        if (db.Entry(s).State == EntityState.Detached)
                            db.Set<Setting>().Attach(s);
                        db.Entry(s).State = EntityState.Modified;
                        db.SaveChanges();
                        Info.Mes("Minimum Reorder Notification Value Updated Successfully");
                    }
                }
            }
        }

        private void BtnSaveConnectionString_Click(object sender, EventArgs e)
        {
            try
            {
                string Database;
                string Server;
                bool Trusted = false;
                string Username = string.Empty;
                string Password = string.Empty;
                StringBuilder cs = new StringBuilder();
                if (Info.IsEmpty(TxtDbName) && Info.IsEmpty(TxtServerName))
                {
                    Database = TxtDbName.Text.Trim();
                    Server = TxtServerName.Text.Trim();
                    cs.Append("Data Source = " + Server + ";");
                    cs.Append(" Initial Catalog = " + Database + ";");
                    if (ChkTrustedConnection.Checked)
                    {
                        Trusted = true;
                        cs.Append(" Integrated Security = True;");
                    }
                    else
                    {
                        if (Info.IsEmpty(TxtUsername) && Info.IsEmpty(TxtPassword) && !ChkTrustedConnection.Checked)
                        {
                            Username = TxtUsername.Text.Trim();
                            Password = TxtPassword.Text.Trim();
                            cs.Append(" User Id = " + Username + ";");
                            cs.Append(" Password = " + Password + ";");
                        }
                        else
                        {
                            Info.Required();
                        }
                    }
                    cs.Append(" MultipleActiveResultSets = True");

                    string fileName = "conString.json";
                    if (!File.Exists(fileName))
                    {
                        File.Create(fileName);
                    }
                    ConnectionString con = new ConnectionString
                    {
                        Database = Database,
                        Source = Server,
                        IntegratedSecurity = Trusted,
                        UserId = Username,
                        Password = Password
                    };
                    string StartupPath = Environment.CurrentDirectory;
                    if (!StartupPath.EndsWith(@"\"))
                        StartupPath += @"\";
                    string Path = StartupPath + fileName;
                    string serializedJson = JsonConvert.SerializeObject(con, Formatting.Indented);
                    File.WriteAllText(@Path, serializedJson);
                    Info.Mes("Connection String Saved Successfully");

                }
                else
                {
                    Info.Required();
                }
            }
            catch (Exception ex)
            {
                Info.Add(ex);
            }
        }
    }
}