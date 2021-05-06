using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class RepositoryTest : Data.IRepository
    {
        private Data.IDataContext context;

        public RepositoryTest(Data.IDataContext context)
        {
            this.context = context;
        }

        public Dictionary<int, Data.IProduct> GetProducts()
        {
            return context.Products;
        }
        public void AddProduct(Data.IProduct Product)
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
        Data.IProduct Data.IRepository.GetProduct(int ID)
        {
            if (context.Products.ContainsKey(ID))
            {
                return context.Products[ID];
            }
            else
            {
                throw new Exception("There is no Product with that ID!");
            }
        }
        public void UpdateProduct(int ID, Data.IProduct Product)
        {
            if (context.Products.ContainsKey(ID))
            {
                context.Products[ID] = Product;
            }
            else
            {
                throw new Exception("There is no Product with that ID!");
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
        public Dictionary<int, Data.IBuyer> GetBuyers()
        {
            return context.Buyers;
        }
        public void AddBuyer(Data.IBuyer Buyer)
        {
            if (!context.Buyers.ContainsKey(Buyer.ID))
            {
                context.Buyers.Add(Buyer.ID, Buyer);
            }
            else
            {
                throw new Exception("There is already a Buyer created with that ID");
            }
        }
        Data.IBuyer Data.IRepository.GetBuyer(int ID)
        {
            if (context.Buyers.ContainsKey(ID))
            {
                return context.Buyers[ID];
            }
            else
            {
                throw new Exception("There is no Buyer with that ID");
            }
        }
        public void UpdateBuyer(int ID, Data.IBuyer Buyer)
        {
            if (context.Buyers.ContainsKey(ID))
            {
                context.Buyers[ID] = Buyer;
            }
            else
            {
                throw new Exception("There is no Buyer with that ID!");
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

        public Dictionary<int, Data.IOrder> GetOrders()
        {
            return context.Orders;
        }
        public void AddOrder(Data.IOrder Order)
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
        Data.IOrder Data.IRepository.GetOrder(int ID)
        {
            if (context.Orders.ContainsKey(ID))
            {
                return context.Orders[ID];
            }
            else
            {
                throw new Exception("There is no Order with that ID");
            }
        }
        public void UpdateOrder(int ID, Data.IOrder Order)
        {
            if (context.Orders.ContainsKey(ID))
            {
                context.Orders[ID] = Order;
            }
            else
            {
                throw new Exception("There is no Order with that ID!");
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

        public Dictionary<int, Data.IProducer> GetProducers()
        {
            return context.Producers;
        }
        public void AddProducer(Data.IProducer Producer)
        {
            if (!context.Producers.ContainsKey(Producer.ID))
            {
                context.Producers.Add(Producer.ID, Producer);
            }
            else
            {
                throw new Exception("There is already an Producer created with that ID");
            }
        }
        Data.IProducer Data.IRepository.GetProducer(int ID)
        {
            if (context.Producers.ContainsKey(ID))
            {
                return context.Producers[ID];
            }
            else
            {
                throw new Exception("There is no Producer with that ID");
            }
        }
        public void UpdateProducer(int ID, Data.IProducer Producer)
        {
            if (context.Producers.ContainsKey(ID))
            {
                context.Producers[ID] = Producer;
            }
            else
            {
                throw new Exception("There is no Producer with that ID!");
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

        public Dictionary<int, Data.IEvent> GetEvents()
        {
            return context.Events;
        }
        public void AddEvent(Data.IEvent Event)
        {
            if (!context.Events.ContainsKey(Event.ID))
            {
                if (Event.GetType() == typeof(Data.OrderEvent))
                {
                    Data.IOrder order = Event.Order;
                    Data.IEvent LastEvent = null;
                    Dictionary<int, Data.IEvent>.ValueCollection valueColl = context.Events.Values;
                    foreach (Data.IEvent e in valueColl)
                    {
                        if (e.Order == order) LastEvent = e;
                    }
                    if (LastEvent == null)
                    {
                        int productId = Event.Order.Product.ID;
                        if (context.States[productId].Quantity == 0) throw new Exception("Not enought products");
                        else
                        {
                            context.States[productId].Quantity -= 1;
                            context.Events.Add(Event.ID, Event);
                        }
                    }
                }
                else if (Event.GetType() == typeof(Data.ComplainEvent))
                {
                    Data.IOrder order = Event.Order;
                    Data.IEvent LastEvent = null;
                    Dictionary<int, Data.IEvent>.ValueCollection valueColl = context.Events.Values;
                    foreach (Data.IEvent e in valueColl)
                    {
                        if (e.Order == order) LastEvent = e;
                    }
                    if (LastEvent == null)
                    {
                        throw new Exception("Something is wrong, last event wasn't order");
                    }
                    if (LastEvent.GetType() == typeof(Data.OrderEvent))
                    {
                        context.Events.Add(Event.ID, Event);
                    }
                    else
                    {
                        throw new Exception("Something is wrong, last event wasn't order");
                    }
                }
                else if (Event.GetType() == typeof(Data.ReturnEvent))
                {
                    Data.IOrder order = Event.Order;
                    Data.IEvent LastEvent = null;
                    Dictionary<int, Data.IEvent>.ValueCollection valueColl = context.Events.Values;
                    foreach (Data.IEvent e in valueColl)
                    {
                        if (e.Order == order) LastEvent = e;
                    }
                    if (LastEvent == null)
                    {
                        throw new Exception("Something is wrong, last event wasn't order");
                    }
                    if (LastEvent.GetType() == typeof(Data.OrderEvent))
                    {
                        int productId = Event.Order.Product.ID;
                        context.States[productId].Quantity += 1;
                        context.Events.Add(Event.ID, Event);
                    }
                    else
                    {
                        throw new Exception("Something is wrong, last event wasn't order");
                    }

                }
                else
                {
                    throw new Exception("Not valid Event");
                }
            }
            else
            {
                throw new Exception("There is already an Event created with that ID");
            }
        }
        Data.IEvent Data.IRepository.GetEvent(int ID)
        {
            if (context.Events.ContainsKey(ID))
            {
                return context.Events[ID];
            }
            else
            {
                throw new Exception("There is no Event with that ID");
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
                throw new Exception("There is no Event with that ID");
            }
        }

        public Dictionary<int, Data.IState> GetStates()
        {
            return context.States;
        }
        public void AddState(Data.IProduct Product, int Quantity)
        {
            if (!context.States.ContainsKey(Product.ID))
            {
                Data.State State = new Data.State(0);
                State.Quantity = Quantity;
                context.States.Add(Product.ID, State);
            }
            else
            {
                throw new Exception("There is already an State for this Product created with that ID");
            }
        }
        public void UpdateState(Data.IProduct Product, int NewQuantity)
        {
            if (context.States.ContainsKey(Product.ID))
            {
                Data.State State = new Data.State(0);
                State.Quantity = NewQuantity;
                context.States[Product.ID] = State;
            }
            else
            {
                throw new Exception("There is no State with that Product.ID");
            }
        }
        public void RemoveState(Data.IProduct Product)
        {
            if (context.States.ContainsKey(Product.ID))
            {
                context.States.Remove(Product.ID);
            }
            else
            {
                throw new Exception("There is no State with that Product.ID");
            }
        }
        public int GetProductsNumber()
        {
            return context.Products.Count;
        }
        public int GetOrdersNumber()
        {
            return context.Orders.Count;
        }
        public int GetEventsNumber()
        {
            return context.Events.Count;
        }
        public int GetProducersNumber()
        {
            return context.Producers.Count;
        }
        public int GetBuyersNumber()
        {
            return context.Buyers.Count;
        }
        public List<Data.IEvent> GetEventsHistory(Data.IOrder Order)
        {
            List<Data.IEvent> events = new List<Data.IEvent>();
            Dictionary<int, Data.IEvent>.ValueCollection valueColl = context.Events.Values;
            foreach (Data.IEvent e in valueColl)
            {
                if (e.Order == Order) events.Add(e);
            }
            return events;
        }
        public Data.IEvent GetLastEvent(Data.IOrder Order)
        {
            Data.IEvent LastEvent = null;
            Dictionary<int, Data.IEvent>.ValueCollection valueColl = context.Events.Values;
            foreach (Data.IEvent e in valueColl)
            {
                if (e.Order == Order) LastEvent = e;
            }
            return LastEvent;
        }
        public int GetProductState(int ProductID)
        {
            if (context.States.ContainsKey(ProductID))
            {
                int quantity = context.States[ProductID].Quantity;
                return quantity;
            }
            else
            {
                throw new Exception("There is no State with that Product.ID");
            }
        }
    }
}