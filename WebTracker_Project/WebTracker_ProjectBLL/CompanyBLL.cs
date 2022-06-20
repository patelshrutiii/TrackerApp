using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using WebTracker_ProjectDLL.Models;
using WebTracker_ProjectDLL.CustomClass;

namespace WebTracker_ProjectBLL
{
    public class CompanyBLL
    {
        public CompanyMaster Create(CompanyMaster _CompanyMaster)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    var c = new CompanyMaster()
                    {
                        CompanyName = _CompanyMaster.CompanyName,
                        CompanyLastName = _CompanyMaster.CompanyLastName,
                        CompanyEmail = _CompanyMaster.CompanyEmail,
                        CompanyPassword = _CompanyMaster.CompanyPassword,
                        CityId = _CompanyMaster.CityId,
                        StateId = _CompanyMaster.StateId,
                        StreetAddress = _CompanyMaster.StreetAddress,
                        MobileNo = _CompanyMaster.MobileNo,
                        PhoneNo = _CompanyMaster.PhoneNo,
                        Extension = _CompanyMaster.Extension,
                        IsActive = true,
                        EntryDate = DateTime.Now
                };

                    var Dubcomp = (from com in db.CompanyMasters where com.CompanyName.Equals(_CompanyMaster.CompanyName) select com.CompanyId).ToList();
                    if (Dubcomp.Count > 0)
                    {
                        throw new Exception("Company Name is already exist");
                    }
                    else
                    {
                        db.CompanyMasters.Add(c);
                        db.SaveChanges();
                        var u = new UserMaster()
                        {
                            CompanyId = c.CompanyId,
                            FirstName = c.CompanyName,
                            LastName = c.CompanyLastName,
                            Email = c.CompanyEmail,
                            Password = c.CompanyPassword,
                            ConfirmPassword = c.CompanyPassword,
                            PhoneNo = c.PhoneNo,
                            Address = c.StreetAddress,
                            IsActive = c.IsActive,
                            EntryUser = c.CompanyId,
                            EntryDate = c.EntryDate,
                            IsDeleted = false
                        };
                        db.UserMasters.Add(u);
                        db.SaveChanges();
                        return _CompanyMaster;
                    }
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public CompanyMaster Update(CompanyMaster _CompanyMaster)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                _CompanyMaster.ModifiedDate = DateTime.Now;
                db.CompanyMasters.Attach(_CompanyMaster);
                db.Entry(_CompanyMaster).State = EntityState.Modified;

                List<UserMaster> user = (from comuser in db.UserMasters where comuser.CompanyId == _CompanyMaster.CompanyId && comuser.FirstName == _CompanyMaster.CompanyName && comuser.LastName == _CompanyMaster.CompanyLastName select comuser).ToList();
                var query = "UPDATE UserMaster SET FirstName ='" + _CompanyMaster.CompanyName + "',LastName = '" + _CompanyMaster.CompanyLastName + "',Email = '" + _CompanyMaster.CompanyEmail + "',PhoneNo = '" + _CompanyMaster.PhoneNo + "',Address = '" + _CompanyMaster.StreetAddress + "',IsActive = '" + _CompanyMaster.IsActive + "',EntryUser = " + _CompanyMaster.CompanyId + ",ModifiedUser = " + _CompanyMaster.CompanyId + ",EntryDate = '" + _CompanyMaster.EntryDate + "',ModifiedDate = '" + _CompanyMaster.ModifiedDate + "' WHERE UserId=" + user[0].UserId + "";

                db.Database.ExecuteSqlCommand(query);

                db.SaveChanges();

                return _CompanyMaster;
            }
        }

        public CompanyMaster GetCompanyList(CompanyMaster _CompanyMaster)
        {
            CompanyMaster company = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    company = db.CompanyMasters.Where(a => a.CompanyEmail.Equals(_CompanyMaster.CompanyEmail) && a.CompanyPassword.Equals(_CompanyMaster.CompanyPassword)).FirstOrDefault();
                    return company;
                }
                catch
                {
                    company = null;
                }
            }
            return company;
        }

        public List<StateMaster> StateList()
        {
            List<StateMaster> state = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    state = db.StateMasters.ToList();
                    return state;
                }
                catch
                {
                    state = null;
                }
            }
            return state;
        }

        public List<CityMaster> CityList(int StateId)
        {
            List<CityMaster> city = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    city = db.CityMasters.Where(x => x.StateId == StateId).ToList();
                    return city;
                }
                catch
                {
                    city = null;
                }
            }
            return city;
        }
        public CompanyMaster UserLogin(LoginData d)
        {
            CompanyMaster company = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                
                try
                {
                    company = db.CompanyMasters.Where(a => a.CompanyEmail.Equals(d.CompanyEmail) && a.CompanyPassword.Equals(d.Password)).SingleOrDefault();
                    return company;
                }
                catch 
                {
                    company = null;
                }
            }
            return company;
        }

         public List<AllCompanyDetailsSp_Result> GetCompanyById(int companyId)
        {
            List<AllCompanyDetailsSp_Result> Company = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    Company = db.AllCompanyDetailsSp(companyId).ToList();
                    return Company;
                }
                catch 
                {
                    Company = null;
                }
            }
           return Company;
        }
    }
}
