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
using MediaBazaarSolution.DTO;

namespace MediaBazaarSolution
{
    public partial class EmployeeAddForm : Form
    {
        MainScreen parentForm;
        List<Employee> managers;
        public EmployeeAddForm(MainScreen parent, Account user)
        {
            InitializeComponent();
            this.parentForm = parent;
            if (user.Type.Equals(EmployeeType.Administrator))
            {
                cbbxType.Items.Add("Admin");
                cbbxType.Items.Add("Manager");
            }
            cbbxType.Items.Add("Employee");

            cbbxType.SelectedIndex = 0;

            managers = EmployeeDAO.Instance.GetAllManagers();


            for (int i = 0; i < managers.Count; i++)
            {
                string fullname = $"{managers[i].FirstName} {managers[i].LastName}";

                ManagerIDCB.Items.Add(fullname);
            }
            ManagerIDCB.SelectedIndex = 0;

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            string fName = tbxFName.Text;
            string lName = tbxLName.Text;
            string username = tbxUName.Text;
            string email = tbxEmail.Text;
            string phone = tbxPhone.Text;
            string address = tbxPlace.Text;
            string type;
            if (cbbxType.SelectedItem.ToString().Equals("Admin"))
            {
                type = "Admin";
            }
            else if (cbbxType.SelectedItem.ToString().Equals("Manager"))
            {
                type = "Manager";
            }
            else
            {
                type = "Employee";
            }

            string hourlyWageString = tbxRate.Text;
            string contractedHours = ContractedHoursTB.Text;
            string NoGoSchedule = "";

            char[] forbiddenCharacters = new char[] { '\\', '\'', '\"', '@', '$', '#', '&', '*', '_', '=', '?', '<', '>', '.' };
            bool forbiddenCharactersUsed = false;
            if ((fName.IndexOfAny(forbiddenCharacters) != -1) ||
                (lName.IndexOfAny(forbiddenCharacters) != -1) ||
                (username.IndexOfAny(forbiddenCharacters) != -1) ||
                (address.IndexOfAny(forbiddenCharacters) != -1))
            {
                forbiddenCharactersUsed = true;
            }

            string[] noGoStringList = new string[NoWorkLB.Items.Count];
            for (int i = 0; i < NoWorkLB.Items.Count; i++)
            {
                noGoStringList[i] = NoWorkLB.Items[i].ToString();
            }
            int[] noGoIntList = new int[NoWorkLB.Items.Count];
            noGoIntList = ConvertToIntegers(noGoStringList);
            //int[] noGoIntStringList = new int[NoWorkLB.Items.Count];
            //noGoStringList.CopyTo(noGoIntStringList, 0);
            Array.ConvertAll(noGoIntList, s => s.ToString());
            for (int i = 0; i < noGoIntList.Length; i++)
            {
                if (i != 0)
                {
                    NoGoSchedule += "-";
                }
                NoGoSchedule += noGoIntList[i];
            }
            int managerID;
            if (!type.Equals("Employee"))
            {
                managerID = 0;
                NoGoSchedule = "";
            }
            else
            {
                managerID = managers[ManagerIDCB.SelectedIndex].ID;
            }

            List<Employee> employees = EmployeeDAO.Instance.GetAllEmployees();
            bool usernameIsTaken = false;
            foreach (Employee employee in employees)
            {
                if (employee.Username.Equals(username))
                {
                    usernameIsTaken = true;
                    break;
                }
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
                MessageBox.Show("The contracted hours must be a number", "Invalid contracted hours", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (intContractedHours < 1)
            {
                MessageBox.Show("The contracted hours must be positive", "Invalid contracted hours", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (forbiddenCharactersUsed)
            {
                MessageBox.Show($"A forbidden character is used, please refrain from using any of the following characters: {new string(forbiddenCharacters)}", "Invalid characters used", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (usernameIsTaken)
            {
                MessageBox.Show("That username is already taken", "Password already taken", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (EmployeeDAO.Instance.AddNewEmployee(fName, lName, address, phone, username, email, type, hourlyWage, NoGoSchedule, intContractedHours, managerID))
                {
                    MessageBox.Show("Employee successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.LoadAll();
                    this.Close();
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
            if (NoWorkLB.Items.Contains(workingString))
            {
                MessageBox.Show("That day is already in there");
            }
            else
            {
                NoWorkLB.Items.Add(workingString);
                SortLB();
            }

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
                if (list[i] / 3 == 0)
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
                if (list[i] % 3 == 0)
                {
                    tempstring += " Morning";
                }
                if (list[i] % 3 == 1)
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

        private void RemoveNoWorkBtn_Click(object sender, EventArgs e)
        {
            NoWorkLB.Items.RemoveAt(NoWorkLB.SelectedIndex);
        }
    }
}
