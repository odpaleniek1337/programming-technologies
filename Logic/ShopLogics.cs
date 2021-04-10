using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    class ShopLogics
    {
        public IRepository repository;
        public ShopLogics(IRepository repository)
        {
            this.repository = repository;
        }
        Dictionary<int, IProduct> GetProducts()
        {
            return repository.GetProducts();
        }
        Dictionary<int, Event> GetEvents()
        {
            return repository.GetEvents();
        }
        Dictionary<int, Producer> GetProducers()
        {
            return repository.GetProducers();
        }
        Dictionary<int, Order> GetOrders()
        {
            return repository.GetOrders();
        }
        
        

    }
}
