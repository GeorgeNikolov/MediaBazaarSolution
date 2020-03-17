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
    public partial class MainScreen : Form
    {
        private ScheduleForm scheduleForm;
        private DepotAddForm depotAddForm;
        public MainScreen()
        {
            InitializeComponent();
            scheduleForm = new ScheduleForm();
            depotAddForm = new DepotAddForm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            scheduleForm.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            depotAddForm.Show();
        }

        private void dgvDepot_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Do you really want to edit that value?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
