using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTracker_Project.Controllers
{
    public class TimesheetController : Controller
    {
        // GET: Timesheet
        public ActionResult List()
        {
            return View();
        }
    }
}