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
    public class Employee
    {
        private int iD;
        private string firstName;
        private string lastName;
        private string username;   
        private string type;
        private double hourlyWage;
        private string department_name;
        private int? manager_id; 

        public int ID { get => iD; set => iD = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public double HourlyWage { get => hourlyWage; set => hourlyWage = value; }
        public string Type { get => type; set => type = value; }
        
        public string Department { get => department_name; set => department_name = value; }
        public int? Manager_ID { get => manager_id; set => manager_id = value; }


        public Employee(DataRow row)
        {
            this.ID = (int)row["employee_id"];
            this.FirstName = row["first_name"].ToString();
            this.LastName = row["last_name"].ToString();
            this.Username = row["username"].ToString();
            this.Type = row["employee_type"].ToString();
            this.hourlyWage = Convert.ToDouble(row["hourly_wage"]);
            this.Department = row["d_name"].ToString();
            this.Manager_ID = row["manager_id"] as int?;

        }

        public Employee(int id, string firstName, string lastName, string username, string email, string phone, string type, double hourlyWage)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Type = type;
            this.hourlyWage = hourlyWage;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.FirstName} {this.LastName}";
        }

    }
}
