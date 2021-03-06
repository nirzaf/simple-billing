﻿using SimpleBilling.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SimpleBilling.MasterForms
{
    public partial class ManageEmployees : Form
    {
        public ManageEmployees()
        {
            InitializeComponent();
        }

        private void ManageEmployees_Load(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = false;
            LoadDGV(string.Empty);
        }

        private void LoadDGV(string Input)
        {
            using (BillingContext db = new BillingContext())
            {
                if (string.IsNullOrWhiteSpace(Input))
                {
                    var data = (from emp in db.Employee.Where(c => !c.IsDeleted)
                                select new
                                {
                                    emp.EmployeeId,
                                    emp.EmployeeName,
                                    emp.Contact,
                                    emp.Address,
                                    emp.Email
                                }).ToList();
                    DGVEmployees.DataSource = data;
                }
                else
                {
                    var data = (from emp in db.Employee.Where(c => !c.IsDeleted)
                                select new
                                {
                                    emp.EmployeeId,
                                    emp.EmployeeName,
                                    emp.Contact,
                                    emp.Address,
                                    emp.Email
                                }).Where(a=>a.EmployeeName.Contains(Input) || a.Contact.Contains(Input) || a.Address.Contains(Input) || a.Email.Contains(Input)).ToList();
                    DGVEmployees.DataSource = data;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            employeeBindingSource1.Add(new Employee());
            employeeBindingSource1.MoveLast();
            TxtEmployeeName.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            TxtEmployeeName.Focus();
            _ = employeeBindingSource1.Current as Employee;
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
                        if (employeeBindingSource1.Current is Employee emp)
                        {
                            if (db.Entry(emp).State == EntityState.Detached)
                                db.Set<Employee>().Attach(emp);
                            emp.IsDeleted = true;
                            emp.UpdatedDate = DateTime.Now;
                            db.Entry(emp).State = EntityState.Modified;
                            emp.UpdatedDate = DateTime.Now;
                            db.SaveChanges();
                            Message("Employee Deleted Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Message(ex.ToString());
            }
            finally
            {
                DGVEmployees.Refresh();
                LoadDGV(string.Empty);
            }
        }

        private void Message(string Message)
        {
            Info.Mes(Message);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    if (employeeBindingSource1.Current is Employee emp)
                    {
                        if (db.Entry(emp).State == EntityState.Detached)
                            db.Set<Employee>().Attach(emp);
                        if (emp.EmployeeId == 0)
                        {
                            db.Entry(emp).State = EntityState.Added;
                            emp.CreatedDate = DateTime.Now;
                            Message("Employee Added");
                        }
                        else
                        {
                            db.Entry(emp).State = EntityState.Modified;
                            emp.UpdatedDate = DateTime.Now;
                            Message("Employee Modified");
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ExportJson.Add(ex);
                Message(ex.ToString());
            }
            finally
            {
                DGVEmployees.Refresh();
                LoadDGV(string.Empty);
            }
        }

        private void TxtEmployeeName_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtEmployeeName);
        }

        private void TxtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtAddress);
        }

        private void TxtSearchEmployees_KeyUp(object sender, KeyEventArgs e)
        {
            Info.ToCapital(TxtSearchEmployees);
            LoadDGV(TxtSearchEmployees.Text.Trim());
        }

        private void DGVEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVEmployees.SelectedRows.Count > 0)
            {
                TxtEmployeeId.Text = DGVEmployees.SelectedRows[0].Cells[0].Value + string.Empty;
                TxtEmployeeName.Text = DGVEmployees.SelectedRows[0].Cells[1].Value + string.Empty;
                TxtContact.Text = DGVEmployees.SelectedRows[0].Cells[2].Value + string.Empty;
                TxtAddress.Text = DGVEmployees.SelectedRows[0].Cells[3].Value + string.Empty;
                TxtEmail.Text = DGVEmployees.SelectedRows[0].Cells[4].Value + string.Empty;
                using (BillingContext db = new BillingContext()) 
                {             
                    int EmpId = Convert.ToInt32(DGVEmployees.SelectedRows[0].Cells[0].Value + string.Empty);
                    var emp = db.Employee.FirstOrDefault(c => c.EmployeeId == EmpId && !c.IsDeleted);
                    TxtSecretCode.Text = emp.SecretCode;
                }
            }
        }
    }
}