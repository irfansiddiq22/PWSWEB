﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Index()
        {
            ViewBag.Title = "Setting";
            ViewBag.Parent = null;
            return View();
        }
    }
}