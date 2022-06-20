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
    public class TimesheetController : ApiController
    {
        TimesheetBLL _TimeSheetBLL;

        public TimesheetController()
        {
            this._TimeSheetBLL = new TimesheetBLL();
        }

        //[HttpGet]
        //[Route("api/TimeSheet/getplist/{Proj_id}")]
        //public IHttpActionResult getplist(int? Proj_id)
        //{
        //    try
        //    {
        //        return Ok(_TimeSheetBLL.getplist(Proj_id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        [HttpGet]
        [Route("api/Timesheet/ProjectReportSP")]
        public IHttpActionResult ProjectReportSP(int companyId, int? projectId, DateTime Todate, DateTime fromdate)
        {

            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TimeSheetBLL.ProjectReportSP(companyId, projectId, Todate, fromdate));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Timesheet/UserReportSP")]
        public IHttpActionResult UserReportSP(int companyId, int? userId, int? designationId, int? departmentId, DateTime Todate, DateTime fromdate)
        {

            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TimeSheetBLL.UserReportSP(companyId, userId, designationId, departmentId, Todate, fromdate));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



    }
}