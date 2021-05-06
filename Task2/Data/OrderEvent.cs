using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrderEvent : Event
    {
        public OrderEvent(int ID, DateTime date, IOrder Order, int ClientRating) : base(ID, date, Order)
        {
            this.ID = ID;
            this.Date = date;
            this.Order = Order;
            this.ClientRating = ClientRating;
        }
        public override int ClientRating { get; set; }
    }
}
