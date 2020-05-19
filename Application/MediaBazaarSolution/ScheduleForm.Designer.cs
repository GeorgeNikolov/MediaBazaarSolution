namespace MediaBazaarSolution
{
    partial class ScheduleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddWorker = new System.Windows.Forms.Button();
            this.btnRemoveWorker = new System.Windows.Forms.Button();
            this.lbxAvailableWorkers = new System.Windows.Forms.ListBox();
            this.lbxWorkersOnShift = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available Workers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Workers on shift";
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWorker.Location = new System.Drawing.Point(33, 302);
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.Size = new System.Drawing.Size(135, 34);
            this.btnAddWorker.TabIndex = 4;
            this.btnAddWorker.Text = "Add Selected";
            this.btnAddWorker.UseVisualStyleBackColor = true;
            this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
            // 
            // btnRemoveWorker
            // 
            this.btnRemoveWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveWorker.Location = new System.Drawing.Point(306, 302);
            this.btnRemoveWorker.Name = "btnRemoveWorker";
            this.btnRemoveWorker.Size = new System.Drawing.Size(153, 34);
            this.btnRemoveWorker.TabIndex = 5;
            this.btnRemoveWorker.Text = "Remove Selected";
            this.btnRemoveWorker.UseVisualStyleBackColor = true;
            this.btnRemoveWorker.Click += new System.EventHandler(this.btnRemoveWorker_Click);
            // 
            // lbxAvailableWorkers
            // 
            this.lbxAvailableWorkers.FormattingEnabled = true;
            this.lbxAvailableWorkers.Location = new System.Drawing.Point(33, 46);
            this.lbxAvailableWorkers.Name = "lbxAvailableWorkers";
            this.lbxAvailableWorkers.Size = new System.Drawing.Size(194, 251);
            this.lbxAvailableWorkers.TabIndex = 9;
            // 
            // lbxWorkersOnShift
            // 
            this.lbxWorkersOnShift.FormattingEnabled = true;
            this.lbxWorkersOnShift.Location = new System.Drawing.Point(274, 45);
            this.lbxWorkersOnShift.Name = "lbxWorkersOnShift";
            this.lbxWorkersOnShift.Size = new System.Drawing.Size(201, 251);
            this.lbxWorkersOnShift.TabIndex = 10;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 396);
            this.Controls.Add(this.lbxWorkersOnShift);
            this.Controls.Add(this.lbxAvailableWorkers);
            this.Controls.Add(this.btnRemoveWorker);
            this.Controls.Add(this.btnAddWorker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScheduleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddWorker;
        private System.Windows.Forms.Button btnRemoveWorker;
        private System.Windows.Forms.ListBox lbxAvailableWorkers;
        private System.Windows.Forms.ListBox lbxWorkersOnShift;
    }
}