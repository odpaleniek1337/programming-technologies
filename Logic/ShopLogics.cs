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
        // GET ALL 
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
        // GET SPECIFIC
        public IProduct GetProduct(int ID)
        {
            return repository.GetProduct(ID);
        }
        public Event GetEvent(int ID)
        {
            return repository.GetEvent(ID);
        }
        public Order GetOrder(int ID)
        {
            return repository.GetOrder(ID);
        }
        public Producer GetProducer(int ID)
        {
            return repository.GetProducer(ID);
        }

        // POST
        public void AddProduct(IProduct Product)
        {
            repository.AddProduct(Product);
        }
        public void AddEvent(Event Event)
        {
            repository.AddEvent(Event);
        }
        public void AddOrder(Order Order)
        {
            repository.AddOrder(Order);
        }
        public void AddProducer(Producer Producer)
        {
            repository.AddProducer(Producer);
        }
        // DELETE
        public void RemoveProduct(int ID)
        {
            repository.RemoveProduct(ID);
        }
        public void RemoveEvent(int ID)
        {
            repository.RemoveEvent(ID);
        }
        public void RemoveOrder(int ID)
        {
            repository.RemoveOrder(ID);
        }
        public void RemoveProducer(int ID)
        {
            repository.RemoveProducer(ID);
        }
        // UPDATE
        public void UpdateProduct(int ID, IProduct Product)
        {
            repository.RemoveProduct(ID, Product);
        }
        public void UpdateOrder(int ID, Order Order)
        {
            repository.UpdateOrder(ID, Order);
        }
        public void UpdateProducer(int ID, Producer Producer)
        {
            repository.UpdateProducer(ID, Producer);
        }
        
    }
}
