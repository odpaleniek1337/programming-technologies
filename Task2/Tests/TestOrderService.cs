using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service;

namespace Tests
{
    [TestClass]
    public class TestOrderService
    {
        [TestMethod]
        public void AddOrderToDatabaseTest()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(OrderService.AddOrder(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id, true, "All good, buyer happy"));

            Assert.IsTrue(OrderService.DeleteOrder(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id));
            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 696").phone));
        }

        [TestMethod]
        public void GetAllOrdersForProductTest()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(OrderService.AddOrder(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id, true, "All good, buyer happy"));
            Assert.IsTrue(OrderService.AddOrder(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id, true, "All good, buyer happy"));

            Assert.IsTrue(OrderService.GetOrdersByProductId(ProductService.GetProductByModel("#343412b").id).Count() == 2);

            Assert.IsTrue(OrderService.DeleteOrder(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id));
            Assert.IsTrue(OrderService.DeleteOrder(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id));
            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 696").phone));
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(BuyerService.AddBuyer("Jesika", "Kowalski", "696 969 697"));
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(OrderService.AddOrder(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id, true, "All good, buyer happy"));

            Assert.IsTrue(OrderService.UpdateOrder(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 696").id).id, BuyerService.GetBuyer("696 969 697").id));

            Assert.AreEqual(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 697").id).buyer_id, BuyerService.GetBuyer("696 969 697").id);

            Assert.IsTrue(OrderService.DeleteOrder(OrderService.GetLatestOrderByProductAndBuyer(ProductService.GetProductByModel("#343412b").id, BuyerService.GetBuyer("696 969 697").id).id));
            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 696").phone));
            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 697").phone));
        }
    }
}
