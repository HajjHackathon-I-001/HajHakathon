using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HajHakathon.ViewModel
{
    public class LoginUsers
    {
        [Display(Name = "اسم المستخدم - UserName")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "كلمة المرور - Passowrd")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public string LoginItem { get; set; }
    }
}