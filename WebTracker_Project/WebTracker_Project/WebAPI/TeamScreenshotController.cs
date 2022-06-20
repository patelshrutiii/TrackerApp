using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebTracker_ProjectBLL;
using WebTracker_ProjectDLL.CustomClass;

namespace WebTracker_Project.WebAPI
{
    public class TeamScreenshotController : ApiController
    {
        TeamScreenshotBLL _TeamScreenshotBLL;

        //Constructor
        public TeamScreenshotController()
        {
            this._TeamScreenshotBLL = new TeamScreenshotBLL();
        }

        [HttpGet]
        [Route("api/TeamScreenshot/GetSSByUser")]
        public IHttpActionResult GetSSByUser(int companyId, int userId, int? projectId, string sdate)
        {
            try
            {
                //companyId = (int)HttpContext.Current.Session["Cid"];
                List<TeamSS> _TeamSS = _TeamScreenshotBLL.GetSSByUser(companyId, userId, projectId, sdate);
                if (_TeamSS != null)
                {
                    HttpContext.Current.Session["Company"] = _TeamSS[0].CompanyName + " " + _TeamSS[0].CompanyLastName;

                    string cname = HttpContext.Current.Session["Company"].ToString();
                    var compname = cname.Split(' ');
                    string fname = compname[0];
                    string lname = compname[1];
                    string res = fname.Substring(0, 1);
                    string res1 = lname.Substring(0, 1);
                    HttpContext.Current.Session["UserLogo"] = res + res1;
                }
                return Ok(_TeamSS);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/TeamScreenshot/GetProjectList")]
        public IHttpActionResult GetProjectList(int companyId)
        {
            try
            {
                return Ok(_TeamScreenshotBLL.GetProjectList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/TeamScreenshot/GetTeamList")]
        public IHttpActionResult GetTeamList(int companyId)
        {
            try
            {
                return Ok(_TeamScreenshotBLL.GetTeamList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/TeamScreenshot/GetDailyTimeDetails")]
        public IHttpActionResult GetDailyTimeDetails(int companyId, int ssid)
        {
            try
            {
                return Ok(_TeamScreenshotBLL.GetDailyTimeDetails(companyId, ssid));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
