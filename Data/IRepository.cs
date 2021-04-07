using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IRepository
    {
        Dictionary<int, IProduct> GetProducts();
        List<Buyer> GetBuyers();
        List<Order> GetOrders();
    }
}
