using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelleryShop.Controllers
{
    public class LoginController : Controller
    {
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(CustomerMaster objLogin)
        {
            if(db.CustomerMasters.Any(p => p.UserName == objLogin.UserName))
            {
                ViewBag.Notification = "This account is already exists";
                return View();
            }
            else if (string.IsNullOrEmpty(objLogin.CustomerName))
            {
                ViewBag.Notification = "Customer Name is required";
                return View();
            }
            else if (string.IsNullOrEmpty(objLogin.UserName))
            {
                ViewBag.Notification = "User Name is required";
                return View();
            }
            else if (string.IsNullOrEmpty(objLogin.EmailId))
            {
                ViewBag.Notification = "Email Address is required";
                return View();
            }
            else if (string.IsNullOrEmpty(objLogin.City))
            {
                ViewBag.Notification = "City is required";
                return View();
            }
            else if (string.IsNullOrEmpty(objLogin.PhoneNo))
            {
                ViewBag.Notification = "Phone Number is required";
                return View();
            }
            else
            {
                db.CustomerMasters.Add(objLogin);
                db.SaveChanges();

                Session["Id"] = objLogin.Id.ToString();
                Session["CustomerName"] = objLogin.CustomerName.ToString();
                Session["Username"] = objLogin.UserName.ToString();
                Session["Password"] = objLogin.Password.ToString();
                Session["EmailId"] = objLogin.EmailId.ToString();
                Session["City"] = objLogin.City.ToString();
                Session["PhoneNo"] = objLogin.PhoneNo.ToString();

                ViewBag.Notification = "Wrong Data Entry";
                return RedirectToAction("Index", "Home");
            }         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CustomerMaster objLogin)
        {
            if (string.IsNullOrEmpty(objLogin.UserName))
            {
                ViewBag.Notification = "Username address is required";
            }
            else if (string.IsNullOrEmpty(objLogin.Password))
            {
                ViewBag.Notification = "Password is required";
            }
            else
            {
                var getValidUser = db.CustomerMasters.Where(p => p.UserName.Equals(objLogin.UserName) && p.Password.Equals(objLogin.Password)).FirstOrDefault();
                if (getValidUser != null)
                {
                    Session["UId"] = getValidUser.Id.ToString();
                    Session["UserName"] = objLogin.UserName.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Notification = "Wrong Username and Password";
                }
            }

            return View(objLogin);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        
    }
    
}