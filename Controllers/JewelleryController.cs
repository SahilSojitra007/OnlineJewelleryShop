using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryShop.Models;

namespace OnlineJewelleryShop.Controllers
{
    public class JewelleryController : Controller
    {
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();
        public ActionResult Index()
        {
            JewelleryMasterListModel objjewellery = new JewelleryMasterListModel();
            var tbljewellery = db.JewelleryMasters.Select(x => new JewelleryMasterModel
            {
                Id = x.Id,
                JewelleryName = x.JewelleryName,
                JewelleryType = x.JewelleryType ?? 0,
                Price = x.Price ?? 0,
                Description = x.Description,
                JewelleryCategory = x.JewelleryCategory ?? 0,
                JewelleryCategoryName = db.CategoryMasters.Where(x1 => x1.Id == x.JewelleryCategory).Select(x1 => x1.CategoryName).FirstOrDefault(),
                JewelleryTypeName = db.TypeMasters.Where(x1 => x1.Id == x.JewelleryType).Select(x1 => x1.TypeName).FirstOrDefault(),
                JewelleryImage = x.JewelleryImage
            }).ToList();
            objjewellery.JewelleryList = tbljewellery;
            return View(objjewellery);
        }
        public ActionResult Detail(int id = 0)
        {
            ViewBag.Typelst = new SelectList(db.TypeMasters.ToList(), "Id", "TypeName");
            ViewBag.Categorylst = new SelectList(db.CategoryMasters.ToList(), "Id", "CategoryName");

            JewelleryMasterModel objjew = new JewelleryMasterModel();
            if (id != 0)
            {
                objjew = db.JewelleryMasters.Where(x => x.Id == id ).Select(x => new JewelleryMasterModel
                {
                    JewelleryName = x.JewelleryName,
                    JewelleryType = x.JewelleryType ?? 0,
                    Price = x.Price ?? 0,
                    Description = x.Description,
                    JewelleryCategory = x.JewelleryCategory ?? 0,
                    JewelleryImage = x.JewelleryImage
                }).FirstOrDefault();
            }
            return View(objjew);
        }
        [HttpPost]
        public ActionResult Detail(JewelleryMasterModel objjew)
        {
            var objtbljew = db.JewelleryMasters.Where(x => x.Id == objjew.Id).FirstOrDefault();
            var file = Path.GetFileNameWithoutExtension(objjew.ImagesFile.FileName);
            var filext = Path.GetExtension(objjew.ImagesFile.FileName);
            var filename = DateTime.Now.ToString("ddmmyyyyhhmmss") + file + filext;
            objjew.JewelleryImage = filename;
            string uploadpath = Server.MapPath("~/UserImages/");
            objjew.ImagesFile.SaveAs(uploadpath + filename);
            if (objtbljew == null)
            {
                var objedxjew = new JewelleryMaster();
                objedxjew.JewelleryName = objjew.JewelleryName;
                objedxjew.JewelleryType = objjew.JewelleryType;
                objedxjew.Price = objjew.Price;
                objedxjew.JewelleryCategory = objjew.JewelleryCategory;
                objedxjew.JewelleryImage = objjew.JewelleryImage;

                db.JewelleryMasters.Add(objedxjew);
                db.SaveChanges();

            }
            else
            {
                objtbljew.JewelleryName = objjew.JewelleryName;
                objtbljew.JewelleryType = objjew.JewelleryType;
                objtbljew.Price = objjew.Price;
                objtbljew.JewelleryCategory = objjew.JewelleryCategory;
                objtbljew.JewelleryImage = objjew.JewelleryImage;

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Jewellery");
        }
        public ActionResult Delete(int id = 0)
        {
            var objtbljew = db.JewelleryMasters.Where(x => x.Id == id).FirstOrDefault();
            if (objtbljew != null)
            {
                db.JewelleryMasters.Remove(objtbljew);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Jewellery");
        }
    }
}