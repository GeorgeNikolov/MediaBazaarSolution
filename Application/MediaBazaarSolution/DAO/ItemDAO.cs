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

        public static ItemDAO Instance { 
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

            List<Item>  itemList = new List<Item>();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            
            foreach(DataRow row in data.Rows)
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

            foreach(DataRow row in data.Rows)
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
            string query = "UPDATE depot_item SET category_id = (SELECT category_id FROM category WHERE category_name = @valueToBeChanged ) WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { category }) > 0;
        }

        public bool UpdateItemAmount(int id, int amount)
        {
            string query = "UPDATE depot_item SET amount = @valueToBeChanged WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { amount }) > 0;
        }

        public bool UpdateItemPrice(int id, decimal price)
        {
            string query = "UPDATE depot_item SET price = @valueToBeChanged WHERE item_id = " + id;
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { price }) > 0; 
        }
    }
}
