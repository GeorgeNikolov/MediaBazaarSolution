using MediaBazaarSolution.DAO;
using MediaBazaarSolution.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSolution
{
    public partial class ScheduleForm : Form
    {
        private int workDayID;
        private MainScreen parentForm;
        public ScheduleForm(MainScreen parent, int workDayID)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.workDayID = workDayID;
            FillAvailableWorkers();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveWorker_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {

        }

        private void FillAvailableWorkers()
        {
            List<Employee> employeeList = EmployeeDAO.Instance.GetAllEmployeesOnly();
            lbxAvailableWorkers.DataSource = employeeList;
            lbxAvailableWorkers.DisplayMember = "firstName" + " " + "lastName";
        }
    }
}
