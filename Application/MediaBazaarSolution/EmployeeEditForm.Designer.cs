namespace MediaBazaarSolution
{
    partial class EmployeeEditForm
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
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.tbxRate = new System.Windows.Forms.TextBox();
            this.tbxPhone = new System.Windows.Forms.TextBox();
            this.tbxLName = new System.Windows.Forms.TextBox();
            this.tbxUName = new System.Windows.Forms.TextBox();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.tbxFName = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblUName = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cbxUserType = new System.Windows.Forms.ComboBox();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(156, 302);
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.ReadOnly = true;
            this.tbxEmail.Size = new System.Drawing.Size(209, 22);
            this.tbxEmail.TabIndex = 38;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(214, 271);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(98, 17);
            this.lblEmail.TabIndex = 37;
            this.lblEmail.Text = "Email Address";
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(156, 444);
            this.btnEditEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(224, 49);
            this.btnEditEmployee.TabIndex = 36;
            this.btnEditEmployee.Text = "Save Changes";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // tbxRate
            // 
            this.tbxRate.Location = new System.Drawing.Point(348, 389);
            this.tbxRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxRate.Name = "tbxRate";
            this.tbxRate.Size = new System.Drawing.Size(101, 22);
            this.tbxRate.TabIndex = 35;
            // 
            // tbxPhone
            // 
            this.tbxPhone.Location = new System.Drawing.Point(348, 121);
            this.tbxPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.ReadOnly = true;
            this.tbxPhone.Size = new System.Drawing.Size(101, 22);
            this.tbxPhone.TabIndex = 34;
            // 
            // tbxLName
            // 
            this.tbxLName.Location = new System.Drawing.Point(348, 48);
            this.tbxLName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxLName.Name = "tbxLName";
            this.tbxLName.Size = new System.Drawing.Size(101, 22);
            this.tbxLName.TabIndex = 33;
            // 
            // tbxUName
            // 
            this.tbxUName.Location = new System.Drawing.Point(88, 209);
            this.tbxUName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxUName.Name = "tbxUName";
            this.tbxUName.Size = new System.Drawing.Size(101, 22);
            this.tbxUName.TabIndex = 31;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(88, 121);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.ReadOnly = true;
            this.tbxAddress.Size = new System.Drawing.Size(101, 22);
            this.tbxAddress.TabIndex = 30;
            // 
            // tbxFName
            // 
            this.tbxFName.Location = new System.Drawing.Point(87, 48);
            this.tbxFName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxFName.Name = "tbxFName";
            this.tbxFName.Size = new System.Drawing.Size(101, 22);
            this.tbxFName.TabIndex = 29;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(344, 359);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(83, 17);
            this.lblRate.TabIndex = 28;
            this.lblRate.Text = "Hourly Rate";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(84, 96);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 17);
            this.lblAddress.TabIndex = 27;
            this.lblAddress.Text = "Address";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(86, 359);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(40, 17);
            this.lblType.TabIndex = 26;
            this.lblType.Text = "Type";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(344, 96);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 17);
            this.lblPhone.TabIndex = 25;
            this.lblPhone.Text = "Phone";
            // 
            // lblUName
            // 
            this.lblUName.AutoSize = true;
            this.lblUName.Location = new System.Drawing.Point(86, 177);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(73, 17);
            this.lblUName.TabIndex = 24;
            this.lblUName.Text = "Username";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Location = new System.Drawing.Point(344, 23);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(76, 17);
            this.lblLName.TabIndex = 23;
            this.lblLName.Text = "Last Name";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(84, 23);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(76, 17);
            this.lblFName.TabIndex = 22;
            this.lblFName.Text = "First Name";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(346, 177);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(82, 17);
            this.lblDepartment.TabIndex = 40;
            this.lblDepartment.Text = "Department";
            // 
            // cbxUserType
            // 
            this.cbxUserType.FormattingEnabled = true;
            this.cbxUserType.Location = new System.Drawing.Point(88, 389);
            this.cbxUserType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxUserType.Name = "cbxUserType";
            this.cbxUserType.Size = new System.Drawing.Size(101, 24);
            this.cbxUserType.TabIndex = 42;
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Items.AddRange(new object[] {
            "Human Resources",
            "Marketing",
            "Accounting and Finance"});
            this.cbxDepartment.Location = new System.Drawing.Point(347, 224);
            this.cbxDepartment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(101, 24);
            this.cbxDepartment.TabIndex = 43;
            // 
            // EmployeeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 530);
            this.Controls.Add(this.cbxDepartment);
            this.Controls.Add(this.cbxUserType);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnEditEmployee);
            this.Controls.Add(this.tbxRate);
            this.Controls.Add(this.tbxPhone);
            this.Controls.Add(this.tbxLName);
            this.Controls.Add(this.tbxUName);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.tbxFName);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblUName);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.lblFName);
            this.Name = "EmployeeEditForm";
            this.Text = "EmployeeEdirForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.TextBox tbxRate;
        private System.Windows.Forms.TextBox tbxPhone;
        private System.Windows.Forms.TextBox tbxLName;
        private System.Windows.Forms.TextBox tbxUName;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.TextBox tbxFName;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cbxUserType;
        private System.Windows.Forms.ComboBox cbxDepartment;
    }
}