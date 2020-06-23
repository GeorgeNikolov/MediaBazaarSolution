namespace MediaBazaarSolution
{
    partial class SendMail
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
            this.tbxSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbxRecipient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbxContent = new System.Windows.Forms.RichTextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "To:";
            // 
            // tbxSubject
            // 
            this.tbxSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbxSubject.Location = new System.Drawing.Point(135, 81);
            this.tbxSubject.Name = "tbxSubject";
            this.tbxSubject.Size = new System.Drawing.Size(211, 26);
            this.tbxSubject.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject:";
            // 
            // cbbxRecipient
            // 
            this.cbbxRecipient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbxRecipient.FormattingEnabled = true;
            this.cbbxRecipient.Location = new System.Drawing.Point(135, 28);
            this.cbbxRecipient.Name = "cbbxRecipient";
            this.cbbxRecipient.Size = new System.Drawing.Size(211, 24);
            this.cbbxRecipient.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message:";
            // 
            // rtbxContent
            // 
            this.rtbxContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rtbxContent.Location = new System.Drawing.Point(17, 179);
            this.rtbxContent.Name = "rtbxContent";
            this.rtbxContent.Size = new System.Drawing.Size(351, 269);
            this.rtbxContent.TabIndex = 5;
            this.rtbxContent.Text = "";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(125, 454);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(115, 39);
            this.btnSendMessage.TabIndex = 6;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 505);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.rtbxContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbxRecipient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxSubject);
            this.Controls.Add(this.label1);
            this.Name = "SendMail";
            this.Text = "SendMail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbxRecipient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbxContent;
        private System.Windows.Forms.Button btnSendMessage;
    }
}