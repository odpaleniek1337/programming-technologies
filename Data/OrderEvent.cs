using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class OrderEvent : Event
    {
        public int ClientRateing {get; set;}
        public OrderEvent(int ID, Buyer Buyer, DateTime date, Order Order, int clientRateing) : base(ID, Buyer, date, Order)
        {
            this.ID = ID;
            this.Buyer = Buyer;
            this.Date = date;
            this.Order = Order;
            this.ClientRateing = clientRateing;
        }
    }
}
