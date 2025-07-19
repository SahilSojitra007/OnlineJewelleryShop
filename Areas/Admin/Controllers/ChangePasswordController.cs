using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryShop.Models;

namespace OnlineJewelleryShop.Areas.Admin.Controllers
{
    public class ChangePasswordController : Controller
    {
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();





        public string ChangePasswordAjax(ChangePasswordModel objCP)
        {
            int UserId = Convert.ToInt32(Session["aUID"].ToString());
            var tblCP = db.AdminMasters.Where(x => x.Id == UserId).FirstOrDefault();
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