using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.DTO
{
    public class Price_History
    {
        
        public Price_History(DataRow row)
        {
            this.ID = (int)row["item_id"];
            this.amount = (int)row["price_change"];
            this.date = (DateTime)row["timestamp"];
        }

        public int ID { get; private set; }
        public int amount { get; private set; }
        public DateTime date { get; private set; }
    }
}
