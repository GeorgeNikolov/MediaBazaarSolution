using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaarSolution.DTO;
using MediaBazaarSolution.DAO;
using System.Text.RegularExpressions;

namespace MediaBazaarSolution
{
    public partial class EmployeeEditForm : Form
    {
        MainScreen parentForm;
        List<Employee> managers;
        Employee employee;

        public EmployeeEditForm(MainScreen parent, Employee employee, Account user)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.employee = employee;

            // Setting the values in the textboxes
            if (user.Type.Equals(EmployeeType.Administrator))
            {
                TypeCB.Items.Add("Admin");
                TypeCB.Items.Add("Manager");
                
            }
            TypeCB.Items.Add("Employee");
            if(employee.Type.Equals(EmployeeType.Administrator))
            {
                TypeCB.SelectedIndex = 0;
            } else if (employee.Type.Equals(EmployeeType.Manager))
            {
                TypeCB.SelectedIndex = 1;
            } else
            {
                TypeCB.SelectedItem = "Employee";
            }
            
            AddressTB.Text = employee.Address;
            CHoursTB.Text = employee.ContractedHours.ToString();
            EmailTB.Text = employee.Email;
            FNameTB.Text = employee.FirstName;
            HWageTB.Text = employee.HourlyWage.ToString();
            LNameTB.Text = employee.LastName;
            PhoneTB.Text = employee.Phone;
            UNameTB.Text = employee.Username;

            string[] shifts = new string[] {
                "Monday Morning",
                "Monday Afternoon",
                "Monday Evening",
                "Tuesday Morning",
                "Tuesday Afternoon",
                "Tuesday Evening",
                "Wednesday Morning",
                "Wednesday Afternoon",
                "Wednesday Evening",
                "Thursday Morning",
                "Thursday Afternoon",
                "Thursday Evening",
                "Friday Morning",
                "Friday Afternoon",
                "Friday Evening",
                "Saturday Morning",
                "Saturday Afternoon",
                "Saturday Evening",
                "Sunday Morning",
                "Sunday Afternoon",
                "Sunday Evening"
            };
            NoWorkCB.Items.AddRange(shifts);
            Employee contractedManager = null;
            managers = EmployeeDAO.Instance.GetAllManagers();
            if(employee.Type.Equals(EmployeeType.Employee))
            {
                contractedManager = EmployeeDAO.Instance.GetManagerByEmployeeID(employee.ID);
            }
            

            for (int i = 0; i < managers.Count; i++)
            {
                string fullname = $"{managers[i].FirstName} {managers[i].LastName}";
                ManagerIDCB.Items.Add(fullname); if (employee.Type.Equals(EmployeeType.Employee))
                {
                    if (managers[i].ID == contractedManager.ID)
                    {
                        ManagerIDCB.SelectedIndex = i;
                    }
                }
                
            }

            if (employee.Type.Equals(EmployeeType.Employee))
            {
                string[] splitsNoGoSchedule = employee.NoGoSchedule.Split('-');
                int[] noGoInts = new int[splitsNoGoSchedule.Length];
                for (int i = 0; i < noGoInts.Length; i++)
                {
                    noGoInts[i] = Convert.ToInt32(splitsNoGoSchedule[i]);
                }
                string[] noGoStrings = ConvertToStrings(noGoInts);
                NoWorkLB.Items.AddRange(noGoStrings);
            }
            

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            string fName = FNameTB.Text;
            string lName = LNameTB.Text;
            string username = UNameTB.Text;
            string email = EmailTB.Text;
            string phone = PhoneTB.Text;
            string address = AddressTB.Text;
            string type;
            if (TypeCB.SelectedItem.ToString().Equals("Admin"))
            {
                type = "Admin";
            }
            else if (TypeCB.SelectedItem.ToString().Equals("Manager"))
            {
                type = "Manager";
            }
            else
            {
                type = "Employee";
            }

            string hourlyWageString = HWageTB.Text;
            string contractedHours = CHoursTB.Text;
            string NoGoSchedule = "";



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
            int managerID;
            if(!type.Equals("Employee"))
            {
                managerID = 0;
                NoGoSchedule = null;

            } else
            {
                managerID = managers[ManagerIDCB.SelectedIndex].ID;
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
                if (EmployeeDAO.Instance.UpdateEmployeeFirstName(employee.ID, fName) &&
                    EmployeeDAO.Instance.UpdateEmployeeLastName(employee.ID, lName) &&
                    EmployeeDAO.Instance.UpdateEmployeeAddress(employee.ID, address) &&
                    EmployeeDAO.Instance.UpdateEmployeePhone(employee.ID, phone) &&
                    EmployeeDAO.Instance.UpdateEmployeeUsername(employee.ID, username) &&
                    EmployeeDAO.Instance.UpdateEmployeeEmail(employee.ID, email) &&
                    EmployeeDAO.Instance.UpdateEmployeeType(employee.ID, type) &&
                    EmployeeDAO.Instance.UpdateEmployeeHourlyWage(employee.ID, hourlyWage) &&
                    EmployeeDAO.Instance.UpdateEmployeeNoGoTimes(employee.ID, NoGoSchedule) &&
                    EmployeeDAO.Instance.UpdateEmployeeContractedHours(employee.ID, intContractedHours) &&
                    EmployeeDAO.Instance.UpdateEmployeeManager(employee.ID, managerID))
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

