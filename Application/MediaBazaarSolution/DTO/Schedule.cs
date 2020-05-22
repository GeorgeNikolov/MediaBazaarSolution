using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DTO
{
    public class Schedule
    {
        private int employeeID;
        private string employeeFirstName;
        private string employeeLastName;
        private string date;
        private string time;
        private string taskName;

        public Schedule(DataRow row)
        {
            this.employeeID = (int)row["employee_id"];
            this.employeeFirstName = row["first_name"].ToString();
            this.employeeLastName = row["last_name"].ToString();
            this.Date = row["date"].ToString();
            this.Time = row["time"].ToString();
            this.taskName = row["task_name"].ToString();
        }

        public Schedule(int employeeID, string employeeFirstName, string employeeLastName, string date, string time, string taskName)
        {
            this.employeeID = employeeID;
            this.employeeFirstName = employeeFirstName;
            this.employeeLastName = employeeLastName;
            this.Date = date;
            this.Time = time;
            this.taskName = taskName;
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeFirstName { get => employeeFirstName; set => employeeFirstName = value; }
        public string EmployeeLastName { get => employeeLastName; set => employeeLastName = value; }
       
        public string TaskName { get => taskName; set => taskName = value; }
        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
    }
}
