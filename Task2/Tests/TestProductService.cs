using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service;

namespace Tests
{
    [TestClass]
    public class TestProductService
    {
        [TestMethod]
        public void AddProductToDatabaseTest()
        {
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.AreEqual(ProductService.GetProductByModel("#343412b").name, "SB White");
            Assert.AreEqual(ProductService.GetProductByModel("#343412b").model, "#343412b");
            Assert.AreEqual(ProductService.GetProductByModel("#343412b").price, 200);
            Assert.AreEqual(ProductService.GetProductByModel("#343412b").size, 41);
            Assert.AreEqual(ProductService.GetProductByModel("#343412b").producer, "Nike");
            Assert.AreEqual(ProductService.GetProductByModel("#343412b").season, "Summer");
            Assert.AreEqual(ProductService.GetProductByModel("#343412b").quantity, 20);

            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
        }

        [TestMethod]
        public void AddSameProductToDatabaseTest()
        {
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.IsFalse(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
        }

        [TestMethod]
        public void GetProductsByName()
        {
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343413b", 200, 42, "Nike", "Summer", 20));

            Assert.IsTrue(ProductService.GetProductByName("SB White").Count() == 2);

            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343413b").id));
        }

        [TestMethod]
        public void UpdateProductQuantity()
        {
            Assert.IsTrue(ProductService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(ProductService.UpdateProductQuantity(ProductService.GetProductByModel("#343412b").id, 30));

            Assert.AreEqual(ProductService.GetProductByModel("#343412b").quantity, 30);

            Assert.IsTrue(ProductService.DeleteProduct(ProductService.GetProductByModel("#343412b").id));
        }
    }
}
