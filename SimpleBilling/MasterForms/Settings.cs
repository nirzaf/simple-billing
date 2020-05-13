using iText.Kernel.Colors;
using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
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
                LblRed.Text = data.Red.ToString();
                LblGreen.Text = data.Green.ToString();
                LblBlue.Text = data.Blue.ToString();
                TBRed.Value = data.Red;
                TBGreen.Value = data.Green;
                TBBlue.Value = data.Blue;
            }
        }

        private void TBRed_Scroll(object sender, EventArgs e)
        {
            LblRed.Text = TBRed.Value.ToString();
            BackColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
        }

        private void TBGreen_Scroll(object sender, EventArgs e)
        {
            LblGreen.Text = TBGreen.Value.ToString();
            BackColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
        }

        private void TBBlue_Scroll(object sender, EventArgs e)
        {
            LblBlue.Text = TBBlue.Value.ToString();
            BackColor = System.Drawing.Color.FromArgb(TBRed.Value, TBGreen.Value, TBBlue.Value);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (BillingContext db = new BillingContext())
            {
                var data = db.Settings.FirstOrDefault(c => c.UserId == Info.CashierId && !c.IsDeleted);
                if (data != null)
                {
                    data.Red = TBRed.Value;
                    data.Green = TBGreen.Value;
                    data.Blue = TBBlue.Value;
                    if (db.Entry(data).State == EntityState.Detached)
                        db.Set<Setting>().Attach(data);
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TBRed.Value = 105;
            TBGreen.Value = 105;
            TBBlue.Value = 105;
        }
    }
}