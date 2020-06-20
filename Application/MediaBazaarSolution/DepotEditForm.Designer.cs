namespace MediaBazaarSolution
{
    partial class DepotEditForm
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
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxAmountInStock = new System.Windows.Forms.TextBox();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblAmountInStock = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblEditUser = new System.Windows.Forms.Label();
            this.tbxId = new System.Windows.Forms.TextBox();
            this.lblItemId = new System.Windows.Forms.Label();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.cbxEditItemCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(89, 214);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(407, 22);
            this.tbxName.TabIndex = 0;
            // 
            // tbxAmountInStock
            // 
            this.tbxAmountInStock.Location = new System.Drawing.Point(368, 369);
            this.tbxAmountInStock.Name = "tbxAmountInStock";
            this.tbxAmountInStock.Size = new System.Drawing.Size(107, 22);
            this.tbxAmountInStock.TabIndex = 2;
            // 
            // tbxPrice
            // 
            this.tbxPrice.Location = new System.Drawing.Point(89, 369);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(100, 22);
            this.tbxPrice.TabIndex = 3;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(86, 183);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(45, 17);
            this.lblItemName.TabIndex = 4;
            this.lblItemName.Text = "Name";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(86, 250);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 17);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category";
            // 
            // lblAmountInStock
            // 
            this.lblAmountInStock.AutoSize = true;
            this.lblAmountInStock.Location = new System.Drawing.Point(365, 349);
            this.lblAmountInStock.Name = "lblAmountInStock";
            this.lblAmountInStock.Size = new System.Drawing.Size(110, 17);
            this.lblAmountInStock.TabIndex = 6;
            this.lblAmountInStock.Text = "Amount in Stock";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(91, 339);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(40, 17);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price";
            // 
            // lblEditUser
            // 
            this.lblEditUser.AutoSize = true;
            this.lblEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditUser.Location = new System.Drawing.Point(179, 37);
            this.lblEditUser.Name = "lblEditUser";
            this.lblEditUser.Size = new System.Drawing.Size(192, 29);
            this.lblEditUser.TabIndex = 8;
            this.lblEditUser.Text = "You are <user>";
            // 
            // tbxId
            // 
            this.tbxId.Location = new System.Drawing.Point(89, 133);
            this.tbxId.Name = "tbxId";
            this.tbxId.ReadOnly = true;
            this.tbxId.Size = new System.Drawing.Size(62, 22);
            this.tbxId.TabIndex = 9;
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Location = new System.Drawing.Point(86, 113);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(19, 17);
            this.lblItemId.TabIndex = 10;
            this.lblItemId.Text = "Id";
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(203, 457);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(131, 52);
            this.btnEditItem.TabIndex = 11;
            this.btnEditItem.Text = "Save Changes";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // cbxEditItemCategory
            // 
            this.cbxEditItemCategory.FormattingEnabled = true;
            this.cbxEditItemCategory.Location = new System.Drawing.Point(89, 282);
            this.cbxEditItemCategory.Name = "cbxEditItemCategory";
            this.cbxEditItemCategory.Size = new System.Drawing.Size(204, 24);
            this.cbxEditItemCategory.TabIndex = 12;
            // 
            // DepotEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 537);
            this.Controls.Add(this.cbxEditItemCategory);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.tbxId);
            this.Controls.Add(this.lblEditUser);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblAmountInStock);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.tbxPrice);
            this.Controls.Add(this.tbxAmountInStock);
            this.Controls.Add(this.tbxName);
            this.Name = "DepotEditForm";
            this.Text = "DepotEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxAmountInStock;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblAmountInStock;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblEditUser;
        private System.Windows.Forms.TextBox tbxId;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.ComboBox cbxEditItemCategory;
    }
}