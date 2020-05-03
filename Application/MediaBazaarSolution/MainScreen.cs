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
using MediaBazaarSolution.DAO;
using MediaBazaarSolution.DTO;

namespace MediaBazaarSolution
{
    public partial class MainScreen : Form
    {
        private ScheduleForm scheduleForm;
        private DepotAddForm depotAddForm;
        internal List<int> indecis;
        internal List<string> categories;
        private int tempID;

        private object oldCellValue;

        public MainScreen()
        {
            InitializeComponent();

            scheduleForm = new ScheduleForm();
            depotAddForm = new DepotAddForm(this);

            indecis = new List<int>();
            categories = new List<string>();
            LoadAllItems();
            LoadItemCategoriesInComboBox();
        }

        #region Methods 

        public void LoadAll()
        {
            LoadAllItems();
            LoadItemCategoriesInComboBox();
        }
        private void LoadAllItems()
        {
            //Load all available items in the database to the depot datagridview
            List<Item> itemList = ItemDAO.Instance.LoadAllItems();
            dgvDepot.DataSource = itemList;

            indecis.Clear();
            categories.Clear();

            foreach (Item item in itemList)
            {
                if (!indecis.Contains(item.ID))
                {
                    indecis.Add(item.ID);
                }
                if (!categories.Contains(item.Category))
                {
                    categories.Add(item.Category);
                }
            }

        }

        private void LoadItemCategoriesInComboBox()
        {
            //Load the available categories to the combobox in the depot tab
            //By default the selected index will be 0
            cbxItemCategory.DataSource = ItemCategoryDAO.Instance.getAllCategory();
            cbxItemCategory.DisplayMember = "name";
            cbxItemCategory.SelectedIndex = 0;
        }

        private void SearchItemByCategory(string categoryWanted)
        {
            dgvDepot.DataSource = ItemDAO.Instance.SearchItemByCategory(categoryWanted);
        }

        public void SearchItemByID(string idAsString)
        {
            bool IsValidWantedId = int.TryParse(idAsString, out int wantedId);

            if (!IsValidWantedId)
            {
                MessageBox.Show("The ID you entered is not an integer!", "ID must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!indecis.Contains(int.Parse(idAsString)))
            {
                MessageBox.Show("There is no item in the depot with the entered ID!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvDepot.DataSource = ItemDAO.Instance.SearchItemByID(idAsString);
            }
        }

        #endregion

        #region Events
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
            bool queryIsSuccess = false;

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

                    //depot.EditSelectedItem(dgvDepot, currentColumnIndex, currentItemId, currentCellValue, this.oldCellValue)
                    if (currentColumnIndex == 1)
                    {
                        queryIsSuccess = ItemDAO.Instance.UpdateItemName(currentItemId, currentCellValue.ToString());
                    } 
                    else if (currentColumnIndex == 2)
                    {
                        if (!categories.Contains(currentCellValue.ToString()))
                        {
                            MessageBox.Show("No such category!", "Invalid category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldCellValue;
                            return;
                        }
                        else
                        {
                            queryIsSuccess = ItemDAO.Instance.UpdateItemCategory(currentItemId, currentCellValue.ToString());
                        }
                    }
                    else if (currentColumnIndex == 3)
                    {
                        bool IsValidAmount = int.TryParse(currentCellValue.ToString(), out int itemInStock);


                        if (!IsValidAmount)
                        {
                            MessageBox.Show("The amount you entered is not an integer!", "Amount must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldCellValue;
                            return;
                        }
                        else if (itemInStock <= 0)
                        {
                            MessageBox.Show("The amount must be positive!", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldCellValue;
                            return;
                        }
                        else
                        {
                            queryIsSuccess = ItemDAO.Instance.UpdateItemAmount(currentItemId, (int)currentCellValue);
                        }
                    } else if (currentColumnIndex == 4)
                    {
                        bool IsValidPrice = decimal.TryParse(currentCellValue.ToString(), out decimal price);

                        if (!IsValidPrice)
                        {
                            MessageBox.Show("The price you entered is not an integer!", "Price must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldCellValue;
                            return;
                        }
                        else if (price <= 0)
                        {
                            MessageBox.Show("The amount must be positive!", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldCellValue;
                            return;
                        }
                        else
                        {
                            queryIsSuccess = ItemDAO.Instance.UpdateItemPrice(currentItemId, Convert.ToDecimal(currentCellValue));
                        }
                    }
                }
            }
            else
            {
                dgvDepot.CurrentCell.Value = oldCellValue;
                return;
            }

            if (queryIsSuccess)
            {
                MessageBox.Show("Item successfully edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadAll();
            } else
            {
                MessageBox.Show("Item not edited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            else if (String.IsNullOrEmpty(idAsString) || String.IsNullOrWhiteSpace(idAsString))
            {
                string categoryWanted = (cbxItemCategory.SelectedItem as Category).Name;

                SearchItemByCategory(categoryWanted);
            }
            else
            {
                SearchItemByID(idAsString);
            }
            cbxItemCategory.SelectedIndex = 0;

        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            //Delete the item based on the ID retrieved from the tempID variable
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete that item?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (ItemDAO.Instance.DeleteSelectedItem(tempID))
                {
                    MessageBox.Show("Item successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LoadAll();
                } else
                {
                    MessageBox.Show("Item not deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }
        private void cbxItemCategory_SelectedValueChanged(object sender, EventArgs e)
        {

            //Allows the search of a product only by ID or by Category but not both.
            if (cbxItemCategory.SelectedIndex != -1 && cbxItemCategory.SelectedIndex != 0)
            {
                tbxSearchItemById.ReadOnly = true;
                tbxSearchItemById.Text = null;
            }
            else
            {
                tbxSearchItemById.ReadOnly = false;
            }

        }


        private void dgvDepot_SelectionChanged(object sender, EventArgs e)
        {
            //Get the ID of the selected row object in the depot datagridview and assign it to the tempID variable
            if (dgvDepot.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvDepot.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvDepot.Rows[selectedRowIndex];
                tempID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
            
        }



        #endregion


    }
}
