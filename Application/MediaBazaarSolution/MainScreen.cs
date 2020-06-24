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
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.VisualBasic;
using System.Collections.Concurrent;
using Org.BouncyCastle.Asn1.IsisMtt;
using Renci.SshNet.Messages.Authentication;
using MediaBazaarSolution.Scheduling;
using GraphQL;
using System.Runtime.CompilerServices;

namespace MediaBazaarSolution
{
    public partial class MainScreen : Form
    {
        private bool sortAlertsByPriority = false;
        private bool showCompletedOrders = false;       

        private DepotAddForm depotAddForm;
        private EmployeeAddForm employeeAddForm;
        private ScheduleAddForm scheduleAddForm;
        private StatisticsScreen statisticsScreen;
        internal List<int> indecis;
        internal List<string> categories;
        internal List<string> employees;
        internal List<Alert> alerts;
        internal List<Order> orders;


        internal List<Mail> allMails;

        private int itemID;
        private int employeeID;
        private int adminID;

        private object oldItemCellValue;
        private object oldEmployeeCellValue;

        private string userFirstName;
        private Account user;

        //Control which is the current tab in the mail tab
        private int currentTab = 0;

        //This 2-dimensional list will hold 6x7 button references so we can change the corresponding date in each button depending on the current month of date
        private List<List<Button>> matrix;

        List<string> dayOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        List<string> possibleOrderStatuses = new List<string> { "complete", "incomplete", "pending", "cancelled" };

        public string UserFirstName
        {
            get
            {
                return this.userFirstName;
            }
        }

        public List<List<Button>> Matrix
        {
            get { return this.matrix; }
            private set { this.matrix = value; }
        }

        public MainScreen(Account user)
        {
            InitializeComponent();

            Alert.PriorityMargin = 1000;
            //scheduleForm = new ScheduleForm();

            indecis = new List<int>();
            categories = new List<string>();
            employees = new List<string>();
            allMails = new List<Mail>();
            alerts = new List<Alert>();
            orders = new List<Order>();
            statisticsScreen = new StatisticsScreen();

            this.user = user;
            LoadAll();

            //YAxisCB.SelectedIndex = 0;
            //XAxisCB.SelectedIndex = 0;
            cbxStatus.SelectedIndex = 0;

            this.userFirstName = user.FirstName;
            this.adminID = user.ID;
            //Creating the DepotAddForm here ensures that the username will be passed from the parent form to the child form.
            depotAddForm = new DepotAddForm(this);

            lblWelcome.Text = "Welcome " + userFirstName + "!";


            //
            // Show/Hide things based on role
            //
            if (user.Type.Equals(EmployeeType.Administrator))
            {
                // Administrator view


            }
            else if (user.Type.Equals(EmployeeType.Manager))
            {
                // Manager view


            }
            else
            {
                // Employee view

                Tabs.TabPages.RemoveByKey("EmployeesTab");
                Tabs.TabPages.RemoveByKey("StatisticsTab");
                Tabs.TabPages.RemoveByKey("OrdersTab");
                AutoScheduleGeneratorBtn.Visible = false;
                btnAddProduct.Visible = false;
                btnDeleteItem.Visible = false;
                EmployeeEditBtn.Visible = false;
            }

            //Update the mail list
            UpdateAllMailsList();

            //By default all the received mails will be displayed
            FillReceivedMails();

        }

        #region Methods 

        public void LoadAll()
        {
            LoadAllItems();
            LoadItemCategoriesInComboBox();
            if(!user.Type.Equals(EmployeeType.Employee))
            {
                LoadAllEmployees();
                LoadAlerts();
                LoadOrders();
                LoadStatisticsPage();
            }
            LoadMatrixSchedule();
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

        private void LoadStatisticsPage()
        {
            // Load all availible items in the database to the statistics Item datagridview
            List<Item> itemList = ItemDAO.Instance.LoadAllItems();
            StProductDGV.DataSource = itemList;

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



            LoadPieChartData();
            LoadPieChart();
            LoadGraphChartData();
            LoadGraphChart();
            LoadMSPC();
        }
        Func<ChartPoint, string> MSPieLabel = chartpoint => String.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        Func<ChartPoint, string> PieLabel = chartpoint => String.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void LoadPieChartData()
        {
            // Updates the combobox on the statistics page
            statisticsScreen.UpdatePiechart();
            PiechartCB.Items.Clear();
            PiechartCB.Items.Add("All Items");
            PiechartCB.SelectedIndex = 0;
            PiechartCB.Items.AddRange(statisticsScreen.GetCategories());

            MissedShiftsCB.Items.Clear();
            MissedShiftsCB.Items.Add("All managers");
            MissedShiftsCB.SelectedIndex = 0;
            List<int> managerIDs = new List<int>();
            managerIDs.AddRange(statisticsScreen.GetManagers());
            foreach(int ID in managerIDs)
            {
                MissedShiftsCB.Items.Add(ID.ToString());
            }
        }

        private void LoadMSPC()
        {
            // Loads the missed shifts pie chart
            string[] employees;
            SeriesCollection series = new SeriesCollection();
            List<Employee> significantEmployees;

            if (MissedShiftsCB.SelectedItem.ToString().Equals("All managers"))
            {
                employees = statisticsScreen.GetManagersNames();
                significantEmployees = EmployeeDAO.Instance.GetAllManagers();
            }
            else
            {
                significantEmployees = EmployeeDAO.Instance.GetAllEmployeesByManager(Convert.ToInt32(MissedShiftsCB.SelectedItem.ToString()));
                List<string> employeeNames = new List<string>();
                foreach (Employee employee in significantEmployees)
                {
                    string name = $"{employee.FirstName} {employee.LastName}";
                    employeeNames.Add(name);
                }
                employees = employeeNames.ToArray();
            }

            int[] values = new int[employees.Length];
            if(MissedShiftsCB.SelectedItem.ToString().Equals("All managers"))
            {
                for (int i = 0; i < employees.Length; i++)
                {

                    
                    values[i] = statisticsScreen.GetMissedShiftsByManager(significantEmployees[i].ID);

                }
            }
            else
            {
                for (int i = 0; i < employees.Length; i++)
                {

                    values[i] = significantEmployees[i].Missed_shifts;

                }
            }

            for (int i = 0; i < values.Length; i++)
            {
                series.Add(new PieSeries() { Title = employees[i].ToString(), Values = new ChartValues<int> { values[i] }, DataLabels = true, LabelPoint = PieLabel });
            }

            missedShiftsPC.Series = series;
            missedShiftsPC.Text = "Missed Shifts";
            missedShiftsPC.LegendLocation = LegendLocation.Right;
            missedShiftsPC.Refresh();
        }

        private void LoadPieChart()
        {
            
            String[] products;
            SeriesCollection series = new SeriesCollection();



            int categoryIndex = 0;
            int valueIndex = 0;
            int nameIndex = 0;


            // Check where the category and amount column are
            for (int i = 0; i < StProductDGV.Columns.Count; i++)
            {
                if (StProductDGV.Columns[i].Name.Equals("Category"))
                {
                    categoryIndex = i;
                }
                if (StProductDGV.Columns[i].Name.Equals("Amount"))
                {
                    valueIndex = i;
                }
                if (StProductDGV.Columns[i].Name.Equals("Name"))
                {
                    nameIndex = i;
                }
            }

            // Decide to show general data or to show category specific data
            if (PiechartCB.SelectedItem.ToString().Equals("All Items"))
            {
                products = statisticsScreen.GetCategories();
            }
            else
            {
                List<String> tempList = new List<string>();
                for (int i = 0; i < StProductDGV.Rows.Count; i++)
                {
                    if (StProductDGV.Rows[i].Cells[categoryIndex].Value.Equals(PiechartCB.SelectedItem.ToString()))
                    {
                        tempList.Add(StProductDGV.Rows[i].Cells[nameIndex].Value.ToString());
                    }
                }
                products = tempList.ToArray();
                categoryIndex = nameIndex;
            }
            int[] values = new int[products.Length];

            // Add values to the values array, for use in the graph generation
            for (int n = 0; n < StProductDGV.Rows.Count; n++)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (StProductDGV.Rows[n].Cells[categoryIndex].Value.Equals(products[i]))
                    {
                        values[i] += Convert.ToInt32(StProductDGV.Rows[n].Cells[valueIndex].Value);
                    }
                }
            }

            // Generate the series required for the graph
            for (int i = 0; i < values.Length; i++)
            {
                series.Add(new PieSeries() { Title = products[i].ToString(), Values = new ChartValues<int> { values[i] }, DataLabels = true, LabelPoint = PieLabel });
            }

            // Make the graph
            SalesPieChart.Series = series;
            SalesPieChart.Text = "Category Sales";
            SalesPieChart.LegendLocation = LegendLocation.Right;

            SalesPieChart.Refresh();

        }

        public Func<double, string> YFormatter { get; set; }
        public string[] Labels { get; set; }
        public SeriesCollection GraphSeries { get; set; }

        private void LoadGraphChartData()
        {
            List<Item> items = statisticsScreen.GetAllItems().ToList();
            List<string> names = new List<string>();
            
            
            XAxisCB.Items.Clear();
            if (PiechartCB.SelectedItem.ToString().Equals("All Items"))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    names.Add(items[i].Name);
                }
                
            } else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Category.Equals(PiechartCB.SelectedItem.ToString()))
                    {
                        names.Add(items[i].Name);
                    }
                }
            }
            XAxisCB.Items.AddRange(names.ToArray());
            XAxisCB.SelectedIndex = 0;



            YAxisCB.SelectedIndex = 0;
        }

        private void LoadGraphChart()
        {
            GraphSeries = new SeriesCollection();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Clear();
            if ( YAxisCB.Text.Equals("Stock History"))
            {
                // Stock History
                Item item = ItemDAO.Instance.SearchItembyName(XAxisCB.Text);
                int id = item.ID;
                    
                List<Stock_History> stock_histories = ItemDAO.Instance.GetStock_Histories(id);
                List<string> stock_history_labels = new List<string>();
                List<int> values = new List<int>();
                int currentAmount = item.Amount;
                for (int i = 0; i < stock_histories.Count; i++)
                {
                    currentAmount -= stock_histories[i].amount;
                }
                values.Add(currentAmount);
                string firstlabel;
                if (stock_history_labels.Count == 0)
                {
                    firstlabel = DateTime.Now.ToString("dd/MM");
                }
                else
                {
                    firstlabel = stock_history_labels[0];
                }
                stock_history_labels.Insert(0, firstlabel);
                for (int i = 0; i < stock_histories.Count; i++)
                {
                    stock_history_labels.Add(stock_histories[i].date.ToString("dd/MM"));
                    currentAmount += stock_histories[i].amount;
                    values.Add(currentAmount);
                    
                }
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Date",
                    Labels = stock_history_labels
                });

                GraphSeries.Add(
                new LineSeries
                {
                    Title = "Stock",
                    Values = new ChartValues<int>(values),
                    LineSmoothness = 0
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Revenue",
                    LabelFormatter = value => value.ToString()
                });
            }
            else
            {
                // Price History
                Item item = ItemDAO.Instance.SearchItembyName(XAxisCB.Text);
                int id = item.ID;

                List<Price_History> price_histories = ItemDAO.Instance.GetPrice_Histories(id);
                List<string> price_history_labels = new List<string>();
                List<double> values = new List<double>();
                double currentPrice = item.Price;
                for (int i = 0; i < price_histories.Count; i++)
                {
                    currentPrice -= price_histories[i].amount;
                }
                values.Add(currentPrice);
                string firstlabel;
                if (price_history_labels.Count == 0)
                {
                    firstlabel = DateTime.Now.ToString("dd/MM");
                }
                else
                {
                    firstlabel = price_history_labels[0];
                }
                price_history_labels.Insert(0, firstlabel);
                for (int i = 0; i < price_histories.Count; i++)
                {
                    price_history_labels.Add(price_histories[i].date.ToString("dd/MM"));
                    currentPrice += price_histories[i].amount;
                    values.Add(currentPrice);
                }
                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Date",
                    Labels = price_history_labels
                });

                GraphSeries.Add(
                new LineSeries
                {
                    Title = "Price",
                    Values = new ChartValues<double>(values),
                    LineSmoothness = 0,
                    
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Revenue",
                    LabelFormatter = value => value.ToString("C")
                });
            }
            
            
            cartesianChart1.LegendLocation = LegendLocation.Right;



            YFormatter = null;
            YFormatter = value => value.ToString();

            
            
            cartesianChart1.Series = GraphSeries;

            


            //statisticsScreen.UpdateGraphchart();
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
            List<Employee> employeeList;
            if(user.Type.Equals(EmployeeType.Administrator))
            {
                employeeList = EmployeeDAO.Instance.GetAllEmployees();
                dgvEmployees.DataSource = employeeList;
            } else
            {
                employeeList = EmployeeDAO.Instance.GetAllEmployeesByManager(user.ID);
                employeeList.Add(EmployeeDAO.Instance.GetEmployeeByID(user.ID));
                dgvEmployees.DataSource = employeeList;
            }
            

            employees.Clear();

            foreach (Employee employee in employeeList)
            {
                if (!employees.Contains(employee.LastName))
                {
                    employees.Add(employee.LastName);
                }
            }
        }

        private void LoadAlerts()
        {
            alerts = RestockDAO.Instance.LoadAlerts(sortAlertsByPriority);
            if (alerts != null)
            {
                lbxAlerts.Items.Clear();
                foreach (Alert alert in alerts)
                {
                    lbxAlerts.Items.Add(alert.ToString());
                }
            }          
        }

        private void LoadOrders()
        {
            orders = RestockDAO.Instance.LoadOrders(showCompletedOrders);
            if(orders != null)
            {
                dgvOrders.DataSource = orders;
                dgvOrders.Columns[dgvOrders.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void AddSchedule()
        {
            // Method for making the schedule

            // Gets all the managers
            List<Employee> managers = EmployeeDAO.Instance.GetAllManagers();
            foreach (Employee manager in managers)
            {
                // Get the info for the schedule making
                List<Employee> employees = AutoSchedulerDAO.Instance.GetNecessaryInfo(manager.ID);
                List<ScheduleUsers> scheduleUsers = new List<ScheduleUsers>();

                // Convert to scheduleUsers format
                foreach (Employee employee in employees)
                {
                    bool[] NoGoBools = ConvertToBools(employee.NoGoSchedule);
                    scheduleUsers.Add(new ScheduleUsers(employee.ID, NoGoBools, (employee.ContractedHours / 4)));
                }

                bool[] availableTimes = new bool[21];
                DateTime today = DateTime.Today;
                int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
                DateTime nextMonday = today.AddDays(daysUntilMonday);
                List<Employee> managerEmployees = EmployeeDAO.Instance.GetAllEmployeesByManager(manager.ID);

                for (int i = 0; i < 21; i++)
                {
                    // TODO: change this to make it so it takes the availability of the actual schedule
                    availableTimes[i] = true;
                    int daysNeededToBeAdded = (i / 3);
                    int hoursNeededToBeAdded = 9 + (i % 3) * 4;
                    DateTime date = nextMonday.AddDays(daysNeededToBeAdded).AddHours(hoursNeededToBeAdded);
                    for (int n = 0; n < managerEmployees.Count; n++)
                    {
                        if (ScheduleDAO.Instance.GetEmployeesIDOnShiftByDateAndStartTime(date.Date.ToString("dd/MM/yyyy"), date.ToString("HH:mm")).Contains(managerEmployees[n].ID))
                        {
                            availableTimes[i] = false;
                        }
                    }
                }
                // Make the schedule
                SchedulingSystem schedulingSystem = new SchedulingSystem(scheduleUsers, availableTimes);
                List<ScheduleUsers> schedule = schedulingSystem.getSchedule().ToList();



                // Send the schedule to the Database
                for (int i = 0; i < 21; i++)
                {
                    int daysNeededToBeAdded = (i / 3);
                    int hoursNeededToBeAdded = 9 + (i % 3) * 4;
                    DateTime date = nextMonday.AddDays(daysNeededToBeAdded).AddHours(hoursNeededToBeAdded);
                    if (schedule[i] == null)
                    {
                        // Error message no employee can be found for certain shift
                        MailDAO.Instance.SendMail("[AUTOMATED] Schedule Conflict", $"Hello {manager.FirstName} \n " +
                            $"\n " +
                            $"No employee could be found for the shift on {date.Date.ToString("dd/MM/yyyy")} at {date.ToString("HH:mm")} until {date.AddHours(4).ToString("HH:mm")}. \n" +
                            $"\n" +
                            $"Please resolve this issue.\n" +
                            $"\n" +
                            $"THIS IS AN AUTOMATED MESSAGE, YOU CANNOT RESPOND TO THIS MESSAGE", DateTime.Now.ToString("dd/MM/yyyy"), 0, manager.ID);
                    }
                    else
                    {
                        ScheduleDAO.Instance.AddSchedule(schedule[i].ID, date.Date.ToString("dd/MM/yyyy"), date.ToString("HH:mm"), date.AddHours(4).ToString("HH:mm"), "Automatically Scheduled Shift");

                    }
                }


            }
            MessageBox.Show("Schedule for next week made");




        }

        private bool[] ConvertToBools(string NoGoSchedule)
        {
            bool[] returnValue = new bool[21];
            string[] collection = NoGoSchedule.Split('-');
            for (int i = 0; i < 21; i++)
            {
                if (collection.Contains(i.ToString()))
                {
                    returnValue[i] = true;
                }
                else
                {
                    returnValue[i] = false;
                }
            }

            return returnValue;
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
                }
                else
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
            employeeAddForm = new EmployeeAddForm(this, user);

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
            }
            else if (isNameNotValid)
            {
                MessageBox.Show("The name should not be an integer!", "Invalid name type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!employees.Contains(name))
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
                            LoadAlerts();
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
                    }
                    else if (currentColumnIndex == 5)
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

        private void PiechartCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPieChart();
            LoadGraphChartData();
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
                for (int j = 0; j < daysInWeek; j++)
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
            scheduleAddForm = new ScheduleAddForm(date, user);
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


        //Mailbox Presentation Layer
        private void btnInbox_Click(object sender, EventArgs e)
        {
            pnlMailContent.Controls.Clear();
            FillReceivedMails();
            this.currentTab = 0;
        }

        private void Mail_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Mail m = btn.Tag as Mail;

            if (currentTab == 0 && btn.BackColor == Color.LightCyan)
            {
                if (MailDAO.Instance.ChangeMailStatus(m.ID))
                {
                    btn.BackColor = Color.Transparent;
                }
            }

            GenerateMailContent(m.ID, m.Subject, EmployeeDAO.Instance.GetFirstNameAndLastNameFromID(m.Sender), EmployeeDAO.Instance.GetFirstNameAndLastNameFromID(m.Receiver), m.Date, m.Content);
        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            pnlMailContent.Controls.Clear();
            FillSentMails();
            this.currentTab = 1;
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            pnlMailContent.Controls.Clear();
            FillDeletedMails();
            this.currentTab = 2;
        }

        private void UpdateAllMailsList()
        {
            List<Mail> mailList = MailDAO.Instance.GetAllMails(this.adminID);
            this.allMails.Clear();

            foreach (Mail m in mailList)
            {
                this.allMails.Add(m);

            }
        }

        private void GenerateMailContent(int mid, string subject, string senderName, string receiverName, string dateStr, string contentStr)
        {
            pnlMailContent.Controls.Clear();
            //Add the mail subject
            Label sj = new Label();
            sj.Text = subject;
            sj.Font = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold);
            sj.AutoSize = true;

            pnlMailContent.Controls.Add(sj);

            //Add the mail sender info
            Label sender = new Label();
            sender.Text = senderName;
            sender.Font = new Font("Arial", 14, FontStyle.Regular);
            sender.AutoSize = true;
            sender.Location = new Point(6, 35);

            pnlMailContent.Controls.Add(sender);

            //Add the mail receiver info 
            Label receiver = new Label();
            receiver.Text = receiverName;
            receiver.Font = new Font("Arial", 14, FontStyle.Regular);
            receiver.AutoSize = true;
            receiver.Location = new Point(600, 35);

            pnlMailContent.Controls.Add(receiver);

            //Add the mail date 
            Label date = new Label();
            date.Text = dateStr;
            date.Font = new Font("Arial", 14, FontStyle.Regular);
            date.AutoSize = true;
            date.Location = new Point(600, 6);

            pnlMailContent.Controls.Add(date);

            //Add the rich text box content 
            RichTextBox rtbx = new RichTextBox();
            rtbx.Text = contentStr;
            rtbx.Font = new Font("Arial", 14, FontStyle.Regular);
            rtbx.AutoSize = true;
            rtbx.Location = new Point(6, 100);
            rtbx.Width = 780;
            rtbx.Height = 380;
            rtbx.ReadOnly = true;


            pnlMailContent.Controls.Add(rtbx);

            //Add the delete button 
            Button btn = new Button();
            btn.Text = "Delete";
            btn.Width = 70;
            btn.Height = 40;
            btn.Location = new Point(700, 490);
            btn.Click += DeleteMailFromAdmin;
            btn.Tag = mid;

            pnlMailContent.Controls.Add(btn);

            if (this.currentTab == 0)
            {
                Button btn1 = new Button();
                btn1.Text = "Reply";
                btn1.Width = 70;
                btn1.Height = 40;
                btn1.Location = new Point(600, 490);
                btn1.Click += ReplyMail;
                btn1.Tag = mid;

                pnlMailContent.Controls.Add(btn1);
            }

        }

        private void ReplyMail(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32((sender as Button).Tag);
            foreach (Mail m in allMails)
            {
                if (m.ID == mid)
                {
                    SendMail sm = new SendMail(this.adminID, m.Sender, m.Subject);
                    sm.Show();
                    break;
                }
            }
        }

        private void DeleteMailFromAdmin(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32((sender as Button).Tag);
            if (this.currentTab != 2)
            {
                if (MailDAO.Instance.DeleteMailFromAdmin(mid))
                {
                    MessageBox.Show("Successfully deleted the mail!", "Successful Mail Deletion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    UpdateAllMailsList();
                    pnlMailContent.Controls.Clear();

                    switch (currentTab)
                    {
                        case 0:
                            FillReceivedMails();
                            break;
                        default:
                            FillSentMails();
                            break;

                    }
                }
            }
            else
            {
                if (MailDAO.Instance.DeleteMailFromAdminForever(mid))
                {
                    MessageBox.Show("Successfully deleted the mail forever !", "Successful Mail Deletion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    UpdateAllMailsList();
                    pnlMailContent.Controls.Clear();

                    FillDeletedMails();
                }
            }

        }

        private void FillReceivedMails()
        {
            flpMailList.Controls.Clear();

            foreach (Mail m in this.allMails)
            {
                if (m.Receiver == this.adminID && m.DeletedFromAdmin == 0)
                {
                    Button btn = new Button() { Width = 285, Height = 72 };
                    string displayText = m.Subject + "\n\n" + EmployeeDAO.Instance.GetFirstNameAndLastNameFromID(m.Sender) + "          " + m.Date;
                    btn.Text = displayText;
                    btn.Tag = m;
                    btn.Click += Mail_Clicked;
                    if (m.Status == 0)
                    {
                        btn.BackColor = Color.LightCyan;
                    }
                    flpMailList.Controls.Add(btn);
                }
            }
        }

        private void FillSentMails()
        {
            flpMailList.Controls.Clear();
            foreach (Mail m in this.allMails)
            {
                if (m.Sender == this.adminID && m.DeletedFromAdmin == 0)
                {
                    Button btn = new Button() { Width = 285, Height = 72 };
                    string displayText = m.Subject + "\n\n" + EmployeeDAO.Instance.GetFirstNameAndLastNameFromID(m.Sender) + "          " + m.Date;
                    btn.Text = displayText;
                    btn.Tag = m;
                    btn.Click += Mail_Clicked;
                    flpMailList.Controls.Add(btn);
                }
            }
        }

        private void FillDeletedMails()
        {
            flpMailList.Controls.Clear();
            foreach (Mail m in this.allMails)
            {
                if (m.DeletedFromAdmin == 1 && m.DeletedFromAdminForever == 0)
                {
                    Button btn = new Button() { Width = 285, Height = 72 };

                    string displayText = m.Subject + "\n\n" + EmployeeDAO.Instance.GetFirstNameAndLastNameFromID(m.Sender) + "          " + m.Date;
                    btn.Text = displayText;
                    btn.Tag = m;
                    btn.Click += Mail_Clicked;
                    flpMailList.Controls.Add(btn);
                }

            }
        }


        private void CheckIfThereIsUnreadMails()
        {
            bool unreadMailExist = false;

            foreach (Mail m in this.allMails)
            {
                if (m.Status == 0 && m.Receiver == this.adminID)
                {
                    unreadMailExist = true;
                    break;
                }
            }

            if (unreadMailExist)
            {
                btnInbox.BackColor = Color.LightCyan;
            }
            else
            {
                btnInbox.BackColor = Color.Transparent;
            }
        }

        private void CheckMail_Tick(object sender, EventArgs e)
        {
            UpdateAllMailsList();
            CheckIfThereIsUnreadMails();
        }

        private void btnComposeMail_Click(object sender, EventArgs e)
        {
            SendMail sendMail = new SendMail(this.adminID);
            sendMail.ShowDialog();
        }

        private void cbShowCompleted_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void rbPriority_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSortAlertsByPriority.Checked)
            {
                sortAlertsByPriority = true;
                LoadAlerts();
            }
        }

        private void rbTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSortAlertsByID.Checked)
            {
                sortAlertsByPriority = false;
                LoadAlerts();
            }
        }

        private void btnMakeOrder_Click(object sender, EventArgs e)
        {
            string message = "Item ID";
            int index = lbxAlerts.SelectedIndex;
            if (index >= 0)
            {
                message = alerts[index].ID.ToString();
            }
            string value = Interaction.InputBox("Please Input ID", "Enter a number", message);

            if(int.TryParse(value, out int id))
            {
                if (ItemDAO.Instance.SearchItemByID(id.ToString()).Count > 0)
                {
                    value = Interaction.InputBox("Please input amount", "Enter a number");             
                    if (int.TryParse(value, out int amount))
                    {

                        bool success = RestockDAO.Instance.AddOrder(id, amount, "incomplete");
                        if (success)
                        {
                            MessageBox.Show("Order succesfully added");
                            LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Order could not be added, please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input.");
                    }
                }
                else
                {
                    MessageBox.Show("Could not find ID, please try again.");
                }          
            }
            else
            {
                if(value != "")
                MessageBox.Show("Enter a valid ID number");
            }
            
        }

        private void btnRemoveLimit_Click(object sender, EventArgs e)
        {
            int index = lbxAlerts.SelectedIndex;
            if (index >= 0)
            {
                Alert alert = alerts[index];
                int id = alert.ID;
                bool success = RestockDAO.Instance.DeleteLimit(id);
                if (success)
                {
                    MessageBox.Show("Alert and corresponding limit deleted");
                }
                else
                {
                    MessageBox.Show($"Alert and corresponding limit could not be deleted");
                }
                LoadAlerts();
            }
            else
            {
                MessageBox.Show("Please select an alert or add a new limit");
            }
        }

        private void btnSetLimit_Click(object sender, EventArgs e)
        {
            int id = (int)nUPLimitID.Value;
            if (ItemDAO.Instance.SearchItemByID(id.ToString()).Count > 0)
            {
                int limit = (int)nUPMinStock.Value;
                bool success = RestockDAO.Instance.AddLimit(id, limit);
                if (success)
                {
                    List<Item> items = ItemDAO.Instance.SearchItemByID(id.ToString());
                    foreach (Item item in items)
                    {
                        if (item.ID == id)
                        {
                            MessageBox.Show($"Limit for {item.ID} : {item.Name} succesfully set to {limit}");
                        }
                        break;
                    }
                    LoadAlerts();
                }
            }
            else
            {
                MessageBox.Show($"Item with ID {id} not found, please try again.");
            }

        }





        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            int orderNo = (int)dgvOrders.SelectedRows[0].Cells[0].Value; 
            int id = (int)dgvOrders.SelectedRows[0].Cells[1].Value;
            int amount = (int)dgvOrders.SelectedRows[0].Cells[2].Value;
            string currentStatus = dgvOrders.SelectedRows[0].Cells[3].Value.ToString();

            string newStatus = cbxStatus.SelectedItem.ToString();           
            bool success = RestockDAO.Instance.UpdateOrderStatus(orderNo, newStatus);
            if (success)
            {
                MessageBox.Show($"Order status succesfully changed from {currentStatus} to {newStatus} ");
                if (newStatus == "complete")
                {
                    
                    if(ItemDAO.Instance.IncreaseItemAmount(id, amount))
                    {
                        Item item = ItemDAO.Instance.SearchItemByID(id.ToString())[0];
                        MessageBox.Show($"{item.ID} : {item.Name} stock replenished by {amount}");
                        LoadAll();
                    }
                }        
            }
            LoadOrders();
        }

        private void btnChangeAmount_Click(object sender, EventArgs e)
        {
            int orderNo = (int)dgvOrders.SelectedRows[0].Cells[0].Value;
            string value = Interaction.InputBox("Please input new amount", "Enter a number");
            if(value == "")
            {
                MessageBox.Show("Change amount cancelled");
            }
            else
            {
                int.TryParse(value, out int amount);

                bool success = RestockDAO.Instance.UpdateAmount(orderNo, amount);
                if (success)
                {
                    MessageBox.Show($"Amount changed to {amount}");
                    LoadOrders();
                }
                else
                {
                    MessageBox.Show($"Could not change amount, please input a valid amount.");
                }
            }        
        }

        private void cbShowCompleted_CheckedChanged_1(object sender, EventArgs e)
        {
            showCompletedOrders = cbShowCompleted.Checked;
            LoadOrders();
        }

        private void AutoScheduleGeneratorBtn_Click(object sender, EventArgs e)
        {
            AddSchedule();
        }

        private void XAxisCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGraphChart();
        }

        private void EmployeeEditBtn_Click(object sender, EventArgs e)
        {
            if(dgvEmployees.SelectedRows.Count != 0)
            {
                Employee employee = (Employee)dgvEmployees.SelectedRows[0].DataBoundItem;
                EmployeeEditForm employeeEditForm = new EmployeeEditForm(this, employee, user);
                employeeEditForm.Show();
            }
            
        }

        private void DepotEditBtn_Click(object sender, EventArgs e)
        {
            if (dgvDepot.SelectedRows.Count != 0)
            {
                Item item = (Item)dgvDepot.SelectedRows[0].DataBoundItem;
                DepotEditForm depotEditForm = new DepotEditForm(this, item, user);
                depotEditForm.Show();
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0) 
            {
                string currentStatus = dgvOrders.SelectedRows[0].Cells[2].Value.ToString();
                cbxStatus.Items.Clear();
                switch (currentStatus)
                {
                    case "complete":
                        cbxStatus.Enabled = false;
                        btnChangeStatus.Enabled = false;
                        break;
                    case "cancelled":
                        cbxStatus.Enabled = false;
                        btnChangeStatus.Enabled = false;
                        break;
                    default:
                        foreach (string item in possibleOrderStatuses)
                        {
                            if (item != currentStatus)
                                cbxStatus.Items.Add(item);
                        }
                        cbxStatus.Enabled = true;
                        btnChangeStatus.Enabled = true;
                        break;
                }
            }     
        }

        private void btnChangePriorityMargin_Click(object sender, EventArgs e)
        {
            Alert.PriorityMargin = (int)nUPPriority.Value;
            LoadAlerts();
        }

        private void MissedShiftsCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMSPC();
            
        }
    }
}
