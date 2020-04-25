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
    public partial class ManageEmployees : Form
    {
        public ManageEmployees()
        {
            InitializeComponent();
        }

        private void ManageEmployees_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            CRUDPanel.Enabled = false;
            LblMessage.Text = string.Empty;
            using (BillingContext db = new BillingContext())
            {
                employeeBindingSource.DataSource = db.Employee.ToList();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            employeeBindingSource.Add(new Employee());
            employeeBindingSource.MoveLast();
            TxtEmployeeName.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CRUDPanel.Enabled = true;
            BtnSave.Enabled = true;
            TxtEmployeeName.Focus();
            Employee emp = employeeBindingSource.Current as Employee;
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
                        if (employeeBindingSource.Current is Employee emp)
                        {
                            if (db.Entry(emp).State == EntityState.Detached)
                                db.Set<Employee>().Attach(emp);
                            db.Entry(emp).State = EntityState.Deleted;
                            db.SaveChanges();
                            Info("Employee Deleted Successfully");
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
                DGVEmployees.Refresh();
                LoadDGV();
            }
        }
        private void Info(string Message)
        {
            LblMessage.Text = Message;
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
                    if (employeeBindingSource.Current is Employee emp)
                    {
                        if (db.Entry(emp).State == EntityState.Detached)
                            db.Set<Employee>().Attach(emp);
                        if (emp.EmployeeId == 0)
                        {
                            db.Entry(emp).State = EntityState.Added;
                            Info("Employee Added");
                        }
                        else
                        {
                            db.Entry(emp).State = EntityState.Modified;
                            Info("Employee Modified");
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
                DGVEmployees.Refresh();
                LoadDGV();
            }
        }
    }
}
