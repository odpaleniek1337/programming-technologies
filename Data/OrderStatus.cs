using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class OrderStatus
    {
        public OrderStatus(string Name, DateTime CreatedAt)
        {
            this.Name = Name;
            this.CreatedAt = CreatedAt;
        }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
