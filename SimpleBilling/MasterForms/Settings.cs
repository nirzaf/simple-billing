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
        private int UId;
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

                        var r = db.Settings.Take(1).FirstOrDefault();
                        //var r = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
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
            LoadForm();
        }

        private void LoadForm()
        {
            using (BillingContext db = new BillingContext())
            {
                //var data = db.Settings.FirstOrDefault(c => c.UserId == UserId);
                var data = db.Settings.Take(1).FirstOrDefault();
                if (data != null)
                {
                    if (data.DefaultPath != null)
                        TxtDefaultPath.Text = data.DefaultPath;
                    if (data.GRNPath != null)
                        TxtDefaultGRN.Text = data.GRNPath;
                    if (data.DefaultPath != null)
                        TxtDefaultExceptionFolder.Text = data.ExceptionPath;
                    if (data.SetMinValue != 0)
                        TxtMinReorderValue.Text = data.SetMinValue.ToString();
                    else
                        TxtMinReorderValue.Text = "0";
                    if (data.QuotationPath != null)
                        TxtDefaultQuotationPath.Text = data.QuotationPath;
                }

                CmbEmployee.ValueMember = "EmployeeId";
                CmbEmployee.DisplayMember = "EmployeeName";
                CmbEmployee.DataSource = db.Employee.Where(c => !c.IsDeleted).ToList();

                var users = (from u in db.Users.Where(c => !c.IsDeleted)
                             join emp in db.Employee.Where(c => !c.IsDeleted)
                             on u.EmployeeId equals emp.EmployeeId
                             select new
                             {
                                 u.UserId,
                                 u.Username,
                                 emp.EmployeeName
                             }).ToList();
                DGVUsers.DataSource = users;
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                //var data = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
                var data = db.Settings.Take(1).FirstOrDefault();
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

                        //var r = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
                        var r = db.Settings.Take(1).FirstOrDefault();
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

                        //var r = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
                        var r = db.Settings.Take(1).FirstOrDefault();
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
                    //var s = db.Settings.FirstOrDefault(c => c.UserId == 1);
                    var s = db.Settings.Take(1).FirstOrDefault();
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


        private void BtnSetDefaultQuotationPath_Click(object sender, EventArgs e)
        {
            try
            {
                var folderBrowserDialog1 = new FolderBrowserDialog();

                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    TxtDefaultQuotationPath.Text = folderName;
                    using (BillingContext db = new BillingContext())
                    {
                        Setting s = new Setting
                        {
                            QuotationPath = folderName,
                            CreatedDate = DateTime.Now
                        };

                        //var r = db.Settings.FirstOrDefault(c => c.UserId == UserId && !c.IsDeleted);
                        var r = db.Settings.Take(1).FirstOrDefault();
                        if (r == null)
                        {
                            if (db.Entry(s).State == EntityState.Detached)
                                db.Set<Setting>().Attach(s);
                            db.Entry(s).State = EntityState.Added;
                            db.SaveChanges();
                        }
                        else
                        {
                            r.QuotationPath = folderName;
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

        private void DGVUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVUsers.SelectedRows.Count > 0)
            {
                using (BillingContext db = new BillingContext())
                {
                    UId = Convert.ToInt32(DGVUsers.SelectedRows[0].Cells[0].Value + string.Empty);
                    var user = db.Users.FirstOrDefault(c => c.UserId == UId && !c.IsDeleted);
                    TxtUName.Text = user.Username;
                    TxtPWord.Text = user.Password;
                    if (user.UserType == 1)
                        CmbUserType.Text = "Admin";
                    if (user.UserType == 2)
                        CmbUserType.Text = "Manager";
                    CmbEmployee.SelectedValue = user.EmployeeId;
                }
            }
        }

        private void BtnSaveUsers_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var u = db.Users.FirstOrDefault(c => c.UserId == UId && !c.IsDeleted);
                    if (u == null)
                    {
                        Users user = new Users
                        {
                            Username = TxtUName.Text.Trim(),
                            Password = TxtPWord.Text.Trim()
                        };
                        if (CmbUserType.Text == "Admin")
                            user.UserType = 1;
                        if (CmbUserType.Text == "Manager")
                            user.UserType = 2;
                        user.EmployeeId = Convert.ToInt32(CmbEmployee.SelectedValue.ToString());
                        user.CreatedDate = DateTime.Today;
                        if (db.Entry(user).State == EntityState.Detached)
                            db.Set<Users>().Attach(user);
                        db.Entry(user).State = EntityState.Added;
                        db.SaveChanges();
                    }
                    else
                    {
                        u.Username = TxtUName.Text.Trim();
                        u.Password = TxtPWord.Text.Trim();
                        if (CmbUserType.Text == "Admin")
                            u.UserType = 1;
                        if (CmbUserType.Text == "Manager")
                            u.UserType = 2;
                        u.EmployeeId = Convert.ToInt32(CmbEmployee.SelectedValue.ToString());
                        u.UpdatedDate = DateTime.Today;
                        if (db.Entry(u).State == EntityState.Detached)
                            db.Set<Users>().Attach(u);
                        db.Entry(u).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    LoadForm();
                }
            }
            catch (Exception ex)
            {
                Info.Add(ex);
            }
        }
    }
}