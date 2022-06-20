using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms;
using WebTracker_ProjectBLL;
using WebTracker_ProjectDLL.Models;
using Newtonsoft.Json;
using System.Web;

namespace WebTracker_Project.WebAPI
{
    public class SettingController : ApiController
    {
        SettingBLL _SettingBLL;
        public SettingController()
        {
            this._SettingBLL = new SettingBLL();
        }
        [HttpGet]
        [Route("api/Setting/GetAccountInfo")]
        public IHttpActionResult GetAccountInfo(int companyId,string cname)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                cname = HttpContext.Current.Session["Cname"].ToString();
                return Ok(_SettingBLL.GetAccountInfo(companyId,cname));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
