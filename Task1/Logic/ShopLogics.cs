using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class ShopLogics
    {
        // GET ALL
        public IRepository repository;
        public ShopLogics(IRepository repository)
        {
            this.repository = new DataRepository(new DataContext());
        }
        Dictionary<int, IProduct> GetProducts()
        {
            return repository.GetProducts();
        }
        Dictionary<int, IEvent> GetEvents()
        {
            return repository.GetEvents();
        }
        Dictionary<int, IProducer> GetProducers()
        {
            return repository.GetProducers();
        }
        Dictionary<int, IOrder> GetOrders()
        {
            return repository.GetOrders();
        }
        Dictionary<int, IBuyer> GetBuyers()
        {
            return repository.GetBuyers();
        }

        // GET SPECIFIC
        public IProduct GetProduct(int ID)
        {
            return repository.GetProduct(ID);
        }
        public IEvent GetEvent(int ID)
        {
            return repository.GetEvent(ID);
        }
        public IOrder GetOrder(int ID)
        {
            return repository.GetOrder(ID);
        }
        public IProducer GetProducer(int ID)
        {
            return repository.GetProducer(ID);
        }
        public IBuyer GetBuyer(int ID)
        {
            return repository.GetBuyer(ID);
        }
        public int GetProductState(int ProductID)
        {
            return repository.GetProductState(ProductID);
        }

        // POST
        public void AddProduct(IProduct Product)    
        {
            repository.AddProduct(Product);
        }
        public void AddEvent(IEvent Event)
        {
            repository.AddEvent(Event);
        }
        public void AddOrder(IOrder Order)
        {
            repository.AddOrder(Order);
        }
        public void AddProducer(IProducer Producer)
        {
            repository.AddProducer(Producer);
        }
        public void AddState(IProduct Product, int Quantity)
        {
            repository.AddState(Product, Quantity);
        }
        public void AddBuyer(IBuyer Buyer)
        {
            repository.AddBuyer(Buyer);
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
        public void RemoveState(IProduct Product)
        {
            repository.RemoveState(Product);
        }
        public void RemoveBuyer(int ID)
        {
            repository.RemoveBuyer(ID);
        }

        // UPDATE
        public void UpdateProduct(int ID, IProduct Product)
        {
            repository.UpdateProduct(ID, Product);
        }
        public void UpdateOrder(int ID, IOrder Order)
        {
            repository.UpdateOrder(ID, Order);
        }
        public void UpdateProducer(int ID, IProducer Producer)
        {
            repository.UpdateProducer(ID, Producer);
        }
        public void UpdateState(IProduct Product, int Quantity)
        {
            repository.UpdateState(Product, Quantity);
        }
        public void UpdateBuyer(int ID, IBuyer Buyer)
        {
            repository.UpdateBuyer(ID, Buyer);
        }

        // GET COUNT
        public int GetProductsNumber()
        {
            return repository.GetProductsNumber();
        }
        public int GetOrdersNumber()
        {
            return repository.GetOrdersNumber();
        }
        public int GetProducersNumber()
        {
            return repository.GetProducersNumber();
        }
        public int GetEventNumber()
        {
            return repository.GetEventsNumber();
        }
        public int GetBuyersNumber()
        {
            return repository.GetBuyersNumber();
        }

        // GET LAST EVENT OF ORDER
        public IEvent GetLastEvent(IOrder Order)
        {
            return repository.GetLastEvent(Order);
        }
        // GET ALL EVENTS OF ORDER
        public List<IEvent> GetEventsHistory(IOrder Order)
        {
            return repository.GetEventsHistory(Order);
        }
    }
}