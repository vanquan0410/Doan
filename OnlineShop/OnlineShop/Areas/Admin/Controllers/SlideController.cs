using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// SlideController
    /// </summary>
    public class SlideController : Controller
    {
        //
        // GET: /Admin/Slide/

        public ActionResult Index()
        {
            return View();
        }

        // xem san pham. co phan trang 
        public ActionResult Select(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new StatisticalDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

    }
}
