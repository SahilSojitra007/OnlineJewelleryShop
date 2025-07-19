using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryShop.Models;

namespace OnlineJewelleryShop.Controllers
{
    public class ChangePasswordController : Controller
    {
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string ChangePasswordAjax(ChangePasswordModel objCP)
        {
            int UserId = Convert.ToInt32(Session["UID"].ToString());
            var tblCP = db.CustomerMasters.Where(x => x.Id == UserId).FirstOrDefault();
            if (tblCP != null)
            {
                if (tblCP.Password == objCP.OldPassword)
                {
                    tblCP.Password = objCP.NewPassword;
                    db.SaveChanges();
                    return "1";
                }
                else
                {
                    return "-1";
                }
            }

            return "";
        }
    }
}