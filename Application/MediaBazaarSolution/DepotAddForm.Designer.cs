﻿namespace MediaBazaarSolution
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnApplyChangesToDepot = new System.Windows.Forms.Button();
            this.tbxPrice = new System.Windows.Forms.TextBox();
            this.tbxInStock = new System.Windows.Forms.TextBox();
            this.tbxCategory = new System.Windows.Forms.TextBox();
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblinStock = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 46);
            this.label2.TabIndex = 27;
            this.label2.Text = "You are <User>";
            // 
            // btnApplyChangesToDepot
            // 
            this.btnApplyChangesToDepot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyChangesToDepot.Location = new System.Drawing.Point(278, 413);
            this.btnApplyChangesToDepot.Name = "btnApplyChangesToDepot";
            this.btnApplyChangesToDepot.Size = new System.Drawing.Size(118, 52);
            this.btnApplyChangesToDepot.TabIndex = 26;
            this.btnApplyChangesToDepot.Text = "Add Item";
            this.btnApplyChangesToDepot.UseVisualStyleBackColor = true;
            this.btnApplyChangesToDepot.Click += new System.EventHandler(this.btnApplyChangesToDepot_Click);
            // 
            // tbxPrice
            // 
            this.tbxPrice.Location = new System.Drawing.Point(104, 431);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(110, 22);
            this.tbxPrice.TabIndex = 25;
            // 
            // tbxInStock
            // 
            this.tbxInStock.Location = new System.Drawing.Point(104, 345);
            this.tbxInStock.Name = "tbxInStock";
            this.tbxInStock.Size = new System.Drawing.Size(110, 22);
            this.tbxInStock.TabIndex = 24;
            // 
            // tbxCategory
            // 
            this.tbxCategory.Location = new System.Drawing.Point(104, 248);
            this.tbxCategory.Name = "tbxCategory";
            this.tbxCategory.Size = new System.Drawing.Size(110, 22);
            this.tbxCategory.TabIndex = 23;
            // 
            // tbxItemName
            // 
            this.tbxItemName.Location = new System.Drawing.Point(104, 150);
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(110, 22);
            this.tbxItemName.TabIndex = 22;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(125, 388);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(61, 25);
            this.lblPrice.TabIndex = 21;
            this.lblPrice.Text = "Price";
            // 
            // lblinStock
            // 
            this.lblinStock.AutoSize = true;
            this.lblinStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinStock.Location = new System.Drawing.Point(112, 297);
            this.lblinStock.Name = "lblinStock";
            this.lblinStock.Size = new System.Drawing.Size(91, 25);
            this.lblinStock.TabIndex = 20;
            this.lblinStock.Text = "In Stock";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(99, 197);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 25);
            this.lblDescription.TabIndex = 19;
            this.lblDescription.Text = "Category";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(99, 107);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(115, 25);
            this.lblItemName.TabIndex = 18;
            this.lblItemName.Text = "Item Name";
            // 
            // DepotAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 499);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnApplyChangesToDepot);
            this.Controls.Add(this.tbxPrice);
            this.Controls.Add(this.tbxInStock);
            this.Controls.Add(this.tbxCategory);
            this.Controls.Add(this.tbxItemName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblinStock);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblItemName);
            this.Name = "DepotAddForm";
            this.Text = "DepotAddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DepotAddForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApplyChangesToDepot;
        private System.Windows.Forms.TextBox tbxPrice;
        private System.Windows.Forms.TextBox tbxInStock;
        private System.Windows.Forms.TextBox tbxCategory;
        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblinStock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblItemName;
    }
}