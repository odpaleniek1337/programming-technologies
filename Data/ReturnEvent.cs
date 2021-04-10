using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class ReturnEvent : Event
    {
        public string Reason { get; set; }
        public ReturnEvent(int ID, Buyer Buyer, DateTime date, Order Order, string reason) : base(ID, Buyer, date, Order)
        {
            this.ID = ID;
            this.Buyer = Buyer;
            this.Date = date;
            this.Order = Order;
            this.Reason = reason;
        }
    }
}
