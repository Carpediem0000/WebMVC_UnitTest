using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC_UnitTest.Models;

namespace WebMVC_UnitTest.Test
{
    public class FakeRepository : IProductRepository
    {
        private List<Product> _products;
        public FakeRepository()
        {
            _products = new List<Product>
            {
                new Product { Id = 5, Name = "Corner flag", Category = "Soccer", Price = 600m }
            };
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product FindById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IList<Product> GetProducts()
        {
            return _products;
        }
    }
}