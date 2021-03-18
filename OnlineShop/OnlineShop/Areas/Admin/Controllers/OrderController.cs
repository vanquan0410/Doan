using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// OrderController
    /// </summary>
    /// createdbu:dvquan
    public class OrderController : BaseController
    {
        //
        // GET: /Admin/Order/

        public ActionResult Index()
        {
            return View();
        }

        // xem san pham. co phan trang 
        public ActionResult Select(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }


        [HttpDelete] // xoa san pham
        public ActionResult Delete(int id)
        {
            new OrderDao().ChangeStatusTrue(id);
            SetAlert("đơn hàng đã được giao đến khách hàng", "success");
            return View("Select");
        }

    }
}
