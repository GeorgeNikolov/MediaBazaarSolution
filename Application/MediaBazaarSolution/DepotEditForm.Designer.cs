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
            this.NameTB = new System.Windows.Forms.TextBox();
            this.lblFName = new System.Windows.Forms.Label();
            this.AmountTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CategoryCB = new System.Windows.Forms.ComboBox();
            this.SaveChangesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(38, 67);
            this.NameTB.Margin = new System.Windows.Forms.Padding(2);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(188, 20);
            this.NameTB.TabIndex = 10;
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(35, 47);
            this.lblFName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(35, 13);
            this.lblFName.TabIndex = 9;
            this.lblFName.Text = "Name";
            // 
            // AmountTB
            // 
            this.AmountTB.Location = new System.Drawing.Point(247, 67);
            this.AmountTB.Margin = new System.Windows.Forms.Padding(2);
            this.AmountTB.Name = "AmountTB";
            this.AmountTB.Size = new System.Drawing.Size(194, 20);
            this.AmountTB.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Amount";
            // 
            // PriceTB
            // 
            this.PriceTB.Location = new System.Drawing.Point(38, 151);
            this.PriceTB.Margin = new System.Windows.Forms.Padding(2);
            this.PriceTB.Name = "PriceTB";
            this.PriceTB.Size = new System.Drawing.Size(77, 20);
            this.PriceTB.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Category";
            // 
            // CategoryCB
            // 
            this.CategoryCB.FormattingEnabled = true;
            this.CategoryCB.Location = new System.Drawing.Point(247, 151);
            this.CategoryCB.Name = "CategoryCB";
            this.CategoryCB.Size = new System.Drawing.Size(121, 21);
            this.CategoryCB.TabIndex = 16;
            // 
            // SaveChangesBtn
            // 
            this.SaveChangesBtn.Location = new System.Drawing.Point(117, 251);
            this.SaveChangesBtn.Name = "SaveChangesBtn";
            this.SaveChangesBtn.Size = new System.Drawing.Size(238, 48);
            this.SaveChangesBtn.TabIndex = 17;
            this.SaveChangesBtn.Text = "Save Changes";
            this.SaveChangesBtn.UseVisualStyleBackColor = true;
            this.SaveChangesBtn.Click += new System.EventHandler(this.SaveChangesBtn_Click);
            // 
            // DepotEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 328);
            this.Controls.Add(this.SaveChangesBtn);
            this.Controls.Add(this.CategoryCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PriceTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AmountTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.lblFName);
            this.Name = "DepotEditForm";
            this.Text = "DepotEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.TextBox AmountTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PriceTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CategoryCB;
        private System.Windows.Forms.Button SaveChangesBtn;
    }
}