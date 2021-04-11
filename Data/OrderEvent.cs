using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class OrderEvent : Event
    {
        public int ClientRating {get; set;}
        public OrderEvent(int ID, DateTime date, Order Order, int ClientRating) : base(ID, date, Order)
        {
            this.ID = ID;
            this.Date = date;
            this.Order = Order;
            this.ClientRating = ClientRating;
        }
    }
}
