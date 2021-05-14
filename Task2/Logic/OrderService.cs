using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Service
{
    public class OrderService
    {
        public IEnumerable<Orders> GetOrder()
        {
            using (var context = new ShopDataContext())
            {
                return context.Orders.ToList();
            }
        }

        static public Orders GetOrderById(int id)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Orders Order in context.Orders.ToList())
                {
                    if (Order.id.Equals(id))
                    {
                        return Order;
                    }
                }
                return null;
            }
        }

        static public Orders GetLatestOrderByProductAndBuyer(int product_id, int buyer_id)
        {
            using (var context = new ShopDataContext())
            {

                foreach (Orders Order in context.Orders.ToList().OrderByDescending (p =>p.id))
                {
                    if (Order.product_id.Equals(product_id) && Order.buyer_id.Equals(buyer_id))
                    {
                        return Order;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<Orders> GetOrdersByProductId(int product_id)
        {
            using (var context = new ShopDataContext())
            {
                List<Orders> result = new List<Orders>();
                foreach (Orders Order in context.Orders.ToList())
                {
                    if (Order.product_id.Equals(product_id))
                    {
                        result.Add(Order);
                    }
                }
                return result;
            }
        }

        static public bool AddOrder(int product_id, int buyer_id, bool is_payed, string event_description)
        {
            using (var context = new ShopDataContext())
            {
                if (!product_id.Equals(null) && !buyer_id.Equals(null) && !is_payed.Equals(null))
                {
                    Orders NewOrder = new Orders
                    {
                        product_id = product_id,
                        buyer_id = buyer_id,
                        is_payed = is_payed,
                    };
                    context.Orders.InsertOnSubmit(NewOrder);
                    context.SubmitChanges();


                    DateTime dateTime = DateTime.Now;

                    return EventService.AddEvent(dateTime, GetLatestOrderByProductAndBuyer(product_id, buyer_id).id, "orderEvent", event_description);
                }
                return false;
            }
        }

        static public bool UpdateOrder(int id, int buyer_id)
        {
            using (var context = new ShopDataContext())
            {
                Orders Order = context.Orders.SingleOrDefault(i => i.id == id);
                if (!buyer_id.Equals(null))
                {
                    Order.buyer_id = buyer_id;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool DeleteOrder(int id)
        {
            using (var context = new ShopDataContext())
            {
                Orders Order = context.Orders.SingleOrDefault(i => i.id == id);
                if (GetOrderById(id) != null && !id.Equals(null))
                {
                    context.Orders.DeleteOnSubmit(Order);
                    List<Events> events = (List<Events>)EventService.GetEventsByOrderId(id);
                    foreach (Events item in events)
                    {
                        EventService.DeleteEvent(item.id);
                    }
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
