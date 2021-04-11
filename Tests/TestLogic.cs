using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;
using Logic;

namespace Tests
{
    [TestClass]
    public class TestLogic
    {
        private ShopLogics Shop;
        private DataContext Context;
        private IGenerator Generator;

        [TestInitialize]
        public void Initialize()
        {
            Context = new DataContext();
            Shop = new ShopLogics(new DataRepository(Context));
            Generator = new FixedGenerator();
            Generator.Generate(Context);
        }
        [TestMethod]
        public void TestAddingBuyer()
        {
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
            Buyer Buyer8 = new Buyer("Jacek", "Krzynowek", 10, 555555555);
            Shop.AddBuyer(Buyer8);
            Assert.AreEqual(Shop.GetBuyer(10), Buyer8);
            Assert.AreEqual(Shop.GetBuyersNumber(), 5);
        }
        [TestMethod]
        public void TestAddingWrongBuyer()
        {
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
            Buyer Buyer8 = new Buyer("Jacek", "Krzynowek", 10, 555555555);
            Shop.AddBuyer(Buyer8);
            Buyer Buyer9 = new Buyer("Adam", "Nowak", 10, 555555555);
            Assert.ThrowsException<Exception>(() => Shop.AddBuyer(Buyer9));
            Assert.AreEqual(Shop.GetBuyer(10), Buyer8);
            Assert.AreEqual(Shop.GetBuyersNumber(), 5);
        }
        [TestMethod]
        public void TestDeletingBuyer()
        {
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
            Shop.RemoveBuyer(3);
            Assert.AreEqual(Shop.GetBuyersNumber(), 3);
        }
        [TestMethod]
        public void TestDeletingWrongBuyer()
        {
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
            Assert.ThrowsException<Exception>(() => Shop.RemoveBuyer(5));
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
        }
        [TestMethod]
        public void TestUpdatingBuyer()
        {
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
            Buyer Buyer8 = new Buyer("Jacek", "Krzynowek", 3, 555555555);
            Shop.UpdateBuyer(3, Buyer8);
            Assert.AreEqual(Shop.GetBuyer(3), Buyer8);
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
        }
        [TestMethod]
        public void TestUpdatinggWrongBuyer()
        {
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
            Buyer Buyer8 = new Buyer("Jacek", "Krzynowek", 5, 555555555);
            Assert.ThrowsException<Exception>(() => Shop.UpdateBuyer(5, Buyer8));
            Assert.AreEqual(Shop.GetBuyersNumber(), 4);
        }
        [TestMethod]
        public void TestAddingProducer()
        {
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
            Producer Producer = new Producer("Medicine", 8, 2020);
            Shop.AddProducer(Producer);
            Assert.AreEqual(Shop.GetProducer(8), Producer);
            Assert.AreEqual(Shop.GetProducersNumber(), 6);
        }
        [TestMethod]
        public void TestAddingWrongProducer()
        {
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
            Producer Producer8 = new Producer("Smyk", 6, 2019);
            Assert.ThrowsException<Exception>(() => Shop.AddProducer(Producer8));
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
        }
        [TestMethod]
        public void TestDeletingProducer()
        {
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
            Shop.RemoveProducer(5);
            Assert.AreEqual(Shop.GetProducersNumber(), 4);
        }
        [TestMethod]
        public void TestDeletingWrongProducer()
        {
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
            Assert.ThrowsException<Exception>(() => Shop.RemoveProducer(3));
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
        }
        [TestMethod]
        public void TestUpdatingProducer()
        {
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
            Producer Producer2 = new Producer("Smyk", 7, 2019);
            Shop.UpdateProducer(7, Producer2);
            Assert.AreEqual(Shop.GetProducer(7), Producer2);
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
        }
        [TestMethod]
        public void TestUpdatinggWrongProducer()
        {
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
            Producer Producer2 = new Producer("Smyk", 7, 2019);
            Shop.UpdateProducer(7, Producer2);
            Assert.ThrowsException<Exception>(() => Shop.UpdateProducer(4, Producer2));
            Assert.AreEqual(Shop.GetProducersNumber(), 5);
        }
        [TestMethod]
        public void TestAddingProduct()
        {
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
            Hoodie Hoodie3 = new Hoodie(9, "Fast Boi", "McQueen", 26.13f, "S", Shop.GetProducer(5), 3);
            Shop.AddProduct(Hoodie3);
            Assert.AreEqual(Shop.GetProduct(9), Hoodie3);
            Assert.AreEqual(Shop.GetProductsNumber(), 10);
        }
        [TestMethod]
        public void TestAddingWrongProduct()
        {
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
            Hoodie Hoodie3 = new Hoodie(8, "Fast Boi", "McQueen", 26.13f, "S", Shop.GetProducer(5), 3);
            Assert.ThrowsException<Exception>(() => Shop.AddProduct(Hoodie3));
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
        }
        [TestMethod]
        public void TestDeletingProduct()
        {
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
            Shop.RemoveProduct(6);
            Assert.AreEqual(Shop.GetProductsNumber(), 8);
        }
        [TestMethod]
        public void TestDeletingWrongProduct()
        {
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
            Assert.ThrowsException<Exception>(() => Shop.RemoveProduct(11));
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
        }
        [TestMethod]
        public void TestUpdatingProduct()
        {
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
            Hoodie Hoodie3 = new Hoodie(8, "Fast Boi", "McQueen", 26.13f, "S", Shop.GetProducer(5), 3);
            Shop.UpdateProduct(8, Hoodie3);
            Assert.AreEqual(Shop.GetProduct(8), Hoodie3);
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
        }
        [TestMethod]
        public void TestUpdatingWrongProduct()
        {
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
            Hoodie Hoodie3 = new Hoodie(11, "Fast Boi", "McQueen", 26.13f, "S", Shop.GetProducer(5), 3);
            Assert.ThrowsException<Exception>(() => Shop.UpdateProduct(11, Hoodie3));
            Assert.AreEqual(Shop.GetProductsNumber(), 9);
        }
        [TestMethod]
        public void TestAddingOrder()
        {
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
            Order Order5 = new Order(4, Shop.GetBuyer(3), Shop.GetProduct(5), 0);
            Shop.AddOrder(Order5);
            Assert.AreEqual(Shop.GetOrder(4), Order5);
            Assert.AreEqual(Shop.GetOrdersNumber(), 5);
        }
        [TestMethod]
        public void TestAddingWrongOrder()
        {
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
            Order Order5 = new Order(3, Shop.GetBuyer(3), Shop.GetProduct(5), 1);
            Assert.ThrowsException<Exception>(() => Shop.AddOrder(Order5));
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
        }
        [TestMethod]
        public void TestDeletingOrder()
        {
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
            Shop.RemoveOrder(2);
            Assert.AreEqual(Shop.GetOrdersNumber(), 3);
        }
        [TestMethod]
        public void TestDeletingWrongOrder()
        {
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
            Assert.ThrowsException<Exception>(() => Shop.RemoveOrder(11));
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
        }
        [TestMethod]
        public void TestUpdatingOrder()
        {
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
            Order Order5 = new Order(3, Shop.GetBuyer(3), Shop.GetProduct(5), 1);
            Shop.UpdateOrder(3, Order5);
            Assert.AreEqual(Shop.GetOrder(3), Order5);
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
        }
        [TestMethod]
        public void TestUpdatingWrongOrder()
        {
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
            Hoodie Hoodie3 = new Hoodie(11, "Fast Boi", "McQueen", 26.13f, "S", Shop.GetProducer(5), 3);
            Assert.ThrowsException<Exception>(() => Shop.UpdateProduct(11, Hoodie3));
            Assert.AreEqual(Shop.GetOrdersNumber(), 4);
        }
        [TestMethod]
        public void TestAddingEventToExistingOrder()
        {
            Assert.AreEqual(Shop.GetEventNumber(), 6);
            Event Event7 = new ReturnEvent(6, new DateTime(2021, 4, 11, 17, 1, 0), Shop.GetOrder(1), "Wrong Size");
            Shop.AddEvent(Event7);
            Assert.AreEqual(Shop.GetEvent(6), Event7);
            Assert.AreEqual(Shop.GetEventNumber(), 7);
        }
        [TestMethod]
        public void TestAddingWrongEvent()
        {
            Assert.AreEqual(Shop.GetEventNumber(), 6);
            Event Event7 = new ReturnEvent(5, new DateTime(2021, 4, 11, 17, 1, 0), Shop.GetOrder(1), "Wrong Size");
            Assert.ThrowsException<Exception>(() => Shop.AddEvent(Event7));
            Assert.AreEqual(Shop.GetEventNumber(), 6);
        }
        [TestMethod]
        public void TestAddingWrongComplainEventWithoutOrder()
        {
            Assert.AreEqual(Shop.GetEventNumber(), 6);
            Order Order5 = new Order(5, Shop.GetBuyer(3), Shop.GetProduct(8), 0);
            Shop.AddOrder(Order5);
            Assert.ThrowsException<Exception>(() => Shop.AddEvent(new ComplainEvent(7, new DateTime(2021, 4, 11, 17, 1, 0), Order5, "Stains on Shirt")));
            Assert.AreEqual(Shop.GetEventNumber(), 6);
        }
        [TestMethod]
        public void TestRemovingEvent()
        {
            Assert.AreEqual(Shop.GetEventNumber(), 6);
            Shop.RemoveEvent(4);
            Assert.AreEqual(Shop.GetEventNumber(), 5);
        }
        [TestMethod]
        public void TestRemovingWrongEvent()
        {
            Assert.AreEqual(Shop.GetEventNumber(), 6);
            Assert.ThrowsException<Exception>(() => Shop.RemoveEvent(11));
            Assert.AreEqual(Shop.GetEventNumber(), 6);
        }
    }
}
