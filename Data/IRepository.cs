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
        void AddProduct(IProduct Product);
        void RemoveProduct(int ID);
        Dictionary<int, Buyer> GetBuyers();
        void AddBuyer(Buyer Buyer);
        void RemoveBuyer(int ID);
        Dictionary<int, Order> GetOrders();
        void AddOrder(Order Order);
        void RemoveOrder(int ID);
    }
}
