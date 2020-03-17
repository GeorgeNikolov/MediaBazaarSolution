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
            this.btnSaveSchedule = new System.Windows.Forms.Button();
            this.lvAvailableWorkers = new System.Windows.Forms.ListView();
            this.clnWorkerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnWorkerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvWorkersOnShift = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available Workers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(379, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Workers on shift";
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWorker.Location = new System.Drawing.Point(44, 372);
            this.btnAddWorker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.Size = new System.Drawing.Size(180, 42);
            this.btnAddWorker.TabIndex = 4;
            this.btnAddWorker.Text = "Add Selected";
            this.btnAddWorker.UseVisualStyleBackColor = true;
            // 
            // btnRemoveWorker
            // 
            this.btnRemoveWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveWorker.Location = new System.Drawing.Point(408, 372);
            this.btnRemoveWorker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveWorker.Name = "btnRemoveWorker";
            this.btnRemoveWorker.Size = new System.Drawing.Size(204, 42);
            this.btnRemoveWorker.TabIndex = 5;
            this.btnRemoveWorker.Text = "Remove Selected";
            this.btnRemoveWorker.UseVisualStyleBackColor = true;
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSchedule.Location = new System.Drawing.Point(252, 431);
            this.btnSaveSchedule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(136, 42);
            this.btnSaveSchedule.TabIndex = 6;
            this.btnSaveSchedule.Text = "Save";
            this.btnSaveSchedule.UseVisualStyleBackColor = true;
            // 
            // lvAvailableWorkers
            // 
            this.lvAvailableWorkers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnWorkerID,
            this.clnWorkerName});
            this.lvAvailableWorkers.HideSelection = false;
            this.lvAvailableWorkers.Location = new System.Drawing.Point(44, 54);
            this.lvAvailableWorkers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvAvailableWorkers.Name = "lvAvailableWorkers";
            this.lvAvailableWorkers.Size = new System.Drawing.Size(248, 309);
            this.lvAvailableWorkers.TabIndex = 7;
            this.lvAvailableWorkers.UseCompatibleStateImageBehavior = false;
            this.lvAvailableWorkers.View = System.Windows.Forms.View.Details;
            // 
            // clnWorkerID
            // 
            this.clnWorkerID.Text = "ID";
            // 
            // clnWorkerName
            // 
            this.clnWorkerName.Text = "Name";
            this.clnWorkerName.Width = 185;
            // 
            // lvWorkersOnShift
            // 
            this.lvWorkersOnShift.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvWorkersOnShift.HideSelection = false;
            this.lvWorkersOnShift.Location = new System.Drawing.Point(363, 57);
            this.lvWorkersOnShift.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvWorkersOnShift.Name = "lvWorkersOnShift";
            this.lvWorkersOnShift.Size = new System.Drawing.Size(248, 309);
            this.lvWorkersOnShift.TabIndex = 8;
            this.lvWorkersOnShift.UseCompatibleStateImageBehavior = false;
            this.lvWorkersOnShift.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 188;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 487);
            this.Controls.Add(this.lvWorkersOnShift);
            this.Controls.Add(this.lvAvailableWorkers);
            this.Controls.Add(this.btnSaveSchedule);
            this.Controls.Add(this.btnRemoveWorker);
            this.Controls.Add(this.btnAddWorker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ScheduleForm";
            this.Text = "ScheduleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddWorker;
        private System.Windows.Forms.Button btnRemoveWorker;
        private System.Windows.Forms.Button btnSaveSchedule;
        private System.Windows.Forms.ListView lvAvailableWorkers;
        private System.Windows.Forms.ColumnHeader clnWorkerID;
        private System.Windows.Forms.ColumnHeader clnWorkerName;
        private System.Windows.Forms.ListView lvWorkersOnShift;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}