using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MediaBazaarSolution.DTO
{
    public class Item
    {
        private int iD;
        private string name;
        private string category;
        private int amount;
        private double price;

        public Item(DataRow row)
        {
            this.iD = (int)row["item_id"];
            this.Name = row["item_name"].ToString();
            this.Amount = (int)row["amount"];
            this.Category = row["category_name"].ToString();
            this.Price = Convert.ToDouble(row["price"]);
        }

        public Item(int id, string name, int amount, string category, double price)
        {
            this.iD = id;
            this.name = name;
            this.amount = amount;
            this.category = category;
            this.price = price;
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public int Amount { get => amount; set => amount = value; }
        public double Price { get => price; set => price = value; }
    }
}
