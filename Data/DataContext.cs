using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class DataContext
    {
        public Dictionary<int, IProduct> Products = new Dictionary<int, IProduct>();
        public List<Buyer> Buyers = new List<Buyer>();
        public List<Order> Orders = new List<Order>();
    }
}
