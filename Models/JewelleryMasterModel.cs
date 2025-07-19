using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewelleryShop.Models
{
    public class JewelleryMasterListModel
    {
        public List<JewelleryMasterModel> JewelleryList { get; set; }
    }
    public class JewelleryMasterModel
    {
        public int Id { get; set; }
        public string JewelleryName { get; set; }
        public int JewelleryType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int JewelleryCategory { get; set; }
        public string JewelleryCategoryName { get; set; }
        public string JewelleryTypeName { get; set; }
        public string JewelleryImage { get; set; }
        public HttpPostedFileBase ImagesFile { get; set; }
    }
    public class objlist
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}