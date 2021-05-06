using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class IDataContext
    {
        public Dictionary<int, IProduct> Products = new Dictionary<int, IProduct>();
        public Dictionary<int, IBuyer> Buyers = new Dictionary<int, IBuyer>();
        public Dictionary<int, IOrder> Orders = new Dictionary<int, IOrder>();
        public Dictionary<int, IProducer> Producers = new Dictionary<int, IProducer>();
        public Dictionary<int, IEvent> Events = new Dictionary<int, IEvent>();
        public Dictionary<int, IState> States = new Dictionary<int, IState>();
    }
}
