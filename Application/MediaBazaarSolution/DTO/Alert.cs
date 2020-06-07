using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DTO
{
    public class Alert : IComparable<Alert>
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
            this.priority = Priority;
        }

        public Alert(int iD, int stock, int limit)
        {
            this.iD = iD;
            this.stock = stock;
            this.limit = limit;
            this.priority = Priority;
        }

        public int ID { get => this.iD; set => this.iD = value; }
        public int Stock { get => this.stock; set => this.stock = value; }
        public int Limit { get => this.limit; set => this.limit = value; }
        public string Priority { get => this.priority; 
            set
            {
                if (this.limit - this.stock >= 50 && this.limit != 0)
                {
                    this.priority = "HIGH";
                }
                else if (this.limit - this.stock >= 0)
                {
                    this.priority = "REG";
                }
            } 
        }

        public int CompareTo(Alert other)
        {
            if (!MainScreen.sortAlertsByPriority)
            {
                if(this.iD < other.iD)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if(this.priority == "HIGH" && other.priority == "REG")
                {
                    return 1;
                }
                else if(this.priority == "REG" && other.priority == "HIGH")
                {
                    return -1;
                }
            }
            return 0;
        }

        public override string ToString()
        {
            return $"{this.iD}: Minimum stock =  {this.limit} , Current Stock = {this.stock}, Alert Priority: {this.priority}";
        }
}
}
