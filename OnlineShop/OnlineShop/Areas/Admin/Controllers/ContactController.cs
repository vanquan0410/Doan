﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    /// <summary>
    /// ContactController
    /// </summary>
    public class ContactController : Controller
    {
        //
        // GET: /Admin/Contact/

        public ActionResult Index()
        {
            return View();
        }

    }
}
