using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Order
    {
        public Order(int ID, Buyer Buyer, IProduct Product, int PaymentMethod)
        {
            this.ID = ID;
            this.Buyer = Buyer;
            this.CreatedAt = DateTime.Now;
            this.Payment = new Payment(PaymentMethod, Product.Price);
            this.Product = Product;
        }
        public IProduct Product { get; set; }
        public int Amount { get; set; }
        public int ID { get; set; }
        public Buyer Buyer { get; set; }
        public Payment Payment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
