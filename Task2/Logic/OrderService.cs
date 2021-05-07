﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Service
{
    class OrderService
    {
        public IEnumerable<Order> GetOrder()
        {
            using (var context = new ShopDataContext())
            {
                return context.Orders.ToList();
            }
        }

        public Order GetOrderById(int id)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Order Order in context.Orders.ToList())
                {
                    if (Order.id.Equals(id))
                    {
                        return Order;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<Order> GetOrdersByProductId(int product_id)
        {
            using (var context = new ShopDataContext())
            {
                List<Order> result = new List<Order>();
                foreach (Order Order in context.Orders.ToList())
                {
                    if (Order.product_id.Equals(product_id))
                    {
                        result.Add(Order);
                    }
                }
                return result;
            }
        }

        public bool AddOrder(int product_id, int buyer_id, bool is_payed, string event_description)
        {
            using (var context = new ShopDataContext())
            {
                if (!product_id.Equals(null) && !buyer_id.Equals(null) && !is_payed.Equals(null))
                {
                    Order NewOrder = new Order
                    {
                        product_id = product_id,
                        buyer_id = buyer_id,
                        is_payed = is_payed,
                    };
                    context.Orders.InsertOnSubmit(NewOrder);
                    context.SubmitChanges();
                    return EventService.AddEvent(DateTime.Now, NewOrder.id, "orderEvent", event_description); ;
                }
                return false;
            }
        }

        public bool UpdateOrder(int id, int buyer_id)
        {
            using (var context = new ShopDataContext())
            {
                Order Order = context.Orders.SingleOrDefault(i => i.id == id);
                if (!buyer_id.Equals(null))
                {
                    Order.buyer_id = buyer_id;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteOrder(int id)
        {
            using (var context = new ShopDataContext())
            {
                Order Order = context.Orders.SingleOrDefault(i => i.id == id);
                if (GetOrderById(id) != null && !id.Equals(null))
                {
                    context.Orders.DeleteOnSubmit(Order);
                    context.SubmitChanges();
                    List<Event> events = (List<Event>)EventService.GetEventsByOrderId(id);
                    foreach (Event item in events)
                    {
                        EventService.DeleteEvent(item.id);
                    }
                    return true;
                }
                return false;
            }
        }
    }
}
