using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Models.Framework;
using Models;

namespace WebAppStore.Controllers
{
    public class ShoppingCartController : Controller
    {


        // GET: ShoppingCart
        public ActionResult ShowToCart()
        {

            if (Session["user"] == null)
            {
                return RedirectToAction("ChuaDangNhap", "ShoppingCart");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("GioTrong", "ShoppingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult ChiTietThanhToan()
        {
            return View();
        }

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            using (var con = new StoreDbContext())
            {
                if (Session["user"] != null)
                {
                    var pro = con.Products.SingleOrDefault(s => s.Id == id);
                    if (pro != null)
                    {
                        GetCart().Add(pro);
                    }
                    return RedirectToAction("ShowToCart", "ShoppingCart");
                }
                else
                    return RedirectToAction("ChuaDangNhap", "ShoppingCart");
            }
        }
      
        public ActionResult Update_Quantity_Cart(int[] Ma, int[] SL)
        {
            Cart cart = Session["Cart"] as Cart;

            var list = new List<CartItem>();
            using (var con = new StoreDbContext())
            {
                if (cart != null)
                {
                    for (int i = 0; i < Ma.Count(); i++)
                    {

                        var pro = con.Products.Find(Ma[i]);
                        cart.Update_QuantiTy_Shopping(pro.Id, SL[i]);
                    }

                    Session["Cart"] = cart;
                }
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }





        }
        public ActionResult ChuaDangNhap()

        {
            return View();
        }

        public ActionResult GioTrong()

        {
            return View();
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");

        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["cart"] as Cart;
            if (cart != null)

                total_item = cart.Total_Quantity_in_Cart();
            ViewBag.QuantityCart = total_item;
            return PartialView("BagCart");

        }

        public ActionResult Shopping_Success()
        {
            return View();
        }

        public ActionResult CheckOut(FormCollection form)
        {

            using (var conx = new StoreDbContext())
            {
                User kh = Session["User"] as User;
                try
                {
                    Cart cart = Session["Cart"] as Cart;
                    Order _order = new Order();
                    _order.Created_At = DateTime.Now;
                    _order.User_Id = kh.Id;
                    _order.Fullname = form["name"];
                    _order.Email = form["Email"];
                    _order.Phonenumber = double.Parse(form["Sdt"]);
                    _order.Address = string.Concat(form["xa"], ", ", form["huyen"], ", ", form["tinh"]);
                    //_order.MaKM = int.Parse(form["Makm"]);
                    _order.TotalMoney = int.Parse(form["tongtien"]);
                    _order.Status = 1;
                    _order.Note = form["msg"];
                    conx.Orders.Add(_order);
                    conx.SaveChanges();
                    foreach (var item in cart.Items)
                    {
                        Order_Detail _order_Detail = new Order_Detail();
                        _order_Detail.Order_Id = _order.Id;
                        _order_Detail.Product_Id = item._shopping_product.Id;
                        _order_Detail.Price = item._shopping_product.Price;
                        _order_Detail.Number = item._shopping_quantity;
                        conx.Order_Detail.Add(_order_Detail);
                    }
                    conx.SaveChanges();
                    cart.ClearCart();
                    return RedirectToAction("Shopping_Success", "ShoppingCart");

                }
                catch
                {
                    return Content("Lỗi đặt hàng ! Vui lòng kiểm tra lại thông tin");
                }
            }
        }
    }
}