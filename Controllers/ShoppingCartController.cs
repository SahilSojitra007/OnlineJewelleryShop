using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelleryShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();

        public ActionResult Index()
        {
            if (Session["UID"] == null)
                return RedirectToAction("Index", "Login");

            int UserId = Convert.ToInt32(Session["UID"].ToString());
            var lstCart = db.CartMasters.Where(x => x.Uid == UserId && x.PId != null).ToList();

            return View(lstCart);
        }

        [HttpPost]
        public ActionResult AddCartAjax(CartMaster tblCartMaster)
        {
            if (Session["UID"] == null)
            {
                return Json(new { response = "login" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int UserId = Convert.ToInt32(Session["UID"].ToString());

                var objCart = new CartMaster();
                objCart.PId = tblCartMaster.PId;
                objCart.Uid = UserId;
                objCart.Qty = tblCartMaster.Qty;
                objCart.Date = DateTime.Now;
                db.CartMasters.Add(objCart);
                db.SaveChanges();

                return Json(new { response = "success" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Delete (int id=0)
        {
            var objCart = db.CartMasters.Where(x => x.Id == id).FirstOrDefault();
            if(objCart!=null)
            {
                db.CartMasters.Remove(objCart);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
