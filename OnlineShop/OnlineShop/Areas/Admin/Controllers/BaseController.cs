using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// controller chức các phương thức chung cho các controller con
    /// </summary>
    /// Createdby:dvquan(13/2/2021)
    public class BaseController : Controller
    {
        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="filterContext">ActionExecutingContext</param>
        /// Createdby:dvquan(13/2/2021)
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// SetAlert
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="type">type</param>
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
    
}