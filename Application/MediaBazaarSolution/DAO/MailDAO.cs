using MediaBazaarSolution.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DAO
{
    public class MailDAO
    {
        private static MailDAO instance;

        public static MailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MailDAO();
                }

                return MailDAO.instance;
            }

            private set
            {
                MailDAO.instance = value;
            }
        }

        private MailDAO() { }

        public List<Mail> GetAllMails(int adminID)
        {
            string query = "SELECT * FROM mail WHERE receiver = " + adminID + " OR sender = " + adminID + " ORDER BY mail_id DESC";
            List<Mail> mailList = new List<Mail>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                Mail m = new Mail(row);
                mailList.Add(m);
            }

            return mailList;
        }

        public bool DeleteMailFromAdmin(int mailID)
        {
            string query = "UPDATE mail SET deletedFromAdmin = 1 WHERE mail_id = " + mailID;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool ChangeMailStatus(int mailID)
        {
            string query = "UPDATE mail SET status = 1 WHERE mail_id = " + mailID;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool SendMail(string subject, string content, string date, int sender, int receiver)
        {
            string query = "INSERT INTO mail SET subject = @subject , content = @content , date = @date , sender = @sender , receiver = @receiver ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { subject, content, date, sender, receiver}) > 0;
        }

        public bool DeleteMailFromAdminForever(int mailID)
        {
            string query = "UPDATE mail SET deletedFromAdminForever = 1 WHERE mail_id = " + mailID;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

    }
}
