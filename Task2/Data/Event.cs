using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Event : IEvent
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public IOrder Order { get; set; }
        public virtual string Reason { get { return null; } set { } }
        public virtual string Complain { get { return null; } set { } }
        public virtual int ClientRating { get { return -1; } set { } }
        protected Event(int ID, DateTime date, IOrder Order)
        {
            this.ID = ID;
            this.Date = date;
            this.Order = Order;
        }
    }
}
