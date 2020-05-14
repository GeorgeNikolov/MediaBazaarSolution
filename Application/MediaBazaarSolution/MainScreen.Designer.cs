namespace MediaBazaarSolution
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.ScheduleTab = new System.Windows.Forms.TabPage();
            this.flpScheduleTable = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFriday = new System.Windows.Forms.Label();
            this.lblThursday = new System.Windows.Forms.Label();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.lblMonday = new System.Windows.Forms.Label();
            this.lblEvening = new System.Windows.Forms.Label();
            this.lblAfternoon = new System.Windows.Forms.Label();
            this.lblMorning = new System.Windows.Forms.Label();
            this.EmployeesTab = new System.Windows.Forms.TabPage();
            this.btnReloadEmployees = new System.Windows.Forms.Button();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSearchEmployeeByName = new System.Windows.Forms.TextBox();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.DepotTab = new System.Windows.Forms.TabPage();
            this.btnReloadItems = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxItemCategory = new System.Windows.Forms.ComboBox();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSearchItemById = new System.Windows.Forms.TextBox();
            this.dgvDepot = new System.Windows.Forms.DataGridView();
            this.StatisticsTab = new System.Windows.Forms.TabPage();
            this.SalesPieChart = new LiveCharts.WinForms.PieChart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.EmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmWage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.StProductDGV = new System.Windows.Forms.DataGridView();
            this.PrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tabs.SuspendLayout();
            this.ScheduleTab.SuspendLayout();
            this.EmployeesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.DepotTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepot)).BeginInit();
            this.StatisticsTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StProductDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(477, 19);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(330, 37);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "WELCOME, <User>!";
            // 
            // Tabs
            // 
            this.Tabs.CausesValidation = false;
            this.Tabs.Controls.Add(this.ScheduleTab);
            this.Tabs.Controls.Add(this.EmployeesTab);
            this.Tabs.Controls.Add(this.DepotTab);
            this.Tabs.Controls.Add(this.StatisticsTab);
            this.Tabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tabs.Location = new System.Drawing.Point(9, 69);
            this.Tabs.Margin = new System.Windows.Forms.Padding(2);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1383, 531);
            this.Tabs.TabIndex = 2;
            // 
            // ScheduleTab
            // 
            this.ScheduleTab.BackColor = System.Drawing.Color.Transparent;
            this.ScheduleTab.Controls.Add(this.flpScheduleTable);
            this.ScheduleTab.Controls.Add(this.lblFriday);
            this.ScheduleTab.Controls.Add(this.lblThursday);
            this.ScheduleTab.Controls.Add(this.lblWednesday);
            this.ScheduleTab.Controls.Add(this.lblTuesday);
            this.ScheduleTab.Controls.Add(this.lblMonday);
            this.ScheduleTab.Controls.Add(this.lblEvening);
            this.ScheduleTab.Controls.Add(this.lblAfternoon);
            this.ScheduleTab.Controls.Add(this.lblMorning);
            this.ScheduleTab.Location = new System.Drawing.Point(4, 29);
            this.ScheduleTab.Margin = new System.Windows.Forms.Padding(2);
            this.ScheduleTab.Name = "ScheduleTab";
            this.ScheduleTab.Padding = new System.Windows.Forms.Padding(2);
            this.ScheduleTab.Size = new System.Drawing.Size(1375, 498);
            this.ScheduleTab.TabIndex = 0;
            this.ScheduleTab.Text = "Schedule";
            // 
            // flpScheduleTable
            // 
            this.flpScheduleTable.Location = new System.Drawing.Point(139, 83);
            this.flpScheduleTable.Name = "flpScheduleTable";
            this.flpScheduleTable.Size = new System.Drawing.Size(1221, 379);
            this.flpScheduleTable.TabIndex = 25;
            // 
            // lblFriday
            // 
            this.lblFriday.AutoSize = true;
            this.lblFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFriday.Location = new System.Drawing.Point(991, 23);
            this.lblFriday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(138, 24);
            this.lblFriday.TabIndex = 24;
            this.lblFriday.Text = "Friday <date>";
            // 
            // lblThursday
            // 
            this.lblThursday.AutoSize = true;
            this.lblThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThursday.Location = new System.Drawing.Point(790, 23);
            this.lblThursday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(167, 24);
            this.lblThursday.TabIndex = 23;
            this.lblThursday.Text = "Thursday <date>";
            // 
            // lblWednesday
            // 
            this.lblWednesday.AutoSize = true;
            this.lblWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWednesday.Location = new System.Drawing.Point(574, 23);
            this.lblWednesday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(190, 24);
            this.lblWednesday.TabIndex = 22;
            this.lblWednesday.Text = "Wednesday <date>";
            // 
            // lblTuesday
            // 
            this.lblTuesday.AutoSize = true;
            this.lblTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuesday.Location = new System.Drawing.Point(376, 23);
            this.lblTuesday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(160, 24);
            this.lblTuesday.TabIndex = 21;
            this.lblTuesday.Text = "Tuesday <date>";
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonday.Location = new System.Drawing.Point(159, 23);
            this.lblMonday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(154, 24);
            this.lblMonday.TabIndex = 20;
            this.lblMonday.Text = "Monday <date>";
            // 
            // lblEvening
            // 
            this.lblEvening.AutoSize = true;
            this.lblEvening.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvening.Location = new System.Drawing.Point(22, 319);
            this.lblEvening.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEvening.Name = "lblEvening";
            this.lblEvening.Size = new System.Drawing.Size(87, 24);
            this.lblEvening.TabIndex = 19;
            this.lblEvening.Text = "Evening";
            // 
            // lblAfternoon
            // 
            this.lblAfternoon.AutoSize = true;
            this.lblAfternoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAfternoon.Location = new System.Drawing.Point(22, 216);
            this.lblAfternoon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAfternoon.Name = "lblAfternoon";
            this.lblAfternoon.Size = new System.Drawing.Size(101, 24);
            this.lblAfternoon.TabIndex = 18;
            this.lblAfternoon.Text = "Afternoon";
            // 
            // lblMorning
            // 
            this.lblMorning.AutoSize = true;
            this.lblMorning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMorning.Location = new System.Drawing.Point(22, 106);
            this.lblMorning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMorning.Name = "lblMorning";
            this.lblMorning.Size = new System.Drawing.Size(87, 24);
            this.lblMorning.TabIndex = 2;
            this.lblMorning.Text = "Morning";
            // 
            // EmployeesTab
            // 
            this.EmployeesTab.Controls.Add(this.btnReloadEmployees);
            this.EmployeesTab.Controls.Add(this.btnSearchEmployee);
            this.EmployeesTab.Controls.Add(this.label4);
            this.EmployeesTab.Controls.Add(this.tbxSearchEmployeeByName);
            this.EmployeesTab.Controls.Add(this.btnAddEmployee);
            this.EmployeesTab.Controls.Add(this.btnDeleteEmployee);
            this.EmployeesTab.Controls.Add(this.dgvEmployees);
            this.EmployeesTab.Location = new System.Drawing.Point(4, 29);
            this.EmployeesTab.Margin = new System.Windows.Forms.Padding(2);
            this.EmployeesTab.Name = "EmployeesTab";
            this.EmployeesTab.Padding = new System.Windows.Forms.Padding(2);
            this.EmployeesTab.Size = new System.Drawing.Size(1375, 498);
            this.EmployeesTab.TabIndex = 1;
            this.EmployeesTab.Text = "Employees";
            this.EmployeesTab.UseVisualStyleBackColor = true;
            // 
            // btnReloadEmployees
            // 
            this.btnReloadEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadEmployees.Location = new System.Drawing.Point(630, 432);
            this.btnReloadEmployees.Name = "btnReloadEmployees";
            this.btnReloadEmployees.Size = new System.Drawing.Size(100, 35);
            this.btnReloadEmployees.TabIndex = 11;
            this.btnReloadEmployees.Text = "Reload";
            this.btnReloadEmployees.UseVisualStyleBackColor = true;
            this.btnReloadEmployees.Click += new System.EventHandler(this.btnReloadEmployees_Click);
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchEmployee.Location = new System.Drawing.Point(1156, 208);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(105, 37);
            this.btnSearchEmployee.TabIndex = 10;
            this.btnSearchEmployee.Text = "Search";
            this.btnSearchEmployee.UseVisualStyleBackColor = true;
            this.btnSearchEmployee.Click += new System.EventHandler(this.btnSearchEmployee_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1085, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Enter Employee Last Name";
            // 
            // tbxSearchEmployeeByName
            // 
            this.tbxSearchEmployeeByName.Location = new System.Drawing.Point(1088, 112);
            this.tbxSearchEmployeeByName.Name = "tbxSearchEmployeeByName";
            this.tbxSearchEmployeeByName.Size = new System.Drawing.Size(246, 26);
            this.tbxSearchEmployeeByName.TabIndex = 8;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.Location = new System.Drawing.Point(921, 432);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(100, 35);
            this.btnAddEmployee.TabIndex = 7;
            this.btnAddEmployee.Text = "Add";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmployee.Location = new System.Drawing.Point(771, 432);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteEmployee.TabIndex = 6;
            this.btnDeleteEmployee.Text = "Delete";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(25, 17);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(1011, 378);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvEmployees_CellBeginEdit);
            this.dgvEmployees.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellEndEdit);
            this.dgvEmployees.SelectionChanged += new System.EventHandler(this.dgvEmployees_SelectionChanged);
            // 
            // DepotTab
            // 
            this.DepotTab.Controls.Add(this.btnReloadItems);
            this.DepotTab.Controls.Add(this.label3);
            this.DepotTab.Controls.Add(this.cbxItemCategory);
            this.DepotTab.Controls.Add(this.btnDeleteItem);
            this.DepotTab.Controls.Add(this.btnAddProduct);
            this.DepotTab.Controls.Add(this.btnSearch);
            this.DepotTab.Controls.Add(this.label1);
            this.DepotTab.Controls.Add(this.tbxSearchItemById);
            this.DepotTab.Controls.Add(this.dgvDepot);
            this.DepotTab.Location = new System.Drawing.Point(4, 29);
            this.DepotTab.Margin = new System.Windows.Forms.Padding(2);
            this.DepotTab.Name = "DepotTab";
            this.DepotTab.Padding = new System.Windows.Forms.Padding(2);
            this.DepotTab.Size = new System.Drawing.Size(1375, 498);
            this.DepotTab.TabIndex = 2;
            this.DepotTab.Text = "Depot";
            this.DepotTab.UseVisualStyleBackColor = true;
            // 
            // btnReloadItems
            // 
            this.btnReloadItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadItems.Location = new System.Drawing.Point(710, 409);
            this.btnReloadItems.Name = "btnReloadItems";
            this.btnReloadItems.Size = new System.Drawing.Size(100, 35);
            this.btnReloadItems.TabIndex = 12;
            this.btnReloadItems.Text = "Reload";
            this.btnReloadItems.UseVisualStyleBackColor = true;
            this.btnReloadItems.Click += new System.EventHandler(this.btnReloadItems_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1196, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select category:";
            // 
            // cbxItemCategory
            // 
            this.cbxItemCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxItemCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItemCategory.FormattingEnabled = true;
            this.cbxItemCategory.Location = new System.Drawing.Point(1186, 229);
            this.cbxItemCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbxItemCategory.Name = "cbxItemCategory";
            this.cbxItemCategory.Size = new System.Drawing.Size(179, 28);
            this.cbxItemCategory.TabIndex = 6;
            this.cbxItemCategory.SelectedValueChanged += new System.EventHandler(this.cbxItemCategory_SelectedValueChanged);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.Location = new System.Drawing.Point(864, 409);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteItem.TabIndex = 5;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(1026, 409);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(100, 35);
            this.btnAddProduct.TabIndex = 4;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1217, 297);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 37);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1205, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Item ID:";
            // 
            // tbxSearchItemById
            // 
            this.tbxSearchItemById.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearchItemById.Location = new System.Drawing.Point(1217, 120);
            this.tbxSearchItemById.Name = "tbxSearchItemById";
            this.tbxSearchItemById.Size = new System.Drawing.Size(106, 30);
            this.tbxSearchItemById.TabIndex = 1;
            // 
            // dgvDepot
            // 
            this.dgvDepot.AllowUserToAddRows = false;
            this.dgvDepot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepot.Location = new System.Drawing.Point(15, 32);
            this.dgvDepot.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDepot.MultiSelect = false;
            this.dgvDepot.Name = "dgvDepot";
            this.dgvDepot.RowHeadersWidth = 51;
            this.dgvDepot.RowTemplate.Height = 24;
            this.dgvDepot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepot.Size = new System.Drawing.Size(1111, 354);
            this.dgvDepot.TabIndex = 0;
            this.dgvDepot.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDepot_CellBeginEdit);
            this.dgvDepot.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepot_CellEndEdit);
            this.dgvDepot.SelectionChanged += new System.EventHandler(this.dgvDepot_SelectionChanged);
            // 
            // StatisticsTab
            // 
            this.StatisticsTab.Controls.Add(this.SalesPieChart);
            this.StatisticsTab.Controls.Add(this.tabControl1);
            this.StatisticsTab.Location = new System.Drawing.Point(4, 29);
            this.StatisticsTab.Margin = new System.Windows.Forms.Padding(2);
            this.StatisticsTab.Name = "StatisticsTab";
            this.StatisticsTab.Padding = new System.Windows.Forms.Padding(2);
            this.StatisticsTab.Size = new System.Drawing.Size(1375, 498);
            this.StatisticsTab.TabIndex = 3;
            this.StatisticsTab.Text = "Statistics";
            this.StatisticsTab.UseVisualStyleBackColor = true;
            // 
            // SalesPieChart
            // 
            this.SalesPieChart.Location = new System.Drawing.Point(870, 59);
            this.SalesPieChart.Margin = new System.Windows.Forms.Padding(2);
            this.SalesPieChart.Name = "SalesPieChart";
            this.SalesPieChart.Size = new System.Drawing.Size(470, 301);
            this.SalesPieChart.TabIndex = 1;
            this.SalesPieChart.Text = "pieChart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 382);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(786, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmID,
            this.EmName,
            this.EmWage});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(2, 2);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(782, 345);
            this.dataGridView3.TabIndex = 0;
            // 
            // EmID
            // 
            this.EmID.HeaderText = "ID";
            this.EmID.MinimumWidth = 6;
            this.EmID.Name = "EmID";
            this.EmID.Width = 125;
            // 
            // EmName
            // 
            this.EmName.HeaderText = "Name";
            this.EmName.MinimumWidth = 6;
            this.EmName.Name = "EmName";
            this.EmName.Width = 125;
            // 
            // EmWage
            // 
            this.EmWage.HeaderText = "Wage";
            this.EmWage.MinimumWidth = 6;
            this.EmWage.Name = "EmWage";
            this.EmWage.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.StProductDGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(786, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StProductDGV
            // 
            this.StProductDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StProductDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrName,
            this.PrSold,
            this.PrPrice});
            this.StProductDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StProductDGV.Location = new System.Drawing.Point(2, 2);
            this.StProductDGV.Margin = new System.Windows.Forms.Padding(2);
            this.StProductDGV.Name = "StProductDGV";
            this.StProductDGV.RowHeadersWidth = 51;
            this.StProductDGV.RowTemplate.Height = 24;
            this.StProductDGV.Size = new System.Drawing.Size(782, 345);
            this.StProductDGV.TabIndex = 0;
            // 
            // PrName
            // 
            this.PrName.HeaderText = "Name";
            this.PrName.MinimumWidth = 6;
            this.PrName.Name = "PrName";
            this.PrName.Width = 125;
            // 
            // PrSold
            // 
            this.PrSold.HeaderText = "Sold";
            this.PrSold.MinimumWidth = 6;
            this.PrSold.Name = "PrSold";
            this.PrSold.Width = 125;
            // 
            // PrPrice
            // 
            this.PrPrice.HeaderText = "Price";
            this.PrPrice.MinimumWidth = 6;
            this.PrPrice.Name = "PrPrice";
            this.PrPrice.Width = 125;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1404, 612);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.lblWelcome);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainScreen";
            this.Text = "Hello";
            this.Tabs.ResumeLayout(false);
            this.ScheduleTab.ResumeLayout(false);
            this.ScheduleTab.PerformLayout();
            this.EmployeesTab.ResumeLayout(false);
            this.EmployeesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.DepotTab.ResumeLayout(false);
            this.DepotTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepot)).EndInit();
            this.StatisticsTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StProductDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage ScheduleTab;
        private System.Windows.Forms.Label lblFriday;
        private System.Windows.Forms.Label lblThursday;
        private System.Windows.Forms.Label lblWednesday;
        private System.Windows.Forms.Label lblTuesday;
        private System.Windows.Forms.Label lblMonday;
        private System.Windows.Forms.Label lblEvening;
        private System.Windows.Forms.Label lblMorning;
        private System.Windows.Forms.TabPage EmployeesTab;
        private System.Windows.Forms.TabPage DepotTab;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSearchItemById;
        private System.Windows.Forms.DataGridView dgvDepot;
        private System.Windows.Forms.TabPage StatisticsTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView StProductDGV;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.ComboBox cbxItemCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxSearchEmployeeByName;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.Button btnReloadEmployees;
        private System.Windows.Forms.Button btnReloadItems;
        private LiveCharts.WinForms.PieChart SalesPieChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmWage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrPrice;
        private System.Windows.Forms.FlowLayoutPanel flpScheduleTable;
        private System.Windows.Forms.Label lblAfternoon;
    }
}