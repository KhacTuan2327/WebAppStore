using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace WebAppStore.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        public ActionResult Staff()
        {
            return View();
        }
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStafflast(string id, string name, HttpPostedFileBase photo, string address, DateTime dateofbirth, string gender, string phone, string position)
        {
            var newnv = new Staff();
            newnv.MaNhanVien = id;
            newnv.HoTen = name;
            string _FileName = Path.GetFileName(photo.FileName);
            string _path = Path.Combine(Server.MapPath("~/Areas/Admin/content/ImageStaff"), _FileName);
            newnv.AnhDaiDien = _FileName;
            photo.SaveAs(_path);
            newnv.DiaChi = address;
            newnv.NgaySinh = dateofbirth;
            newnv.GioiTinh = gender;
            newnv.SDT = phone;
            newnv.Chucvu = position;
            using (var model = new StoreDbContext())
            {
                model.Staffs.Add(newnv);
                model.SaveChanges();
                return RedirectToAction("Staff");
            }
        }
        public ActionResult UpdateStaff(string id)
        {
            using (var model = new StoreDbContext())
            {
                var nv = model.Staffs.Find(id);
                return View(nv);
            }
        }
        [HttpPost]
        public ActionResult UpdateStafflast(string id, string name, HttpPostedFileBase photo, string address, DateTime dateofbirth, string gender, string phone, string position)
        {
            using (var con = new StoreDbContext())
            {
                var newnv = con.Staffs.Find(id);
                newnv.MaNhanVien = id;
                newnv.HoTen = name;
                string _FileName = Path.GetFileName(photo.FileName);
                string _path = Path.Combine(Server.MapPath("~/Areas/Admin/content/ImageStaff"), _FileName);
                newnv.AnhDaiDien = _FileName;
                photo.SaveAs(_path);
                newnv.DiaChi = address;
                newnv.NgaySinh = dateofbirth;
                newnv.GioiTinh = gender;
                newnv.SDT = phone;
                newnv.Chucvu = position;
                con.SaveChanges();
                return RedirectToAction("Staff");
            }
        }
        public ActionResult DeleteStaff(string id)
        {
            using (var model = new StoreDbContext())
            {
                var nv = model.Staffs.Find(id);
                model.Staffs.Remove(nv);
                model.SaveChanges();
                return RedirectToAction("Staff");
            }
        }
    }
}