using MediaBazaarSolution.DAO;
using MediaBazaarSolution.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSolution
{
    public partial class SendMail : Form
    {
        private int adminID;
        private int receiver = -1;
        private string subject = "";

        public SendMail(int adminID, int receiver = -1, string subject = "")
        {
            InitializeComponent();
            this.adminID = adminID;

            cbbxRecipient.DataSource = EmployeeDAO.Instance.GetAllEmployeesOnly();

            //This is the case for reply mail button
            if (receiver != -1 && subject != "")
            {
                this.receiver = receiver;
                this.subject = subject;

                int counter = 0;
                foreach (Employee em in cbbxRecipient.Items)
                {
                    if (em.ID == receiver)
                    {
                        cbbxRecipient.SelectedIndex = counter;
                    }
                    counter++;
                }
                tbxSubject.Text = this.subject;

                cbbxRecipient.Enabled = false;
                tbxSubject.ReadOnly = true;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            
                if (cbbxRecipient.SelectedIndex < 0)
                {
                    MessageBox.Show("Please choose a recipient!", "Missing recipient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (String.IsNullOrEmpty(tbxSubject.Text))
                {
                    MessageBox.Show("Please write the subject", "Missing subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (String.IsNullOrEmpty(rtbxContent.Text))
                {
                    MessageBox.Show("You are missing the mail content", "Missing content", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DateTime now = DateTime.Now;
                    string date = now.ToString("dd/MM/yyyy HH:mm");
                    int receiver = (cbbxRecipient.SelectedItem as Employee).ID;
                    if (MailDAO.Instance.SendMail(this.subject != ""?this.subject:tbxSubject.Text, rtbxContent.Text, date, this.adminID, receiver))
                    {
                        MessageBox.Show("Succefully sent your mail!", "Mail sent successfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                }
        }

    }
}
