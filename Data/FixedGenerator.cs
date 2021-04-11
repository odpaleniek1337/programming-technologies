using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FixedGenerator : IGenerator
    {
        public void Generate(DataContext Context)
        {//Generating Producers
            Producer Producer1 = new Producer("Adidas", 1, 1997);
            Producer Producer2 = new Producer("Nike", 2, 1998);
            Producer Producer3 = new Producer("H&M", 5, 1999);
            Producer Producer4 = new Producer("Reserved", 6, 2010);
            Producer Producer5 = new Producer("North Face", 7, 1980);

            Context.Producers.Add(1, Producer1);
            Context.Producers.Add(2, Producer2);
            Context.Producers.Add(3, Producer3);
            Context.Producers.Add(4, Producer4);
            Context.Producers.Add(5, Producer5);

            //Generating Products
            Hoodie Hoodie1 = new Hoodie(0, "Sunny Longsleeve", "Black", 72.05f, "M", Producer4, 1);
            Hoodie Hoodie2 = new Hoodie(6, "Fast Zip", "Rainbow", 56.22f, "L", Producer3, 3);
            Jacket Jacket1 = new Jacket(1, "Happy", "Cyan", 125.11f, "XL", Producer5, 2);
            Jacket Jacket2 = new Jacket(7, "Sad", "Magenta", 183.12f, "L", Producer4, 1);
            Shirt Shirt1 = new Shirt(8, "Boi", "White", 13.22f, "XS", Producer3, 0);
            Shirt Shirt2 = new Shirt(2, "Fregaty Dwie", "Blue", 22.22f, "M", Producer4, 0);
            Shoes Shoes1 = new Shoes(3, "Comfy Ones", "Red", 13.37f, "38", Producer1, 0);
            Shoes Shoes2 = new Shoes(4, "Uncomfy Ones", "White", 21.15f, "43", Producer2, 2);
            Shoes Shoes3 = new Shoes(5, "Maklowicz", "Pink", 99.99f, "42", Producer1, 1);

            Context.Products.Add(0, Hoodie1);
            Context.Products.Add(6, Hoodie2);
            Context.Products.Add(1, Jacket1);
            Context.Products.Add(7, Jacket2);
            Context.Products.Add(8, Shirt1);
            Context.Products.Add(2, Shirt2);
            Context.Products.Add(3, Shoes1);
            Context.Products.Add(4, Shoes2);
            Context.Products.Add(5, Shoes3);

            //Generating Buyers
            Buyer Buyer1 = new Buyer("Piotr", "Sienkiewicz", 0, 600600600);
            Buyer Buyer2 = new Buyer("Michal", "Grzyb", 1, 500900400);
            Buyer Buyer3 = new Buyer("Lukasz", "Szukasz", 2, 713713713);
            Buyer Buyer4 = new Buyer("Walter", "Bialy", 3, 350400500);

            Context.Buyers.Add(0, Buyer1);
            Context.Buyers.Add(1, Buyer2);
            Context.Buyers.Add(2, Buyer3);
            Context.Buyers.Add(3, Buyer4);

            //Generating Orders

            Order Order1 = new Order(0, Buyer1, Shoes1, 0);
            Order Order2 = new Order(1, Buyer2, Jacket2, 1);
            Order Order3 = new Order(2, Buyer3, Jacket1, 0);
            Order Order4 = new Order(3, Buyer4, Hoodie2, 0);

            Context.Orders.Add(0, Order1);
            Context.Orders.Add(1, Order2);
            Context.Orders.Add(2, Order3);
            Context.Orders.Add(3, Order4);
            //Generating Events

            Event Event1 = new OrderEvent(0, new DateTime(2021, 4, 11, 15, 0, 0), Order1, 2);
            Event Event2 = new OrderEvent(1, new DateTime(2021, 4, 11, 15, 1, 0), Order2, 7);
            Event Event3 = new OrderEvent(2, new DateTime(2021, 4, 11, 15, 2, 0), Order3, 0);
            Event Event4 = new OrderEvent(3, new DateTime(2021, 4, 11, 15, 3, 0), Order4, 10);
            Event Event5 = new ComplainEvent(4, new DateTime(2021, 4, 11, 15, 4, 0), Order3, "Bad");
            Event Event6 = new ReturnEvent(5, new DateTime(2021, 4, 11, 15, 5, 0), Order1, "Wrong Size");

            

            Context.Events.Add(0, Event1);
            Context.Events.Add(1, Event2);
            Context.Events.Add(2, Event3);
            Context.Events.Add(3, Event4);
            Context.Events.Add(4, Event5);
            Context.Events.Add(5, Event6);
        }
    }
}
