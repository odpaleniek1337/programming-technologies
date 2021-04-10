using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext
    {
        public Dictionary<int, IProduct> Products = new Dictionary<int, IProduct>();
        public Dictionary<int, Buyer> Buyers = new Dictionary<int, Buyer>();
        public Dictionary<int, Order> Orders = new Dictionary<int, Order>();
        public Dictionary<int, Producer> Producers = new Dictionary<int, Producer>();
        public Dictionary<int, Event> Events = new Dictionary<int, Event>();
        public Dictionary<int, State> States = new Dictionary<int, State>();
    }
}
