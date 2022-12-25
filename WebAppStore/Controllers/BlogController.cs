using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppStore.Controllers
{
    public class BlogController : Controller
    {
        StoreDbContext db = new StoreDbContext();
        // GET: Blog
        public ActionResult Blog()
        {
            var blogs = db.Blogs.ToList();
            Mix m = new Mix();
            m.ListBlog = blogs;
            return View(m);
        }
        [HttpPost]
        public ActionResult getInfBlog(int id)// Lấy ra thông tin của sản phẩm 
        {
            var blog = db.Blogs.Where(a => a.Id == id).FirstOrDefault();
            Blog blog1 = new Blog();
            blog1.Id = blog.Id;
            blog1.Title = blog.Title;
            blog1.Content = blog.Content;
            blog1.Photo = blog.Photo;
            blog1.Created_At = blog.Created_At;
            return Json(blog1);
        }
        public ActionResult BlogDetail(int Id)
        {
            var blogDetail = db.Blogs.Where(n => n.Id == Id).FirstOrDefault();
            return View(blogDetail);
        }
    }
}