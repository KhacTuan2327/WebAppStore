using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using Models;

namespace WebAppStore.Controllers
{
    public class HomeController :Controller
    {
        StoreDbContext db = new StoreDbContext();
        public ActionResult Index(int size =16)
        {
            var lstCate = db.Categories.ToList();
            var lstProd = db.Products.OrderBy(a => a.Id).Skip(0).Take(size).ToList();
            var lstBlog = db.Blogs.ToList();
            ViewBag.Cart = db.Order_Detail.ToList();
            Mix mix = new Mix();
            mix.ListCategory = lstCate;
            mix.ListProduct = lstProd;
            mix.ListBlog = lstBlog;
            return View(mix);
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
        
    }
}