using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    /// <summary>
    /// controller about
    /// </summary>
    /// Createdby:dvquan(13/2/2021)
    public class AboutController : Controller
    {
        /// <summary>
        /// trang about
        /// </summary>
        /// <returns>view</returns>
        //Createdby:dvquan(13/2/2021)
        // GET: /About/
        public ActionResult Index()
        {
            return View();
        }

    }
}
