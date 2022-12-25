using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppStore.Controllers;
namespace WebAppStore.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        StoreDbContext _context = new StoreDbContext();
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            var sodh = _context.Orders.Count();
            ViewBag.SoDH = sodh;

            var sokh = _context.Users.Count();
            ViewBag.SoKH = sokh;

            var sosp = _context.Products.Count();
            ViewBag.SoSP = sosp;

            var nv = _context.Staffs.Count();
            ViewBag.NV = nv;

            var sp = _context.Products
            .Where(o => o.Quantity < 3)
            .Count();
            ViewBag.SoSPHET = sp;
            return View();
        }
    }
}