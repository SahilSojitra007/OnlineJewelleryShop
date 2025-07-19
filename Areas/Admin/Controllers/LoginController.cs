using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelleryShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminMaster objLogin)
        {
            if (string.IsNullOrEmpty(objLogin.Email_Id))
            {
                ViewBag.Notification = "Email  address is required";
            }
            else if (string.IsNullOrEmpty(objLogin.Password))
            {
                ViewBag.Notification = "Password is required";
            }
            else
            {
                var getValidUser = db.AdminMasters.Where(p => p.Email_Id.Equals(objLogin.Email_Id) && p.Password.Equals(objLogin.Password)).FirstOrDefault();
                if (getValidUser != null)
                {
                    Session["aUID"] = getValidUser.Id.ToString();
                    Session["aEmail_Id"] = objLogin.Email_Id.ToString();
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Notification = "Wrong Username and Password";
                }
            }
            return View(objLogin);
        }
    }
}