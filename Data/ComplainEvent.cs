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
        public ComplainEvent(int ID, DateTime date, Order Order, string Complain) : base(ID, date, Order)
        {
            this.ID = ID;
            this.Date = date;
            this.Order = Order;
            this.Complain = Complain;
        }
    }
}
