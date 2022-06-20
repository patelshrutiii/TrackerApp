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
    public class RoleController : ApiController
    {
        RoleBLL _RoleBLL;

        //Constructor
        public RoleController()
        {
            this._RoleBLL = new RoleBLL();
        }

        //Methods
        [HttpGet]
        [Route("api/Role/GetRoleList")]
        public IHttpActionResult GetRoleList(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_RoleBLL.GetRoleList(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
