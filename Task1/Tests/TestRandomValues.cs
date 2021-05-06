using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;

namespace Tests
{
    [TestClass]
    public class TestRandomValues
    {
        [TestClass]
        public class TestGeneratedValues
        {
            private IRepository Repository;
            private IGenerator Generator;
            private IDataContext Context;
            [TestInitialize]
            public void Initialize()
            {
                Context = new DataContext();
                Repository = new DataRepository(Context);
                Generator = new RandomGenerator();
                Generator.Generate(Context);
            }
            [TestMethod]
            public void TestProducerFields()
            {
                Assert.IsTrue(Repository.GetProducer(2).Name.Length == 6);
                Assert.IsTrue(Repository.GetProducer(2).ID == 2);
                Assert.IsTrue(Repository.GetProducer(2).YearOfCreation > 1949);
            }
            [TestMethod]
            public void TestBuyerFields()
            {
                Assert.IsTrue(Repository.GetBuyer(1).Name.Length == 8);
                Assert.IsTrue(Repository.GetBuyer(1).Surname.Length == 8);
                Assert.AreEqual(Repository.GetBuyer(1).ID, 1);
                Assert.IsTrue(Repository.GetBuyer(1).Phone > 100000000);
            }
            [TestMethod]
            public void TestOrderFields()
            {
                Assert.AreEqual(Repository.GetOrder(3).ID, 3);
                Assert.IsTrue(Repository.GetOrder(3).Buyer.Name.Length == 8);
                Assert.IsTrue(Repository.GetOrder(3).Buyer.Surname.Length == 8);
                Assert.AreEqual(Repository.GetOrder(3).Buyer.ID, 3);
                Assert.IsTrue(Repository.GetOrder(3).Buyer.Phone > 100000000);
                Assert.AreEqual(Repository.GetOrder(3).Product.ID, 6);
                Assert.IsTrue(Repository.GetOrder(3).Product.Name.Length == 8);
                Assert.IsTrue(Repository.GetOrder(3).Product.Model.Length == 8);
                Assert.IsTrue(Repository.GetOrder(3).Product.Price > 10f);
                Assert.IsTrue(Repository.GetOrder(3).Product.Size.Length == 2);
                Assert.IsTrue(Repository.GetOrder(3).Product.Producer.Name.Length == 6);
                Assert.AreEqual(Repository.GetOrder(3).Product.Producer.ID, 3);
                Assert.IsTrue(Repository.GetOrder(3).Product.Producer.YearOfCreation > 1949);
            }
            [TestMethod]
            public void TestProductFields()
            {
                Assert.IsTrue(Repository.GetProduct(2).Name.Length == 8);
                Assert.AreEqual(Repository.GetProduct(2).ID, 2);
                Assert.IsTrue(Repository.GetProduct(2).Model.Length == 8);
                Assert.IsTrue(Repository.GetProduct(2).Price > 10f);
                Assert.IsTrue(Repository.GetProduct(2).Size.Length == 2);
                Assert.IsTrue(Repository.GetProduct(2).SeasonID < 4);
                Assert.IsTrue(Repository.GetProduct(2).GetSeason().Length > 0);
                Assert.IsTrue(Repository.GetProduct(2).Producer.Name.Length == 6);
                Assert.AreEqual(Repository.GetProduct(2).Producer.ID, 4);
                Assert.IsTrue(Repository.GetProduct(2).Producer.YearOfCreation > 1949);
            }
            [TestMethod]
            public void TestEventFields()
            {
                Assert.AreEqual(Repository.GetEvent(2).ID, 2);
                Assert.IsTrue(Repository.GetEvent(2).ClientRating < 10);
                Assert.IsTrue(Repository.GetEvent(2).ClientRating > 0);
                Assert.AreEqual(Repository.GetEvent(2).Complain, null);
                Assert.IsTrue(Repository.GetEvent(2).Date !=null);
                Assert.AreEqual(Repository.GetEvent(2).Order.ID, 2);
                Assert.IsTrue(Repository.GetEvent(2).Order.Payment.Method >= 0);
                Assert.IsTrue(Repository.GetEvent(2).Order.Payment.Method < 4);
                Assert.AreEqual(Repository.GetEvent(2).Order.Buyer.ID, 2);
                Assert.IsTrue(Repository.GetEvent(2).Order.Buyer.Name.Length == 8);
                Assert.IsTrue(Repository.GetEvent(2).Order.Buyer.Surname.Length == 8);
                Assert.IsTrue(Repository.GetEvent(2).Order.Buyer.Phone > 100000000);
                Assert.AreEqual(Repository.GetEvent(2).Order.Product.ID, 1);
                Assert.IsTrue(Repository.GetEvent(2).Order.Product.Name.Length == 8);
                Assert.IsTrue(Repository.GetEvent(2).Order.Product.Model.Length == 8);
                Assert.IsTrue(Repository.GetEvent(2).Order.Product.Price > 10f);
                Assert.IsTrue(Repository.GetEvent(2).Order.Product.Size.Length == 2);
                Assert.AreEqual(Repository.GetEvent(2).Order.Product.Producer.ID, 5);
                Assert.IsTrue(Repository.GetEvent(2).Order.Product.Producer.Name.Length == 6);
                Assert.IsTrue(Repository.GetEvent(2).Order.Product.Producer.YearOfCreation > 1949);
            }
            [TestMethod]
            public void TestStates()
            {
                // ORDER EVENT
                Repository.AddEvent(new OrderEvent(8, new DateTime(2021, 4, 11, 15, 2, 0), Repository.GetOrder(4), 5));
                Assert.IsTrue(Repository.GetProductState(1) > -1);

                // COPLAIN EVENT
                Repository.AddEvent(new ComplainEvent(9, new DateTime(2021, 4, 11, 15, 2, 0), Repository.GetOrder(1), "Broken Zipper"));
                Assert.AreEqual(Repository.GetLastEvent(Repository.GetOrder(1)), Repository.GetEvent(9));
                Assert.AreEqual(Repository.GetEvent(9).Complain, "Broken Zipper");

                // ORDER -> RETURN Status test
                int status = Repository.GetProductState(0);
                Repository.AddEvent(new ReturnEvent(10, new DateTime(2021, 4, 11, 15, 2, 0), Repository.GetOrder(4), "Bad Size"));
                Assert.AreEqual(Repository.GetProductState(0), status + 1);
            }

            [TestMethod]
            public void TestNumberOfElements()
            {
                Assert.AreEqual(Repository.GetProductsNumber(), 9);
                Assert.AreEqual(Repository.GetEventsNumber(), 6);
                Assert.AreEqual(Repository.GetOrdersNumber(), 5);
                Assert.AreEqual(Repository.GetProducersNumber(), 5);
                Assert.AreEqual(Repository.GetBuyersNumber(), 4);
            }
        }
    }
}

