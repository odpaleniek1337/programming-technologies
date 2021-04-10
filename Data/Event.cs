using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Event
    {
        public int ID { get; set; }
        public Buyer Buyer { get; set; }
        public DateTime Date { get; set; }
        public Order Order { get; set; }

        protected Event(int ID, Buyer Buyer, DateTime date, Order Order)
        {
            this.ID = ID;
            this.Buyer = Buyer;
            this.Date = date;
            this.Order = Order;
        }
    }
}
