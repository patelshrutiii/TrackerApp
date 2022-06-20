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
    //[RoutePrefix("api/Department")]
    public class AttendenceController : ApiController
    {
        AttendenceBLL _AttendenceBLL;

        //Constructor
        public AttendenceController()
        {
            this._AttendenceBLL = new AttendenceBLL();
        }

        [HttpGet]
        [Route("api/Attendence/GetAttendence")]
        public IHttpActionResult GetAttendence(int companyId, int? userId, int? deptId, int? desId, string sdate)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_AttendenceBLL.GetAttendence(companyId, userId, deptId, desId, sdate));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
