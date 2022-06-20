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
    public class DepartmentController : ApiController
    {
            DepartmentBLL _DepartmentBLL;

            //Constructor
            public DepartmentController()
            {
                this._DepartmentBLL = new DepartmentBLL();
            }

            //Methods
            [HttpPost]
            [Route("api/Department/Create")]
            public IHttpActionResult Create(Department _Department, int companyId)
            {
                try
                {
                    companyId = (int)HttpContext.Current.Session["Cid"];
                    return Ok(_DepartmentBLL.Create(_Department, companyId));
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            [HttpPost]
            [Route("api/Department/Update")]
            public IHttpActionResult Update(Department _Department,int companyId)
            {
                try
                {
                    companyId = (int)HttpContext.Current.Session["Cid"];
                    return Ok(_DepartmentBLL.Update(_Department, companyId));
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            [HttpPost]
            [Route("api/Department/CreateUpdate")]
            public IHttpActionResult CreateUpdate(Department _Department,int companyId)
            {
                try
                {
                    if (_Department.DepartmentId == 0)
                    {
                        return this.Create(_Department, companyId);
                    }
                    else
                    {
                        return this.Update(_Department, companyId);
                    }
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
          
            [HttpPost]
            [Route("api/Department/Delete/{dept_id}")]
            public void Delete(int dept_id)
            {
                try
                {
                    _DepartmentBLL.Delete(dept_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            [HttpPost]
            [Route("api/Department/Trash/{dept_id}")]
            public void Trash(int dept_id)
            {
                try
                {
                    _DepartmentBLL.Trash(dept_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            [HttpPost]
            [Route("api/Department/Restore/{dept_id}")]
            public void Restore(int dept_id)
            {
                try
                {
                    _DepartmentBLL.Restore(dept_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            

            [HttpGet]
            [Route("api/Department/GetDeptList")]
            public IHttpActionResult GetDeptList(int companyId)
            {
                try
                {
                    companyId = (int)HttpContext.Current.Session["Cid"];
                    return Ok(_DepartmentBLL.GetDeptList(companyId));
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            [HttpGet]
            [Route("api/Department/ArchieveDeptList")]
            public IHttpActionResult ArchieveDeptList(int companyId)
            {
                try
                {
                    companyId = (int)HttpContext.Current.Session["Cid"];
                    return Ok(_DepartmentBLL.ArchieveDeptList(companyId));
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
    }
}
