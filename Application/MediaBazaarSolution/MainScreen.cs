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
        private DepotAddForm dpAddForm;
        private DepotEditForm dpEdit;
        private ScheduleForm scheduleForm;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDepot_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //For testing purposes.
            dpEdit = new DepotEditForm();

            dpEdit.Visible = true;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //For testing purposes
            dpAddForm = new DepotAddForm();

            dpAddForm.Visible = true;
        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            scheduleForm = new ScheduleForm();

            scheduleForm.Show();
        }
    }
}
