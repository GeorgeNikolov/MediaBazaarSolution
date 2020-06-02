using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string query = "SELECT d.item_id, d.amount, l.limit FROM depot_item as d, limits as l" +
                           "WHERE d.item_id = l.item_id AND d.amount <= l.limit";

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
            string query = "SELECT * FROM orders ";
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

        public bool AddOrder(int item_id, int amount)
        {
            string query = "INSERT INTO orders(item_id, amount, status)" +
                           "VALUES( @item_id , @amount, 'incomplete' )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { item_id, amount, "incomplete" }) > 0;
        }

        public bool AddAlert(int item_id)
        { //Validate if alert is real (if stock < min_stock)
            string query = "INSERT INTO alerts(item_id, stock, min_stock , priority)" +
                           "VALUES( @item_id , (SELECT amount FROM depot_item WHERE item_id = @item_id ), (SELECT min_stock FROM limits WHERE item_id= @item_id ))";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { item_id }) > 0;
        }

        public bool AddLimit(int item_id, int limit)
        {
            string query = "INSERT into limits( item_id, limit)" +
                           "VALUES( @item_id, @limit)";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { item_id, limit })> 0;
        }

    }
}
