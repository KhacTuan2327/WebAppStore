using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using WebAppStore.Controllers;
namespace WebAppStore.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult DeleteCustomer(int id)
        {
            using (var model = new StoreDbContext())
            {
                var kh = model.Users.Find(id);
                var od = (from c in model.Orders
                          where c.User_Id == id
                          select c).ToList();
                foreach (var it in od)
                {
                    model.Orders.Remove(it);
                }
                model.Users.Remove(kh);
                model.SaveChanges();
                return RedirectToAction("Customer");
            }
        }
    }
}