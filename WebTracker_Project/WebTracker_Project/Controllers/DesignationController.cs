﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTracker_Project.Controllers
{
    public class DesignationController : Controller
    {
        // GET: Designation
        public ActionResult List()
        {
            return View();
        }

        public ActionResult ArchieveList()
        {
            return View();
        }
    }
}