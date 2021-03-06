using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Order : IOrder
    {
        public Order(int ID, IBuyer Buyer, IProduct Product, int PaymentMethod)
        {
            this.ID = ID;
            this.Buyer = Buyer;
            this.Payment = new Payment(PaymentMethod, Product.Price);
            this.Product = Product;
        }
        public IProduct Product { get; set; }
        public int ID { get; set; }
        public IBuyer Buyer { get; set; }
        public Payment Payment { get; set; }
    }
}
