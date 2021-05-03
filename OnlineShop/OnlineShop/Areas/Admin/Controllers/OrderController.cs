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

        /// <summary>
        /// trang order
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// xem sản phẩm có phân trang
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// createdby:dvquan
        // xem san pham. co phan trang 
        public ActionResult Select(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        /// <summary>
        /// thực hiện xóa trạng thái khi khách hàng đã thanh toán
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// createdby:dvquan
        [HttpDelete] // thực hiện xóa trạng thái khi khách hàng đã thanh toán
        public ActionResult Delete(int id)
        {
            new OrderDao().ChangeStatusTrue(id);
            SetAlert("đơn hàng đã được giao đến khách hàng", "success");
            return View("Select");
        }

        /// <summary>
        /// thực hiện xóa trạng thái khi khách đã thanh toán
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// createdby:dvquan
        [HttpDelete] // thực hiện xóa trạng thái khi khách hàng đã thanh toán
        public ActionResult DeleteCancel(int id)
        {
            new OrderDao().ChangeStatusFalse(id);
            SetAlert("hủy đơn hàng", "success");
            return View("Select");
        }

    }
}
