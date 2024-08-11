using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC_UnitTest.DbClasses;
using WebMVC_UnitTest.Models;

namespace WebMVC_UnitTest.Test
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;
        public ProductRepository()
        {
            _context = new ProductContext();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public IList<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}