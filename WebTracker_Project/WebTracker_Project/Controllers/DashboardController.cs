using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTracker_ProjectDLL.CustomClass;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_Project.Controllers
{
    public class DashboardController : Controller
    {
        public class Ratio
        {
            public int user { get; set; }
            public int proj { get; set; }
            public int task { get; set; }
        }

        public JsonResult piechartdata()
        {
            #region Peichart
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var companyId = (int)Session["Cid"];
                var users = (from user in db.UserMasters
                             join c in db.CompanyMasters on user.CompanyId equals c.CompanyId
                             where user.CompanyId == companyId && user.IsDeleted == false
                             select user).Count();
                var projs = (from proj in db.ProjectMasters
                             join c in db.CompanyMasters on proj.CompanyId equals c.CompanyId
                             where proj.CompanyId == companyId && proj.IsDeleted == false
                             select proj).Count();
                var tasks = (from tid in db.TaskMasters
                             join c in db.CompanyMasters on tid.CompanyId equals c.CompanyId
                             where tid.CompanyId == companyId && tid.IsDeleted == false
                             select tid).Count();

                Ratio obj = new Ratio();
                obj.user = users;
                obj.proj = projs;
                obj.task = tasks;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            #endregion

        }

        public ActionResult List()
        {
            return View();
        }

    }
}