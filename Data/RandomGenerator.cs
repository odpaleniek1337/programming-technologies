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
        public void Generate(DataContext Context)
        {
            var rand = new Random();
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

            Hoodie Hoodie1 = new Hoodie(0, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer4, rand.Next(0, 3));
            Hoodie Hoodie2 = new Hoodie(6, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer3, rand.Next(0, 3));
            Jacket Jacket1 = new Jacket(1, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer5, rand.Next(0, 3));
            Jacket Jacket2 = new Jacket(7, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer4, rand.Next(0, 3));
            Shirt Shirt1 = new Shirt(8, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer3, rand.Next(0, 3));
            Shirt Shirt2 = new Shirt(2, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), RandomString(2), Producer4, rand.Next(0, 3));
            Shoes Shoes1 = new Shoes(3, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), rand.Next(30, 45).ToString(), Producer1, rand.Next(0, 3));
            Shoes Shoes2 = new Shoes(4, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), rand.Next(30, 45).ToString(), Producer2, rand.Next(0, 3));
            Shoes Shoes3 = new Shoes(5, RandomString(8), RandomStringNumber(8), rand.Next(10, 200), rand.Next(30, 45).ToString(), Producer1, rand.Next(0, 3));
        }      
    }
}