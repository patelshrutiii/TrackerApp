using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Windows.Forms;
using WebTracker_ProjectBLL;
using WebTracker_ProjectDLL.CustomClass;
using WebTracker_ProjectDLL.Models;
using Newtonsoft.Json;
using System.Web;

namespace WebTracker_Project.WebAPI
{
    // Route   
    //[RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        ProjectBLL _ProjectBAL;

        //Constructor
        public ProjectController()
        {
            this._ProjectBAL = new ProjectBLL();
        }


        //Methods
        [HttpPost]
        [Route("api/Project/Create")]
        public IHttpActionResult Create(Project _ProjectMaster,int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_ProjectBAL.Create(_ProjectMaster,companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Project/Update")]
        public IHttpActionResult Update(Project _ProjectMaster,int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_ProjectBAL.Update(_ProjectMaster,companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Project/CreateUpdate")]
        public IHttpActionResult CreateUpdate(Project _ProjectMaster,int companyId)
        {
            try
            {
                if (_ProjectMaster.ProjectId == 0)
                {
                    return this.Create(_ProjectMaster, companyId);
                }
                else
                {
                    
                    return this.Update(_ProjectMaster,companyId);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
      
        [HttpPost]
        [Route("api/Project/Delete/{proj_id}")]
        public void Delete(int proj_id)
        {
            try
            {
                //return this.Delete(proj_id);
                _ProjectBAL.Delete(proj_id);
            }
            catch (Exception ex)
            {
                //return InternalServerError(ex);
                MessageBox.Show(ex.Message);
            }
        }        

        [HttpPost]
        [Route("api/Project/Restore/{proj_id}")]
        public void Restore(int proj_id)
        {
            try
            {
                //return this.Delete(proj_id);
                _ProjectBAL.Restore(proj_id);
            }
            catch (Exception ex)
            {
                //return InternalServerError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Project/Trash/{proj_id}")]
        public void Trash(int proj_id)
        {
            try
            {
                //return this.Delete(proj_id);
                _ProjectBAL.Trash(proj_id);
            }
            catch (Exception ex)
            {
                //return InternalServerError(ex);
                MessageBox.Show(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Project/GetProjectList")]
        public IHttpActionResult GetProjectList(int companyId)
        {
            try
            {
               companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_ProjectBAL.GetProjectList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Project/ArchieveProjList")]
        public IHttpActionResult ArchieveProjList(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_ProjectBAL.ArchieveProjList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[HttpGet]
        //[Route("api/Task/GetProjectAssignedUsers")]

        //public IHttpActionResult GetProjectAssignedUsers(int companyId, int ProjectId)
        //{
        //    try
        //    {
        //        companyId = (int)HttpContext.Current.Session["Cid"];
        //        return Ok(_ProjectBAL.GetProjectAssignedUsers(companyId, ProjectId));
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}


    }
}