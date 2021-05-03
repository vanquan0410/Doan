using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    /// <summary>
    /// LoginModel
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required(ErrorMessage = "Chưa Nhập Tài Khoản ")]
        public string UserName { get; set; }

        /// <summary>
        /// PassWord
        /// </summary>
        [Required(ErrorMessage = "Chưa Nhập Mật Khẩu ")]
        public string PassWord { get; set; }

        /// <summary>
        /// RememberMe
        /// </summary>
        public bool RememberMe { get; set; }
    }
}