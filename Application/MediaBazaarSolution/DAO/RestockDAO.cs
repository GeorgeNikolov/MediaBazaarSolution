using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;
using MediaBazaarSolution.DTO;

namespace MediaBazaarSolution.DAO
{
    public class RestockDAO
    {
        private static RestockDAO instance;

        public static RestockDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RestockDAO();
                }

                return RestockDAO.instance;
            }

            private set
            {
                RestockDAO.instance = value;
            }
        }
            private RestockDAO() { }
    
        public List<Alert> LoadAlerts(bool sortAlertsByPriority)
        {
            string query = "SELECT * FROM alerts";
            if (sortAlertsByPriority)
                query += " ORDER BY priority";

            List<Alert> alertList = new List<Alert>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);


            foreach (DataRow row in data.Rows)
            {
                Alert alert = new Alert(row);
                alertList.Add(alert);
            }


            return alertList;
        }

        public List<Order> LoadOrders(bool showCompletedOrders)
        {
            string query = "SELECT * FROM orders";
            if(!showCompletedOrders)
            query += "WHERE status = 'incomplete'";

            List<Order> orderList = new List<Order>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);


            foreach (DataRow row in data.Rows)
            {
                Order order = new Order(row);
                orderList.Add(order);
            }


            return orderList;
        }
    }
}
