using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MediaBazaarSolution.Helper;
using MediaBazaarSolution.DTO;

namespace MediaBazaarSolution.DAO
{
    class AutoSchedulerDAO
    {
        private static AutoSchedulerDAO instance;

        public static AutoSchedulerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AutoSchedulerDAO();
                }

                return AutoSchedulerDAO.instance;
            }

            private set
            {
                AutoSchedulerDAO.instance = value;
            }
        }

        private AutoSchedulerDAO() { }

        public List<Employee> GetNecessaryInfo(int managerID)
        {
            List<Employee> employeeList = new List<Employee>();
            string query = "SELECT employee_id, NoGoSchedule, ContractedHours FROM employee WHERE employee_type = 'employee' AND manager_id = @managerID";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { managerID });

            foreach (DataRow row in data.Rows)
            {
                Employee employee = new Employee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }

        
    }
}
