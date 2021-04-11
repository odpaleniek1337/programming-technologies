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
        public DateTime Date { get; set; }
        public Order Order { get; set; }

        protected Event(int ID, DateTime date, Order Order)
        {
            this.ID = ID;
            this.Date = date;
            this.Order = Order;
        }
    }
}
