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
        public ReturnEvent(int ID, DateTime date, Order Order, string reason) : base(ID, date, Order)
        {
            this.ID = ID;
            this.Date = date;
            this.Order = Order;
            this.Reason = reason;
        }
    }
}
