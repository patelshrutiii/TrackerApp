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
    public class ProjectBLL
    {
        public Project Create(Project _ProjectMaster,int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    var p = new ProjectMaster()
                    {
                        ProjectName = _ProjectMaster.ProjectName,
                        CompanyId = companyId,
                        StartDate = _ProjectMaster.StartDate,
                        DeadLine = _ProjectMaster.DeadLine,
                        EstimationHour = _ProjectMaster.EstimationHour,
                        Remark = _ProjectMaster.Remark,                       
                        IsActive = true,
                        EntryUser = companyId,
                        EntryDate = DateTime.Now,
                        IsDeleted = false
                    };

                    var DubProj = (from proj in db.ProjectMasters where proj.CompanyId == companyId && proj.IsDeleted == false && proj.ProjectName.Equals(_ProjectMaster.ProjectName) select proj.ProjectId).ToList();
                    if (DubProj.Count > 0)
                    {
                        throw new Exception("Project Name is already exist");
                    }
                    else
                    {
                        db.ProjectMasters.Add(p);
                        db.SaveChanges();
                        foreach (ProjectUser user in _ProjectMaster.assign)
                        {
                            ProjectAssign _ProjectAssign = new ProjectAssign();
                            _ProjectAssign.ProjectId = p.ProjectId;
                            _ProjectAssign.CompanyId = p.CompanyId;
                            _ProjectAssign.UserId = user.UserId;
                            _ProjectAssign.WeeklyLimit = user.WeeklyLimit;
                            _ProjectAssign.Rate = user.Rate;
                            _ProjectAssign.EntryUser = p.EntryUser;
                            _ProjectAssign.EntryDate = p.EntryDate;                            
                            _ProjectAssign.IsDeleted = false;
                            db.ProjectAssigns.Add(_ProjectAssign);
                        }
                        db.SaveChanges();
                        return _ProjectMaster;
                    }                 
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }        

        public Project Update(Project _Project,int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {

                var existRecord = db.ProjectMasters
                 .Where(s => s.ProjectId == _Project.ProjectId)
                 .Include(Cts => Cts.ProjectAssigns)
                 .SingleOrDefault();

                if (existRecord != null)
                {
                    // Update Project Master Table
                    existRecord.ProjectName = _Project.ProjectName;
                    existRecord.StartDate = _Project.StartDate;
                    existRecord.DeadLine = _Project.DeadLine;
                    existRecord.EstimationHour = _Project.EstimationHour;
                    existRecord.CompanyId = companyId;
                    existRecord.Remark = _Project.Remark;
                    existRecord.IsActive = _Project.IsActive;
                    existRecord.EntryUser = _Project.EntryUser;
                    existRecord.ModifiedUser = companyId;
                    existRecord.EntryDate = _Project.EntryDate;
                    existRecord.ModifiedDate = DateTime.Now;
                    existRecord.IsDeleted = false;
                    db.Entry(existRecord).CurrentValues.SetValues(existRecord);

                    // Delete Project Assign Record
                    foreach (var DeleteAssign in existRecord.ProjectAssigns.ToList())
                    {
                        if (!_Project.assign.Any(c => c.ProjectAssignId == DeleteAssign.ProjectAssignId))
                            db.ProjectAssigns.Remove(DeleteAssign);
                    }

                    foreach (var _assign in _Project.assign)
                    {
                        var _projectAssign = existRecord.ProjectAssigns
                            .Where(c => c.ProjectAssignId == _assign.ProjectAssignId && _assign.ProjectAssignId != 0 &&  c.ProjectId != default(int))
                            .SingleOrDefault();

                        if (_projectAssign != null)
                        {
                            // Update Project Assign
                            _assign.ProjectAssignId = _projectAssign.ProjectAssignId;
                            _assign.UserId = _assign.UserId;
                            _assign.WeeklyLimit = _assign.WeeklyLimit;
                            _assign.Rate = _assign.Rate;
                            _assign.EntryUser = existRecord.EntryUser;
                            _assign.ModifiedUser = existRecord.ModifiedUser;
                            _assign.EntryDate = existRecord.EntryDate;
                            _assign.ModifiedDate = existRecord.ModifiedDate;
                            _assign.IsDeleted = existRecord.IsDeleted;
                            db.Entry(_projectAssign).CurrentValues.SetValues(_assign);
                        }
                        else
                        {
                            // Insert New Project Assign
                            var newAssign = new ProjectAssign
                            {
                                ProjectId = _Project.ProjectId,
                                CompanyId = companyId,
                                UserId = _assign.UserId,
                                WeeklyLimit = _assign.WeeklyLimit,
                                Rate = _assign.Rate,
                                EntryUser = _Project.EntryUser,
                                ModifiedUser = _Project.ModifiedUser,
                                EntryDate = _Project.EntryDate,
                                ModifiedDate = _Project.ModifiedDate,
                                IsDeleted = _Project.IsDeleted
                            };
                            existRecord.ProjectAssigns.Add(newAssign);
                        }
                    }
                    db.SaveChanges();
                }
            }
            return _Project;
        }
    
        public void Delete(int pid)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
               // List<ProjectAssign> _ProjectAssign = null;
                List<ProjectAssign> passign = db.ProjectAssigns.Where(x => x.ProjectId == pid).ToList();
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

                    List<TaskMaster> tmaster = db.TaskMasters.Where(x => x.ProjectId == pid).ToList();
                    if (tmaster != null)
                    {
                        foreach (TaskMaster t in tmaster)
                        {
                            t.IsDeleted = true;
                            db.TaskMasters.Attach(t);
                            db.Entry(t).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    ProjectMaster project = db.ProjectMasters.Where(x => x.ProjectId == pid).FirstOrDefault();
                    if (project != null)
                    {
                        project.IsDeleted = true;
                        db.ProjectMasters.Attach(project);
                        db.Entry(project).State = EntityState.Modified;
                        db.SaveChanges();
                    }
            }
        }

        public void Trash(int pid)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                // List<ProjectAssign> _ProjectAssign = null;
                List<ProjectAssign> passign = db.ProjectAssigns.Where(x => x.ProjectId == pid).ToList();
                if (passign != null)
                {
                    foreach (ProjectAssign p in passign)
                    {
                        db.ProjectAssigns.Remove(p);
                        db.SaveChanges();
                    }
                }

                List<TaskMaster> tmaster = db.TaskMasters.Where(x => x.ProjectId == pid).ToList();
                if (tmaster != null)
                {
                    foreach (TaskMaster t in tmaster)
                    {

                        db.TaskMasters.Remove(t);
                        db.SaveChanges();
                    }
                }

                ProjectMaster project = db.ProjectMasters.Where(x => x.ProjectId == pid).FirstOrDefault();
                if (project != null)
                {
                    db.ProjectMasters.Remove(project);
                    db.SaveChanges();
                }
            }
        }

        public void Restore(int pid)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                // List<ProjectAssign> _ProjectAssign = null;
                List<ProjectAssign> passign = db.ProjectAssigns.Where(x => x.ProjectId == pid).ToList();
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

                List<TaskMaster> tmaster = db.TaskMasters.Where(x => x.ProjectId == pid).ToList();
                if (tmaster != null)
                {
                    foreach (TaskMaster t in tmaster)
                    {
                        t.IsDeleted = false;
                        db.TaskMasters.Attach(t);
                        db.Entry(t).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                ProjectMaster project = db.ProjectMasters.Where(x => x.ProjectId == pid).FirstOrDefault();
                if (project != null)
                {
                    project.IsDeleted = false;
                    db.ProjectMasters.Attach(project);
                    db.Entry(project).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public List<Project> GetProjectList(int compnayId)
        {

            List<Project> _projects = new List<Project>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var _pmaster = db.ProjectMasters.Where(x => x.CompanyId == compnayId && x.IsDeleted == false).ToList();
                foreach (ProjectMaster _ProjectMaster in _pmaster)
                {
                    Project _Project = new Project();
                    _Project.ProjectId = _ProjectMaster.ProjectId;
                    _Project.ProjectName = _ProjectMaster.ProjectName;
                    _Project.Remark = _ProjectMaster.Remark;
                    _Project.StartDate = _ProjectMaster.StartDate;
                    _Project.DeadLine = _ProjectMaster.DeadLine;
                    _Project.EstimationHour = _ProjectMaster.EstimationHour;
                    _Project.IsActive = _ProjectMaster.IsActive;
                    _Project.EntryUser = _ProjectMaster.EntryUser;
                    _Project.ModifiedUser = _ProjectMaster.ModifiedUser;
                    _Project.EntryDate = _ProjectMaster.EntryDate;
                    _Project.ModifiedDate = _ProjectMaster.ModifiedDate;
                    _Project.IsDeleted = _ProjectMaster.IsDeleted;

                    var a = (from u in db.ProjectAssigns.Where(z => z.ProjectId == _ProjectMaster.ProjectId && z.IsDeleted == false)
                             join f in db.UserMasters
                             on u.UserId equals f.UserId
                             select new ProjectUser
                             {
                                 ProjectAssignId = u.ProjectAssignId,
                                 ProjectId = u.ProjectId,
                                 CompanyId = u.CompanyId,
                                 UserId = u.UserId,
                                 UserName = f.FirstName + " " + f.LastName,
                                 WeeklyLimit = u.WeeklyLimit,
                                 Rate = u.Rate,
                                 EntryUser = u.EntryUser,
                                 ModifiedUser = u.ModifiedUser,
                                 EntryDate = u.EntryDate,
                                 ModifiedDate = u.ModifiedDate,
                                 IsDeleted = u.IsDeleted
                             }).ToList();

                    foreach (ProjectUser _ProjectUser in a)
                    {
                        ProjectUser _Puser = new ProjectUser();
                        _Puser.ProjectAssignId = _ProjectUser.ProjectAssignId;
                        _Puser.ProjectId = _ProjectUser.ProjectId;
                        _Puser.CompanyId = _ProjectUser.CompanyId;
                        _Puser.UserId = _ProjectUser.UserId;
                        _Puser.UserName = _ProjectUser.UserName;
                        _Puser.WeeklyLimit = _ProjectUser.WeeklyLimit;
                        _Puser.Rate = _ProjectUser.Rate;
                        _Puser.EntryUser = _ProjectUser.EntryUser;
                        _Puser.ModifiedUser = _ProjectUser.ModifiedUser;
                        _Puser.EntryDate = _ProjectUser.EntryDate;
                        _Puser.ModifiedDate = _ProjectUser.ModifiedDate;
                        _Puser.IsDeleted = _ProjectUser.IsDeleted;
                        _Project.assign.Add(_Puser);
                    }
                    _projects.Add(_Project);
                }
            }
            return _projects;
        }

        public List<Project> ArchieveProjList(int compnayId)
        {

            List<Project> _projects = new List<Project>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var _pmaster = db.ProjectMasters.Where(x => x.CompanyId == compnayId && x.IsDeleted == true).ToList();
                foreach (ProjectMaster _ProjectMaster in _pmaster)
                {
                    Project _Project = new Project();
                    _Project.ProjectId = _ProjectMaster.ProjectId;
                    _Project.ProjectName = _ProjectMaster.ProjectName;
                    _Project.Remark = _ProjectMaster.Remark;
                    _Project.StartDate = _ProjectMaster.StartDate;
                    _Project.DeadLine = _ProjectMaster.DeadLine;
                    _Project.EstimationHour = _ProjectMaster.EstimationHour;

                    var a = (from u in db.ProjectAssigns.Where(z => z.ProjectId == _ProjectMaster.ProjectId && z.IsDeleted == true)
                             join f in db.UserMasters
                             on u.UserId equals f.UserId
                             select new ProjectUser
                             {
                                 ProjectAssignId = u.ProjectAssignId,
                                 ProjectId = u.ProjectId,
                                 CompanyId = u.CompanyId,
                                 UserId = u.UserId,
                                 UserName = f.FirstName + " " + f.LastName,
                                 WeeklyLimit = u.WeeklyLimit,
                                 Rate = u.Rate
                             }).ToList();

                    foreach (ProjectUser _ProjectUser in a)
                    {
                        ProjectUser _Puser = new ProjectUser();
                        _Puser.ProjectAssignId = _ProjectUser.ProjectAssignId;
                        _Puser.ProjectId = _ProjectUser.ProjectId;
                        _Puser.CompanyId = _ProjectUser.CompanyId;
                        _Puser.UserId = _ProjectUser.UserId;
                        _Puser.WeeklyLimit = _ProjectUser.WeeklyLimit;
                        _Puser.Rate = _ProjectUser.Rate;
                        _Puser.UserName = _ProjectUser.UserName;
                        _Project.assign.Add(_Puser);
                    }
                    _projects.Add(_Project);
                }
            }
            return _projects;
        }
     
        public class CustomGetProjectUsers
        {

            public Nullable<int> ProjectId { get; set; }
            public Nullable<int> CompanyId { get; set; }
            public int UserId { get; set; }
            public String FirstName { get; set; }
            public string LastName { get; set; }
        }

        //public List<CustomGetProjectUsers> GetProjectAssignedUsers(int companyId,int ProjectId)
        //{

        //    List<CustomGetProjectUsers> users = new List<CustomGetProjectUsers>();
        //    using (TrackerAppEntities db = new TrackerAppEntities())
        //    {
        //        try
        //        {
        //            var subselect = (from pAssign in db.ProjectAssigns where pAssign.ProjectId == ProjectId && pAssign.IsDeleted == false select pAssign.UserId).ToList();

        //            users = (from user in db.UserMasters
        //                     join company in db.CompanyMasters
        //                     on user.CompanyId equals company.CompanyId                             
        //                     where !subselect.Contains(user.UserId) && user.CompanyId == companyId && user.IsDeleted == false
        //                     select new CustomGetProjectUsers
        //                     {
        //                         CompanyId = user.CompanyId,
        //                         UserId = user.UserId,
        //                         FirstName = user.FirstName,
        //                         LastName = user.LastName,
        //                     }).ToList();
        //            return users;

        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}


    }

}


