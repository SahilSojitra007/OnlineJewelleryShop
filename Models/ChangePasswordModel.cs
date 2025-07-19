using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewelleryShop.Models
{
    public class ChangePasswordModel
    {
        [Display(Name = "Old Password:")]
        [Required(ErrorMessage = "Old Password is required.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New Password is Required.")]
        [Display(Name = "New Password:")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password:")]
        [Required(ErrorMessage = "Confirm new password is required.")]
        [Compare(otherProperty: "New Password", ErrorMessage = "New Password doesn't match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}