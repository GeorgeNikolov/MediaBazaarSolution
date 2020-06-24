using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSolution.DTO
{
    public class Alert : IComparable<Alert>
    {
        private int iD;
        private int stock;
        private int limit;
        private string priority;
        private static int priorityMargin;

        

        public Alert(DataRow row)
        {
            this.ID = (int)row["item_id"];
            this.Stock = (int)row["stock"];
            this.Limit = (int)row["min_stock"];
        }

        public Alert(int iD, int stock, int limit)
        {
            this.ID = iD;
            this.Stock = stock;
            this.Limit = limit;
        }

        public int ID { get => this.iD; set => this.iD = value; }
        public int Stock { get => this.stock; set => this.stock = value; }
        public int Limit { get => this.limit; set { this.limit = value; SetPriority(); } }
        public string Priority { get => this.priority;}
        public static int PriorityMargin { set => priorityMargin = value; }

        public int CompareTo(Alert other)
        {
            if(this.priority == "HIGH" && other.priority == "HIGH")
            {
                return 0;
            }
            else if(this.priority == "HIGH" && other.priority == "REG")
            {
                return -1;
            }
            return 1;
        }

        public override string ToString()
        {
            return $"{this.iD}: Min {this.limit}, Now {this.stock}, {this.Priority} priority";
        }

        private void SetPriority()
        {
            int difference = this.limit - this.stock;
            if(difference < priorityMargin && difference >=0)
                {
                    this.priority = "REG";
                }
                else if(difference >= priorityMargin)
                {
                    this.priority = "HIGH";
                }
        }

        
}
}
