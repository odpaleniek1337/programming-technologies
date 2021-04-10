using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataRepository : IRepository
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
        public void AddProduct(IProduct Product)
        {
            if (!context.Products.ContainsKey(Product.ID))
            {
                context.Products.Add(Product.ID, Product);
            }
            else
            {
                throw new Exception("There is already a Product created with that ID");
            }
        }
        public void RemoveProduct(int ID)
        {
            if (context.Products.ContainsKey(ID))
            {
                context.Products.Remove(ID);
            }
            else
            {
                throw new Exception("There is no Product with that ID!");
            }
        }

        public Dictionary<int,Buyer> GetBuyers()
        {
            return context.Buyers;
        }
        public void AddBuyer(Buyer Buyer)
        {
            if(!context.Buyers.ContainsKey(Buyer.ID))
            { 
                context.Buyers.Add(Buyer.ID, Buyer); 
            }
            else
            {
                throw new Exception("There is already a Buyer created with that ID");
            }
        }
        public void RemoveBuyer(int ID)
        {
            if (context.Buyers.ContainsKey(ID))
            {
                context.Buyers.Remove(ID);
            }
            else
            {
                throw new Exception("There is no Buyer with that ID");
            }
        }

        public Dictionary<int, Order> GetOrders()
        {
            return context.Orders;
        }

        public void AddOrder(Order Order)
        {
            if (!context.Orders.ContainsKey(Order.ID))
            {
                context.Orders.Add(Order.ID, Order);
            }
            else
            {
                throw new Exception("There is already an Order created with that ID");
            }
        }
        public void RemoveOrder(int ID)
        {
            if (context.Orders.ContainsKey(ID))
            {
                context.Orders.Remove(ID);
            }
            else
            {
                throw new Exception("There is no Order with that ID");
            }
        }

        public Dictionary<int, Producer> GetProducers()
        {
            return context.Producers;
        }

        public void AddProducer(Producer Producer)
        {
            if (!context.Orders.ContainsKey(Producer.ID))
            {
                context.Producers.Add(Producer.ID, Producer);
            }
            else
            {
                throw new Exception("There is already an Producer created with that ID");
            }
        }
        public void RemoveProducer(int ID)
        {
            if (context.Producers.ContainsKey(ID))
            {
                context.Producers.Remove(ID);
            }
            else
            {
                throw new Exception("There is no Producer with that ID");
            }
        }
        public Dictionary<int, Event> GetEvents()
        {
            return context.Events;
        }

        public void AddEvent(Event Event)
        {
            if (!context.Events.ContainsKey(Event.ID))
            {
                context.Events.Add(Event.ID, Event);
            }
            else
            {
                throw new Exception("There is already an Producer created with that ID");
            }
        }
        public void RemoveEvent(int ID)
        {
            if (context.Events.ContainsKey(ID))
            {
                context.Events.Remove(ID);
            }
            else
            {
                throw new Exception("There is no Producer with that ID");
            }
        }
        public Dictionary<int, State> GetStates()
        {
            return context.States;
        }

        public void AddState(State State, IProduct Product)
        {
            if (!context.States.ContainsKey(Product.ID))
            {
                context.States.Add(Product.ID , State);
            }
            else
            {
                throw new Exception("There is already an State for this Product created with that ID");
            }
        }
        public void RemoveState(int ID)
        {
            if (context.States.ContainsKey(ID))
            {
                context.States.Remove(ID);
            }
            else
            {
                throw new Exception("There is no State with that Product.ID");
            }
        }
    }
}
