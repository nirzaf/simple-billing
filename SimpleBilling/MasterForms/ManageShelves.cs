using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageShelves : Form
    {
        public ManageShelves()
        {
            InitializeComponent();
        }

        private void ManageShelves_Load(object sender, EventArgs e)
        {
            LoadDGV();
            Init();
        }

        private void LoadDGV()
        {
            using (BillingContext db = new BillingContext())
            {
                shelfBindingSource.DataSource = db.Shelves.Where(c => c.IsDeleted == false).ToList();
            }
        }

        private void Init()
        {
            PanelCRUD.Enabled = false;
            BtnSave.Enabled = false;
            BtnDelete.Enabled = false;
            LblMessage.Text = string.Empty;
        }

        private void Delete()
        {
            if (DGVShelf.SelectedRows.Count > 0)
            {
                BtnDelete.Enabled = true;
            }
        }

        private void DGVShelf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Delete();
        }

        private void ManageShelves_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void Add()
        {
            shelfBindingSource.Add(new Shelf());
            shelfBindingSource.MoveLast();
            Edit();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            PanelCRUD.Enabled = true;
            BtnAdd.Enabled = false;
            BtnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            BtnSave.Enabled = true;
            TxtShelfName.Focus();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirmation delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (BillingContext db = new BillingContext())
                    {
                        int Id = Convert.ToInt32(TxtId.Text.Trim().ToString());
                        Shelf shelve = db.Shelves.FirstOrDefault(s => s.ShelfId == Id);
                        if (shelve != null)
                        {
                            shelve.IsDeleted = true;
                            db.Entry(shelve).State = EntityState.Modified;
                            db.SaveChanges();
                            Info("Shelve Deleted Successfully");
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
                DGVShelf.Refresh();
                LoadDGV();
            }
        }

        private void Info(string Message)
        {
            LblMessage.Text = Message;
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            LblMessage.Text = string.Empty;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveItem();
        }

        private void SaveItem()
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (shelfBindingSource.Current is Shelf shelve)
                    {
                        if (db.Entry(shelve).State == EntityState.Detached)
                            db.Set<Shelf>().Attach(shelve);
                        if (shelve.ShelfId == 0)
                        {
                            db.Entry(shelve).State = EntityState.Added;
                            Info("Shelf Added");
                        }
                        else
                        {
                            db.Entry(shelve).State = EntityState.Modified;
                            Info("Shelf Modified");
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Info(ex.Message);
            }
            finally
            {
                LoadDGV();
                Save();
            }
        }
        private void Save()
        {
            BtnSave.Enabled = false;
            PanelCRUD.Enabled = false;
            BtnAdd.Enabled = true;
            BtnEdit.Enabled = true;
        }
    }
}
