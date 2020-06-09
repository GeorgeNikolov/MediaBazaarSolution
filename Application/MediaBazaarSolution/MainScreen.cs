﻿using MySql.Data.MySqlClient;
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
using LiveCharts;
using LiveCharts.Wpf;

namespace MediaBazaarSolution
{
    public partial class MainScreen : Form
    {
        private DepotAddForm depotAddForm;
        private EmployeeAddForm employeeAddForm;
        private ScheduleAddForm scheduleAddForm;
        private EmployeeEditForm employeeEditForm;

        internal List<int> indecis;
        internal List<string> categories;
        internal List<string> employees;
        private  List<TabPage> tabPages;
        
        private int itemID;
        private int employeeID;

        private object oldItemCellValue;
        private object oldEmployeeCellValue;

        private string userFirstName;
        private string userType;
        private int managerId;

        //This 2-dimensional list will hold 6x7 button references so we can change the corresponding date in each button depending on the current month of date
        private List<List<Button>> matrix;

        List<string> dayOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public string UserFirstName { 
            get 
            {
                return this.userFirstName;    
            }
        }
        public string UserType { 
            get
            {
                return this.userType;
            }
        }
        public int ManagerId
        {
            get
            {
                return this.managerId;
            }
        }

        public List<List<Button>> Matrix
        {
            get { return this.matrix; }
            private set { this.matrix = value; }
        }

        public MainScreen(string userFirstName,string userType, int managerId)
        {
            InitializeComponent();

            //scheduleForm = new ScheduleForm();

            indecis = new List<int>();
            categories = new List<string>();
            employees = new List<string>();
            tabPages = new List<TabPage>();
            LoadAll();
            

            this.userFirstName = userFirstName;
            this.userType = userType;
            this.managerId = managerId;
            //Creating the DepotAddForm here ensures that the username will be passed from the parent form to the child form.
            depotAddForm = new DepotAddForm(this);

            lblWelcome.Text = "Welcome " + userFirstName + "!";


            // Dummy Data for presentation Week 12
            SeriesCollection series = new SeriesCollection();
            string[] categoryNames = new string[6] { "Computer", "Home Appliances", "Television", "Camera", "Mobile", "Gaming" };
            int[] categoryNumbers = new int[6] { 50, 30, 57, 134, 264, 80 };
            for(int i = 0; i < 6; i++) {
                series.Add(new PieSeries() { Title = categoryNames[i], Values = new ChartValues<int> { categoryNumbers[i] }, DataLabels = true, LabelPoint = label });
            }
            SalesPieChart.Series = series;
            SalesPieChart.Text = "Category Sales";
            SalesPieChart.LegendLocation = LegendLocation.Right;
            
            SalesPieChart.Refresh();
        }

        #region Methods 

        public void LoadAll()
        {
            LoadAllItems();
            LoadItemCategoriesInComboBox();
            LoadMatrixSchedule();
            //LoadTabPages();
            
        }
        private void LoadAllItems()
        {
            //Load all available items in the database to the depot datagridview
            List<Item> itemList = ItemDAO.Instance.LoadAllItems();
            dgvDepot.DataSource = itemList;
            dgvDepot.ReadOnly = true;

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

        public void LoadAllEmployees()
        {

            List<Employee> employeeList = EmployeeDAO.Instance.GetAllEmployees();
            dgvEmployees.DataSource = employeeList;
            dgvEmployees.ReadOnly = true;

            employees.Clear();

            foreach (Employee employee in employeeList)
            {
                if (!employees.Contains(employee.LastName))
                {
                    employees.Add(employee.LastName);
                }       
            }
        }
        public void LoadAllDepotWorkers()
        {
            List<Employee> employeeList = EmployeeDAO.Instance.GetAllDepotWorkers(this.ManagerId);
            dgvEmployees.DataSource = employeeList;
            dgvEmployees.ReadOnly = true;

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
            employeeAddForm = new EmployeeAddForm(this);

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
            MainScreen_Load(this, e);
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

        

        #endregion


        // Dummy methods for statistics page
        Func<ChartPoint, string> label = chartpoint => String.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        const int daysInWeek = 7;
        const int numOfLines = 6;
        private void LoadMatrixSchedule()
        {
            
            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-6, 0) };
            Matrix = new List<List<Button>>();

            for (int i = 0; i < numOfLines; i++)
            {
                Matrix.Add(new List<Button>());
                for(int j = 0; j < daysInWeek; j++)
                {
                    Button btn = new Button() { Width = 137, Height = 73 };
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width + 6, oldBtn.Location.Y);
                    
                    pnlMatrix.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    oldBtn = btn;
                }

                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-6, oldBtn.Location.Y + 74) };
            }

            SetDefaultDate();
        }

        private void AddNumberToMatrixButtons(DateTime date)
        {
            ClearMatrix();

            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            int line = 0;
            for (int i = 1; i <= numberOfDaysInMonth(date); i++)
            {
                int column = dayOfWeek.IndexOf(useDate.DayOfWeek.ToString());

                Button btn = Matrix[line][column];
                btn.Text = i.ToString();
                btn.Tag = useDate.ToString("dd/MM/yyyy");
                //We need to deregister all existing events before registering a new one to make sure that only one event is registered
                btn.Click -= Btn_Click;
                btn.Click += Btn_Click;
                if (column == 6)
                {
                    line++;
                }

                //This will mark the selected date
                if (AreEqualDates(useDate, date))
                {
                    btn.BackColor = Color.Yellow;
                }

                //This will mark the current date
                if (AreEqualDates(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.Cyan;
                }

                //Check if there are already some existing schedules in the date
                if (ScheduleDAO.Instance.countAllScheduleOfTheDate(useDate.ToString("dd/MM/yyyy")) > 0)
                {
                    btn.BackColor = Color.LightYellow;
                }
                
                useDate = useDate.AddDays(1);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string date = (sender as Button).Tag.ToString();
            Button btn = sender as Button;
            
            //Pass the reference of the current button to the scheduleAddForm
            scheduleAddForm = new ScheduleAddForm(date, ref btn, this.UserType, this.ManagerId);
            scheduleAddForm.Show();
        }

        private void ClearMatrix()
        {
            for (int i = 0; i < numOfLines; i++)
            {
                for (int j = 0; j < daysInWeek; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.White;
                }
            }
        }

        private int numberOfDaysInMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 30;
            }
        }

        private bool AreEqualDates(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        private void SetDefaultDate()
        {
            dtpDate.Value = DateTime.Now;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberToMatrixButtons((sender as DateTimePicker).Value);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddMonths(1);
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddMonths(-1);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            if(String.Compare(this.UserType,"admin") == 0)
            {
                LoadAllEmployees();
            }
            else
            {
                LoadAllDepotWorkers();
            }
        }

        private void btnEmployeeEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvEmployees.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEmployees.Rows[selectedRowIndex];
                employeeEditForm = new EmployeeEditForm(this, selectedRow);
                employeeEditForm.Show();
            }
            else
            {
                MessageBox.Show("No employee selected!");
            }
            
        }
    }
}
