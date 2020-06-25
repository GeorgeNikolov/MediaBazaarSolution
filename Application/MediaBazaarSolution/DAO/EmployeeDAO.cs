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

            string query = "SELECT e.employee_id, e.manager_id, e.missed_shifts, e.first_name, e.last_name, e.username, e.email,  e.phone, e.address, e.employee_type, e.hourly_wage, e.missed_shifts, e.manager_id, d.d_name, e.NoGoSchedule, e.ContractedHours FROM employee AS e " +
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

        public bool AddNewEmployee(string fName, string lName, string place, string phone, string username, string email, string type, double hourlyWage, string NoGoSchedule, int ContractedHours, int managerID)
        {
            string password = "password";
            string hashedPassword = MD5.GenerateMD5(password);
            string query = "INSERT INTO employee(first_name, last_name, username, password, email, phone, employee_type, hourly_wage, address, NoGoSchedule, ContractedHours, manager_id, missed_shifts)" +
                           "VALUES( @fName , @lName , @username , @password , @email , @phone , @type , @hourlyWage , @address , @NoGoSchedule , @ContractedHours , @managerID , @missedShifts )";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { fName, lName, username, hashedPassword, email, phone, type, hourlyWage, place, NoGoSchedule, ContractedHours, managerID, 0 }) > 0;
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
            string query = "UPDATE employee SET address = @place WHERE employee_id = " + id;
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
            foreach (DataRow row in data.Rows)
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
            foreach (DataRow row in data.Rows)
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
            foreach (DataRow row in data.Rows)
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

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { managerID });
            foreach (DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }

        public Employee GetManagerByEmployeeID(int employeeID)
        {
            string query = "SELECT * FROM employee WHERE employee_id IN ( SELECT manager_id FROM employee WHERE employee_id = @employeeID )";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { employeeID });
            Employee employee = new Employee(data.Rows[0]);
            return employee;
        }

        public bool UpdateEmployeeManager(int employeeID, int managerID)
        {
            string query = "UPDATE employee SET manager_id = @managerID WHERE employee_id = @employeeID ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { managerID, employeeID }) > 0;
        }

        public bool UpdateEmployeePassword(int employeeID, string password)
        {
            string hashedpassword = MD5.GenerateMD5(password);
            string query = "UPDATE employee SET password = @password WHERE employee_id = @employeeID ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { hashedpassword, employeeID }) > 0;
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            string query = "SELECT * FROM employee WHERE employee_id = @employeeID ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { employeeID });
            return new Employee(data.Rows[0]);
        }

        public bool UpdateEmployee(int employeeID, string fname, string lname, string uname, string email, string phone, double hwage, string type, string place, string noGoSchedule, int cHours, int managerID)
        {
            string query = "UPDATE employee SET first_name = @fname , last_name = @lname , username = @uname , email = @mail , phone = @pnumber , hourly_wage = @hwage , employee_type = @type , address = @place , NoGoSchedule = @noGoSchedule , ContractedHours = @cHours , manager_id = @managerID WHERE employee_id = @id ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { fname, lname, uname, email, phone, hwage, type, place, noGoSchedule, cHours, managerID, employeeID }) > 0;
        }


    }
}
