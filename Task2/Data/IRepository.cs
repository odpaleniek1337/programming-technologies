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
        Dictionary<int, IBuyer> GetBuyers();
        void AddBuyer(IBuyer Buyer);
        IBuyer GetBuyer(int ID);
        void UpdateBuyer(int ID, IBuyer Buyer);
        void RemoveBuyer(int ID);
        Dictionary<int, IOrder> GetOrders();
        void AddOrder(IOrder Order);
        IOrder GetOrder(int ID);
        void UpdateOrder(int ID, IOrder Order);
        void RemoveOrder(int ID);
        Dictionary<int, IProducer> GetProducers();
        void AddProducer(IProducer Producer);
        IProducer GetProducer(int ID);
        void UpdateProducer(int ID, IProducer Producer);
        void RemoveProducer(int ID);
        Dictionary<int, IEvent> GetEvents();
        void AddEvent(IEvent Event);
        IEvent GetEvent(int ID);
        void RemoveEvent(int ID);
        Dictionary<int, IState> GetStates();
        void AddState(IProduct Product, int Quantity);
        void UpdateState(IProduct Product, int NewQuantity);
        void RemoveState(IProduct Product);
        int GetProductsNumber();
        int GetOrdersNumber();
        int GetEventsNumber();
        int GetProducersNumber();
        int GetBuyersNumber();
        List<IEvent> GetEventsHistory(IOrder Order);
        IEvent GetLastEvent(IOrder Order);
        int GetProductState(int ProductID);
    }
}
