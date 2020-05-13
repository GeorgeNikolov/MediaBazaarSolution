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
        private List<Employee> availableEmployees;
        public ScheduleForm(MainScreen parent, int workDayID)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.workDayID = workDayID;
            
            FillAvailableWorkers();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            if (lbxAvailableWorkers.SelectedIndex < 0)
            {
                MessageBox.Show("Please specify a worker to select!", "Add worker warnig!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else
            {
                int employeeID = (lbxAvailableWorkers.SelectedItem as Employee).ID;

                if (ScheduleDAO.Instance.)
                {
                    foreach(Employee employee in availableEmployees )
                    {
                        if (employee.ID == employeeID)
                        {
                            lbxWorkersOnShift.Items.Add(employee);
                        }
                    }
                    MessageBox.Show("Successfully added the employee on shift!", "Successful Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else
                {
                    MessageBox.Show("Failed to add the employee on shift!", "Fail Notitfication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemoveWorker_Click(object sender, EventArgs e)
        {
            if (lbxWorkersOnShift.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a employee to be deleted from shift schedule!", "Remove Worker Notitfication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                int employeeID = (lbxWorkersOnShift.SelectedItem as Employee).ID;

                if (ScheduleDAO.Instance.)
                {
                    foreach(Employee employee in )
                }
            }
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {

        }

        private void FillAvailableWorkers()
        {
            availableEmployees = EmployeeDAO.Instance.GetAllEmployeesOnly();

            lbxAvailableWorkers.DataSource = availableEmployees;
        }
    }
}
