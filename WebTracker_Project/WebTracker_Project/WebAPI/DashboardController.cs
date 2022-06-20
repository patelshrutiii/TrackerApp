using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Windows.Forms;
using WebTracker_ProjectBLL;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_Project.WebAPI
{
    // Route   
    public class DashboardController : ApiController
    {
        DashboardBLL _DashboardBLL;

        //Constructor
        public DashboardController()
        {
            this._DashboardBLL = new DashboardBLL();
        }

        [HttpGet]
        [Route("api/Dashboard/TaskProgress")]
        public IHttpActionResult TaskProgress(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.TaskProgress(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Dashboard/GetAllUsers")]
        public IHttpActionResult GetAllUsers(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.GetAllUsers(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Dashboard/GetAllProjects")]
        public IHttpActionResult GetAllProjects(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.GetAllProjects(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Dashboard/GetAllTasks")]
        public IHttpActionResult GetAllTasks(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.GetAllTasks(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Dashboard/GetAllRoles")]
        public IHttpActionResult GetAllRoles(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.GetAllRoles(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Dashboard/GetTotalDailyTime")]
        public IHttpActionResult GetTotalDailyTime(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.GetTotalDailyTime(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Dashboard/GetTotalWeeklyTime")]
        public IHttpActionResult GetTotalWeeklyTime(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.GetTotalWeeklyTime(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Dashboard/GetAllDepartments")]
        public IHttpActionResult GetAllDepartments(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.GetAllDepartments(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Dashboard/GetAllDesignations")]
        public IHttpActionResult GetAllDesignations(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DashboardBLL.GetAllDesignations(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
