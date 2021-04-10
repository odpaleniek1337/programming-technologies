using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
namespace Logic
{
    public interface IShopLogics
    {
        Dictionary<int, IProduct> GetProducts();
        Dictionary<int, Event> GetEvents();
        Dictionary<int, Producer> GetProducers();
        Dictionary<int, Order> GetOrders();
        // GET SPECIFIC
        IProduct GetProduct(int ID);
        Event GetEvent(int ID);
        Order GetOrder(int ID);
        Producer GetProducer(int ID);

        // POST
        void AddProduct(IProduct Product);
        void AddEvent(Event Event);
        void AddOrder(Order Order);
        void AddProducer(Producer Producer);

        // DELETE
        void RemoveProduct(int ID);
        void RemoveEvent(int ID);
        void RemoveOrder(int ID);
        void RemoveProducer(int ID);

        // UPDATE
        void UpdateProduct(int ID, IProduct Product);
        void UpdateOrder(int ID, Order Order);
        void UpdateProducer(int ID, Producer Producer);
    }
}
