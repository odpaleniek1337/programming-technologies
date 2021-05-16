using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;
using Data.API;
using Model;
using Service;

namespace Tests.ModelTest
{
    [TestClass]
    public class TestProductModelFixed
    {
        public IRepository repository;
        public ProductService service;
        public ProductViewModel model;

        [TestInitialize]
        public void Initialize()
        {
            repository = new FixedRepository();
            service = new ProductService(repository);
            model = new ProductViewModel(service);
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
