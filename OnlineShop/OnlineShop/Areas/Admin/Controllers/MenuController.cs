using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// MenuController
    /// </summary>
    /// createdby:dvquan
    public class MenuController : Controller
    {
        //
        // GET: /Admin/Menu/

        public ActionResult Index()
        {
            return View();
        }

    }
}
