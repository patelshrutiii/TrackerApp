using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebTracker_ProjectDLL.CustomClass;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_Project.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string EmailId)
        {

            TrackerAppEntities db = new TrackerAppEntities();

            var _objuserdetail = db.UserMasters.Where(x => x.Email == EmailId).FirstOrDefault();
            if (_objuserdetail != null)
            {
                string name = _objuserdetail.FirstName + " " + _objuserdetail.LastName;
                string resetCode = new Guid().ToString();
                string status = SendVerification(resetCode, _objuserdetail.Email, name);
                _objuserdetail.ResetPasswordCode = resetCode;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                ViewBag.Message = 1;
            }
            else
            {
                ViewBag.Message = 0;
            }
            return View();

        }
        public string SendVerification(string resetcode, string emailId, string name)
        {
            var verifyUrl = "/Company/ResetPassword/" + resetcode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            MailMessage mail = new MailMessage();
            mail.To.Add(emailId);
            mail.From = new MailAddress("shraddhamodhera.mscit18@vnsgu.ac.in");
            mail.Subject = "Reset Password for Tracker of " + emailId;

            string Body = "Dear " + name + ", <br/><br/> We got request for reset your account password.Please click on the below link to reset your password" +
                " <br/><br/><a href=" + link + ">Reset Password Link</a>";
            mail.Body = Body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //SMTP Server Address of gmail
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("shraddhamodhera.mscit18@vnsgu.ac.in", "#ShruModhera2010");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return "Please check your email for account login detail.";

        }

        public ActionResult ResetPassword(string id)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var _user = db.UserMasters.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (_user != null)
                {
                    ResetPassword _resetPassword = new ResetPassword();
                    _resetPassword.ResetCode = id;
                    return View(_resetPassword);
                }
                else
                {
                    return HttpNotFound();
                }

            }
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPassword _resetPassword)
        {

            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var _user = db.UserMasters.Where(a => a.ResetPasswordCode == _resetPassword.ResetCode).FirstOrDefault();
                if (_user != null && _resetPassword.NewPassword == _resetPassword.ConfirmPassword)
                {
                    var c = db.CompanyMasters.Where(z => z.CompanyId == _user.CompanyId && z.CompanyName.Equals(_user.FirstName)).FirstOrDefault();
                    if(c != null)
                    {
                        c.CompanyPassword = _resetPassword.NewPassword;
                    }                              
                    _user.Password = _resetPassword.NewPassword;
                    _user.ConfirmPassword = _resetPassword.ConfirmPassword;
                    _user.ResetPasswordCode = "";
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    ViewBag.Msg = 1;
                }
                else
                {
                    ViewBag.Msg = 0;
                }

            }
            return View(_resetPassword);
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Abandon();
            return RedirectToAction("Login","Company");
        }
    }
}