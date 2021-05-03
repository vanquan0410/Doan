using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// ContentController
    /// </summary>
    public class ContentController : BaseController
    {
        /// <summary>
        /// trang content
        /// </summary>
        /// <returns></returns>
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// tạo content
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }


        /// <summary>
        /// SetViewBag
        /// </summary>
        /// <param name="selectedId"></param>
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.AllList(), "ID", "Name", selectedId);
        }
    }
}