using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MediaBazaarSolution.DTO;
using MediaBazaarSolution.Helper;

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

            string query = "SELECT e.employee_id, e.first_name, e.last_name, e.username, e.employee_type,e.hourly_wage, e.missed_shifts, e.manager_id, d.d_name FROM employee AS e " +
                "LEFT JOIN department AS d ON e.department_id = d.id " +
                "ORDER BY e.employee_id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }
            return employeeList;

        }
        //Method for extracting only depot workers from the database.
        public List<Employee> GetAllDepotWorkers(int managerId)
        {
            List<Employee> employeeList = new List<Employee>();

            string query = "SELECT e.employee_id, e.first_name, e.last_name, e.username, e.employee_type,e.hourly_wage, e.missed_shifts, e.manager_id, d.d_name FROM employee AS e " +
                "LEFT JOIN department AS d ON e.department_id = d.id WHERE e.employee_type = 'employee' AND e.manager_id = @managerId";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { managerId });

            foreach (DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }
            return employeeList;
        }

        public bool AddNewEmployee(string fName, string lName, string place, string phone, string username, string email, string type, double hourlyWage)
        {
            string passwordToBeHashed = "password";
            string hashedPassword = MD5.GenerateMD5(passwordToBeHashed);
            string query = "INSERT INTO employee(first_name, last_name, username, password, email, phone, employee_type, hourly_wage, address)" +
                           "VALUES( @fName , @lName , @username , @password , @email , @phone , @type , @hourlyWage , @address )";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { fName, lName, username, hashedPassword, email, phone, type, hourlyWage, place }) > 0;
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

        public List<Employee> GetAllEmployeesOnShift(int workDayID)
        {

            string query = "SELECT * FROM employee WHERE employee_id IN (SELECT employee_id FROM schedule WHERE work_day_id = " + workDayID + ")";
            List<Employee> employeeList = new List<Employee>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }

        public bool UpdateEmployeeDepartment(int id, string newDepartment)
        {
            string query = "UPDATE employee " +
                           "SET department_id = (SELECT d.id FROM department d WHERE d.d_name = @newDepartment ) " +
                           "WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { newDepartment }) > 0;
        }
        public bool UpdateEmployeeManager(int id, string newManager)
        {
            string query = "UPDATE employee e " +
                           "SET e.manager_id = (SELECT d.manager_id FROM department d WHERE d.d_name = @newDepartment ) " +
                           "WHERE employee_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { newManager }) > 0;
        }
    }
}
