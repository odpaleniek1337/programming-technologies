using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Service
{
    public class EventService
    {
        static public IEnumerable<Event> GetEvents()
        {
            using (var context = new ShopDataContext())
            {
                return context.Events.ToList();
            }
        }

        static public Event GetEventById(int id)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Event Event in context.Events.ToList())
                {
                    if (Event.id.Equals(id))
                    {
                        return Event;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<Event> GetEventsByOrderId(int order_id)
        {
            using (var context = new ShopDataContext())
            {
                List<Event> result = new List<Event>();
                foreach (Event Event in context.Events.ToList())
                {
                    if (Event.order_id.Equals(order_id))
                    {
                        result.Add(Event);
                    }
                }
                return result;
            }
        }

        static public bool AddEvent(DateTime date, int order_id, string type, string description)
        {
            using (var context = new ShopDataContext())
            {
                if (!date.Equals(null) && !order_id.Equals(null) && !type.Equals(null) && !description.Equals(null))
                {
                    if (type == "orderEvent")
                    {
                        if (GetEventsByOrderId(order_id).Count() == 0)
                        {
                            Order Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                            Product Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);
                            if (Product.quantity > 0)
                            {
                                Product.quantity -= 1;

                                Event NewEvent = new Event
                                {
                                    date = date,
                                    order_id = order_id,
                                    type = type,
                                    description = description,
                                };
                                context.Events.InsertOnSubmit(NewEvent);
                                context.SubmitChanges();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (type == "returnEvent")
                    {
                        Order Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                        Product Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);

                        Product.quantity += 1;

                        Event NewEvent = new Event
                        {
                            date = date,
                            order_id = order_id,
                            type = type,
                            description = description,
                        };
                        context.Events.InsertOnSubmit(NewEvent);
                        context.SubmitChanges();
                        return true;
                    }
                    if (type == "complainEvent")
                    {
                        Order Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                        Product Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);

                        Event NewEvent = new Event
                        {
                            date = date,
                            order_id = order_id,
                            type = type,
                            description = description,
                        };
                        context.Events.InsertOnSubmit(NewEvent);
                        context.SubmitChanges();
                        return true;
                    }
                }
                return false;
            }
        }

        static public bool UpdateEvent(int id , string description)
        {
            using (var context = new ShopDataContext())
            {
                Event Event = context.Events.SingleOrDefault(i => i.id == id);
                if (!description.Equals(null))
                {
                    Event.description = description;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool DeleteEvent(int id)
        {
            using (var context = new ShopDataContext())
            {
                Event Event = context.Events.SingleOrDefault(i => i.id == id);
                if (GetEventById(id) != null && !id.Equals(null))
                {
                    context.Events.DeleteOnSubmit(Event);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
