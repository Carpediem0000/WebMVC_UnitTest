using System.Data.Entity;
using WebMVC_UnitTest.Models;

namespace WebMVC_UnitTest.DbClasses
{
    public class ProductContext:DbContext
    {
        public ProductContext()
            :base("ProductTestMVC")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}