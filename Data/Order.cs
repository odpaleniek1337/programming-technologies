﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Order
    {
        static List<OrderStatus> order_statuses = new List<OrderStatus>();
        public Order(int ID, Buyer Buyer)
        {
            this.ID = ID;
            this.Buyer = Buyer;
            this.CreatedAt = DateTime.Now;
            order_statuses.Add(new OrderStatus("Created", DateTime.Now));
        }

        public int ID { get; set; }
        public Buyer Buyer { get; set; }

        public DateTime CreatedAt { get; set; }

        public OrderStatus GetLastStatus()
        {
            return order_statuses[order_statuses.Count - 1];
        }
    }
}
