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
    public class DesignationController : ApiController
    {
        DesignationBLL _DesignationBLL;

        //Constructor
        public DesignationController()
        {
            this._DesignationBLL = new DesignationBLL();
        }

        //Methods
        [HttpPost]
        [Route("api/Designation/Create")]
        public IHttpActionResult Create(Designation _Designation, int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DesignationBLL.Create(_Designation, companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Designation/Update")]
        public IHttpActionResult Update(Designation _Designation, int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DesignationBLL.Update(_Designation, companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Designation/CreateUpdate")]
        public IHttpActionResult CreateUpdate(Designation _Designation, int companyId)
        {
            try
            {
                if (_Designation.DesignationId == 0)
                {
                    return this.Create(_Designation, companyId);
                }
                else
                {
                    return this.Update(_Designation, companyId);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Designation/Delete/{des_id}")]
        public void Delete(int des_id)
        {
            try
            {
                _DesignationBLL.Delete(des_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Designation/Trash/{des_id}")]
        public void Trash(int des_id)
        {
            try
            {
                _DesignationBLL.Trash(des_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Designation/Restore/{des_id}")]
        public void Restore(int des_id)
        {
            try
            {
                _DesignationBLL.Restore(des_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        [HttpGet]
        [Route("api/Designation/GetDesList")]
        public IHttpActionResult GetDesList(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DesignationBLL.GetDesList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Designation/ArchieveDesList")]
        public IHttpActionResult ArchieveDesList(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_DesignationBLL.ArchieveDesList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
