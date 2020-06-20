﻿using System;
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
    
        public List<Alert> LoadAlerts(bool sortByPriority)
        {
            string query = "SELECT dp.item_id as item_id , dp.amount as stock ,l.min_stock as min_stock " +
                    "FROM `depot_item` AS dp " +
                    "LEFT JOIN limits AS l " +
                    "ON dp.item_id = l.item_id " +
                    "WHERE dp.item_id = l.item_id ";

            if (sortByPriority)
            {
                query += "ORDER BY priority";
            }
            else
            {
                query += "ORDER BY item_id";
            }
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
            query += "WHERE status = 'incomplete' ";

            query += "ORDER BY item_id";

            List<Order> orderList = new List<Order>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);


            foreach (DataRow row in data.Rows)
            {
                Order order = new Order(row);
                orderList.Add(order);
            }


            return orderList;
        }

        public bool AddOrder(int item_id, int amount, string status)
        {
            string query = "INSERT INTO orders(item_id, amount, status) " +
                           "VALUES( @item_id , @amount , @status )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { item_id, amount, status }) > 0;
        }


        public bool AddLimit(int item_id, int min_stock)
        {
            bool hasLimit = HasLimit(item_id);
            if (hasLimit)
            {
                UpdateLimit(item_id, min_stock);
                return true;
            }
            else
            {
                string query = "INSERT into limits( item_id, min_stock) " +
                           "VALUES( @item_id , @min_stock )";
                return DataProvider.Instance.ExecuteNonQuery(query, new object[] { item_id, min_stock }) > 0;
            }
            return false;
        }

        private bool HasLimit(int id)
        {
            string query = "SELECT COUNT(item_id) " +
                           " FROM limits WHERE item_id = " + id;
            if((int)DataProvider.Instance.ExecuteScalar(query) > 0)
            {
                return true;
            }
            return false;
        }

        private bool UpdateLimit(int id, int valueToBeChanged)
        {      
                string query = "UPDATE limits SET min_stock = @valueToBeChanged WHERE item_id = " + id;
                return DataProvider.Instance.ExecuteNonQuery(query, new object[] { valueToBeChanged }) > 0;    
        }

        public bool DeleteLimit(int id)
        {
            string query = "DELETE FROM limits WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool DeleteOrder(int id)
        {
            string query = "DELETE FROM orders WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool UpdateOrderStatus(int id, string newStatus)
        {
            string query = $"UPDATE orders SET status = '{newStatus}' WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool UpdateAmount(int id, int amount)
        {
            string query = "UPDATE orders SET amount = @amount WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { amount }) > 0;
        }
    }
}
