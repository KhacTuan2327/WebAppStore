using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppStore.Controllers;
namespace WebAppStore.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Oder
        public ActionResult Order()
        {
            return View();
        }
        public ActionResult UpdateOrder(int id)
        {
            using (var model = new StoreDbContext())
            {
                var od = model.Order_Detail.Find(id);
                return View(od);
            }
        }
        [HttpPost]
        public ActionResult UpdateOrder1(int id, int orderid, string title, int price, int number, int totalmoney )
        {
            using (var model = new StoreDbContext())
            {
                var newpd = model.Order_Detail.Find(id);
                newpd.Id = id;
                newpd.Order_Id = orderid;
                newpd.Title = title;
                newpd.Price = price;
                newpd.Number = number;
                newpd.TotalMoney = totalmoney;
                model.SaveChanges();
                return RedirectToAction("Oder");
            }
        }
        public ActionResult DeleteOrder(int id)
        {
            using (var model = new StoreDbContext())
            {
                var od = model.Orders.Find(id);
                var order = (from s in model.Order_Detail
                             where s.Order_Id == id
                             select s).ToList();
                foreach(var it in order)
                {
                    model.Order_Detail.Remove(it);
                }
                model.SaveChanges();
                var kh = (from s in model.Users
                             where s.Id == od.User_Id
                             select s).ToList();
                foreach (var item in kh)
                {
                    model.Users.Remove(item);
                }
                model.SaveChanges();
                model.Orders.Remove(od);
                model.SaveChanges();
                return RedirectToAction("Order");
            }
        }
    }
}