using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DTO
{
    enum EmployeeType{
        Employee,Manager, Administrator
    }
    class Employee
    {
        private int id;
        private string firstName;
        private string lastName;
        private string username;   
        private string email;
        private string phone;
        private EmployeeType type;
        private double hourlyRate;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public double HourlyRate { get => hourlyRate; set => hourlyRate = value; }
        internal EmployeeType Type { get => type; set { EmployeeType.TryParse(value.ToString(), out this.type); this.Type = type; } }

        //private string password;

        public Employee(DataRow row)
        {
            this.Id = (int)row["employee_id"];
            this.FirstName = row["first_name"].ToString();
            this.LastName = row["last_name"].ToString();
            this.Username = row["username"].ToString();
            this.Email = row["email"].ToString();
            this.Phone = row["phone"].ToString();
            this.Type = (EmployeeType)row["employee_type"];
            this.hourlyRate = Convert.ToDouble(row["hourly_wage"]);
        }
        }
}
