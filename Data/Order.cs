using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Order
    {
        public Order(int ID, Buyer Buyer, DateTime Time)
        {
            this.ID = ID;
            this.Buyer = Buyer;
            this.Time = Time;
            State = true;//true - ordered, false - cancelled
        }

        public int ID { get; set; }
        public Buyer Buyer { get; set; }

        public DateTime Time { get; set; }

        public bool State { get; set; }
    }
}
