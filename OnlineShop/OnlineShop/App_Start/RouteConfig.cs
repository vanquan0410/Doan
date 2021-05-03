﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    /// <summary>
    /// config router
    /// </summary>
    /// createdby:dvquan
    public class RouteConfig
    {
        /// <summary>
        /// RegisterRoutes
        /// </summary>
        /// <param name="routes">routes</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Capcha
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            //danh sách sản phẩm
            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatitle}-{cateId}",
               defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
            );
            //chi tiet san pham
            routes.MapRoute(
               name: "Product Detail",
               url: "chi-tiet/{metatitle}-{cateId}",
              defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
           );
            //Tim kiem
            routes.MapRoute(
            name: "Search",
            url: "tim-kiem",
            defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
           );
            //khach hang dang ky 
            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
   );
            //Khach hang dang Nhap
            routes.MapRoute(
        name: "Login",
        url: "dang-nhap",
        defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
        namespaces: new[] { "OnlineShop.Controllers" }
    );
            //Phan gioi thieu
            routes.MapRoute(
              name: "About",
              url: "gioi-thieu",
             defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "OnlineShop.Controllers" }
          );
            //Thong tin lien he
            routes.MapRoute(
            name: "Contact",
            url: "lien-he",
           defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "OnlineShop.Controllers" }
        );
            //Gio Hang
            routes.MapRoute(
          name: "Cart",
          url: "gio-hang",
          defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" }
      );
            //Them vao gio hang
            routes.MapRoute(
           name: "Add Cart",
           url: "them-gio-hang",
           defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
           namespaces: new[] { "OnlineShop.Controllers" }
       );
            //Thanh toan
            routes.MapRoute(
         name: "Payment",
         url: "thanh-toan",
         defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
         namespaces: new[] { "OnlineShop.Controllers" }
     );
            //thanh toan thanh cong
            routes.MapRoute(
         name: "Payment Success",
         url: "hoan-thanh",
         defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
         namespaces: new[] { "OnlineShop.Controllers" }
     );
            //Mac dinh
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }

            );
        }
    }
}