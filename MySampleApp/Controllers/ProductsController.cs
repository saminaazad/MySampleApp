using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MySampleApp.Models;

namespace MySampleApp.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products;
        private static int count;

        static ProductsController()
        {
            _products = new List<Product>();

            _products.Add(new Product() { ProductId = 1, ProductName = "Product A", ProductDescription = "Description for product A", Price = 10.00 });
            _products.Add(new Product() { ProductId = 2, ProductName = "Product B", ProductDescription = "Description for product B", Price = 15.00 });
            _products.Add(new Product() { ProductId = 3, ProductName = "Product C", ProductDescription = "Description for product C", Price = 20.00 });
            _products.Add(new Product() { ProductId = 4, ProductName = "Product D", ProductDescription = "Description for product D", Price = 40.00 });

            count = 4;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(int id)
        {
            return View(id);
        }

        public ActionResult List()
        {
            return Json(_products, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("Action")]
        public ActionResult Get(int id)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == id);
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Action")]
        public ActionResult Create(Product newProduct)
        {
            newProduct.ProductId = ++count;
            _products.Add(newProduct);

            return Json(newProduct, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        [ActionName("Action")]
        public ActionResult Update(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == id);

            _products.Remove(product);
            _products.Add(updatedProduct);

            return Json(updatedProduct, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        [ActionName("Action")]
        public ActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == id);
            _products.Remove(product);

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
