using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;
using Data.API;
using Model;
using Service;
using Model.ViewModel;

namespace Tests.ModelTest
{
    [TestClass]
    public class TestBuyerModelDatabase
    {
        public IRepository repository;
        public BuyerService service;
        public BuyersViewModel model;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            service = new BuyerService(repository);
            model = new BuyersViewModel(service);
        }
        [TestMethod]
        public void TestAddDeleteBuyer()
        {
            model.Name = "test";
            model.Surname = "testowy";
            model.Phone = "111111111";
            model.Text = "test";
            // model.AddBuyer();
            model.DeleteBuyer();
            Assert.IsNull(service.GetBuyers());
        }
    }
}
