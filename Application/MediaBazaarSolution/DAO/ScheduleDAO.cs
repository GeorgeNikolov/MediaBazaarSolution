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
            string query = "INSERT INTO employee_work_day_int(employee_id, work_day_id)" +
                           "VALUES(@employee_id, @work_day_id);";

            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { employee_id , work_day_id }) > 0;
        }

        public bool RemoveEmployeeFromShift(int work_day_id)
        {
            string query = "DELETE FROM employee_work_day_int WHERE work_day_id = " + work_day_id;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

    }
}
