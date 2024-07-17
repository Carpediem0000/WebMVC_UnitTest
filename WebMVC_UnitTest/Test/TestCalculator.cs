using System.Collections.Generic;
using System.Linq;
using WebMVC_UnitTest.Models;

namespace WebMVC_UnitTest.Test
{
    public class TestCalculator
    {
        private IDiscountHelper _helper;
        public TestCalculator(IDiscountHelper helper) // Dependency Injection (DI)
        {
            _helper = helper;
        }
        public decimal AllDiscount(IEnumerable<Product> products)
        {
            return _helper.Dicsount(products.Sum(p => p.Price));
        }
    }
}