
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryShop.Models;

namespace OnlineJewelleryShop.Areas.Admin.Controllers
{
    public class TypeController : Controller
    {
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();
        public ActionResult Index()
        {
            var Typelst = db.TypeMasters.ToList();
            return View(Typelst);
        }
        public ActionResult Detail(int id = 0)
        {
            TypeMasterModel objtype = new TypeMasterModel();
            if (id != 0)
            {
                objtype = db.TypeMasters.Where(x => x.Id == id).Select(x => new TypeMasterModel
                {
                    Id = x.Id,
                    TypeName = x.TypeName,
                }).FirstOrDefault();
            }
            return View(objtype);
        }
        [HttpPost]
        public ActionResult Detail(TypeMasterModel objType)
        {
            var tbltype = db.TypeMasters.Where(x => x.Id == objType.Id).FirstOrDefault();
            if (tbltype == null)
            {
                tbltype = new TypeMaster();
                tbltype.TypeName = objType.TypeName;
                db.TypeMasters.Add(tbltype);
                db.SaveChanges();

            }
            else
            {
                tbltype.TypeName = objType.TypeName;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Type");
        }
        public ActionResult Delete(int id = 0)
        {
            var tbltype = db.TypeMasters.Where(x => x.Id == id).FirstOrDefault();
            if (tbltype != null)
            {
                db.TypeMasters.Remove(tbltype);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Type");
        }
    }
}
