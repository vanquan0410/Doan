using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// HomeController
    /// </summary>
    /// createdby:qvquan
    public class HomeController : BaseController
    {
        /// <summary>
        /// home
        /// </summary>
        /// <returns></returns>
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}