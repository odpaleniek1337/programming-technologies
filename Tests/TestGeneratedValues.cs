using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;

namespace Tests
{
    [TestClass]
    public class TestGeneratedValues
    {
        private IRepository Repository;
        private IGenerator Generator;
        private DataContext Context;
        [TestInitialize]
        public void Initialize()
        {
            Context = new DataContext();
            Repository = new DataRepository(Context);
            Generator = new FixedGenerator();
            Generator.Generate(Context);
        }

        [TestMethod]
        public void TestProducerFields()
        {
            Assert.AreEqual(Repository.GetProducer(2).Name, "Nike");
            Assert.AreEqual(Repository.GetProducer(2).ID, 2);
            Assert.AreEqual(Repository.GetProducer(2).YearOfCreation, 1998);
        }
        [TestMethod]
        public void TestBuyerFields()
        {
            Assert.AreEqual(Repository.GetBuyer(1).Name, "Michal");
            Assert.AreEqual(Repository.GetBuyer(1).Surname, "Grzyb");
            Assert.AreEqual(Repository.GetBuyer(1).ID, 1);
            Assert.AreEqual(Repository.GetBuyer(1).Phone, 500900400);
        }
        [TestMethod]
        public void TestOrderFields()
        {
            Assert.AreEqual(Repository.GetOrder(3).ID, 3);
            Assert.AreEqual(Repository.GetOrder(3).Buyer.Name, "Walter");
            Assert.AreEqual(Repository.GetOrder(3).Buyer.Surname, "Bialy");
            Assert.AreEqual(Repository.GetOrder(3).Buyer.ID, 3);
            Assert.AreEqual(Repository.GetOrder(3).Buyer.Phone, 350400500);
            Assert.AreEqual(Repository.GetOrder(3).Product.ID, 6);
            Assert.AreEqual(Repository.GetOrder(3).Product.Name, "Fast Zip");
            Assert.AreEqual(Repository.GetOrder(3).Product.Model, "Rainbow");
            Assert.AreEqual(Repository.GetOrder(3).Product.Price, 56.22f);
            Assert.AreEqual(Repository.GetOrder(3).Product.Size, "L");
            Assert.AreEqual(Repository.GetOrder(3).Product.Producer.Name, "H&M");
            Assert.AreEqual(Repository.GetOrder(3).Product.Producer.ID, 5);
            Assert.AreEqual(Repository.GetOrder(3).Product.Producer.YearOfCreation, 1999);
        }
        [TestMethod]
        public void TestProductFields()
        {
            Assert.AreEqual(Repository.GetProduct(2).Name, "Fregaty Dwie");
            Assert.AreEqual(Repository.GetProduct(2).ID, 2);
            Assert.AreEqual(Repository.GetProduct(2).Model, "Blue");
            Assert.AreEqual(Repository.GetProduct(2).Price, 22.22f);
            Assert.AreEqual(Repository.GetProduct(2).Size, "M");
            Assert.AreEqual(Repository.GetProduct(2).SeasonID, 0);
            Assert.AreEqual(Repository.GetProduct(2).GetSeason(), "Summer");
            Assert.AreEqual(Repository.GetProduct(2).Producer.Name, "Reserved");
            Assert.AreEqual(Repository.GetProduct(2).Producer.ID, 6);
            Assert.AreEqual(Repository.GetProduct(2).Producer.YearOfCreation, 2010);
        }

        [TestMethod]
        public void TestEventFields()
        {
            Assert.AreEqual(Repository.GetEvent(2).ID, 2);
            Assert.AreEqual(Repository.GetEvent(2).ClientRating, 0);
            Assert.AreEqual(Repository.GetEvent(2).Complain, null);
            Assert.AreEqual(Repository.GetEvent(2).Date, new DateTime(2021, 4, 11, 15, 2, 0));
            Assert.AreEqual(Repository.GetEvent(2).Order.ID, 2);
            Assert.AreEqual(Repository.GetEvent(2).Order.Payment.Method, 0);
            Assert.AreEqual(Repository.GetEvent(2).Order.Buyer.ID, 2);
            Assert.AreEqual(Repository.GetEvent(2).Order.Buyer.Name, "Lukasz");
            Assert.AreEqual(Repository.GetEvent(2).Order.Buyer.Surname, "Szukasz");
            Assert.AreEqual(Repository.GetEvent(2).Order.Buyer.Phone, 713713713);
            Assert.AreEqual(Repository.GetEvent(2).Order.Product.ID, 1);
            Assert.AreEqual(Repository.GetEvent(2).Order.Product.Name, "Happy");
            Assert.AreEqual(Repository.GetEvent(2).Order.Product.Model, "Cyan");
            Assert.AreEqual(Repository.GetEvent(2).Order.Product.Price, 125.11f);
            Assert.AreEqual(Repository.GetEvent(2).Order.Product.Size, "XL");
            Assert.AreEqual(Repository.GetEvent(2).Order.Product.Producer.ID, 7);
            Assert.AreEqual(Repository.GetEvent(2).Order.Product.Producer.Name, "North Face");
            Assert.AreEqual(Repository.GetEvent(2).Order.Product.Producer.YearOfCreation, 1980);
        }
        [TestMethod]
        public void TestStates()
        {
            // ORDER EVENT
            Repository.AddOrder(new Order(10, Repository.GetBuyer(1), Repository.GetProduct(1), 0));
            Repository.AddEvent(new OrderEvent(8, new DateTime(2021, 4, 11, 15, 2, 0), Repository.GetOrder(10), 5));
            Assert.AreEqual(Repository.GetProductState(1), 9);

            // FORCE CHANGE STATUS (AKA RESUPPLY)
            Repository.UpdateState(Repository.GetProduct(0), 20);
            Assert.AreEqual(Repository.GetProductState(0), 20);

            // COPLAIN EVENT
            Repository.AddEvent(new ComplainEvent(9, new DateTime(2021, 4, 11, 15, 2, 0), Repository.GetOrder(10), "Broken Zipper"));
            Assert.AreEqual(Repository.GetLastEvent(Repository.GetOrder(10)), Repository.GetEvent(9));
            Assert.AreEqual(Repository.GetEvent(9).Complain, "Broken Zipper");

            // ORDER -> RETURN Status test
            Assert.AreEqual(Repository.GetProductState(0), 20);
            Repository.AddOrder(new Order(11, Repository.GetBuyer(1), Repository.GetProduct(0), 0));
            Repository.AddEvent(new OrderEvent(10, new DateTime(2021, 4, 11, 15, 2, 0), Repository.GetOrder(11), 5));
            Assert.AreEqual(Repository.GetProductState(0), 19);
            Repository.AddEvent(new ReturnEvent(11, new DateTime(2021, 4, 11, 15, 2, 0), Repository.GetOrder(11), "Bad Size"));
            Assert.AreEqual(Repository.GetProductState(0), 20);
        }
        [TestMethod]
        public void TestNumberOfElements()
        {
            Assert.AreEqual(Repository.GetProductsNumber(), 9);
            Assert.AreEqual(Repository.GetEventsNumber(), 6);
            Assert.AreEqual(Repository.GetOrdersNumber(), 4);
            Assert.AreEqual(Repository.GetProducersNumber(), 6);
            Assert.AreEqual(Repository.GetBuyersNumber(), 4);
        }
    }
}
