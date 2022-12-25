using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace WebAppStore.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        StoreDbContext db = new StoreDbContext();
        // GET: Admin/AdminProduct
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct1(int id, string title, int? price, HttpPostedFileBase photo, int category_id, string color, string size, string description, int quantity)
        {
            var newpd = new Product();
            newpd.Id = id;
            newpd.Title = title;
            newpd.Category_Id = category_id;
            string _FileName = Path.GetFileName(photo.FileName);
            string _path = Path.Combine(Server.MapPath("~/Content/images/AllProduct"), _FileName);
            newpd.Photo = _FileName;
            photo.SaveAs(_path);
            newpd.Size = size;
            newpd.Color = color;
            newpd.Price = price;
            newpd.Quantity = quantity;
            newpd.Description = description;
            using (var model = new StoreDbContext())
            {
                model.Products.Add(newpd);
                model.SaveChanges();
                return RedirectToAction("Product");
            }
        }
        public ActionResult UpdateProduct(int id)
        {
            using (var model = new StoreDbContext())
            {
                var pd = model.Products.Find(id);
                return View(pd);
            }
        }
        [HttpPost]
        public ActionResult UpdateProduct1(int id, string title, int? price, HttpPostedFileBase photo, int category_id, string color, string size, string description, int quantity)
        {
            using (var model = new StoreDbContext())
            {
                var newpd = model.Products.Find(id);
                newpd.Title = title;
                newpd.Category_Id = category_id;
                newpd.Size = size;
                newpd.Color = color;
                newpd.Price = price;
                newpd.Quantity = quantity;
                string _FileName = Path.GetFileName(photo.FileName);
                string _path = Path.Combine(Server.MapPath("~/Areas/Admin/content/ImageProduct"), _FileName);
                newpd.Photo = _FileName;
                photo.SaveAs(_path);
                newpd.Description = description;
                model.SaveChanges();
                return RedirectToAction("Product");
            }
        }
        public ActionResult DeleteProduct(int id)
        {
            using (var model = new StoreDbContext())
            {
                var pd = model.Products.Find(id);
                model.Products.Remove(pd);
                model.SaveChanges();
                return RedirectToAction("Product");
            }
        }
    }
}