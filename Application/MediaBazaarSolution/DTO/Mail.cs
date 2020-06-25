using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DTO
{
    public class Mail
    {
        private int iD;
        private string subject;
        private string content;
        private int sender;
        private int receiver;
        private string date;
        private int deletedFromAdmin;
        private int deletedFromAdminForever;
        private int status;

        public Mail(DataRow row)
        {
            this.ID = Convert.ToInt32(row["mail_id"]);
            this.Subject = row["subject"].ToString();
            this.Content = row["content"].ToString();
            this.Date = row["date"].ToString();
            this.DeletedFromAdmin = Convert.ToInt32(row["deletedFromAdmin"]);
            this.Status = Convert.ToInt32(row["status"]);
            this.Receiver = Convert.ToInt32(row["receiver"]);
            this.Sender = Convert.ToInt32(row["sender"]);
            this.DeletedFromAdminForever = Convert.ToInt32(row["deletedFromAdminForever"]);
        }

        public Mail(int ID, string subject, string content, int receiver, int sender, string date, int deletedFromAdmin, int status, int deletedFromAdminForever)
        {
            this.ID = ID;
            this.Subject = subject;
            this.Content = content;
            this.Receiver = receiver;
            this.Sender = sender;
            this.Date = date;
            this.DeletedFromAdmin = deletedFromAdmin;
            this.status = status;
            this.DeletedFromAdminForever = deletedFromAdminForever;
        }


        public string Subject { get => subject; set => subject = value; }
        public string Content { get => content; set => content = value; }

        public string Date { get => date; set => date = value; }
        public int DeletedFromAdmin { get => deletedFromAdmin; set => deletedFromAdmin = value; }
        public int Status { get => status; set => status = value; }
        public int Sender { get => sender; set => sender = value; }
        public int Receiver { get => receiver; set => receiver = value; }
        public int ID { get => iD; set => iD = value; }
        public int DeletedFromAdminForever { get => deletedFromAdminForever; set => deletedFromAdminForever = value; }
    }
}
