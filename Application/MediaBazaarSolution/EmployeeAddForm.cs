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
            string contractedHours = ContractedHoursTB.Text;
            string NoGoSchedule = null;



            string[] noGoStringList = new string[NoWorkLB.Items.Count];
            for (int i = 0; i < NoWorkLB.Items.Count; i++)
            {
                noGoStringList[i] = NoWorkLB.Items[i].ToString();
            }
            int[] noGoIntList = new int[NoWorkLB.Items.Count];
            noGoIntList = ConvertToIntegers(noGoStringList);
            Array.ConvertAll(noGoIntList, s => s.ToString());
            for (int i = 0; i < noGoIntList.Length; i++)
            {
                if (i != 0)
                {
                    NoGoSchedule += "-";
                }
                NoGoSchedule += noGoIntList[i];
            }

            


            bool isNotValidFirstName = int.TryParse(fName, out int intFName);
            bool isNotValidLastName = int.TryParse(lName, out int intLName);
            bool isEmailValid = checkEmail(email);
            bool isValidHourlyWage = double.TryParse(hourlyWageString, out double hourlyWage);
            bool isValidContractedHours = int.TryParse(contractedHours, out int intContractedHours);




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
            else if (!isValidContractedHours)
            {
                MessageBox.Show("The contracted hours must be a number");
            }
            else if (intContractedHours < 1)
            {
                MessageBox.Show("The contracted hours must be positive");
            }
            else
            {
                if (EmployeeDAO.Instance.AddNewEmployee(fName, lName, address, phone, username, email, type, hourlyWage, NoGoSchedule, intContractedHours))
                {
                    MessageBox.Show("Employee successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    parentForm.LoadAll();
                }
                else
                {
                    MessageBox.Show("Employee not added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool checkEmail(string input)
        {
            return Regex.IsMatch(input, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        private void AddNoWorkBtn_Click(object sender, EventArgs e)
        {
            string workingString = NoWorkCB.Text.ToString();
            NoWorkLB.Items.Add(workingString);
            SortLB();
        }



        private void SortLB()
        {
            string[] tempStringList = new string[NoWorkLB.Items.Count];
            for (int i = 0; i < NoWorkLB.Items.Count; i++)
            {
                tempStringList[i] = NoWorkLB.Items[i].ToString();
            }
            int[] tempIntArray;
            Array.Sort(tempIntArray = ConvertToIntegers(tempStringList));
            tempStringList = ConvertToStrings(tempIntArray);
            NoWorkLB.Items.Clear();
            NoWorkLB.Items.AddRange(tempStringList);
        }

        private int[] ConvertToIntegers(string[] list)
        {
            int[] returnvalues = new int[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                int number = 0;
                if (list[i].Contains("Tuesday"))
                {
                    number += 3;
                }
                if (list[i].Contains("Wednesday"))
                {
                    number += 6;
                }
                if (list[i].Contains("Thursday"))
                {
                    number += 9;
                }
                if (list[i].Contains("Friday"))
                {
                    number += 12;
                }
                if (list[i].Contains("Saturday"))
                {
                    number += 15;
                }
                if (list[i].Contains("Sunday"))
                {
                    number += 18;
                }
                if (list[i].Contains("Afternoon"))
                {
                    number += 1;
                }
                if (list[i].Contains("Evening"))
                {
                    number += 2;
                }
                returnvalues[i] = number;
            }
            return returnvalues;
        }

        private string[] ConvertToStrings(int[] list)
        {
            string[] returnvalues = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                string tempstring = "";
                if(list[i]/3 == 0)
                {
                    tempstring = "Monday";
                }
                if (list[i] / 3 == 1)
                {
                    tempstring = "Tuesday";
                }
                if (list[i] / 3 == 2)
                {
                    tempstring = "Wednesday";
                }
                if (list[i] / 3 == 3)
                {
                    tempstring = "Thursday";
                }
                if (list[i] / 3 == 4)
                {
                    tempstring = "Friday";
                }
                if (list[i] / 3 == 5)
                {
                    tempstring = "Saturday";
                }
                if (list[i] / 3 == 6)
                {
                    tempstring = "Sunday";
                }
                if (list[i]%3 == 0)
                {
                    tempstring += " Morning";
                }
                if (list[i]%3 == 1)
                {
                    tempstring += " Afternoon";
                }
                if (list[i] % 3 == 2)
                {
                    tempstring += " Evening";
                }

                returnvalues[i] = tempstring;
            }

            return returnvalues;
        }
    }
}
