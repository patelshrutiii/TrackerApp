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
using WebTracker_ProjectDLL.CustomClass;
using Newtonsoft.Json;


namespace WebTracker_Project.WebAPI
{
    public class CompanyController : ApiController
    {
        CompanyBLL _CompanyBAL;
        // GET: Company


        //Constructor
        public CompanyController()
        {
            this._CompanyBAL = new CompanyBLL();
        }

        //Methods
        [HttpPost]
        [Route("api/Company/Create")]
        public IHttpActionResult Create(CompanyMaster _CompanyMaster)
        {
            try
            {
                return Ok(_CompanyBAL.Create(_CompanyMaster));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Update(CompanyMaster _CompanyMaster)
        {
            try
            {
                return Ok(_CompanyBAL.Update(_CompanyMaster));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Company/CreateUpdate")]
        public IHttpActionResult CreateUpdate(CompanyMaster _CompanyMaster)
        {
            try
            {
                if (_CompanyMaster.CompanyId == 0)
                {
                    return this.Create(_CompanyMaster);
                }
                else
                {
                    return this.Update(_CompanyMaster);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/Company/UserLogin")]
        public IHttpActionResult UserLogin(LoginData _logindata)
        {
            try
            {
                HttpCookie cookie = new HttpCookie("users");
                CompanyMaster companyMaster = _CompanyBAL.UserLogin(_logindata);
                if (_logindata.RememberMe == true)
                {
                    cookie["useremail"] = _logindata.CompanyEmail;
                    cookie["password"] = _logindata.Password;
                    cookie["remember"] = _logindata.RememberMe.ToString();
                    cookie.Expires = DateTime.Now.AddDays(4);
                    HttpContext.Current.Response.Cookies.Add(cookie);                    
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookie);                  
                }

                if (companyMaster != null)
                {
                    HttpContext.Current.Session["Cid"] = companyMaster.CompanyId;
                    HttpContext.Current.Session["CName"] = companyMaster.CompanyName + " " + companyMaster.CompanyLastName;

                    string cname = HttpContext.Current.Session["CName"].ToString();
                    var compname = cname.Split(' ');
                    string fname = compname[0];
                    string lname = compname[1];
                    string res = fname.Substring(0, 1);
                    string res1 = lname.Substring(0, 1);
                    HttpContext.Current.Session["Logo"] = res + res1;
                }
                
                return Ok(companyMaster);
                //HttpContext.Current.Session["Cid"] = _logindata.CompanyId;
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetCompanyById(int companyId)
        {
            try
            {
                companyId = (int)HttpContext.Current.Session["Cid"];
                return Ok(_CompanyBAL.GetCompanyById(companyId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult StateList()
        {
            try
            {
                return Ok(_CompanyBAL.StateList());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Company/CityList/{StateId}")]
        public IHttpActionResult CityList(int StateId)
        {
            try
            {
                return Ok(_CompanyBAL.CityList(StateId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
