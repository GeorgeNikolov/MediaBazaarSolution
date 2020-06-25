using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DTO
{

    public class Account
    {
        private int iD;
        private string firstName;
        private string lastName;
        private string username;
        private string email;
        private string phone;
        private string address;
        private string noGoSchedule;
        private int contractedHours;

        //private EmployeeType type;
        private EmployeeType type;
        private double hourlyWage;

        public int ID { get => iD; set => iD = value; }
        public string FirstName { get => firstName; set { if (value == null || value == "") this.firstName = "None"; else { firstName = value; } } }
        public string LastName { get => lastName; set { if (value == null || value == "") this.lastName = "None"; else { lastName = value; } } }
        public string Username { get => username; set { if (value == null || value == "") this.username = "None"; else { username = value; } } }
        public string Email { get => email; set { if (value == null || value == "") this.email = "None"; else { email = value; } } }
        public string Phone { get => phone; set { if (value == null || value == "") this.phone = "None"; else { phone = value; } } }
        public double HourlyWage { get => hourlyWage; set { if (value == null || value == 0) this.hourlyWage = 0; else { hourlyWage = value; } } }
        public EmployeeType Type { get => type; set => type = value; }
        public string Address { get => address; set { if (value == null || value == "") this.address = "None"; else { address = value; } } }
        public string NoGoSchedule { get => noGoSchedule; set { if (value == null || value == "") this.noGoSchedule = "None"; else { noGoSchedule = value; } } }
        public int ContractedHours { get => contractedHours; set { if (value == null || value == 0) this.contractedHours = 0; else { contractedHours = value; } } }



        //internal EmployeeType Type { get => type; set { EmployeeType.TryParse(value.ToString(), out this.type); this.Type = type; } }

        //private string password;

        public Account(DataRow row)
        {
            this.ID = (int)row["employee_id"];
            this.FirstName = row["first_name"].ToString();
            this.LastName = row["last_name"].ToString();
            this.Username = row["username"].ToString();
            this.Email = row["email"].ToString();
            this.Phone = row["phone"].ToString();
            this.Address = row["address"].ToString();
            string value = row["employee_type"].ToString();
            if (value == null || value == "")
            {
                this.type = EmployeeType.Employee;
            }
            else if (value.ToString().Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                Type = EmployeeType.Administrator;
            }
            else if (value.ToString().Equals("Manager"))
            {
                Type = EmployeeType.Manager;
            }
            else
            {
                Type = EmployeeType.Employee;
            }


            this.hourlyWage = Convert.ToDouble(row["hourly_wage"]);
            this.ContractedHours = (int)row["ContractedHours"];
            this.NoGoSchedule = row["NoGoSchedule"].ToString();


        }

        public Account(int id, string firstName, string lastName, string username, string email, string phone, string type, double hourlyWage)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Email = email;
            this.Phone = phone;
            //EmployeeType.TryParse(type, out this.type);
            string value = type;
            if (value == null || value == "")
            {
                this.type = EmployeeType.Employee;
            }
            else if (value.ToString().Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                Type = EmployeeType.Administrator;
            }
            else if (value.ToString().Equals("Manager"))
            {
                Type = EmployeeType.Manager;
            }
            else
            {
                Type = EmployeeType.Employee;
            }
            this.hourlyWage = hourlyWage;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.FirstName} {this.LastName}";
        }

    }
}



