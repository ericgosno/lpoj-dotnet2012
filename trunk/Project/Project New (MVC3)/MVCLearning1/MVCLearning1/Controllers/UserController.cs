﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLearning1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ManUser()
        {
            return View();
        }
    }
}
