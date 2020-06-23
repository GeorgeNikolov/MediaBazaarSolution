using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MediaBazaarSolution.Helper;
using MediaBazaarSolution.DTO;

namespace MediaBazaarSolution.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }

                return AccountDAO.instance;
            }

            private set
            {
                AccountDAO.instance = value;
            }
        }

        private AccountDAO() { }

        public bool LoginValid(string username, string password)
        {
            string hashedPassword = MD5.GenerateMD5(password);
            string query = "SELECT * FROM employee WHERE username = @username AND password = @password ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, hashedPassword });

            return result.Rows.Count > 0;
        }
        
        public string GetUserFirstName(string username, string password)
        {
            string hashedPassword = MD5.GenerateMD5(password);
            string query = "SELECT first_name FROM employee WHERE username = @username AND password = @password AND employee_type = 'admin'";

            return DataProvider.Instance.ExecuteScalar(query, new object[] { username, hashedPassword }).ToString();
        }

        public int GetAdminID(string username, string password)
        {
            string hashedPassword = MD5.GenerateMD5(password);
            string query = "SELECT employee_id FROM employee WHERE username = @username AND password = @password AND employee_type = 'admin'";

            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { username, hashedPassword });
        }

        public Account GetAccount(string username, string password)
        {
            string hashedPassword = MD5.GenerateMD5(password);
            string query = "SELECT * FROM employee WHERE username = @username AND password = @password";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username, hashedPassword });
            Account account = new Account(data.Rows[0]);
            return account;
        }
    }
}
