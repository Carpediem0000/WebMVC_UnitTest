using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC_UnitTest.Models;
using WebMVC_UnitTest.Test;

namespace WebMVC_UnitTest.Controllers
{
    public class ProductTestController : Controller
    {
        private IProductRepository _repository;

        public ProductTestController()
        {
            _repository = new ProductRepository();
        }

        // Dependency injection (DI)
        public ProductTestController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: ProductTest
        public ActionResult Index()
        {
            return View(_repository.GetProducts());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View("Create", product);
        }

        public ActionResult Details(int id)
        {
            if (id < 1)
                return RedirectToAction("Index");

            return View("Details", _repository.FindById(id));
        }
    }
}