using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WebTracker_Project.Controllers
{
    public class ProjectController : Controller
    {       
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