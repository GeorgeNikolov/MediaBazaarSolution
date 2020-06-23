using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DTO
{
    public class Order
    {
        private int iD;
        private int amount;
        private string status;

        public Order(DataRow row)
        {
            this.iD = (int)row["item_id"];
            this.amount = (int)row["amount"];
            this.status = row["status"].ToString();
        }

        public Order(int iD, int amount, string status)
        {
            this.iD = iD;
            this.amount = amount;
            this.status = status;
        }

        public int ID { get => this.iD; set => this.iD = value; }
        public int Amount { get => this.amount; set => this.amount = value; }
        public string Status { get => this.status; set => this.status = value; }
    }
}
