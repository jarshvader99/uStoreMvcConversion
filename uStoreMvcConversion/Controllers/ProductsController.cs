using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UStore.data1.EF;

namespace uStoreMvcConversion.Controllers
{
    public class ProductsController : Controller
    {
        private uStoreEntities db = new uStoreEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Status);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusID", "StatusName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Description,Price,UnitsInStock,ProductImage,StatusId,CategoryID,Notes,ReferenceURL")] Product product, HttpPostedFileBase productImage)
        {
            if (ModelState.IsValid)
            {
                string image = "noimage.jpg";
                if (productImage != null)
                {
                    image = productImage.FileName;
                    string ext = image.Substring(image.LastIndexOf("."));
                    string[] goodExts = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    if (goodExts.Contains(ext.ToLower()))
                    {
                        image = Guid.NewGuid() + ext;
                        productImage.SaveAs(Server.MapPath("~/Content/img/product/" + image));
                    }
                    else
                    {
                        image = "noimage.jpg";
                    }

                }
                product.ProductImage = image;


                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }



            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Description,Price,UnitsInStock,ProductImage,StatusId,CategoryID,Notes,ReferenceURL")] Product product, HttpPostedFileBase productImage)
        {
            if (ModelState.IsValid)
            {
                if (productImage != null)
                {
                    string image = productImage.FileName;
                    string ext = image.Substring(image.LastIndexOf("."));
                    string[] goodExts = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    if (goodExts.Contains(ext.ToLower()))
                    {
                        image = Guid.NewGuid() + ext;
                        productImage.SaveAs(Server.MapPath("~/Content/img/product/" + image));

                        product.ProductImage = image;

                        //if (Session["currentImage"].ToString() != "noimage.jpg")
                        //{
                        //    System.IO.File.Delete(Server.MapPath("~/Content/img/product" + Session["currentImage"].ToString()));
                        //}

                    }
                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
          
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);


            if (product.ProductImage != "noimage.jpg")
            {
                System.IO.File.Delete(Server.MapPath("~/Content/img/product/" + product.ProductImage));

            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
