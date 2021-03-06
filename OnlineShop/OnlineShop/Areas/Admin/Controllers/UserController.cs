using Common;
using Models.DAO;
using Models.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// UserController
    /// </summary>
    /// createdby:dvquan
    public class UserController : BaseController
    {
        // GET: Admin/User
        //public ActionResult Index(int page = 1, int pageSize = 1)
        //{
        //    var dao = new UserDAO();
        //    var model = dao.ListAllPaging( page, pageSize);
        //    return View(model);
        //}
        /// <summary>
        /// logout
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session[Common.CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        /// <summary>
        /// lấy danh sách
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Select(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        /// <summary>
        /// chỉnh sửa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        /// <summary>
        /// tạo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// tạo
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (user.UserName == null)
            {
                SetAlert("Tên tài khoản bắt buộc", "error");
                return View("Create");
            }
            else if (user.Password == null)
            {
                SetAlert("Mật khẩu bắt buộc", "error");
                return View("Create");
            }
            else if (ModelState.IsValid)
            {
                var dao = new UserDao();
                user.Password = Encryptor.MD5Hash(user.Password);
                user.GroupID = "ADMIN";
                var session = (Common.UserLogin)Session[OnlineShop.Common.CommonConstants.USER_SESSION];
                user.CreatedBy = session.UserName;
                user.CreatedDate = DateTime.Now;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm tài khoản thành công", "success");
                    return RedirectToAction("Select", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tài khoản không thành công");
                }
            }
            return View("Create");
        }

        /// <summary>
        /// chỉnh sửa user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// createdby:dvquan
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var session = (Common.UserLogin)Session[OnlineShop.Common.CommonConstants.USER_SESSION];
                user.ModifiedBy = session.UserName;
                user.ModifiedDate = DateTime.Now;
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật tài khoản thành công", "success");
                    return RedirectToAction("Select", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tài khoản không thành công");
                }
            }
            return View("Select");
        }

        /// <summary>
        /// xóa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// thay đổi trạng thái
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}