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
        private EmployeeAddForm employeeAddForm;
        internal List<int> indecis;
        internal List<string> categories;
        internal List<string> employees;
        
        private int itemID;
        private int employeeID;

        private object oldItemCellValue;
        private object oldEmployeeCellValue;

        private string userFirstName;

        public MainScreen(string userFirstName)
        {
            InitializeComponent();

            scheduleForm = new ScheduleForm();
            depotAddForm = new DepotAddForm(this);
            employeeAddForm = new EmployeeAddForm(this);

            indecis = new List<int>();
            categories = new List<string>();
            employees = new List<string>();
            LoadAll();

            this.userFirstName = userFirstName;
            lblWelcome.Text = "Welcome " + userFirstName + "!";
        }

        #region Methods 

        public void LoadAll()
        {
            LoadAllItems();
            LoadItemCategoriesInComboBox();
            LoadAllEmployees();
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

        private void LoadAllEmployees()
        {

            List<Employee> employeeList = EmployeeDAO.Instance.GetAllEmployees();
            dgvEmployees.DataSource = employeeList;

            employees.Clear();

            foreach (Employee employee in employeeList)
            {
                if (!employees.Contains(employee.LastName))
                {
                    employees.Add(employee.LastName);
                }       
            }
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

        private void dgvDepot_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //Saves the old value of the cell that is currently being edited. 
            oldItemCellValue = dgvDepot.CurrentCell.Value;
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
                if (ItemDAO.Instance.DeleteSelectedItem(itemID))
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
                itemID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
            
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            employeeAddForm.Show();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete that employee?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (EmployeeDAO.Instance.DeleteEmployee(employeeID))
                {
                    MessageBox.Show("Employee successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LoadAll();
                }
                else
                {
                    MessageBox.Show("Employee not deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        { 
            if (dgvEmployees.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvEmployees.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEmployees.Rows[selectedRowIndex];
                employeeID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            string name = tbxSearchEmployeeByName.Text;
            bool isNameNotValid = int.TryParse(name, out int nameAsInt);

            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter An Invalid Name!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (isNameNotValid)
            {
                MessageBox.Show("The name should not be an integer!", "Invalid name type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!employees.Contains(name))
            {
                MessageBox.Show("There is no matching for the employee name", "No matching result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvEmployees.DataSource = EmployeeDAO.Instance.SearchEmployeeByLastName(name);
            }
            
        }

        private void btnReloadEmployees_Click(object sender, EventArgs e)
        {
            LoadAllEmployees();
        }


        private void btnReloadItems_Click(object sender, EventArgs e)
        {
            LoadAllItems();
        }


        private void dgvDepot_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object currentItemCellValue = dgvDepot.CurrentCell.Value;

            bool queryIsSuccess = false;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit that item?", "Edit Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (currentItemCellValue == null)
                {
                    MessageBox.Show("Enter a valid parameter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDepot.CurrentCell.Value = oldItemCellValue;
                }
                else
                {
                    currentItemCellValue = dgvDepot.CurrentCell.Value;
                    int currentColumnIndex = dgvDepot.CurrentCell.ColumnIndex;
                    int currentItemId = Convert.ToInt32(dgvDepot.Rows[e.RowIndex].Cells[0].Value);

                    //depot.EditSelectedItem(dgvDepot, currentColumnIndex, currentItemId, currentCellValue, this.oldCellValue)
                    if (currentColumnIndex == 1)
                    {
                        queryIsSuccess = ItemDAO.Instance.UpdateItemName(currentItemId, currentItemCellValue.ToString());
                    }
                    else if (currentColumnIndex == 2)
                    {
                        if (!categories.Contains(currentItemCellValue.ToString()))
                        {
                            MessageBox.Show("No such category!", "Invalid category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldItemCellValue;
                            return;
                        }
                        else
                        {
                            queryIsSuccess = ItemDAO.Instance.UpdateItemCategory(currentItemId, currentItemCellValue.ToString());
                        }
                    }
                    else if (currentColumnIndex == 3)
                    {
                        bool IsValidAmount = int.TryParse(currentItemCellValue.ToString(), out int itemInStock);


                        if (!IsValidAmount)
                        {
                            MessageBox.Show("The amount you entered is not an integer!", "Amount must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldItemCellValue;
                            return;
                        }
                        else if (itemInStock <= 0)
                        {
                            MessageBox.Show("The amount must be positive!", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldItemCellValue;
                            return;
                        }
                        else
                        {
                            queryIsSuccess = ItemDAO.Instance.UpdateItemAmount(currentItemId, (int)currentItemCellValue);
                        }
                    }
                    else if (currentColumnIndex == 4)
                    {
                        bool IsValidPrice = decimal.TryParse(currentItemCellValue.ToString(), out decimal price);

                        if (!IsValidPrice)
                        {
                            MessageBox.Show("The price you entered is not an integer!", "Price must be a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldItemCellValue;
                            return;
                        }
                        else if (price <= 0)
                        {
                            MessageBox.Show("The amount must be positive!", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDepot.CurrentCell.Value = oldItemCellValue;
                            return;
                        }
                        else
                        {
                            queryIsSuccess = ItemDAO.Instance.UpdateItemPrice(currentItemId, Convert.ToDecimal(currentItemCellValue));
                        }
                    }
                }
            }
            else
            {
                dgvDepot.CurrentCell.Value = oldItemCellValue;
                return;
            }

            if (queryIsSuccess)
            {
                MessageBox.Show("Item successfully edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadAll();
            }
            else
            {
                MessageBox.Show("Item not edited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployees_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldEmployeeCellValue = dgvEmployees.CurrentCell.Value;
        }


        private void dgvEmployees_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object currentEmployeeCellValue = dgvEmployees.CurrentCell.Value;

            bool queryIsSuccess = false;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit that employee?", "Edit Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (currentEmployeeCellValue == null)
                {
                    MessageBox.Show("Enter a valid parameter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvEmployees.CurrentCell.Value = oldEmployeeCellValue;
                }
                else
                {
                    currentEmployeeCellValue = dgvEmployees.CurrentCell.Value;
                    int currentColumnIndex = dgvEmployees.CurrentCell.ColumnIndex;
                    int currentEmployeeId = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells[0].Value);

                    if (currentColumnIndex == 1)
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeFirstName(currentEmployeeId, currentEmployeeCellValue.ToString());
                    }
                    else if (currentColumnIndex == 2)
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeLastName(currentEmployeeId, currentEmployeeCellValue.ToString());
                    }
                    else if (currentColumnIndex == 3)
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeUsername(currentEmployeeId, currentEmployeeCellValue.ToString());
                    }
                    else if (currentColumnIndex == 4)
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeEmail(currentEmployeeId, currentEmployeeCellValue.ToString());
                    } else if (currentColumnIndex == 5)
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeePhone(currentEmployeeId, currentEmployeeCellValue.ToString());
                    }
                    else if (currentColumnIndex == 6)
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeHourlyWage(currentEmployeeId, Convert.ToDouble(currentEmployeeCellValue));
                    }
                    else if (currentColumnIndex == 7)
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeType(currentEmployeeId, currentEmployeeCellValue.ToString());
                    }
                    else if (currentColumnIndex == 8)
                    {
                        queryIsSuccess = EmployeeDAO.Instance.UpdateEmployeeAddress(currentEmployeeId, currentEmployeeCellValue.ToString());
                    }
                }
            }
            else
            {
                dgvEmployees.CurrentCell.Value = oldEmployeeCellValue;
                return;
            }

            if (queryIsSuccess)
            {
                MessageBox.Show("Employee successfully edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadAll();
            }
            else
            {
                MessageBox.Show("Employee not edited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
