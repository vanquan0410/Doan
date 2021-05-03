using System.Web.Mvc;

namespace OnlineShop.Areas.Admin
{
    /// <summary>
    /// AdminAreaRegistration
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// AreaName
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        /// <summary>
        /// RegisterArea
        /// </summary>
        /// <param name="context">AreaRegistrationContext</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}