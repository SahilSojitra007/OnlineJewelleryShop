using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryShop.Models;

namespace OnlineJewelleryShop.Controllers
{
    public class ProductController : Controller
    {
        OnlineJewelleryEntities db = new OnlineJewelleryEntities();
        public ActionResult ProductList(int Id = 0)
        {
            JewelleryMasterListModel objjewellery = new JewelleryMasterListModel();
            var tbljewellery = db.JewelleryMasters.Select(x => new JewelleryMasterModel
            {
                Id = x.Id,
                JewelleryName = x.JewelleryName,
                JewelleryType = x.JewelleryType??0,
                Price = x.Price??0,
                JewelleryCategory = x.JewelleryCategory??0,
                JewelleryCategoryName = db.CategoryMasters.Where(x1 => x1.Id == x.JewelleryCategory).Select(x1 => x1.CategoryName).FirstOrDefault(),
                JewelleryTypeName = db.TypeMasters.Where(x1 => x1.Id == x.JewelleryType).Select(x1 => x1.TypeName).FirstOrDefault(),
                JewelleryImage = x.JewelleryImage
            }).Where(x => x.JewelleryCategory == Id).ToList();
            objjewellery.JewelleryList = tbljewellery;
            return View(objjewellery);
        }

        public ActionResult ProductDetail(int Id = 0)
        {
            var objjewellery = db.JewelleryMasters.Where(x => x.Id == Id).FirstOrDefault();
            return View(objjewellery);
        }
    }
}