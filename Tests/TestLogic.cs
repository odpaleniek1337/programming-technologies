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
    }
}
