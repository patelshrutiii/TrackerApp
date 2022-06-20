using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.CustomClass;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_ProjectBLL
{
    public class TeamBLL
    {
        public UserMaster Create(UserMaster _UserMaster,int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    _UserMaster.CompanyId = companyId;
                    _UserMaster.JoiningDate = DateTime.Now;
                    _UserMaster.IsActive = true;
                    _UserMaster.EntryUser = companyId;
                    _UserMaster.EntryDate = DateTime.Now;
                    _UserMaster.IsDeleted = false;

                    var Dupemail = (from team in db.UserMasters where team.CompanyId == companyId && team.IsDeleted == false && team.Email.Equals(_UserMaster.Email) select team.UserId).ToList();
                    if (Dupemail.Count > 0)
                    {
                        throw new Exception("User Email is already exist");
                    }
                    else
                    {
                        db.UserMasters.Add(_UserMaster);
                        db.SaveChanges();
                        return _UserMaster;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }                                         
        }

        public UserMaster Update(UserMaster _UserMaster,int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                _UserMaster.CompanyId = companyId;
                _UserMaster.ModifiedUser = companyId;
                _UserMaster.ModifiedDate = DateTime.Now;
                _UserMaster.IsDeleted = false;
                db.UserMasters.Attach(_UserMaster);
                db.Entry(_UserMaster).State = EntityState.Modified;

                List<CompanyMaster> company = (from com in db.CompanyMasters where com.CompanyId == _UserMaster.CompanyId select com).ToList();
                var query = "UPDATE CompanyMaster SET PhoneNo = '" + _UserMaster.PhoneNo + "',StreetAddress = '" + _UserMaster.Address + "',EntryDate = '" + _UserMaster.EntryDate + "',ModifiedDate = '" + _UserMaster.ModifiedDate + "',IsActive = '" + _UserMaster.IsActive + "' WHERE CompanyId=" + company[0].CompanyId + "";

                db.Database.ExecuteSqlCommand(query);
                db.SaveChanges();
                return _UserMaster;
            }
        }

        public void Delete(int uid)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<ProjectAssign> passign = db.ProjectAssigns.Where(x => x.UserId == uid).ToList();
                if (passign != null)
                {
                    foreach (ProjectAssign p in passign)
                    {
                        p.IsDeleted = true;
                        db.ProjectAssigns.Attach(p);
                        db.Entry(p).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                UserMaster user = db.UserMasters.Where(x => x.UserId == uid).FirstOrDefault();
                if (user != null)
                {
                    user.IsDeleted = true;
                    db.UserMasters.Attach(user);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }      
                

            }
        }

        public void Restore(int uid)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<ProjectAssign> passign = db.ProjectAssigns.Where(x => x.UserId == uid).ToList();
                if (passign != null)
                {
                    foreach (ProjectAssign p in passign)
                    {
                        p.IsDeleted = false;
                        db.ProjectAssigns.Attach(p);
                        db.Entry(p).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                UserMaster user = db.UserMasters.Where(x => x.UserId == uid).FirstOrDefault();
                if (user != null)
                {
                    user.IsDeleted = false;
                    db.UserMasters.Attach(user);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }


            }
        }

        public void Trash(int uid)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<ProjectAssign> passign = db.ProjectAssigns.Where(x => x.UserId == uid).ToList();
                if (passign != null)
                {
                    foreach (ProjectAssign p in passign)
                    {
                        db.ProjectAssigns.Remove(p);
                        db.SaveChanges();
                    }
                }

                UserMaster user = db.UserMasters.Where(x => x.UserId == uid).FirstOrDefault();
                if (user != null)
                {
                    db.UserMasters.Remove(user);
                    db.SaveChanges();
                }


            }
        }

        public List<TeamRoleDetails> GetTeamList(int companyId)
        {
            List<TeamRoleDetails> details = new List<TeamRoleDetails>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    var users = (from u in db.UserMasters.Where(z => z.CompanyId == companyId && z.IsDeleted == false)
                                 join r in db.Roles on u.RoleId equals r.RoleId
                                 select new
                                 {
                                     UserId = u.UserId,
                                     DepartmentId = u.DepartmentId,
                                     DesignationId = u.DesignationId,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     Email = u.Email,
                                     Password = u.Password,
                                     ConfirmPassword = u.ConfirmPassword,
                                     JobTitle = u.JobTitle,
                                     PhoneNo = u.PhoneNo,
                                     Address = u.Address,
                                     Additionalinfo = u.Additionalinfo,
                                     JoiningDate = u.JoiningDate,
                                     IsActive = u.IsActive,
                                     EntryUser = u.EntryUser,
                                     ModifiedUser = u.ModifiedUser,
                                     EntryDate = u.EntryDate,
                                     ModifiedDate = u.ModifiedDate,
                                     IsDeleted = u.IsDeleted,
                                     RoleId = u.RoleId,
                                     RoleName = r.RoleName
                                 }).ToList();
                    foreach (var user in users)
                    {
                        TeamRoleDetails _TeamRoleDetails = new TeamRoleDetails();
                        _TeamRoleDetails.UserId = user.UserId;
                        _TeamRoleDetails.DepartmentId = user.DepartmentId;
                        _TeamRoleDetails.DesignationId = user.DesignationId;
                        _TeamRoleDetails.FirstName = user.FirstName;
                        _TeamRoleDetails.LastName = user.LastName;
                        _TeamRoleDetails.Email = user.Email;
                        _TeamRoleDetails.Password = user.Password;
                        _TeamRoleDetails.ConfirmPassword = user.ConfirmPassword;
                        _TeamRoleDetails.JobTitle = user.JobTitle;
                        _TeamRoleDetails.PhoneNo = user.PhoneNo;
                        _TeamRoleDetails.Address = user.Address;
                        _TeamRoleDetails.Additionalinfo = user.Additionalinfo;
                        _TeamRoleDetails.JoiningDate = user.JoiningDate;
                        _TeamRoleDetails.IsActive = user.IsActive;
                        _TeamRoleDetails.EntryUser = user.EntryUser;
                        _TeamRoleDetails.ModifiedUser = user.ModifiedUser;
                        _TeamRoleDetails.EntryDate = user.EntryDate;
                        _TeamRoleDetails.ModifiedDate = user.ModifiedDate;
                        _TeamRoleDetails.IsDeleted = user.IsDeleted;
                        _TeamRoleDetails.RoleId = user.RoleId;
                        _TeamRoleDetails.RoleName = user.RoleName;
                        details.Add(_TeamRoleDetails);
                    }
                    return details;
                }
                catch
                {
                    details = null;
                }
            }
            return details;
        }

        public List<TeamRoleDetails> ArchieveTeamList(int companyId)
        {
            List<TeamRoleDetails> details = new List<TeamRoleDetails>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    var users = (from u in db.UserMasters.Where(z => z.CompanyId == companyId && z.IsDeleted == true)
                                 join r in db.Roles on u.RoleId equals r.RoleId
                                 select new
                                 {
                                     UserId = u.UserId,
                                     DepartmentId = u.DepartmentId,
                                     DesignationId = u.DesignationId,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     Email = u.Email,
                                     Password = u.Password,
                                     ConfirmPassword = u.ConfirmPassword,
                                     JobTitle = u.JobTitle,
                                     PhoneNo = u.PhoneNo,
                                     Address = u.Address,
                                     Additionalinfo = u.Additionalinfo,
                                     JoiningDate = u.JoiningDate,
                                     RoleId = u.RoleId,
                                     RoleName = r.RoleName
                                 }).ToList();
                    foreach (var user in users)
                    {
                        TeamRoleDetails _TeamRoleDetails = new TeamRoleDetails();
                        _TeamRoleDetails.UserId = user.UserId;
                        _TeamRoleDetails.DepartmentId = user.DepartmentId;
                        _TeamRoleDetails.DesignationId = user.DesignationId;
                        _TeamRoleDetails.FirstName = user.FirstName;
                        _TeamRoleDetails.LastName = user.LastName;
                        _TeamRoleDetails.Email = user.Email;
                        _TeamRoleDetails.Password = user.Password;
                        _TeamRoleDetails.ConfirmPassword = user.ConfirmPassword;
                        _TeamRoleDetails.JobTitle = user.JobTitle;
                        _TeamRoleDetails.PhoneNo = user.PhoneNo;
                        _TeamRoleDetails.Address = user.Address;
                        _TeamRoleDetails.Additionalinfo = user.Additionalinfo;
                        _TeamRoleDetails.JoiningDate = user.JoiningDate;
                        _TeamRoleDetails.RoleId = user.RoleId;
                        _TeamRoleDetails.RoleName = user.RoleName;
                        details.Add(_TeamRoleDetails);
                    }
                    return details;
                }
                catch
                {
                    details = null;
                }
            }
            return details;
        }
       
    }
}
