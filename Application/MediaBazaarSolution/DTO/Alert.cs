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
        private int priority;

        public Alert(DataRow row)
        {
            this.iD = (int)row["item_id"];
            this.stock = (int)row["stock"];
            this.limit = (int)row["min_stock"];
            this.priority = (int)row["priority"];
        }

        public Alert(int iD, int stock, int limit, int priority)
        {
            this.iD = iD;
            this.stock = stock;
            this.limit = limit;
            this.priority = priority;
        }

        public int ID { get => this.iD; set => this.iD = value; }
        public int Stock { get => this.stock; set => this.stock = value; }
        public int Limit { get => this.limit; set => this.limit = value; }
        public int Priority { get => this.priority; set => this.priority = value; }
    }
}
