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
            string query = "SELECT s.employee_id, e.first_name, e.last_name, s.date, s.start_time, s.end_time, s.task_name FROM schedule s INNER JOIN employee e ON s.employee_id = e.employee_id WHERE s.date = '" + date + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            
            foreach(DataRow row in data.Rows)
            {
                Schedule schedule = new Schedule(row);
                scheduleList.Add(schedule);
            }
            return scheduleList;
        }

        public bool AddSchedule(int employeeID, string date, string start_time, string end_time, string taskName)
        {
            string query = "INSERT INTO schedule (employee_id, date, start_time, end_time, task_name) VALUES( @employeeID , @date , @start_time , @end_time , @taskName )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {employeeID, date, start_time, end_time, taskName}) > 0;
        }

        public bool DeleteSchedule(int employeeID, string date, string startTime)
        {
            string query = "DELETE FROM schedule WHERE schedule_id = (SELECT schedule_id FROM schedule WHERE employee_id = @employeeID && date = @date && start_time = @_time )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { employeeID, date, startTime }) > 0;
        }

        public bool GetSchedule(int employeeID, string date, string startTime, string endTime, string taskName)
        {
            string query = "SELECT * FROM schedule WHERE employee_id = @employeeID && date = @date && start_time = @startTime && end_time = @endTime && task_name = @taskName ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { employeeID, date, startTime, endTime, taskName });
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSchedule(string oldStartTime, string newStartTime, string newEndTime, string newTaskName, int employeeID, string date)
        {
            string query = "UPDATE schedule SET start_time = @newStartTime , end_time = @newEndTime , task_name = @newTaskName WHERE schedule_id = (SELECT schedule_id WHERE employee_id = @employeeID && date = @date && start_time = @oldStartTime )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { newStartTime, newEndTime, newTaskName, employeeID, date, oldStartTime}) > 0;
        }

        public int countAllScheduleOfTheDate(string date)
        {
            string query = "SELECT * FROM schedule WHERE date = " + "'" + date + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count;
        }

        public List<int> GetEmployeesIDOnShiftByDateAndStartTime(string date, string start_time)
        {
            string query = "SELECT employee_id FROM schedule WHERE date = @date && start_time = @start_time";
            List<int> idList = new List<int>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { date, start_time });

            foreach (DataRow row in data.Rows)
            {
                
                idList.Add((int)row["employee_id"]);
            }

            return idList;
        }
    }
}
