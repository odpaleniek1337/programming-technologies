using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class ComplainEvent : Event
    {
        public string Complain { get; set; }
        public ComplainEvent(int ID, Buyer Buyer, DateTime date, Order Order, string complain) : base(ID, Buyer, date, Order)
        {
            this.ID = ID;
            this.Buyer = Buyer;
            this.Date = date;
            this.Order = Order;
            this.Complain = complain;
        }
    }
}
