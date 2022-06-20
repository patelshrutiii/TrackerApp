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
using Newtonsoft.Json;
namespace WebTracker_Project.WebAPI
{
    // Route   
    //[RoutePrefix("api/Department")]
    public class ScreenshotController : ApiController
    {
        ScreenshotBLL _ScreenshotBLL;

        //Constructor
        public ScreenshotController()
        {
            this._ScreenshotBLL = new ScreenshotBLL();
        }
        class a1
        {
            public string[] itemList { get; set; }
        }

        //Methods
        [HttpPost]
        [Route("api/Screenshot/Delete")]
        public void Delete(object itemList)
        {
            try
            {
                  a1 a  = JsonConvert.DeserializeObject<a1>(itemList.ToString());                
                  _ScreenshotBLL.Delete(a.itemList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Screenshot/Restore")]
        public void Restore(object itemList)
        {
            try
            {
                a1 a = JsonConvert.DeserializeObject<a1>(itemList.ToString());
                _ScreenshotBLL.Restore(a.itemList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Screenshot/Trash")]
        public void Trash(object itemList)
        {
            try
            {
                a1 a = JsonConvert.DeserializeObject<a1>(itemList.ToString());
                _ScreenshotBLL.Trash(a.itemList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        [HttpGet]
        [Route("api/Screenshot/GetSSByUser")]
        public IHttpActionResult GetSSByUser(int companyId,int userId,int? projectId,string sdate)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_ScreenshotBLL.GetSSByUser(companyId, userId,projectId,sdate));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Screenshot/GetArchieveSSByUser")]
        public IHttpActionResult GetArchieveSSByUser(int companyId, int userId, int projectId, string sdate)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_ScreenshotBLL.GetArchieveSSByUser(companyId, userId, projectId, sdate));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Screenshot/GetDailyTimeDetails")]
        public IHttpActionResult GetDailyTimeDetails(int companyId, int ssid)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_ScreenshotBLL.GetDailyTimeDetails(companyId, ssid));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
