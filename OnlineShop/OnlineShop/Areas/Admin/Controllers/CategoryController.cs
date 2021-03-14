using Models.DAO;
using Models.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// CategoryController
    /// </summary>
    /// createdby:dvquan
    public class CategoryController : BaseController
    {
        /// <summary>
        /// object StaticResources
        /// </summary>
        public object StaticResources { get; private set; }

        //
        // GET: /Admin/Category/
        /// <summary>
        /// trang chủ
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString">searchString</param>
        /// <param name="page">page</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns></returns>
        public ActionResult Select(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);

        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// thêm sản phẩm
        /// </summary>
        /// <param name="model">Category</param>
        /// <returns>View</returns>
        /// createdny:dvquan
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if(model.Name == null)
            {
                SetAlert("Tên loại sản phẩm bắt buộc", "error");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                //var currentCulture = Session[CommonConstants.CurrentCulture];
                //    model.Language = currentCulture.ToString();
                var session = (Common.UserLogin)Session[OnlineShop.Common.CommonConstants.USER_SESSION];
                model.CreatedBy = session.UserName;
                model.CreatedDate = DateTime.Now;
                var id = new CategoryDao().Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm loại sản phẩm thành công", "success");
                    return RedirectToAction("Create");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm loại sản phẩm không thành công");
                }
            }
            return View(model);
        }

    }
}
