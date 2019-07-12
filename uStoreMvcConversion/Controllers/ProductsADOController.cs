
using Data.ADO;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using UStore.Domain;


namespace uStoreMvcConversion.Controllers
{
    public class ProductsADOController : Controller
    {
        ProductsDAL products = new ProductsDAL();
       
        public ActionResult Index()
        {

            ViewBag.ProductsName = products.GetProductName();
            return View();
        }

        public ActionResult DisplayProducts()
        {
            return View(products.GetProducts());
        }

        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                products.CreateProduct(product);
                return RedirectToAction("DisplayProducts");
            }
            return View(product);
        }

        public ActionResult DeleteProduct(int id)
        {
            products.DeleteProduct(id);
            return RedirectToAction("DisplayProducts");
        }

        public ActionResult UpdateProduct(int id)
        {
            return View(products.GetProduct(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(ProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                products.UpdateProduct(newProduct);
                return RedirectToAction("DisplayProducts");
            }//end if
            return View(newProduct);
        }//end UpdateProduct()
    }
}