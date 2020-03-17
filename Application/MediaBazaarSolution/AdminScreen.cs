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
    public partial class AdminScreen : Form
    {
        Schedule schedule;
        Depot depot;
        Employees employees;
        Statistics statistics;
        public AdminScreen(/** User user */)
        {
            InitializeComponent();
            schedule = new Schedule();
            depot = new Depot();
            employees = new Employees();
            statistics = new Statistics();
            //WelcomeLbl.Text = user.Fname();
        }

        

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    // Schedule tab
                    break;
                case 1:
                    // Employees tab
                    break;
                case 2:
                    // Depot tab
                    break;
                case 3:
                    // Statistics tab
                    break;
            }
        }

        private void EmployeeSelected(object sender, DataGridViewCellEventArgs e)
        {
            employees.EmployeeSelected();
        }
    }
}
