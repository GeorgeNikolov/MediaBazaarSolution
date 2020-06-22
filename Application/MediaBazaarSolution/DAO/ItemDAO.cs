using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MediaBazaarSolution.DTO;

namespace MediaBazaarSolution.DAO
{
    public class ItemDAO
    {
        //using Singleton Design pattern 
        //this ensures that only one object of its kind exists and provides a single point of access to it for any other code
        private static ItemDAO instance;

        public static ItemDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemDAO();
                }

                return ItemDAO.instance;
            }

            private set
            {
                ItemDAO.instance = value;
            }
        }

        //set the constructor to private so that it will not be instantiated because of its protection level
        private ItemDAO() { }

        public List<Item> LoadAllItems()
        {
            string query = "SELECT dp.item_id, dp.item_name, dp.amount,c.category_name, dp.price " +
                "FROM `depot_item` AS dp " +
                "LEFT JOIN category AS c " +
                "ON dp.category_id = c.category_id";

            List<Item> itemList = new List<Item>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);


            foreach (DataRow row in data.Rows)
            {
                Item item = new Item(row);
                itemList.Add(item);
            }


            return itemList;
        }

        public List<Item> SearchItemByCategory(string categoryWanted)
        {
            List<Item> itemList = new List<Item>();


            string query = "SELECT dp.item_id, dp.item_name, dp.amount, c.category_name, dp.price " +
                    "FROM `depot_item` AS dp " +
                    "LEFT JOIN category AS c " +
                    "ON dp.category_id = c.category_id " +
                    "WHERE c.category_name = '" + categoryWanted + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Item item = new Item(row);
                itemList.Add(item);
            }

            return itemList;
        }

        public List<Item> SearchItemByID(string idAsString)
        {
            List<Item> itemList = new List<Item>();
            int idAsInt = Convert.ToInt32(idAsString);

            string query = "SELECT dp.item_id, dp.item_name, dp.amount,c.category_name, dp.price " +
                    "FROM `depot_item` AS dp " +
                    "LEFT JOIN category AS c " +
                    "ON dp.category_id = c.category_id " +
                    "WHERE dp.item_id = @item_id";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idAsInt });

            foreach (DataRow row in data.Rows)
            {
                Item item = new Item(row);
                itemList.Add(item);
            }

            return itemList;
        }

        public bool AddItemToDepot(string itemName, string category, int itemInStock, decimal price)
        {
            string query = "INSERT INTO depot_item(item_name,amount,category_id, price)" +
                           "VALUES( @itemName , @itemInStock ,(SELECT category_id FROM category WHERE category_name= @category ), @price )";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { itemName, itemInStock, category, price }) > 0;
        }

        public bool DeleteSelectedItem(int id)
        {
            string query = "DELETE FROM depot_item WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

        public bool UpdateItemName(int id, string name)
        {
            string query = "UPDATE depot_item SET item_name = @valueToBeChanged WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { name }) > 0;
        }

        public bool UpdateItemCategory(int id, string category)
        {
            string query = "UPDATE depot_item SET `category_id` = (SELECT category_id FROM category WHERE category_name = @valueToBeChanged) WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { category }) > 0;
        }

        public bool UpdateItemAmount(int id, int amount)
        {
            int oldStock;
            string oldStockQuery = "SELECT amount FROM depot_item " +
                                   "WHERE item_id = " + id;
            oldStock = (int)DataProvider.Instance.ExecuteScalar(oldStockQuery);

            string query = "UPDATE depot_item SET amount = @amount WHERE item_id = " + id;
            bool result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { amount }) > 0;
            if (result)
                AddStockHistory(id, oldStock, amount);
            return result;
        }

        public bool UpdateItemPrice(int id, decimal price)
        {
            double oldprice;
            string oldPriceQuery = "SELECT price from depot_item " +
                                   "WHERE item_id = " + id;
            oldprice = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(oldPriceQuery));

            string query = "UPDATE depot_item SET price = @valueToBeChanged WHERE item_id = " + id;
            bool result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { price }) > 0;
            if (result)
                AddPriceHistory(id, oldprice, (double)price);
            return result;
        }

        private void AddPriceHistory(int id, double oldPrice, double price)
        {
            double priceChange = price - oldPrice;
            DateTime dateNow = DateTime.Now;
            string query = "INSERT INTO price_history(item_id, price_change, timestamp) " +
                           "VALUES( @id , @priceChange , @dateNow ) ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { id, priceChange, dateNow });
        }

        private void AddStockHistory(int id, int oldStock, int stock)
        {
            int stockChange = stock - oldStock;
            DateTime dateNow = DateTime.Now;
            string query = "INSERT INTO stock_history(item_id, stock_change, timestamp) " +
                           "VALUES( @id , @stockChange , @dateNow ) ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { id, stockChange, dateNow });
        }

        public List<Stock_History> GetStock_Histories(int id)
        {
            List<Stock_History> stocks = new List<Stock_History>();
            string query = "SELECT * FROM stock_history WHERE item_id = @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach(DataRow row in data.Rows)
            {
                Stock_History item = new Stock_History(row);
                stocks.Add(item);
            }
            return stocks;
        }

        public List<Price_History> GetPrice_Histories(int id)
        {
            List<Price_History> prices = new List<Price_History>();
            string query = "SELECT * FROM price_history WHERE item_id = @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach(DataRow row in data.Rows)
            {
                Price_History item = new Price_History(row);
                prices.Add(item);
            }
            return prices;
        }

        public Item SearchItembyName(string name)
        {
            List<Item> items = new List<Item>(); 
            string query = "SELECT dp.item_id, dp.item_name, dp.amount,c.category_name, dp.price " +
                    "FROM `depot_item` AS dp " +
                    "LEFT JOIN category AS c " +
                    "ON dp.category_id = c.category_id " +
                    "WHERE dp.item_name = @name ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            Item item = new Item(data.Rows[0]);
            return item;
        }


    }
}
