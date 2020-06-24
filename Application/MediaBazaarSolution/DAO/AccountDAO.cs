using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MediaBazaarSolution.Helper;
using MediaBazaarSolution.DTO;
using Microsoft.VisualBasic.ApplicationServices;

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

        private void LoadAll(string userType)
        {
            //string query = "SELECT dp.item_id, dp.item_name, dp.amount,c.category_name, dp.price " +
            //    "FROM `depot_item` AS dp " +
            //    "LEFT JOIN category AS c " +
            //    "ON dp.category_id = c.category_id";

            //List<Item> itemList = new List<Item>();

            //DataTable data = DataProvider.Instance.ExecuteQuery(query);


            //foreach (DataRow row in data.Rows)
            //{
            //    Item item = new Item(row);
            //    itemList.Add(item);
            //}


            //return itemList;

            List<int> indecis = new List<int>();
            List<string> categories = new List<string>();
            List<string> employees = new List<string>();
            List<Mail> allMails = new List<Mail>();
            List<Alert> alerts = new List<Alert>();
            List<Order> orders = new List<Order>();

            switch (userType)
            {
                case "Employee":

                    break;
            }

        }
    }
}