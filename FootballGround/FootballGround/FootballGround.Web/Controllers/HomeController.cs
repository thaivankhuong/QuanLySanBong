﻿using FootballGround.Web.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballGround.Web.Controllers
{
    public class HomeController : BaseMenuController
    {
        public ActionResult Index()
        {
            return View();
        }
     

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }
    }
}