using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebMVC_UnitTest.Models;
using WebMVC_UnitTest.Test;

namespace WebMVC_UnitTest.Tests
{
    [TestClass]
    public class UnitTestDiscount
    {
        private IDiscountHelper GetDiscountHelper()
        {
            return new DiscountHelper();
        }

        [TestMethod]
        public void Above1000()
        {
            // arrange
            IDiscountHelper helper = GetDiscountHelper();
            decimal price = 2000;

            // act
            decimal result = helper.Dicsount(price);

            // assert
            Assert.AreEqual(price*0.9m, result);
        }

        [TestMethod]
        public void Beetwen100And1000()
        {
            // arrange
            IDiscountHelper helper = GetDiscountHelper();

            // act
            decimal hundred = helper.Dicsount(100);
            decimal fiveHundred = helper.Dicsount(500);
            decimal thousend = helper.Dicsount(1000);

            // assert
            Assert.AreEqual(100 * 0.95m, hundred, "100 discount not equal");
            Assert.AreEqual(500 * 0.95m, fiveHundred);
            Assert.AreEqual(1000 * 0.95m, thousend);
        }

        [TestMethod]
        public void Less100()
        {
            IDiscountHelper helper = GetDiscountHelper();

            decimal fifty = helper.Dicsount(50);
            decimal zero = helper.Dicsount(0);

            Assert.AreEqual(50, fifty);
            Assert.AreEqual(0, zero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Negative()
        {
            GetDiscountHelper().Dicsount(-1);
        }

        private IEnumerable<Product> _products = new List<Product>
        {
            new Product { Name = "Kayak", Category = "Watersports", Price = 750m },
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 400m },
            new Product { Name = "Soccer ball", Category = "Soccer", Price = 250m },
            new Product { Name = "Corner flag", Category = "Soccer", Price = 600m }
        };

        [TestMethod]
        public void AllDiscountTest()
        {
            IDiscountHelper helper = GetDiscountHelper();
            TestCalculator testCalculator = new TestCalculator(helper);

            decimal two_thous = testCalculator.AllDiscount(_products);

            Assert.AreEqual(1800m, two_thous);
        }
    }
}
