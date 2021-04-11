using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReturnEvent : Event
    {
        public ReturnEvent(int ID, DateTime date, Order Order, string reason) : base(ID, date, Order)
        {
            this.ID = ID;
            this.Date = date;
            this.Order = Order;
            this.Reason = reason;
        }
        public override string Reason { get; set; }
    }
}
