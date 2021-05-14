using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Service
{
    public class EventService
    {
        static public IEnumerable<Events> GetEvents()
        {
            using (var context = new ShopDataContext())
            {
                return context.Events.ToList();
            }
        }

        static public Events GetEventById(int id)
        {
            using (var context = new ShopDataContext())
            {
                foreach (Events Event in context.Events.ToList())
                {
                    if (Event.id.Equals(id))
                    {
                        return Event;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<Events> GetEventsByOrderId(int order_id)
        {
            using (var context = new ShopDataContext())
            {
                List<Events> result = new List<Events>();
                foreach (Events Event in context.Events.ToList())
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
                            Orders Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                            Products Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);
                            if (Product.quantity > 0)
                            {
                                Product.quantity -= 1;

                                Events NewEvent = new Events
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
                        Orders Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                        Products Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);

                        Product.quantity += 1;

                        Events NewEvent = new Events
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
                        Orders Order = context.Orders.SingleOrDefault(i => i.id == order_id);
                        Products Product = context.Products.SingleOrDefault(i => i.id == Order.product_id);

                        Events NewEvent = new Events
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
                Events Event = context.Events.SingleOrDefault(i => i.id == id);
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
                Events Event = context.Events.SingleOrDefault(i => i.id == id);
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
