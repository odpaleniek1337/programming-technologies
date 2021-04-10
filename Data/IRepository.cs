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
        void RemoveProduct(int ID);
        Dictionary<int, Buyer> GetBuyers();
        void AddBuyer(Buyer Buyer);
        void RemoveBuyer(int ID);
        Dictionary<int, Order> GetOrders();
        void AddOrder(Order Order);
        void RemoveOrder(int ID);
        Dictionary<int, Producer> GetProducers();
        void AddProducer(Producer Producer);
        void RemoveProducer(int ID);
        Dictionary<int, Event> GetEvents();
        void AddEvent(Event Event);
        void RemoveEvent(int ID);
    }
}
