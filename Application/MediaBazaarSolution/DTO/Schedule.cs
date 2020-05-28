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
        private string startTime;
        private string endTime;
        private string taskName;

        public Schedule(DataRow row)
        {
            this.employeeID = (int)row["employee_id"];
            this.employeeFirstName = row["first_name"].ToString();
            this.employeeLastName = row["last_name"].ToString();
            this.Date = row["date"].ToString();
            this.StartTime = row["start_time"].ToString();
            this.EndTime = row["end_time"].ToString();
            this.taskName = row["task_name"].ToString();
        }

        public Schedule(int employeeID, string employeeFirstName, string employeeLastName, string date, string startTime, string endTime, string taskName)
        {
            this.employeeID = employeeID;
            this.employeeFirstName = employeeFirstName;
            this.employeeLastName = employeeLastName;
            this.Date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.taskName = taskName;
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeFirstName { get => employeeFirstName; set => employeeFirstName = value; }
        public string EmployeeLastName { get => employeeLastName; set => employeeLastName = value; }
       
        public string TaskName { get => taskName; set => taskName = value; }
        public string Date { get => date; set => date = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public string EndTime { get => endTime; set => endTime = value; }
    }
}
