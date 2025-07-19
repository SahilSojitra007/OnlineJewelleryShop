using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelleryShop.Models;

namespace OnlineJewelleryShop.Controllers
{
	public class HomeController : Controller
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
                JewelleryCategory = x.JewelleryCategory ?? 0,
                JewelleryCategoryName = db.CategoryMasters.Where(x1 => x1.Id == x.JewelleryCategory).Select(x1 => x1.CategoryName).FirstOrDefault(),
                JewelleryTypeName = db.TypeMasters.Where(x1 => x1.Id == x.JewelleryType).Select(x1 => x1.TypeName).FirstOrDefault(),
                JewelleryImage = x.JewelleryImage
            }).ToList();
            objjewellery.JewelleryList = tbljewellery;
            return View(objjewellery);
        }
		public ActionResult AboutUs()
        {
			return View();
        }
		public ActionResult ContactUS()
		{
			return View();
		}
	}
}