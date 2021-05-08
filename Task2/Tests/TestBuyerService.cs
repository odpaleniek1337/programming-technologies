using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service;

namespace Tests
{
    [TestClass]
    public class TestBuyerService
    {
        [TestMethod]
        public void AddBuyerToDatabaseTest()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.AreEqual(BuyerService.GetBuyer("696 969 696").name, "Jan");
            Assert.AreEqual(BuyerService.GetBuyer("696 969 696").surname, "Kowalski");
            Assert.AreEqual(BuyerService.GetBuyer("696 969 696").phone, "696 969 696");

            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 696").phone));
        }

        [TestMethod]
        public void UpdateBuyerTest()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(BuyerService.UpdateBuyer(BuyerService.GetBuyer("696 969 696").id, "Jan", "Kowalski", "696 969 697"));

            Assert.AreEqual(BuyerService.GetBuyer("696 969 697").name, "Jan");
            Assert.AreEqual(BuyerService.GetBuyer("696 969 697").surname, "Kowalski");
            Assert.AreEqual(BuyerService.GetBuyer("696 969 697").phone, "696 969 697");

            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 697").phone));
        }

        [TestMethod]
        public void AddSameBuyerTest()
        {
            Assert.IsTrue(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsFalse(BuyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));

            Assert.IsTrue(BuyerService.DeleteBuyer(BuyerService.GetBuyer("696 969 696").phone));
        }
    }
}
