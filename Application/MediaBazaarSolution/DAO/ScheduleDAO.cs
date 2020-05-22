using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MediaBazaarSolution.DTO;
using MySql.Data;

namespace MediaBazaarSolution.DAO
{
    public class ScheduleDAO
    {
        private static ScheduleDAO instance;

        public static ScheduleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScheduleDAO();
                }

                return ScheduleDAO.instance;
            }

            private set
            {
                ScheduleDAO.instance = value;
            }
        }

        private ScheduleDAO() { }

        public List<Schedule> GetEmployeesOnShiftByDate(string date)
        {
            List<Schedule> scheduleList = new List<Schedule>();
            string query = "SELECT s.employee_id, e.first_name, e.last_name, s.date, s.time, s.task_name FROM schedule s INNER JOIN employee e ON s.employee_id = e.employee_id WHERE s.date = '" + date + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            
            foreach(DataRow row in data.Rows)
            {
                Schedule schedule = new Schedule(row);
                scheduleList.Add(schedule);
            }
            return scheduleList;
        }

        public bool AddSchedule(int employeeID, string date, string time, string taskName)
        {
            string query = "INSERT INTO schedule (employee_id, date, time, task_name) VALUES( @employeeID , @date , @time , @taskName )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {employeeID, date, time, taskName}) > 0;
        }

        public bool DeleteSchedule(int employeeID, string date, string time)
        {
            string query = "DELETE FROM schedule WHERE schedule_id = (SELECT schedule_id FROM schedule WHERE employee_id = @employeeID && date = @date && time = @time )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { employeeID, date, time }) > 0;
        }

        public bool GetSchedule(int employeeID, string date, string time, string taskName)
        {
            string query = "SELECT * FROM schedule WHERE employee_id = @employeeID && date = @date && time = @time && task_name = @taskName ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { employeeID, date, time, taskName });
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSchedule(string oldTime, string oldTaskName, string newTime, string newTaskName, int employeeID, string date)
        {
            string query = "UPDATE schedule SET time = @newTime , task_name = @newTaskName WHERE schedule_id = (SELECT schedule_id WHERE employee_id = @employeeID && date = @date && time = @oldTime && task_name = @oldTaskName )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { newTime, newTaskName, employeeID, date, oldTime, oldTaskName }) > 0;
        }
    }
}
