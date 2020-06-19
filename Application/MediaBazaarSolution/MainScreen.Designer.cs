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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlMatrix = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnPreviousMonth = new System.Windows.Forms.Button();
            this.btnSunday = new System.Windows.Forms.Button();
            this.btnSaturday = new System.Windows.Forms.Button();
            this.btnFriday = new System.Windows.Forms.Button();
            this.btnThursday = new System.Windows.Forms.Button();
            this.btnWednesday = new System.Windows.Forms.Button();
            this.btnTuesday = new System.Windows.Forms.Button();
            this.btnMonday = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnToday = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.XAxisCB = new System.Windows.Forms.ComboBox();
            this.YAxisCB = new System.Windows.Forms.ComboBox();
            this.PiechartCB = new System.Windows.Forms.ComboBox();
            this.SalesPieChart = new LiveCharts.WinForms.PieChart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.StEmployeeDGV = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.StProductDGV = new System.Windows.Forms.DataGridView();
            this.OrdersTab = new System.Windows.Forms.TabPage();
            this.lbxAlerts = new System.Windows.Forms.ListBox();
            this.gbSetLimit = new System.Windows.Forms.GroupBox();
            this.btnSetLimit = new System.Windows.Forms.Button();
            this.tbLimitId = new System.Windows.Forms.TextBox();
            this.lblSetMinStock = new System.Windows.Forms.Label();
            this.nUPMinStock = new System.Windows.Forms.NumericUpDown();
            this.lbSetLimitId = new System.Windows.Forms.Label();
            this.gbRestockView = new System.Windows.Forms.GroupBox();
            this.rbSortAlertsByPriority = new System.Windows.Forms.RadioButton();
            this.rbSortAlertsByID = new System.Windows.Forms.RadioButton();
            this.lblSortAlerts = new System.Windows.Forms.Label();
            this.cbShowCompleted = new System.Windows.Forms.CheckBox();
            this.btnChangeAmount = new System.Windows.Forms.Button();
            this.lblOrders = new System.Windows.Forms.Label();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.lblAlerts = new System.Windows.Forms.Label();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnRemoveLimit = new System.Windows.Forms.Button();
            this.btnMakeOrder = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.AutoScheduleGeneratorBtn = new System.Windows.Forms.Button();
            this.Tabs.SuspendLayout();
            this.ScheduleTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.EmployeesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.DepotTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepot)).BeginInit();
            this.StatisticsTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StEmployeeDGV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StProductDGV)).BeginInit();
            this.OrdersTab.SuspendLayout();
            this.gbSetLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUPMinStock)).BeginInit();
            this.gbRestockView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(531, 9);
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
            this.Tabs.Controls.Add(this.OrdersTab);
            this.Tabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tabs.Location = new System.Drawing.Point(10, 48);
            this.Tabs.Margin = new System.Windows.Forms.Padding(2);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1383, 610);
            this.Tabs.TabIndex = 2;
            // 
            // ScheduleTab
            // 
            this.ScheduleTab.BackColor = System.Drawing.Color.Transparent;
            this.ScheduleTab.Controls.Add(this.panel2);
            this.ScheduleTab.Controls.Add(this.panel1);
            this.ScheduleTab.Location = new System.Drawing.Point(4, 29);
            this.ScheduleTab.Margin = new System.Windows.Forms.Padding(2);
            this.ScheduleTab.Name = "ScheduleTab";
            this.ScheduleTab.Padding = new System.Windows.Forms.Padding(2);
            this.ScheduleTab.Size = new System.Drawing.Size(1375, 577);
            this.ScheduleTab.TabIndex = 0;
            this.ScheduleTab.Text = "Schedule";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AutoScheduleGeneratorBtn);
            this.panel2.Controls.Add(this.pnlMatrix);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1369, 544);
            this.panel2.TabIndex = 1;
            // 
            // pnlMatrix
            // 
            this.pnlMatrix.Location = new System.Drawing.Point(203, 91);
            this.pnlMatrix.Name = "pnlMatrix";
            this.pnlMatrix.Size = new System.Drawing.Size(995, 453);
            this.pnlMatrix.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNextMonth);
            this.panel3.Controls.Add(this.btnPreviousMonth);
            this.panel3.Controls.Add(this.btnSunday);
            this.panel3.Controls.Add(this.btnSaturday);
            this.panel3.Controls.Add(this.btnFriday);
            this.panel3.Controls.Add(this.btnThursday);
            this.panel3.Controls.Add(this.btnWednesday);
            this.panel3.Controls.Add(this.btnTuesday);
            this.panel3.Controls.Add(this.btnMonday);
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1362, 81);
            this.panel3.TabIndex = 0;
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(1222, 3);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(137, 74);
            this.btnNextMonth.TabIndex = 8;
            this.btnNextMonth.Text = "Next Month";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnPreviousMonth
            // 
            this.btnPreviousMonth.Location = new System.Drawing.Point(3, 3);
            this.btnPreviousMonth.Name = "btnPreviousMonth";
            this.btnPreviousMonth.Size = new System.Drawing.Size(137, 74);
            this.btnPreviousMonth.TabIndex = 7;
            this.btnPreviousMonth.Text = "Previous Month ";
            this.btnPreviousMonth.UseVisualStyleBackColor = true;
            this.btnPreviousMonth.Click += new System.EventHandler(this.btnPreviousMonth_Click);
            // 
            // btnSunday
            // 
            this.btnSunday.Location = new System.Drawing.Point(1057, 4);
            this.btnSunday.Name = "btnSunday";
            this.btnSunday.Size = new System.Drawing.Size(137, 74);
            this.btnSunday.TabIndex = 6;
            this.btnSunday.Text = "Sunday";
            this.btnSunday.UseVisualStyleBackColor = true;
            // 
            // btnSaturday
            // 
            this.btnSaturday.Location = new System.Drawing.Point(914, 4);
            this.btnSaturday.Name = "btnSaturday";
            this.btnSaturday.Size = new System.Drawing.Size(137, 74);
            this.btnSaturday.TabIndex = 5;
            this.btnSaturday.Text = "Saturday";
            this.btnSaturday.UseVisualStyleBackColor = true;
            // 
            // btnFriday
            // 
            this.btnFriday.Location = new System.Drawing.Point(771, 4);
            this.btnFriday.Name = "btnFriday";
            this.btnFriday.Size = new System.Drawing.Size(137, 74);
            this.btnFriday.TabIndex = 4;
            this.btnFriday.Text = "Friday";
            this.btnFriday.UseVisualStyleBackColor = true;
            // 
            // btnThursday
            // 
            this.btnThursday.Location = new System.Drawing.Point(628, 4);
            this.btnThursday.Name = "btnThursday";
            this.btnThursday.Size = new System.Drawing.Size(137, 74);
            this.btnThursday.TabIndex = 3;
            this.btnThursday.Text = "Thursday";
            this.btnThursday.UseVisualStyleBackColor = true;
            // 
            // btnWednesday
            // 
            this.btnWednesday.Location = new System.Drawing.Point(485, 4);
            this.btnWednesday.Name = "btnWednesday";
            this.btnWednesday.Size = new System.Drawing.Size(137, 74);
            this.btnWednesday.TabIndex = 2;
            this.btnWednesday.Text = "Wednesday";
            this.btnWednesday.UseVisualStyleBackColor = true;
            // 
            // btnTuesday
            // 
            this.btnTuesday.Location = new System.Drawing.Point(342, 4);
            this.btnTuesday.Name = "btnTuesday";
            this.btnTuesday.Size = new System.Drawing.Size(137, 74);
            this.btnTuesday.TabIndex = 1;
            this.btnTuesday.Text = "Tuesday";
            this.btnTuesday.UseVisualStyleBackColor = true;
            // 
            // btnMonday
            // 
            this.btnMonday.Location = new System.Drawing.Point(199, 3);
            this.btnMonday.Name = "btnMonday";
            this.btnMonday.Size = new System.Drawing.Size(137, 74);
            this.btnMonday.TabIndex = 0;
            this.btnMonday.Text = "Monday";
            this.btnMonday.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnToday);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1369, 27);
            this.panel1.TabIndex = 0;
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(796, 1);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(90, 26);
            this.btnToday.TabIndex = 1;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(489, 1);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(282, 26);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
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
            this.EmployeesTab.Size = new System.Drawing.Size(1375, 577);
            this.EmployeesTab.TabIndex = 1;
            this.EmployeesTab.Text = "Employees";
            this.EmployeesTab.UseVisualStyleBackColor = true;
            // 
            // btnReloadEmployees
            // 
            this.btnReloadEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadEmployees.Location = new System.Drawing.Point(630, 486);
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
            this.btnAddEmployee.Location = new System.Drawing.Point(924, 486);
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
            this.btnDeleteEmployee.Location = new System.Drawing.Point(777, 486);
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
            this.DepotTab.Size = new System.Drawing.Size(1375, 577);
            this.DepotTab.TabIndex = 2;
            this.DepotTab.Text = "Depot";
            this.DepotTab.UseVisualStyleBackColor = true;
            // 
            // btnReloadItems
            // 
            this.btnReloadItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadItems.Location = new System.Drawing.Point(709, 478);
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
            this.btnDeleteItem.Location = new System.Drawing.Point(866, 478);
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
            this.btnAddProduct.Location = new System.Drawing.Point(1026, 478);
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
            this.StatisticsTab.Controls.Add(this.cartesianChart1);
            this.StatisticsTab.Controls.Add(this.XAxisCB);
            this.StatisticsTab.Controls.Add(this.YAxisCB);
            this.StatisticsTab.Controls.Add(this.PiechartCB);
            this.StatisticsTab.Controls.Add(this.SalesPieChart);
            this.StatisticsTab.Controls.Add(this.tabControl1);
            this.StatisticsTab.Location = new System.Drawing.Point(4, 29);
            this.StatisticsTab.Margin = new System.Windows.Forms.Padding(2);
            this.StatisticsTab.Name = "StatisticsTab";
            this.StatisticsTab.Padding = new System.Windows.Forms.Padding(2);
            this.StatisticsTab.Size = new System.Drawing.Size(1375, 577);
            this.StatisticsTab.TabIndex = 3;
            this.StatisticsTab.Text = "Statistics";
            this.StatisticsTab.UseVisualStyleBackColor = true;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(839, 302);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(505, 230);
            this.cartesianChart1.TabIndex = 5;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // XAxisCB
            // 
            this.XAxisCB.FormattingEnabled = true;
            this.XAxisCB.Location = new System.Drawing.Point(870, 538);
            this.XAxisCB.Name = "XAxisCB";
            this.XAxisCB.Size = new System.Drawing.Size(121, 28);
            this.XAxisCB.TabIndex = 4;
            // 
            // YAxisCB
            // 
            this.YAxisCB.FormattingEnabled = true;
            this.YAxisCB.Location = new System.Drawing.Point(712, 374);
            this.YAxisCB.Name = "YAxisCB";
            this.YAxisCB.Size = new System.Drawing.Size(121, 28);
            this.YAxisCB.TabIndex = 3;
            // 
            // PiechartCB
            // 
            this.PiechartCB.FormattingEnabled = true;
            this.PiechartCB.Location = new System.Drawing.Point(1223, 73);
            this.PiechartCB.Name = "PiechartCB";
            this.PiechartCB.Size = new System.Drawing.Size(121, 28);
            this.PiechartCB.TabIndex = 2;
            this.PiechartCB.SelectedIndexChanged += new System.EventHandler(this.PiechartCB_SelectedIndexChanged);
            // 
            // SalesPieChart
            // 
            this.SalesPieChart.Location = new System.Drawing.Point(730, 34);
            this.SalesPieChart.Margin = new System.Windows.Forms.Padding(2);
            this.SalesPieChart.Name = "SalesPieChart";
            this.SalesPieChart.Size = new System.Drawing.Size(470, 223);
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
            this.tabControl1.Size = new System.Drawing.Size(703, 382);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.StEmployeeDGV);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(695, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // StEmployeeDGV
            // 
            this.StEmployeeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StEmployeeDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StEmployeeDGV.Location = new System.Drawing.Point(2, 2);
            this.StEmployeeDGV.Margin = new System.Windows.Forms.Padding(2);
            this.StEmployeeDGV.Name = "StEmployeeDGV";
            this.StEmployeeDGV.RowHeadersWidth = 51;
            this.StEmployeeDGV.RowTemplate.Height = 24;
            this.StEmployeeDGV.Size = new System.Drawing.Size(691, 345);
            this.StEmployeeDGV.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.StProductDGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(695, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StProductDGV
            // 
            this.StProductDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StProductDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StProductDGV.Location = new System.Drawing.Point(2, 2);
            this.StProductDGV.Margin = new System.Windows.Forms.Padding(2);
            this.StProductDGV.Name = "StProductDGV";
            this.StProductDGV.RowHeadersWidth = 51;
            this.StProductDGV.RowTemplate.Height = 24;
            this.StProductDGV.Size = new System.Drawing.Size(691, 345);
            this.StProductDGV.TabIndex = 0;
            // 
            // OrdersTab
            // 
            this.OrdersTab.Controls.Add(this.lbxAlerts);
            this.OrdersTab.Controls.Add(this.gbSetLimit);
            this.OrdersTab.Controls.Add(this.gbRestockView);
            this.OrdersTab.Controls.Add(this.btnChangeAmount);
            this.OrdersTab.Controls.Add(this.lblOrders);
            this.OrdersTab.Controls.Add(this.btnCancelOrder);
            this.OrdersTab.Controls.Add(this.lblAlerts);
            this.OrdersTab.Controls.Add(this.btnChangeStatus);
            this.OrdersTab.Controls.Add(this.btnRemoveLimit);
            this.OrdersTab.Controls.Add(this.btnMakeOrder);
            this.OrdersTab.Controls.Add(this.dgvOrders);
            this.OrdersTab.Location = new System.Drawing.Point(4, 29);
            this.OrdersTab.Margin = new System.Windows.Forms.Padding(2);
            this.OrdersTab.Name = "OrdersTab";
            this.OrdersTab.Size = new System.Drawing.Size(1375, 577);
            this.OrdersTab.TabIndex = 4;
            this.OrdersTab.Text = "Orders";
            this.OrdersTab.UseVisualStyleBackColor = true;
            // 
            // lbxAlerts
            // 
            this.lbxAlerts.FormattingEnabled = true;
            this.lbxAlerts.ItemHeight = 20;
            this.lbxAlerts.Location = new System.Drawing.Point(13, 74);
            this.lbxAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.lbxAlerts.Name = "lbxAlerts";
            this.lbxAlerts.Size = new System.Drawing.Size(317, 384);
            this.lbxAlerts.TabIndex = 18;
            // 
            // gbSetLimit
            // 
            this.gbSetLimit.Controls.Add(this.btnSetLimit);
            this.gbSetLimit.Controls.Add(this.tbLimitId);
            this.gbSetLimit.Controls.Add(this.lblSetMinStock);
            this.gbSetLimit.Controls.Add(this.nUPMinStock);
            this.gbSetLimit.Controls.Add(this.lbSetLimitId);
            this.gbSetLimit.Location = new System.Drawing.Point(949, 335);
            this.gbSetLimit.Margin = new System.Windows.Forms.Padding(2);
            this.gbSetLimit.Name = "gbSetLimit";
            this.gbSetLimit.Padding = new System.Windows.Forms.Padding(2);
            this.gbSetLimit.Size = new System.Drawing.Size(337, 218);
            this.gbSetLimit.TabIndex = 17;
            this.gbSetLimit.TabStop = false;
            this.gbSetLimit.Text = "Set Item Limit";
            // 
            // btnSetLimit
            // 
            this.btnSetLimit.Location = new System.Drawing.Point(106, 164);
            this.btnSetLimit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetLimit.Name = "btnSetLimit";
            this.btnSetLimit.Size = new System.Drawing.Size(119, 36);
            this.btnSetLimit.TabIndex = 11;
            this.btnSetLimit.Text = "Set";
            this.btnSetLimit.UseVisualStyleBackColor = true;
            this.btnSetLimit.Click += new System.EventHandler(this.btnSetLimit_Click);
            // 
            // tbLimitId
            // 
            this.tbLimitId.Location = new System.Drawing.Point(64, 96);
            this.tbLimitId.Margin = new System.Windows.Forms.Padding(2);
            this.tbLimitId.Name = "tbLimitId";
            this.tbLimitId.Size = new System.Drawing.Size(68, 26);
            this.tbLimitId.TabIndex = 10;
            // 
            // lblSetMinStock
            // 
            this.lblSetMinStock.AutoSize = true;
            this.lblSetMinStock.Location = new System.Drawing.Point(186, 54);
            this.lblSetMinStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSetMinStock.Name = "lblSetMinStock";
            this.lblSetMinStock.Size = new System.Drawing.Size(83, 20);
            this.lblSetMinStock.TabIndex = 15;
            this.lblSetMinStock.Text = "Min. Stock";
            // 
            // nUPMinStock
            // 
            this.nUPMinStock.Location = new System.Drawing.Point(190, 97);
            this.nUPMinStock.Margin = new System.Windows.Forms.Padding(2);
            this.nUPMinStock.Name = "nUPMinStock";
            this.nUPMinStock.Size = new System.Drawing.Size(82, 26);
            this.nUPMinStock.TabIndex = 12;
            // 
            // lbSetLimitId
            // 
            this.lbSetLimitId.AutoSize = true;
            this.lbSetLimitId.Location = new System.Drawing.Point(60, 53);
            this.lbSetLimitId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSetLimitId.Name = "lbSetLimitId";
            this.lbSetLimitId.Size = new System.Drawing.Size(62, 20);
            this.lbSetLimitId.TabIndex = 14;
            this.lbSetLimitId.Text = "Item ID";
            // 
            // gbRestockView
            // 
            this.gbRestockView.Controls.Add(this.rbSortAlertsByPriority);
            this.gbRestockView.Controls.Add(this.rbSortAlertsByID);
            this.gbRestockView.Controls.Add(this.lblSortAlerts);
            this.gbRestockView.Controls.Add(this.cbShowCompleted);
            this.gbRestockView.Location = new System.Drawing.Point(949, 53);
            this.gbRestockView.Margin = new System.Windows.Forms.Padding(2);
            this.gbRestockView.Name = "gbRestockView";
            this.gbRestockView.Padding = new System.Windows.Forms.Padding(2);
            this.gbRestockView.Size = new System.Drawing.Size(337, 254);
            this.gbRestockView.TabIndex = 16;
            this.gbRestockView.TabStop = false;
            this.gbRestockView.Text = "Viewing options";
            // 
            // rbSortAlertsByPriority
            // 
            this.rbSortAlertsByPriority.AutoSize = true;
            this.rbSortAlertsByPriority.Checked = true;
            this.rbSortAlertsByPriority.Location = new System.Drawing.Point(40, 91);
            this.rbSortAlertsByPriority.Margin = new System.Windows.Forms.Padding(2);
            this.rbSortAlertsByPriority.Name = "rbSortAlertsByPriority";
            this.rbSortAlertsByPriority.Size = new System.Drawing.Size(74, 24);
            this.rbSortAlertsByPriority.TabIndex = 0;
            this.rbSortAlertsByPriority.TabStop = true;
            this.rbSortAlertsByPriority.Text = "Priority";
            this.rbSortAlertsByPriority.UseVisualStyleBackColor = true;
            this.rbSortAlertsByPriority.CheckedChanged += new System.EventHandler(this.rbPriority_CheckedChanged);
            // 
            // rbSortAlertsByID
            // 
            this.rbSortAlertsByID.AutoSize = true;
            this.rbSortAlertsByID.Location = new System.Drawing.Point(40, 133);
            this.rbSortAlertsByID.Margin = new System.Windows.Forms.Padding(2);
            this.rbSortAlertsByID.Name = "rbSortAlertsByID";
            this.rbSortAlertsByID.Size = new System.Drawing.Size(44, 24);
            this.rbSortAlertsByID.TabIndex = 1;
            this.rbSortAlertsByID.Text = "ID";
            this.rbSortAlertsByID.UseVisualStyleBackColor = true;
            this.rbSortAlertsByID.CheckedChanged += new System.EventHandler(this.rbTime_CheckedChanged);
            // 
            // lblSortAlerts
            // 
            this.lblSortAlerts.AutoSize = true;
            this.lblSortAlerts.Location = new System.Drawing.Point(36, 57);
            this.lblSortAlerts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSortAlerts.Name = "lblSortAlerts";
            this.lblSortAlerts.Size = new System.Drawing.Size(110, 20);
            this.lblSortAlerts.TabIndex = 2;
            this.lblSortAlerts.Text = "Sort Alerts By:";
            // 
            // cbShowCompleted
            // 
            this.cbShowCompleted.AutoSize = true;
            this.cbShowCompleted.Location = new System.Drawing.Point(40, 195);
            this.cbShowCompleted.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowCompleted.Name = "cbShowCompleted";
            this.cbShowCompleted.Size = new System.Drawing.Size(195, 24);
            this.cbShowCompleted.TabIndex = 3;
            this.cbShowCompleted.Text = "Show completed orders";
            this.cbShowCompleted.UseVisualStyleBackColor = true;
            this.cbShowCompleted.CheckedChanged += new System.EventHandler(this.cbShowCompleted_CheckedChanged);
            // 
            // btnChangeAmount
            // 
            this.btnChangeAmount.Location = new System.Drawing.Point(545, 467);
            this.btnChangeAmount.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeAmount.Name = "btnChangeAmount";
            this.btnChangeAmount.Size = new System.Drawing.Size(137, 100);
            this.btnChangeAmount.TabIndex = 8;
            this.btnChangeAmount.Text = "Change Amount";
            this.btnChangeAmount.UseVisualStyleBackColor = true;
            this.btnChangeAmount.Click += new System.EventHandler(this.btnChangeAmount_Click);
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Location = new System.Drawing.Point(583, 29);
            this.lblOrders.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(57, 20);
            this.lblOrders.TabIndex = 7;
            this.lblOrders.Text = "Orders";
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(701, 467);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(126, 100);
            this.btnCancelOrder.TabIndex = 4;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // lblAlerts
            // 
            this.lblAlerts.AutoSize = true;
            this.lblAlerts.Location = new System.Drawing.Point(141, 29);
            this.lblAlerts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlerts.Name = "lblAlerts";
            this.lblAlerts.Size = new System.Drawing.Size(50, 20);
            this.lblAlerts.TabIndex = 6;
            this.lblAlerts.Text = "Alerts";
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Location = new System.Drawing.Point(400, 467);
            this.btnChangeStatus.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(127, 100);
            this.btnChangeStatus.TabIndex = 5;
            this.btnChangeStatus.Text = "Toggle Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnRemoveLimit
            // 
            this.btnRemoveLimit.Location = new System.Drawing.Point(170, 467);
            this.btnRemoveLimit.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveLimit.Name = "btnRemoveLimit";
            this.btnRemoveLimit.Size = new System.Drawing.Size(160, 100);
            this.btnRemoveLimit.TabIndex = 3;
            this.btnRemoveLimit.Text = "Remove Limit";
            this.btnRemoveLimit.UseVisualStyleBackColor = true;
            this.btnRemoveLimit.Click += new System.EventHandler(this.btnRemoveLimit_Click);
            // 
            // btnMakeOrder
            // 
            this.btnMakeOrder.Location = new System.Drawing.Point(13, 467);
            this.btnMakeOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnMakeOrder.Name = "btnMakeOrder";
            this.btnMakeOrder.Size = new System.Drawing.Size(153, 100);
            this.btnMakeOrder.TabIndex = 2;
            this.btnMakeOrder.Text = "Make Order";
            this.btnMakeOrder.UseVisualStyleBackColor = true;
            this.btnMakeOrder.Click += new System.EventHandler(this.btnMakeOrder_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(400, 74);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(427, 384);
            this.dgvOrders.TabIndex = 1;
            // 
            // AutoScheduleGeneratorBtn
            // 
            this.AutoScheduleGeneratorBtn.Location = new System.Drawing.Point(1226, 108);
            this.AutoScheduleGeneratorBtn.Name = "AutoScheduleGeneratorBtn";
            this.AutoScheduleGeneratorBtn.Size = new System.Drawing.Size(137, 81);
            this.AutoScheduleGeneratorBtn.TabIndex = 2;
            this.AutoScheduleGeneratorBtn.Text = "Generate Next Week Schedule";
            this.AutoScheduleGeneratorBtn.UseVisualStyleBackColor = true;
            this.AutoScheduleGeneratorBtn.Click += new System.EventHandler(this.AutoScheduleGeneratorBtn_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1392, 655);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.lblWelcome);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainScreen";
            this.Text = "Hello";
            this.Tabs.ResumeLayout(false);
            this.ScheduleTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.EmployeesTab.ResumeLayout(false);
            this.EmployeesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.DepotTab.ResumeLayout(false);
            this.DepotTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepot)).EndInit();
            this.StatisticsTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StEmployeeDGV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StProductDGV)).EndInit();
            this.OrdersTab.ResumeLayout(false);
            this.OrdersTab.PerformLayout();
            this.gbSetLimit.ResumeLayout(false);
            this.gbSetLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUPMinStock)).EndInit();
            this.gbRestockView.ResumeLayout(false);
            this.gbRestockView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage ScheduleTab;
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
        private System.Windows.Forms.DataGridView StEmployeeDGV;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMatrix;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMonday;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSunday;
        private System.Windows.Forms.Button btnSaturday;
        private System.Windows.Forms.Button btnFriday;
        private System.Windows.Forms.Button btnThursday;
        private System.Windows.Forms.Button btnWednesday;
        private System.Windows.Forms.Button btnTuesday;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnPreviousMonth;
        private System.Windows.Forms.TabPage OrdersTab;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnRemoveLimit;
        private System.Windows.Forms.Button btnMakeOrder;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblAlerts;
        private System.Windows.Forms.Button btnChangeAmount;
        private System.Windows.Forms.CheckBox cbShowCompleted;
        private System.Windows.Forms.Label lblSortAlerts;
        private System.Windows.Forms.RadioButton rbSortAlertsByID;
        private System.Windows.Forms.RadioButton rbSortAlertsByPriority;
        private System.Windows.Forms.Label lbSetLimitId;
        private System.Windows.Forms.NumericUpDown nUPMinStock;
        private System.Windows.Forms.Button btnSetLimit;
        private System.Windows.Forms.TextBox tbLimitId;
        private System.Windows.Forms.GroupBox gbRestockView;
        private System.Windows.Forms.Label lblSetMinStock;
        private System.Windows.Forms.GroupBox gbSetLimit;
        private System.Windows.Forms.ListBox lbxAlerts;
        private System.Windows.Forms.ComboBox XAxisCB;
        private System.Windows.Forms.ComboBox YAxisCB;
        private System.Windows.Forms.ComboBox PiechartCB;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button AutoScheduleGeneratorBtn;
    }
}