using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MediaBazaarSolution.DAO;

namespace MediaBazaarSolution
{
    public partial class EmployeeAddForm : Form
    {
        MainScreen parentForm;
        public EmployeeAddForm(MainScreen parent)
        {
            InitializeComponent();
            this.parentForm = parent;

            cbbxType.Items.Add("Employee");
            cbbxType.Items.Add("Admin");
            cbbxType.SelectedIndex = 0;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            string fName = tbxFName.Text;
            string lName = tbxLName.Text;
            string username = tbxUName.Text;
            string email = tbxEmail.Text;
            string phone = tbxPhone.Text;
            string address = tbxPlace.Text;
            string type = (cbbxType.SelectedIndex == 0) ? "employee" : "admin";
            string hourlyWageString = tbxRate.Text;
            

            bool isNotValidFirstName = int.TryParse(fName, out int intFName);
            bool isNotValidLastName = int.TryParse(lName, out int intLName);
            bool isEmailValid = checkEmail(email);
            bool isValidHourlyWage = double.TryParse(hourlyWageString, out double hourlyWage);

            


            if (String.IsNullOrEmpty(fName) || String.IsNullOrWhiteSpace(fName))
            {
                MessageBox.Show("The first name is not valid!", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(lName) || String.IsNullOrWhiteSpace(lName))
            {
                MessageBox.Show("The last name is not valid!", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(address) || String.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("The address is not valid!", "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(phone) || String.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("The phone is not valid!", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("The username is not valid!", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(email) || String.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("The email is not valid!", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(hourlyWageString) || String.IsNullOrWhiteSpace(hourlyWageString))
            {
                MessageBox.Show("The hourly rate is not valid!", "Invalid Hourly Rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isNotValidFirstName)
            {
                MessageBox.Show("The first name you enter is not a string!", "First Name must be a string", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isNotValidLastName)
            {
                MessageBox.Show("The last name you enter is not a string!", "Last Name must be a string", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!isEmailValid)
            {
                MessageBox.Show("The email you enter is not valid", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (hourlyWage < 0)
            {
                MessageBox.Show("The hourly wage must be positive!", "Invalid hourly wage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (EmployeeDAO.Instance.AddNewEmployee(fName, lName, address, phone, username, email, type, hourlyWage)) {
                    MessageBox.Show("Employee successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    parentForm.LoadAll();
                } else
                {
                    MessageBox.Show("Employee not added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool checkEmail(string input)
        {
            return Regex.IsMatch(input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
    }
}
