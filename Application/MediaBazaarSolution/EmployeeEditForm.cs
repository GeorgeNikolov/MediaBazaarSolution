using MediaBazaarSolution.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSolution
{
    public partial class EmployeeEditForm : Form
    {
        private MainScreen parentForm;
        private DataGridViewRow row;
        private string previousFName;
        private string previousLName;
        private string previousUName;
        private string previousRate;
        private string previousDepartment;
        private string previousUserType;
        private int employeeID;


        public EmployeeEditForm(MainScreen parent, DataGridViewRow row)
        {
            InitializeComponent();
            this.parentForm = parent;
            LoadEmployeeValues(row);

        }

        private void LoadEmployeeValues(DataGridViewRow row)
        {
            employeeID = Convert.ToInt32(row.Cells[0].Value.ToString());
            tbxFName.Text = row.Cells[1].Value.ToString();
            previousFName = tbxFName.Text;
            tbxLName.Text = row.Cells[2].Value.ToString();
            previousLName = tbxLName.Text;
            tbxUName.Text = row.Cells[3].Value.ToString();
            previousUName = tbxUName.Text;
            tbxRate.Text = row.Cells[4].Value.ToString();
            previousRate = tbxRate.Text;
            bool isAdmin = String.Compare(parentForm.UserType, "admin") == 0;
            if (isAdmin)
            {
                cbxUserType.Items.Add("Admin");
                cbxUserType.Items.Add("Manager");
                cbxUserType.Items.Add("Employee");

            }
            else
            {
                cbxUserType.Items.Add("Employee");
            }

            if (row.Cells[5].Value.ToString().ToLower() == "admin" && isAdmin)
            {
                cbxUserType.SelectedIndex = 0;
            }
            else if (row.Cells[5].Value.ToString().ToLower() == "manager" && isAdmin)
            {
                cbxUserType.SelectedIndex = 1;
            }
            else if (row.Cells[5].Value.ToString().ToLower() == "employee" && isAdmin)
            {
                cbxUserType.SelectedIndex = 2;
            }
            else
            {
                cbxUserType.SelectedIndex = 0;
            }
            previousUserType = cbxUserType.SelectedItem.ToString();

            cbxDepartment.SelectedItem = row.Cells[6].Value.ToString();

            if(cbxDepartment.SelectedItem.ToString() == null)
            {
                previousDepartment = null;
            }
            else
            {
                previousDepartment = cbxDepartment.SelectedItem.ToString();
            }

            GetEmployeesPersonalInfo(employeeID);
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            bool queryIsSuccess = false;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit that employee?", "Edit Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (String.Compare(previousFName, tbxFName.Text) != 0)
                {
                    bool IsValidName = Regex.IsMatch(tbxFName.Text, "[A-Z][a-zA-Z]");

                    if (String.IsNullOrEmpty(tbxFName.Text) || String.IsNullOrWhiteSpace(tbxFName.Text))
                    {
                        MessageBox.Show("First name must not be blank!", "First Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxFName.Text = previousFName;
                    }
                    else if (!IsValidName)
                    {
                        MessageBox.Show("First name must be valid!", "First Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxFName.Text = previousFName;
                    }
                    else
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeFirstName(employeeID, tbxFName.Text);
                    }
                }
                else if (String.Compare(previousLName, tbxLName.Text) != 0)
                {
                    bool IsValidName = Regex.IsMatch(tbxLName.Text, "[A-Z][a-zA-Z]");

                    if (String.IsNullOrEmpty(tbxLName.Text) || String.IsNullOrWhiteSpace(tbxLName.Text))
                    {
                        MessageBox.Show("Last name must not be blank!", "Last Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxLName.Text = previousLName;
                    }
                    else if (!IsValidName)
                    {
                        MessageBox.Show("Last name must be valid!", "Last Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxLName.Text = previousLName;
                    }
                    else
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeLastName(employeeID, tbxLName.Text);
                    }
                }
                else if (String.Compare(previousUName, tbxUName.Text) != 0)
                {
                    
                    if (String.IsNullOrEmpty(tbxUName.Text) || String.IsNullOrWhiteSpace(tbxUName.Text))
                    {
                        MessageBox.Show("Username must not be blank!", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxUName.Text = previousUName;
                    }
                    else
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeEmail(employeeID, tbxUName.Text);
                    }
                }
                else if(String.Compare(previousRate, tbxRate.Text) != 0)
                {
                    bool isValidRate = double.TryParse(tbxRate.Text, out double newRate);
                    if (String.IsNullOrEmpty(tbxRate.Text) || String.IsNullOrWhiteSpace(tbxRate.Text))
                    {
                        MessageBox.Show("Rate must not be blank!", "Rate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxRate.Text = previousRate;
                    }
                    
                    else if (!isValidRate) 
                    {
                        MessageBox.Show("Rate must be valid!", "Rate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxRate.Text = previousRate;
                    }
                    else if (newRate < 0)
                    {
                        MessageBox.Show("Rate must not be negative!", "Rate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxRate.Text = previousRate;
                    }
                    else
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeHourlyWage(employeeID, newRate);

                    }
                }
                else if (String.Compare(previousDepartment, cbxDepartment.SelectedItem.ToString()) != 0)
                {
                    queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeManager(employeeID, cbxDepartment.SelectedItem.ToString());
                    queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeDepartment(employeeID, cbxDepartment.SelectedItem.ToString());
                    
                }
                else if (String.Compare(previousUserType, cbxUserType.SelectedItem.ToString()) != 0)
                {
                    queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeType(employeeID, cbxUserType.SelectedItem.ToString());
                }
            }
            else
            {
                tbxFName.Text = previousFName;
                tbxLName.Text = previousLName;
                tbxUName.Text = previousUName;
                cbxDepartment.SelectedItem = previousDepartment;
                tbxRate.Text = previousRate;
                return;
            }

            if (queryIsSuccess)
            {
                MessageBox.Show("Employee successfully edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                MessageBox.Show("Employee not edited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetEmployeesPersonalInfo(int id)
        {
            string query = "SELECT employee_id, email, phone, address FROM employee WHERE employee_id = @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });

            tbxEmail.Text = data.Rows[0].Field<string>(data.Columns[1].ColumnName).ToString();
            tbxPhone.Text = data.Rows[0].Field<string>(data.Columns[2].ColumnName).ToString();
            tbxAddress.Text = data.Rows[0].Field<string>(data.Columns[3].ColumnName).ToString();
        }
    }
}
