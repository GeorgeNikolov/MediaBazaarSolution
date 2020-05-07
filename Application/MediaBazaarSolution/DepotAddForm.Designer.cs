namespace MediaBazaarSolution
{
    partial class DepotAddForm
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
            this.lblDepotAddFormUser = new System.Windows.Forms.Label();
            this.btnApplyChangesToDepot = new System.Windows.Forms.Button();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.tbxInStock = new System.Windows.Forms.TextBox();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblinStock = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblDepotAddFormUser
            // 
            this.lblDepotAddFormUser.AutoSize = true;
            this.lblDepotAddFormUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepotAddFormUser.Location = new System.Drawing.Point(78, 9);
            this.lblDepotAddFormUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepotAddFormUser.Name = "lblDepotAddFormUser";
            this.lblDepotAddFormUser.Size = new System.Drawing.Size(314, 46);
            this.lblDepotAddFormUser.TabIndex = 27;
            this.lblDepotAddFormUser.Text = "You are <User>";
            // 
            // btnApplyChangesToDepot
            // 
            this.btnApplyChangesToDepot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToDepot.Location = new System.Drawing.Point(187, 496);
            this.btnApplyChangesToDepot.Name = "btnApplyChangesToDepot";
            this.btnApplyChangesToDepot.Size = new System.Drawing.Size(118, 52);
            this.btnApplyChangesToDepot.TabIndex = 26;
            this.btnApplyChangesToDepot.Text = "Add Item";
            this.btnApplyChangesToDepot.UseVisualStyleBackColor = true;
            this.btnApplyChangesToDepot.Click += new System.EventHandler(this.btnApplyChangesToDepot_Click);
            // 
            // tbxPrice
            // 
            this.tbxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPrice.Location = new System.Drawing.Point(314, 430);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(78, 30);
            this.tbxPrice.TabIndex = 25;
            // 
            // tbxInStock
            // 
            this.tbxInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInStock.Location = new System.Drawing.Point(86, 430);
            this.tbxInStock.Name = "tbxInStock";
            this.tbxInStock.Size = new System.Drawing.Size(86, 30);
            this.tbxInStock.TabIndex = 24;
            // 
            // tbxItemName
            // 
            this.tbxItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxItemName.Location = new System.Drawing.Point(156, 160);
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(163, 30);
            this.tbxItemName.TabIndex = 22;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(322, 388);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(61, 25);
            this.lblPrice.TabIndex = 21;
            this.lblPrice.Text = "Price";
            // 
            // lblinStock
            // 
            this.lblinStock.AutoSize = true;
            this.lblinStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinStock.Location = new System.Drawing.Point(81, 388);
            this.lblinStock.Name = "lblinStock";
            this.lblinStock.Size = new System.Drawing.Size(91, 25);
            this.lblinStock.TabIndex = 20;
            this.lblinStock.Text = "In Stock";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(182, 243);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 25);
            this.lblDescription.TabIndex = 19;
            this.lblDescription.Text = "Category";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(182, 106);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(115, 25);
            this.lblItemName.TabIndex = 18;
            this.lblItemName.Text = "Item Name";
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(74, 285);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(309, 33);
            this.cbxCategory.TabIndex = 28;
            // 
            // DepotAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 597);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.lblDepotAddFormUser);
            this.Controls.Add(this.btnApplyChangesToDepot);
            this.Controls.Add(this.tbxPrice);
            this.Controls.Add(this.tbxInStock);
            this.Controls.Add(this.tbxItemName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblinStock);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblItemName);
            this.Name = "DepotAddForm";
            this.Text = "DepotAddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DepotAddForm_FormClosing);
            this.Load += new System.EventHandler(this.DepotAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDepotAddFormUser;
        private System.Windows.Forms.Button btnApplyChangesToDepot;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.TextBox tbxInStock;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblinStock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.ComboBox cbxCategory;
    }
}