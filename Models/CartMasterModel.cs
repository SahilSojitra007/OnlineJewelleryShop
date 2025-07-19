using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewelleryShop.Models
{
    public class CartMasterModel
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public int PId { get; set; }
        public int Qty { get; set; }
        public DateTime Date { get; set; }
    }
}