using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service;


namespace Tests
{
    [TestClass]
    public class TestEventService
    {
        [TestMethod]
        public void AddEventToDatabaseTest()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(OrderService.AddOrder(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id, true, "All good, buyer happy"));

            Assert.IsTrue(EventService.AddEvent(DateTime.Now, OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id, "returnEvent", "test"));

            Assert.AreEqual(EventService.GetEventsByOrderId(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id).Count(), 2);
  
            Assert.IsTrue(OrderService.DeleteOrder(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id));
            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 696").phone));
        }

        [TestMethod]
        public void AddReturnEventToDatabaseTest()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(OrderService.AddOrder(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id, true, "All good, buyer happy"));

            Assert.AreEqual(ProductService.GetProductByModel("#343412b").quantity, 19);

            Assert.IsTrue(EventService.AddEvent(DateTime.Now, OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id, "returnEvent", "test"));

            Assert.AreEqual(EventService.GetEventsByOrderId(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id).ElementAt(1).type, "returnEvent");

            Assert.AreEqual(EventService.GetEventsByOrderId(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id).Count(), 2);

            Assert.AreEqual(ProductService.GetProductByModel("#343412b").quantity, 20);

            Assert.IsTrue(OrderService.DeleteOrder(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id));
            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 696").phone));
        }

        [TestMethod]
        public void UpdateEvent()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(OrderService.AddOrder(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id, true, "All good, buyer happy"));

            Assert.AreEqual(ProductService.GetProductByModel("#343412b").quantity, 19);

            Assert.IsTrue(EventService.AddEvent(DateTime.Now, OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id, "returnEvent", "test"));

            Assert.IsTrue(EventService.UpdateEvent(EventService.GetEventsByOrderId(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id).ElementAt(1).id, "Wrong size"));

            Assert.AreEqual(EventService.GetEventsByOrderId(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id).ElementAt(1).description, "Wrong size");

            Assert.AreEqual(EventService.GetEventsByOrderId(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id).Count(), 2);

            Assert.AreEqual(ProductService.GetProductByModel("#343412b").quantity, 20);

            Assert.IsTrue(OrderService.DeleteOrder(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id));
            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 696").phone));
        }
    }
}
