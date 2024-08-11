using System.Collections.Generic;
using WebMVC_UnitTest.Models;

namespace WebMVC_UnitTest.Test
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();
        Product FindById(int id);
        void AddProduct(Product product);
    }
}
