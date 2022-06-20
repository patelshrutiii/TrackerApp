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
    //[RoutePrefix("api/Team")]
    public class TeamController : ApiController
    {
        TeamBLL _TeamBLL;

        //Constructor
        public TeamController()
        {
            this._TeamBLL = new TeamBLL();
        }

        //Methods
        [HttpPost]
        [Route("api/Team/Create")]
        public IHttpActionResult Create(UserMaster _UserMaster,int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TeamBLL.Create(_UserMaster, companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Team/Update")]
        public IHttpActionResult Update(UserMaster _UserMaster,int companyId)
        {
            companyId = (int)HttpContext.Current.Session["Cid"];
            return Ok(_TeamBLL.Update(_UserMaster, companyId));

            //try
            //{
            //   }
            //catch (Exception ex)
            //{
            //    return InternalServerError(ex);
            //}
        }

        [HttpPost]
        [Route("api/Team/CreateUpdate")]
        public IHttpActionResult CreateUpdate(UserMaster _UserMaster,int companyId)
        {
            //try
            //{
                if (_UserMaster.UserId == 0)
                {
                    return this.Create(_UserMaster, companyId);
                }
                else
                {
                    return this.Update(_UserMaster, companyId);
                }
            //}
            //catch (Exception ex)
            //{
            //    return InternalServerError(ex);
            //}
        }

        [HttpPost]
        [Route("api/Team/Delete/{user_id}")]
        public void Delete(int user_id)
        {
            try
            {
                _TeamBLL.Delete(user_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        [HttpPost]
        [Route("api/Team/Restore/{user_id}")]
        public void Restore(int user_id)
        {
            try
            {
                _TeamBLL.Restore(user_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Team/Trash/{user_id}")]
        public void Trash(int user_id)
        {
            try
            {
                _TeamBLL.Trash(user_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Team/GetTeamList")]
        public IHttpActionResult GetTeamList(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TeamBLL.GetTeamList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Team/ArchieveTeamList")]
        public IHttpActionResult ArchieveTeamList(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TeamBLL.ArchieveTeamList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
