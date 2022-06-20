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
    public class TaskController : ApiController
    {
        TaskBLL _TaskBAL;
        public TaskController()
        {
            this._TaskBAL = new TaskBLL();
        }

        [HttpPost]
        [Route("api/Task/TaskAssignToAll")]
        public IHttpActionResult TaskAssignToAll(TaskAssign _TaskAssign)
        {
            try
            {
                return Ok(_TaskBAL.TaskAssignToAll(_TaskAssign));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("api/Task/TaskAssignUser")]
        public IHttpActionResult TaskAssignUser(TaskAssign _TaskAssign)
        {
            try
            {
                return Ok(_TaskBAL.TaskAssignUser(_TaskAssign));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Task/Create")]
        public IHttpActionResult Create(TaskMaster _TaskMaster, int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.Create(_TaskMaster, companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Update(TaskMaster _TaskMaster,int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.Update(_TaskMaster, companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Task/CreateUpdate")]
        public IHttpActionResult CreateUpdate(TaskMaster _TaskMaster,int companyId)
        {
            try
            {
                if (_TaskMaster.TaskId == 0)
                {
                    return this.Create(_TaskMaster, companyId);
                }
                else
                {
                    return this.Update(_TaskMaster, companyId);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public void DeleteAllTask(int companyId, int Pid)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                _TaskBAL.DeleteAllTask(companyId, Pid);
            }
            catch (Exception ex)
            {
                //return InternalServerError(ex);
                MessageBox.Show(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Task/DeleteCompletedTask")]
        public void DeleteCompletedTask(int companyId, int Pid)
        {
            try
            {
                //return this.Delete(proj_id);
                companyId = (int)HttpContext.Current.Session["Cid"];
                _TaskBAL.DeleteCompletedTask(companyId, Pid);
            }
            catch (Exception ex)
            {
                //return InternalServerError(ex);
                MessageBox.Show(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Task/Delete")]
        public void Delete(int companyId, int selectedProjectId, int TaskId)
        {
            try
            {
                //return this.Delete(proj_id);
                companyId = (int)HttpContext.Current.Session["Cid"];
                _TaskBAL.Delete(companyId, selectedProjectId, TaskId);
            }
            catch (Exception ex)
            {
                //return InternalServerError(ex);
                MessageBox.Show(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Task/DeleteUser/{AssignId}")]
        public void DeleteUser(int AssignId)
        {
            try
            {
                //return this.Delete(proj_id);
                _TaskBAL.DeleteUser(AssignId);
            }
            catch (Exception ex)
            {
                //return InternalServerError(ex);
                MessageBox.Show(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Task/GetActiveTask")]
        public IHttpActionResult GetActiveTask(int companyId, int ProjectId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.GetActiveTask(companyId, ProjectId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Task/refreshedit")]
        public IHttpActionResult refreshedit(int companyId, int ProjectId, int TaskId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.refreshedit(companyId, ProjectId, TaskId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("api/Task/GetCompletedList")]
        public IHttpActionResult GetCompletedList(int companyId, int ProjectId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.GetCompletedList(companyId, ProjectId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetTaskList(int companyId, int ProjectId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.GetTaskList(companyId, ProjectId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("api/Task/GetProjectname")]
        public IHttpActionResult GetProjectname(int companyId, int ProjectId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.GetProjectname(companyId, ProjectId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Task/GetPriorityList")]
        public IHttpActionResult GetPriorityList()
        {
            try
            {
                return Ok(_TaskBAL.GetPriorityList());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Task/GetStatusList")]
        public IHttpActionResult GetStatusList()
        {
            try
            {
                return Ok(_TaskBAL.GetStatusList());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("api/Task/GetTaskByProject/{companyId,projectID}")]

        public IHttpActionResult GetTaskByProject(int companyId, int projectID)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.GetTaskByProject(companyId, projectID));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        //[Route("api/Task/GetTaskAssignedUsers/{selectedProjectId}")]
        public IHttpActionResult GetTaskAssignedUsers(int companyId, int selectedProjectId, int TaskId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_TaskBAL.GetTaskAssignedUsers(companyId, selectedProjectId, TaskId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Task/UpdateStatus/{TaskId}")]
        public IHttpActionResult UpdateStatus(int TaskId)
        {
            try
            {
                return Ok(_TaskBAL.UpdateStatus(TaskId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
