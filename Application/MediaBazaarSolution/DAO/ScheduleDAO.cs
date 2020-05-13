using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool AddEmployeeToShift(int employee_id, int work_day_id)
        {
            string query = "INSERT INTO schedule(employee_id, work_day_id)" +
                           "VALUES(employee_id, work_day_id);";

            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool RemoveEmployeeFromShift(int employee_id)
        {
            string query = "DELETE FROM schedule WHERE employee_id = " + employee_id;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

    }
}
