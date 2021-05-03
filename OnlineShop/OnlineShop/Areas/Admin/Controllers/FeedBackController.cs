using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// FeedBackController
    /// </summary>
    /// createdby:dvquan
    public class FeedBackController : Controller
    {
        //
        // GET: /Admin/FeedBack/
        /// <summary>
        /// trang FeedBack
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}
