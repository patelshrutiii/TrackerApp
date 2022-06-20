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
    public class TeamReportController : ApiController
    {
        TeamReportBLL _TeamReportBLL;
        public TeamReportController()
        {
            this._TeamReportBLL = new TeamReportBLL();
        }

        [HttpGet]
        [Route("api/TeamReport/GetTeamList")]
        public IHttpActionResult GetTeamList(int companyId)
        {
            try
            {
                return Ok(_TeamReportBLL.GetTeamList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("api/TeamReport/TeamReportSP")]
        public IHttpActionResult TeamReportSP(int companyId, int userId, DateTime Todate, DateTime fromdate)
        {

            try
            {

                return Ok(_TeamReportBLL.TeamReportSP(companyId, userId, Todate, fromdate));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
