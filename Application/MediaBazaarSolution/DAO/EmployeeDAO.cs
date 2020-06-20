using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MediaBazaarSolution.DTO;
using MediaBazaarSolution.Helper;
using System.Windows;

namespace MediaBazaarSolution.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeDAO();
                }

                return EmployeeDAO.instance;
            }

            private set
            {
                EmployeeDAO.instance = value;
            }
        }

        private EmployeeDAO() { }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            string query = "SELECT * FROM employee";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }
            return employeeList;

        }

        public bool AddNewEmployee(string fName, string lName, string place, string phone, string username, string email, string type, double hourlyWage, string NoGoSchedule, int ContractedHours)
        {
            string passwordToBeHashed = "password";
            string hashedPassword = MD5.GenerateMD5(passwordToBeHashed);
            string query = "INSERT INTO employee(first_name, last_name, username, password, email, phone, employee_type, hourly_wage, address, NoGoSchedule, ContractedHours)" +
                           "VALUES( @fName , @lName , @username , @password , @email , @phone , @type , @hourlyWage , @address , @NoGoSchedule , @ContractedHours)";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {fName, lName, username, hashedPassword, email, phone, type, hourlyWage, place, NoGoSchedule, ContractedHours}) > 0;
        }

        public bool DeleteEmployee(int id)
        {
            string query = "DELETE FROM employee WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public List<Employee> SearchEmployeeByLastName(string name)
        {
            List<Employee> employeeList = new List<Employee>();
            string query = "SELECT * FROM employee WHERE last_name = @name";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { name });

            foreach (DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }

        public bool UpdateEmployeeFirstName(int id, string fName)
        {
            string query = "UPDATE employee SET first_name = @fName WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { fName }) > 0;
        }

        public bool UpdateEmployeeLastName(int id, string lName)
        {
            string query = "UPDATE employee SET last_name = @lName WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { lName }) > 0;
        }

        public bool UpdateEmployeeUsername(int id, string username)
        {
            string query = "UPDATE employee SET username = @username WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { username }) > 0;
        }

        public bool UpdateEmployeeEmail(int id, string email)
        {
            string query = "UPDATE employee SET email = @email WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { email }) > 0;
            
            
        }

        public bool UpdateEmployeePhone(int id, string phone)
        {
            string query = "UPDATE employee SET phone = @phone WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { phone }) > 0;
        }

        public bool UpdateEmployeeHourlyWage(int id, double hourlyWage)
        {
            string query = "UPDATE employee SET hourly_wage = @hourlyWage WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { hourlyWage }) > 0;
        }

        public bool UpdateEmployeeType(int id, string type)
        {
            string query = "UPDATE employee SET employee_type = @type WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { type }) > 0;
        }

        public bool UpdateEmployeeAddress(int id, string address)
        {
            string query = "UPDATE employee SET address = @address WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { address }) > 0;
        }

        public bool UpdateEmployeeContractedHours(int id, int contractedHours)
        {
            string query = "UPDATE employee SET ContractedHours = @contractedHours WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { contractedHours }) > 0;
        }

        public bool UpdateEmployeeNoGoTimes(int id, string noGoSchedule)
        {
            string query = "UPDATE employee SET NoGoSchedule = @noGoSchedule WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { noGoSchedule }) > 0;
        }

        public List<Employee> GetAllEmployeesOnly()
        {
            string query = "SELECT * FROM employee WHERE employee_type = 'employee'";
            List<Employee> employeeList = new List<Employee>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }
            return employeeList;
        }

        public List<Employee> GetAllEmployeesOnShift(int workDayID)
        {

            string query = "SELECT * FROM employee WHERE employee_id IN (SELECT employee_id FROM schedule WHERE work_day_id = " + workDayID + ")";
            List<Employee> employeeList = new List<Employee>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }

        public List<Employee> GetAllManagers()
        {
            string query = "SELECT * FROM employee WHERE employee_type='manager'";
            List<Employee> employeeList = new List<Employee>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }

        public string GetFirstNameAndLastNameFromID(int ID)
        {
            string query1 = "SELECT first_name FROM employee WHERE employee_id = " + ID;
            string query2 = "SELECT last_name FROM employee WHERE employee_id = " + ID;

            return DataProvider.Instance.ExecuteScalar(query1).ToString() + " " + DataProvider.Instance.ExecuteScalar(query2);
        }

        public List<Employee> GetAllEmployeesByManager(int managerID)
        {
            string query = "SELECT * FROM employee WHERE manager_id = @managerID && employee_type = 'employee'";
            List<Employee> employeeList = new List<Employee>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }
        
    }
}
