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
        private string email;
        private string phone;
        private string address;
        
        //private EmployeeType type;
        private string type;
        private double hourlyWage;

        public int ID { get => iD; set => iD = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public double HourlyWage { get => hourlyWage; set => hourlyWage = value; }
        public string Type { get => type; set => type = value; }
        public string Address { get => address; set => address = value; }

        //internal EmployeeType Type { get => type; set { EmployeeType.TryParse(value.ToString(), out this.type); this.Type = type; } }

        //private string password;

        public Employee(DataRow row)
        {
            this.ID = (int)row["employee_id"];
            this.FirstName = row["first_name"].ToString();
            this.LastName = row["last_name"].ToString();
            this.Username = row["username"].ToString();
            this.Email = row["email"].ToString();
            this.Phone = row["phone"].ToString();
            this.Address = row["address"].ToString();
            //this.Type =  row["employee_type"].ToString();
            this.Type = row["employee_type"].ToString();
            this.hourlyWage = Convert.ToDouble(row["hourly_wage"]);
        }

        public Employee(int id, string firstName, string lastName, string username, string email, string phone, string type, double hourlyWage)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Email = email;
            this.Phone = phone;
            //EmployeeType.TryParse(type, out this.type);
            this.Type = type;
            this.hourlyWage = hourlyWage;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.FirstName} {this.LastName}";
        }

    }
}
