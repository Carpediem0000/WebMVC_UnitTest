using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebMVC_UnitTest.Models;

namespace WebMVC_UnitTest.DbClasses
{
    //CreateDatabaseIfNotExists
    //
    //DropCreateDatabaseIfModelChanges

    public class ProductDbInittializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            context.Products.Add(new Product { Name = "Kayak", Category = "Watersports", Price = 275.7m });
            context.Products.Add(new Product { Name = "Corner flag", Category = "Soccer", Price = 34.65m });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}