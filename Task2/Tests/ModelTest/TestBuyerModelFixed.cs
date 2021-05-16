using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;
using Data.API;
using Model;
using Service;

namespace Tests.ModelTest
{
    [TestClass]
    public class TestBuyerModelFixed
    {
        public IRepository repository;
        public BuyerService service;
        public BuyersViewModel model;

        [TestInitialize]
        public void Initialize()
        {
            repository = new FixedRepository();
            service = new BuyerService(repository);
            model = new BuyersViewModel(service);
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
