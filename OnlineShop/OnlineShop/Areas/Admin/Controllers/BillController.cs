using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// BillController
    /// </summary>
    public class BillController : Controller
    {
        //
        // GET: /Admin/Bill/

        OnlineShopDbContext db = new OnlineShopDbContext();
        /// <summary>
        /// trang Bill
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        // xem san pham. co phan trang 
        /*public ActionResult Select(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
*/
    }
}
