using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Framework;

namespace WebAppStore.Controllers
{
    public class ProductController : Controller
    {
        StoreDbContext db = new StoreDbContext();
        // GET: Product
        public ActionResult Product(int size = 16)
        {
            var lProd = db.Products.OrderBy(a=>a.Id).Skip(0).Take(size).ToList();
            var lCate = db.Categories.ToList();
            Mix m = new Mix();
            m.ListCategory = lCate;
            m.ListProduct = lProd;
            m.Count = 16;
            return View(m);
        }
        public ActionResult Search(string keyword)
        {
            ViewBag.Keyword = keyword;
            var lProd = db.Products.ToList();
            var lCate = db.Categories.ToList();
            Mix m = new Mix();
            m.ListCategory = lCate;
            m.ListProduct = lProd;
            return View(m);
        }
        public ActionResult ProductDetail(int Id)
        {
            var productDetail = db.Products.Where(n => n.Id == Id).FirstOrDefault();
            var prod = db.Products.Where(a => a.Category_Id == productDetail.Category_Id && a.Id !=Id).ToList();
            ViewBag.prodRelate = prod;
            return View(productDetail);
        }
        [HttpPost]
        public ActionResult listProduct(int size = 16)
        {
            var lstCategory = db.Products.OrderBy(a => a.Id).Skip(0).Take(size).ToList();
            var count = db.Products.OrderBy(a => a.Id).Skip(0).Take(size).ToList().Count;
            Mix objMix = new Mix();
            objMix.ListProduct = lstCategory;
            objMix.Count = count;

            return PartialView("~/Views/Product/listProduct.cshtml", objMix);

        }
        [HttpPost]
        public ActionResult getInfProd(int id)// Lấy ra thông tin của sản phẩm 
        {
            var prod = db.Products.Where(a => a.Id == id).FirstOrDefault();
            ProductDetail product = new ProductDetail();
            product.Id = prod.Id;
            product.Title = prod.Title;
            product.Description = prod.Description;
            product.Price = prod.Price;
            product.Quantity = prod.Quantity;
            product.Size = prod.Size;
            product.Photo = prod.Photo;
            product.Color = prod.Color;
            return Json(product);
        }
        public JsonResult ListTitle(string q)
        {
            var data = new Product().ListTitle(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}