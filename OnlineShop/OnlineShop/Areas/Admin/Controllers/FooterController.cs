using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// FooterController
    /// </summary>
    /// createdby:dvquan
    public class FooterController : Controller
    {
        //
        // GET: /Admin/Footer/
        /// <summary>
        /// footer
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}
