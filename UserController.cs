using dangnhapp.App_Start;
using dangnhapp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dangnhapp.Controllers
{
    public class UserController : Controller
    {
        quanLyBanHangEntities db = new quanLyBanHangEntities();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {

            var user = db.Users.FirstOrDefault(x => x.email == model.email && x.passwordHash == model.passwordHash);


            if (user != null)
            {
                SessionConfig.SetUser(user);
                if (user.role == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "Customer" });

                }
            }
            ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng";
            return View();
        }
    }
}