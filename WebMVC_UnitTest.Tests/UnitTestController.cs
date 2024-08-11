using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebMVC_UnitTest.Controllers;
using WebMVC_UnitTest.Models;
using WebMVC_UnitTest.Test;

namespace WebMVC_UnitTest.Tests
{
    [TestClass]
    public class UnitTestController
    {
        [TestMethod]
        public void TestIndexRender()
        {
            // arrange
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            // act
            ActionResult result = fakeController.Index();

            // assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestIndexModel()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            ViewResult result = fakeController.Index() as ViewResult;
            IList<Product> products = result.Model as IList<Product>;

            Assert.IsNotNull(products);
            Assert.AreEqual(1, products.Count);
        }

        [TestMethod]
        public void TestCreateModel()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());
            fakeController.ModelState.AddModelError("Price", "Not required");

            ViewResult result = fakeController.Create(new Product()) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void TestCreateRedirectToIndex()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            RedirectToRouteResult result = fakeController.Create(new Product()) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            var products = (fakeController.Index() as ViewResult).Model;
            Assert.AreEqual(2, (products as IList<Product>).Count);
        }

        // ACtion Details
        [TestMethod]
        public void TestDetailsView()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            ViewResult result = fakeController.Details(2) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestDetailsViewData()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            ViewResult result = fakeController.Details(5) as ViewResult;
            Product product = result.ViewData.Model as Product;

            Assert.IsNotNull(product);
            Assert.AreEqual("Corner flag", product.Name);
        }

        [TestMethod]
        public void TestDetailsRedirect()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            RedirectToRouteResult result = fakeController.Details(-1) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNotNull(result);
        }
    }
}
