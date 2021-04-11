using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class FixedGenerator
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
            Hoodie Hoodie1 = new Hoodie(0, "Sunny Longsleeve", "Black", 72.05f, "M", Producer4);
            Hoodie Hoodie2 = new Hoodie(6, "Fast Zip", "Rainbow", 56.22f, "L", Producer3);
            Jacket Jacket1 = new Jacket(1, "Happy", "Cyan", 125.11f, "XL", Producer5, 3);
            Jacket Jacket2 = new Jacket(7, "Sad", "Magenta", 183.12f, "L", Producer4, 0);
            Shirt Shirt1 = new Shirt(8, "Boi", "White", 13.22f, "XS", Producer3, "Classic");
            Shirt Shirt2 = new Shirt(2, "Fregaty Dwie", "Blue", 22.22f, "M", Producer4, "Sailor");
            Shoes Shoes1 = new Shoes(3, "Comfy Ones", "Red", 13.37f, "38", Producer1, true);
            Shoes Shoes2 = new Shoes(4, "Uncomfy Ones", "White", 21.15f, "43", Producer2, false);
            Shoes Shoes3 = new Shoes(5, "Maklowicz", "Pink", 99.99f, "42", Producer1, true);

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
            Buyer Buyer4 = new Buyer("Walter", "Biały", 3, 350400500);

            Context.Buyers.Add(0, Buyer1);
            Context.Buyers.Add(1, Buyer2);
            Context.Buyers.Add(2, Buyer3);
            Context.Buyers.Add(3, Buyer4);

            //Generating Orders
            //Generating Events
        }
    }
}
