using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;
using OnlineShop.Common;
using OnlineShop.Controllers;
using OnlineShop.Models;
namespace OnlineShop.Controllers
{
    /// <summary>
    /// HomeController
    /// </summary>
    /// createdby:dvquan
    public class HomeController : Controller
    {
        /// <summary>
        /// home controller
        /// </summary>
        /// <returns></returns>
        //createdby:dvquan
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(4);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(4);
            return View();
        }

        /// <summary>
        /// controller menu
        /// </summary>
        /// <returns></returns>
        /// createdby:dvquan
        //Menu chinh
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupID(1);
            return PartialView(model);
        }

        /// <summary>
        /// controller menu top
        /// </summary>
        /// <returns></returns>
        /// createdby:dvquan
        //Menu Top
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupID(2);
            return PartialView(model);
        }

        /// <summary>
        /// controller HeaderCart
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if(cart!=null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        /// <summary>
        /// controller Footer
        /// </summary>
        /// <returns></returns>
        //Footer
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
    }
}
