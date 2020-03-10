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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.ScheduleTab = new System.Windows.Forms.TabPage();
            this.EmployeesTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HWageCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepotTab = new System.Windows.Forms.TabPage();
            this.StatisticsTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Tabs.SuspendLayout();
            this.EmployeesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.StatisticsTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.CausesValidation = false;
            this.Tabs.Controls.Add(this.ScheduleTab);
            this.Tabs.Controls.Add(this.EmployeesTab);
            this.Tabs.Controls.Add(this.DepotTab);
            this.Tabs.Controls.Add(this.StatisticsTab);
            this.Tabs.Location = new System.Drawing.Point(13, 13);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(997, 485);
            this.Tabs.TabIndex = 0;
            // 
            // ScheduleTab
            // 
            this.ScheduleTab.BackColor = System.Drawing.Color.Transparent;
            this.ScheduleTab.Location = new System.Drawing.Point(4, 25);
            this.ScheduleTab.Name = "ScheduleTab";
            this.ScheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScheduleTab.Size = new System.Drawing.Size(989, 456);
            this.ScheduleTab.TabIndex = 0;
            this.ScheduleTab.Text = "Schedule";
            // 
            // EmployeesTab
            // 
            this.EmployeesTab.Controls.Add(this.dataGridView1);
            this.EmployeesTab.Location = new System.Drawing.Point(4, 25);
            this.EmployeesTab.Name = "EmployeesTab";
            this.EmployeesTab.Padding = new System.Windows.Forms.Padding(3);
            this.EmployeesTab.Size = new System.Drawing.Size(989, 456);
            this.EmployeesTab.TabIndex = 1;
            this.EmployeesTab.Text = "Employees";
            this.EmployeesTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.FNameCol,
            this.LNameCol,
            this.HWageCol,
            this.AddressCol});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(983, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.Width = 125;
            // 
            // FNameCol
            // 
            this.FNameCol.HeaderText = "First Name";
            this.FNameCol.MinimumWidth = 6;
            this.FNameCol.Name = "FNameCol";
            this.FNameCol.Width = 125;
            // 
            // LNameCol
            // 
            this.LNameCol.HeaderText = "Last Name";
            this.LNameCol.MinimumWidth = 6;
            this.LNameCol.Name = "LNameCol";
            this.LNameCol.Width = 125;
            // 
            // HWageCol
            // 
            this.HWageCol.HeaderText = "HWage";
            this.HWageCol.MinimumWidth = 6;
            this.HWageCol.Name = "HWageCol";
            this.HWageCol.Width = 125;
            // 
            // AddressCol
            // 
            this.AddressCol.HeaderText = "Address";
            this.AddressCol.MinimumWidth = 6;
            this.AddressCol.Name = "AddressCol";
            this.AddressCol.Width = 125;
            // 
            // DepotTab
            // 
            this.DepotTab.Location = new System.Drawing.Point(4, 25);
            this.DepotTab.Name = "DepotTab";
            this.DepotTab.Padding = new System.Windows.Forms.Padding(3);
            this.DepotTab.Size = new System.Drawing.Size(989, 456);
            this.DepotTab.TabIndex = 2;
            this.DepotTab.Text = "Depot";
            this.DepotTab.UseVisualStyleBackColor = true;
            // 
            // StatisticsTab
            // 
            this.StatisticsTab.Controls.Add(this.tabControl1);
            this.StatisticsTab.Location = new System.Drawing.Point(4, 25);
            this.StatisticsTab.Name = "StatisticsTab";
            this.StatisticsTab.Padding = new System.Windows.Forms.Padding(3);
            this.StatisticsTab.Size = new System.Drawing.Size(989, 456);
            this.StatisticsTab.TabIndex = 3;
            this.StatisticsTab.Text = "Statistics";
            this.StatisticsTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(977, 447);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(969, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(969, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(963, 412);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(963, 412);
            this.dataGridView3.TabIndex = 0;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 510);
            this.Controls.Add(this.Tabs);
            this.Name = "MainScreen";
            this.Text = "Hello";
            this.Tabs.ResumeLayout(false);
            this.EmployeesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.StatisticsTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage ScheduleTab;
        private System.Windows.Forms.TabPage EmployeesTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage DepotTab;
        private System.Windows.Forms.TabPage StatisticsTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HWageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressCol;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}