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
        public MainScreen()
        {
            InitializeComponent();
            scheduleForm = new ScheduleForm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            scheduleForm.Show();
        }
    }
}
