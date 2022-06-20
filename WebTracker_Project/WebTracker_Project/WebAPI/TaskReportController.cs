using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Windows.Forms;
using WebTracker_ProjectBLL;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_Project.WebAPI
{
    public class TaskReportController : ApiController
    {
        TaskReportBLL _TaskReportBLL;
        public TaskReportController()
        {
            this._TaskReportBLL = new TaskReportBLL();
        }

        [HttpGet]
        [Route("api/TaskReport/GetManageTaskList")]
        public IHttpActionResult GetManageTaskList(int companyId, int? projectId, int? deptId, int? desId, string sdate, string edate)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];

                return Ok(_TaskReportBLL.GetManageTaskList(companyId, projectId, deptId, desId, sdate, edate));
                //return Ok("Test Return");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
