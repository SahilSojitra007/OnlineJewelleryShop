using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryShop.Models;

namespace OnlineJewelleryShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();
        public ActionResult Index()
        {
            var Categorylst = db.CategoryMasters.ToList();
            return View(Categorylst);
        }
        public ActionResult Detail(int id = 0)
        {
            CategoryMasterModel objtype = new CategoryMasterModel();
            if (id != 0)
            {
                objtype = db.CategoryMasters.Where(x => x.Id == id).Select(x => new CategoryMasterModel
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName
                }).FirstOrDefault();
            }
            return View(objtype);
        }


        [HttpPost]
        public ActionResult Detail(CategoryMasterModel ObjType)
        {
            var tbltype = db.CategoryMasters.Where(x => x.Id == ObjType.Id).FirstOrDefault();
            if (tbltype == null)
            {
                tbltype = new CategoryMaster();
                tbltype.CategoryName = ObjType.CategoryName;
                db.CategoryMasters.Add(tbltype);
                db.SaveChanges();
            }
            else
            {
                tbltype.CategoryName = ObjType.CategoryName;

                db.SaveChanges();
            }
            return RedirectToAction("Index","Category");
        }
        public ActionResult Delete(int id = 0)
        {
            var tbltype = db.CategoryMasters.Where(x => x.Id == id).FirstOrDefault();
            if (tbltype != null)
            {
                db.CategoryMasters.Remove(tbltype);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Category");
        }
    }
}