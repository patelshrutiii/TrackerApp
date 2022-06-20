using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTracker_Project.Controllers
{
    public class TaskReportController : Controller
    {
        // GET: TaskReport
        public ActionResult List()
        {
            return View();
        }
    }
}