using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private Depot depot;
        private object oldCellValue;

        public Depot Depot
        {
            get
            {
                return this.depot;
            }
        }
        public MainScreen()
        {
            InitializeComponent();

            scheduleForm = new ScheduleForm();
            depotAddForm = new DepotAddForm(this, dgvDepot);

            depot = new Depot();
            depot.LoadDepot(dgvDepot);
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
            object currentCellValue = dgvDepot.CurrentCell.Value;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit that item?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if(dgvDepot.CurrentCell.Value == null)
                {
                    MessageBox.Show("Enter a valid parameter!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDepot.CurrentCell.Value = oldCellValue;
                }
                else
                {
                    currentCellValue = dgvDepot.CurrentCell.Value;
                    int currentColumnIndex = dgvDepot.CurrentCell.ColumnIndex;
                    int currentItemId = Convert.ToInt32(dgvDepot.Rows[e.RowIndex].Cells[0].Value);

                    depot.EditSelectedItem(dgvDepot, currentColumnIndex, currentItemId, currentCellValue,this.oldCellValue);
                }
                
            }
            else
            {
                dgvDepot.CurrentCell.Value = oldCellValue;
            }
        }
        private void dgvDepot_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldCellValue = dgvDepot.CurrentCell.Value;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string IdAsString = tbxSearchItemById.Text;
            depot.SearchItemById(IdAsString, dgvDepot);
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete that item?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                depot.DeleteSelectedItem(dgvDepot);
            }
        }
    }
}
