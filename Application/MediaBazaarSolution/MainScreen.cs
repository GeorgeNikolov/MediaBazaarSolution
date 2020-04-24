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
            depot.LoadItemCategoriesInComboBox(cbxItemCategory);
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

                    depot.EditSelectedItem(dgvDepot, currentColumnIndex, currentItemId, currentCellValue, this.oldCellValue);
                }
            }
            else
            {
                dgvDepot.CurrentCell.Value = oldCellValue;
            }
        }
        private void dgvDepot_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //Saves the old value of the cell that is currently being edited. 
            oldCellValue = dgvDepot.CurrentCell.Value;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string idAsString = tbxSearchItemById.Text;

            //Checks whether the category checkbox is unset or equal to "None".
            bool isCategoryWantedInvalid = false;
            if (cbxItemCategory.SelectedIndex == -1 || cbxItemCategory.SelectedIndex == 0)
            {
                isCategoryWantedInvalid = true;
            }

            if ((String.IsNullOrEmpty(idAsString) || String.IsNullOrWhiteSpace(idAsString)) && isCategoryWantedInvalid)
            {
                MessageBox.Show("Enter a valid ID or select a valid category!", "Value not selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                depot.LoadDepot(dgvDepot);
            }
            else if(String.IsNullOrEmpty(idAsString) || String.IsNullOrWhiteSpace(idAsString))
            {
                string categoryWanted = cbxItemCategory.SelectedItem.ToString();
                depot.SearchItemByCategory(categoryWanted, dgvDepot);
            }
            else
            {
                depot.SearchItemById(idAsString, dgvDepot);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete that item?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                depot.DeleteSelectedItem(dgvDepot);
            }
        }
        private void cbxItemCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            //Allows the search of a product only by ID or by Category but not both.
            if(cbxItemCategory.SelectedIndex != -1 && cbxItemCategory.SelectedIndex != 0)
            {
                tbxSearchItemById.ReadOnly = true;
                tbxSearchItemById.Text = null;
            }
            else
            {
                tbxSearchItemById.ReadOnly = false;
            }
        }
    }
}
