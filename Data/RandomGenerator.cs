using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RandomGenerator : IGenerator
    {
        public static string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;

        }
        public static string RandomStringNumber(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;

        }
        public static DateTime RandomDate()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));

        }
        public void Generate(DataContext Context)
        {
            var rand = new Random();
            // Generating Producers
            Producer Producer1 = new Producer(RandomString(6), 1, rand.Next(1950, 2020));
            Producer Producer2 = new Producer(RandomString(6), 2, rand.Next(1950, 2020));
            Producer Producer3 = new Producer(RandomString(6), 3, rand.Next(1950, 2020));
            Producer Producer4 = new Producer(RandomString(6), 4, rand.Next(1950, 2020));
            Producer Producer5 = new Producer(RandomString(6), 5, rand.Next(1950, 2020));

            Context.Producers.Add(1, Producer1);
            Context.Producers.Add(2, Producer2);
            Context.Producers.Add(3, Producer3);
            Context.Producers.Add(4, Producer4);
            Context.Producers.Add(5, Producer5);

            // Generating Products
            Hoodie Hoodie1 = new Hoodie(0, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer4, rand.Next(0, 3));
            Hoodie Hoodie2 = new Hoodie(6, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer3, rand.Next(0, 3));
            Jacket Jacket1 = new Jacket(1, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer5, rand.Next(0, 3));
            Jacket Jacket2 = new Jacket(7, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer4, rand.Next(0, 3));
            Shirt Shirt1 = new Shirt(8, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer3, rand.Next(0, 3));
            Shirt Shirt2 = new Shirt(2, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer4, rand.Next(0, 3));
            Shoes Shoes1 = new Shoes(3, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), rand.Next(30, 45).ToString(), Producer1, rand.Next(0, 3));
            Shoes Shoes2 = new Shoes(4, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), rand.Next(30, 45).ToString(), Producer2, rand.Next(0, 3));
            Shoes Shoes3 = new Shoes(5, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), rand.Next(30, 45).ToString(), Producer1, rand.Next(0, 3));

            Context.Products.Add(0, Hoodie1);
            Context.Products.Add(6, Hoodie2);
            Context.Products.Add(1, Jacket1);
            Context.Products.Add(7, Jacket2);
            Context.Products.Add(8, Shirt1);
            Context.Products.Add(2, Shirt2);
            Context.Products.Add(3, Shoes1);
            Context.Products.Add(4, Shoes2);
            Context.Products.Add(5, Shoes3);

            // Generating Buyers
            Buyer Buyer1 = new Buyer(RandomString(8), RandomString(8), 0, rand.Next(100000000, 999999999));
            Buyer Buyer2 = new Buyer(RandomString(8), RandomString(8), 1, rand.Next(100000000, 999999999));
            Buyer Buyer3 = new Buyer(RandomString(8), RandomString(8), 2, rand.Next(100000000, 999999999));
            Buyer Buyer4 = new Buyer(RandomString(8), RandomString(8), 3, rand.Next(100000000, 999999999));

            Context.Buyers.Add(0, Buyer1);
            Context.Buyers.Add(1, Buyer2);
            Context.Buyers.Add(2, Buyer3);
            Context.Buyers.Add(3, Buyer4);

            // Generating Orders
            Order Order1 = new Order(0, Buyer1, Shoes1, rand.Next(0, 2));
            Order Order2 = new Order(1, Buyer2, Jacket2, rand.Next(0, 2));
            Order Order3 = new Order(2, Buyer3, Jacket1, rand.Next(0, 2));
            Order Order4 = new Order(3, Buyer4, Hoodie2, rand.Next(0, 2));

            Context.Orders.Add(0, Order1);
            Context.Orders.Add(1, Order2);
            Context.Orders.Add(2, Order3);
            Context.Orders.Add(3, Order4);

            // Generating Events
            Event Event1 = new OrderEvent(0, RandomDate(), Order1, rand.Next(1, 5));
            Event Event2 = new OrderEvent(1, RandomDate(), Order2, rand.Next(1, 5));
            Event Event3 = new OrderEvent(2, RandomDate(), Order3, rand.Next(1, 5));
            Event Event4 = new OrderEvent(3, RandomDate(), Order4, rand.Next(1, 5));
            Event Event5 = new ComplainEvent(4, RandomDate(), Order3, RandomString(20));
            Event Event6 = new ReturnEvent(5, RandomDate(), Order1, RandomString(20));

            Context.Events.Add(0, Event1);
            Context.Events.Add(1, Event2);
            Context.Events.Add(2, Event3);
            Context.Events.Add(3, Event4);
            Context.Events.Add(4, Event5);
            Context.Events.Add(5, Event6);
        }      
    }
}