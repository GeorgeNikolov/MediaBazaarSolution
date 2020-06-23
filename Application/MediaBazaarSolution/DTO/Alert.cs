using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DTO
{
    public class Alert
    {
        private int iD;
        private int stock;
        private int limit;
        private string priority;

        public Alert(DataRow row)
        {
            this.iD = (int)row["item_id"];
            this.stock = (int)row["stock"];
            this.limit = (int)row["min_stock"];
            SetPriority();
        }

        public Alert(int iD, int stock, int limit)
        {
            this.iD = iD;
            this.stock = stock;
            this.limit = limit;
            SetPriority();
        }

        public int ID { get => this.iD; set => this.iD = value; }
        public int Stock { get => this.stock; set => this.stock = value; }
        public int Limit { get => this.limit; set => this.limit = value; }
        public string Priority { get => this.priority;}

        
        public override string ToString()
        {
            return $"{this.iD}: Min =  {this.limit} , Now = {this.stock}, Priority: {this.Priority}";
        }

        private void SetPriority()
        {
            if(this.stock - this.limit >= 50)
                {
                    this.priority = "HIGH";
                }
                else 
                {
                    this.priority = "REG";
                }
        }
}
}
