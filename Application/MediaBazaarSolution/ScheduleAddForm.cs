﻿using MediaBazaarSolution.DAO;
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
    public partial class ScheduleAddForm : Form
    {
        List<int> employeeIDList;
        Account user;
        private int employeeID;
        private string date;
        private string time;
        private string taskName;
        public ScheduleAddForm(string date, Account user)
        {
            InitializeComponent();
            employeeIDList = new List<int>();
            this.user = user;
            this.date = date;
            dtpStartTime.CustomFormat = "HH:mm";
            dtpEndTime.CustomFormat = "HH:mm";
            FillDgvSchedule();
            FillEmployeesComboBox();
            tbxDate.Text = date;
            AddScheduleBinding();

            if (dgvSchedule.Rows.Count > 0)
            { 
                cbbxEmployees.SelectedIndex = employeeIDList.IndexOf((int)dgvSchedule.Rows[0].Cells[0].Value);
            }
            if(user.Type.Equals(EmployeeType.Employee))
            {
                btnAddSchedule.Visible = false;
                btnDeleteSchedule.Visible = false;
                btnUpdateSchedule.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                cbbxEmployees.Visible = false;
                tbxDate.Visible = false;
                tbxTaskName.Visible = false;
                dtpEndTime.Visible = false;
                dtpStartTime.Visible = false;
            }

            this.Text = $"Schedule of {date.ToString()}";
        }

        public void FillDgvSchedule()
        {
            if (user.Type.Equals(EmployeeType.Administrator))
            {
                dgvSchedule.DataSource = ScheduleDAO.Instance.GetEmployeesOnShiftByDate(this.date);
            } else if (user.Type.Equals(EmployeeType.Manager))
            {
                dgvSchedule.DataSource = ScheduleDAO.Instance.GetScheduleByDateManager(this.date, this.user.ID);
            } else
            {
                dgvSchedule.DataSource = ScheduleDAO.Instance.GetScheduleByDateEmployee(this.date, this.user.ID);
            }
            
        }

        public void FillEmployeesComboBox()
        {
            employeeIDList.Clear();
            List<Employee> employeeList = EmployeeDAO.Instance.GetAllEmployeesOnly();
            cbbxEmployees.DataSource = employeeList;

            foreach(Employee e in employeeList)
            {
                employeeIDList.Add(e.ID);
            }
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            //Convert selected date as string to datetime datatype
            DateTime myDate = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //Create a new DateTime variable made up of selected date + selected time of day
            DateTime newDateTime = myDate.Date + dtpStartTime.Value.TimeOfDay;
            DateTime newEndTime = myDate.Date + dtpEndTime.Value.TimeOfDay;
            
            if(cbbxEmployees.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an employee to add", "Select Employee Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (newDateTime.AddMinutes(1) < DateTime.Now)
            {
                MessageBox.Show("You cannot choose a date in the past", "Choosing past date warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (String.IsNullOrEmpty(tbxTaskName.Text))
            {
                MessageBox.Show("Invalid task name!", "Task name error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (newDateTime > newEndTime)
            {
                MessageBox.Show("The end time cannot be earlier than the start time", "Invalid End time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int employeeID = (cbbxEmployees.SelectedItem as Employee).ID;
                string time = dtpStartTime.Value.ToString("HH:mm");
                string endTime = dtpEndTime.Value.ToString("HH:mm");
                string taskName = tbxTaskName.Text;
                if (ScheduleDAO.Instance.GetSchedule(employeeID, date, time, endTime, taskName))
                {
                    MessageBox.Show("The same schedule item has been put into the list!", "Duplicate schedule item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(ScheduleDAO.Instance.AddSchedule(employeeID, date, time, endTime, taskName))
                {
                    MessageBox.Show("Successfully added the employee on shift !", "Successful added schedule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    FillDgvSchedule();
                } else
                {
                    MessageBox.Show("Fail to add the employee on shift !", "Fail to add schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            FillDgvSchedule();
        }

        private void AddScheduleBinding()
        {
            dtpStartTime.DataBindings.Add(new Binding("Value", dgvSchedule.DataSource, "StartTime"));
            tbxTaskName.DataBindings.Add(new Binding("Text", dgvSchedule.DataSource, "TaskName"));
        }

        private void dgvSchedule_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count != 0)
            {
                int employeeID = (int)dgvSchedule.SelectedCells[0].Value;

                cbbxEmployees.SelectedIndex = employeeIDList.IndexOf(employeeID);
            }
            
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (ScheduleDAO.Instance.DeleteSchedule(employeeID, date, time))
            {
                MessageBox.Show("Successfully deleted the schedule item", "Successful deletion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FillDgvSchedule();
            }
        }

        private void dgvSchedule_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgvSchedule.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvSchedule.Rows[selectedRowIndex];
                employeeID = Convert.ToInt32(selectedRow.Cells["EmployeeID"].Value);
                time = selectedRow.Cells["StartTime"].Value.ToString();
                taskName = selectedRow.Cells["TaskName"].Value.ToString();
            }
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            string oldTime = this.time;
         
            string oldTaskName = this.taskName;
            string newTime = dtpStartTime.Value.ToString("HH:mm");
            string newEndTime = dtpStartTime.Value.AddHours(4).ToString("HH:mm");
            string newTaskName = tbxTaskName.Text;

            if (employeeID != (cbbxEmployees.SelectedItem as Employee).ID)
            {
                MessageBox.Show("The selected employeeID does not match!", "Failed updation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ScheduleDAO.Instance.UpdateSchedule(oldTime, newTime, newEndTime, newTaskName, employeeID, date))
            {
                MessageBox.Show("Succesfully updated the schedule!", "Successful updation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDgvSchedule();
            } else
            {
                MessageBox.Show("Fail to update the schedule!", "Failed updation", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
