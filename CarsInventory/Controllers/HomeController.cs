﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsInventory.DataContext;

namespace CarsInventory.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IdentityDb _content;

        public HomeController(IdentityDb content)
        {
            _content = content;
        }

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
    }
}