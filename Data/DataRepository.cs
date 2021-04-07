using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class DataRepository : IRepository
    {
        private DataContext context;

        public DataRepository(DataContext context)
        {
            this.context = context;
        }

        public Dictionary<int, IProduct> GetProducts()
        {
            return context.Products;
        }

        public List<Buyer> GetBuyers()
        {
            return context.Buyers;
        }

        public List<Order> GetOrders()
        {
            return context.Orders;
        }
    }
}
