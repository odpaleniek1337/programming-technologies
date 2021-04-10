using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository
    {
        Dictionary<int, IProduct> GetProducts();
        void AddProduct(IProduct Product);
        IProduct GetProduct(int ID);
        void UpdateProduct(int ID, IProduct Product);
        void RemoveProduct(int ID);
        Dictionary<int, Buyer> GetBuyers();
        void AddBuyer(Buyer Buyer);
        Buyer GetBuyer(int ID);
        void UpdateBuyer(int ID, Buyer Buyer);
        void RemoveBuyer(int ID);
        Dictionary<int, Order> GetOrders();
        void AddOrder(Order Order);
        Order GetOrder(int ID);
        void UpdateOrder(int ID, Order Order);
        void RemoveOrder(int ID);
        Dictionary<int, Producer> GetProducers();
        void AddProducer(Producer Producer);
        Producer GetProducer(int ID);
        void UpdateProducer(int ID, Producer Producer);
        void RemoveProducer(int ID);
        Dictionary<int, Event> GetEvents();
        void AddEvent(Event Event);
        Event GetEvent(int ID);
        void RemoveEvent(int ID);
    }
}
