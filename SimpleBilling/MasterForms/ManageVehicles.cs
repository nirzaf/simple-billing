using SimpleBilling.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageVehicles : Form
    {
        private string VehicleNum;

        public ManageVehicles()
        {
            InitializeComponent();
        }

        private void ManageVehicles_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDGV();
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info.Mes(ex.Message);
            }
            finally
            {
                Save();
            }
        }

        private void LoadDGV()
        {
            using (BillingContext db = new BillingContext())
            {
                var data = (from ve in db.Vehicles.Where(c => !c.IsDeleted)
                            join cus in db.Customers
                            on ve.OwnerId equals cus.CustomerId
                            select new
                            {
                                ve.VehicleNo,
                                ve.Brand,
                                ve.Model,
                                ve.Type,
                                ve.CurrentMileage,
                                ve.ServiceMileageDue,
                                ve.AddedDate,
                                cus.Name
                            }).ToList();
                DGVVehicles.DataSource = data;

                CmbVehicleOwner.ValueMember = "CustomerId";
                CmbVehicleOwner.DisplayMember = "Name";
                CmbVehicleOwner.DataSource = db.Customers.ToList();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var r = db.Vehicles.FirstOrDefault(c => c.VehicleNo == VehicleNum && !c.IsDeleted);
                    if (r != null)
                    {
                        if (db.Entry(r).State == EntityState.Detached)
                            db.Set<Vehicle>().Attach(r);
                        r.IsDeleted = true;
                        r.UpdatedDate = Info.Today();
                        db.Entry(r).State = EntityState.Added;
                        db.SaveChanges();
                        Info.Mes("Selected Vehicle Deleted Successfully");
                    }
                    else
                    {
                        Info.Mes("something went Wrong! please try again");
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info.Mes(ex.Message);
            }
            finally
            {
                LoadDGV();
                Save();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var r = db.Vehicles.FirstOrDefault(c => c.VehicleNo == TxtVehicleNumber.Text.Trim() && !c.IsDeleted);
                    if (r == null)
                    {
                        if (Info.IsEmpty(TxtCurrentMileage) && Info.IsEmpty(TxtServiceMileageDue))
                        {
                            Vehicle v = new Vehicle
                            {
                                VehicleNo = TxtVehicleNumber.Text,
                                Brand = TxtBrand.Text,
                                Model = TxtModel.Text,
                                Type = TxtType.Text,
                                CurrentMileage = Convert.ToInt32(TxtCurrentMileage.Text.Trim()),
                                ServiceMileageDue = Convert.ToInt32(TxtServiceMileageDue.Text.Trim()),
                                AddedDate = Info.Today(),
                                CreatedDate = Info.Today(),
                                OwnerId = Convert.ToInt32(CmbVehicleOwner.SelectedValue.ToString())
                            };
                            if (db.Entry(v).State == EntityState.Detached)
                                db.Set<Vehicle>().Attach(v);
                            db.Entry(v).State = EntityState.Added;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (Info.IsEmpty(TxtCurrentMileage) && Info.IsEmpty(TxtServiceMileageDue))
                        {
                            r.Brand = TxtBrand.Text;
                            r.Type = TxtType.Text;
                            r.Model = TxtModel.Text;
                            r.CurrentMileage = Convert.ToInt32(TxtCurrentMileage.Text.Trim());
                            r.ServiceMileageDue = Convert.ToInt32(TxtServiceMileageDue.Text.Trim());
                            r.AddedDate = Info.Today();
                            r.UpdatedDate = Info.Today();
                            r.OwnerId = Convert.ToInt32(CmbVehicleOwner.SelectedValue.ToString());
                            if (db.Entry(r).State == EntityState.Detached)
                                db.Set<Vehicle>().Attach(r);
                            db.Entry(r).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJSON.Add(ex);
                Info.Mes(ex.Message);
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
            BtnCancel.Enabled = false;
            BtnAdd.Enabled = true;
            BtnEdit.Enabled = true;
            tableLayoutPanel2.Enabled = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Enabled = true;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            TxtVehicleNumber.ReadOnly = true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Enabled = true;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            TxtVehicleNumber.ReadOnly = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnAdd.Enabled = true;
            BtnEdit.Enabled = true;
            tableLayoutPanel2.Enabled = false;
        }

        private void DGVVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVVehicles.SelectedRows.Count > 0)
            {
                VehicleNum = DGVVehicles.SelectedRows[0].Cells[0].Value + string.Empty;
                TxtVehicleNumber.Text = VehicleNum;
                TxtBrand.Text = DGVVehicles.SelectedRows[0].Cells[1].Value + string.Empty;
                TxtModel.Text = DGVVehicles.SelectedRows[0].Cells[2].Value + string.Empty;
                TxtType.Text = DGVVehicles.SelectedRows[0].Cells[3].Value + string.Empty;
                TxtCurrentMileage.Text = DGVVehicles.SelectedRows[0].Cells[4].Value + string.Empty;
                TxtServiceMileageDue.Text = DGVVehicles.SelectedRows[0].Cells[5].Value + string.Empty;
                CmbVehicleOwner.Text = DGVVehicles.SelectedRows[0].Cells[7].Value + string.Empty;
            }
        }

        private void TxtCurrentMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            Info.IsInt(e);
        }
    }
}