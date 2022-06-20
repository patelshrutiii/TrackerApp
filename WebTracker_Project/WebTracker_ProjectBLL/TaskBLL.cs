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
    public class TaskBLL
    {
        public TaskMaster Create(TaskMaster _TaskMaster, int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    _TaskMaster.CompanyId = companyId;
                    _TaskMaster.PriorityId = 202;
                    _TaskMaster.StatusId = 2001;
                    _TaskMaster.StartDate = DateTime.Now;
                    _TaskMaster.IsActive = true;
                    _TaskMaster.EntryUser = companyId;
                    _TaskMaster.EntryDate = DateTime.Now;
                    _TaskMaster.IsDeleted = false;

                    var Dubtask = (from Task in db.TaskMasters where Task.CompanyId == companyId && Task.IsDeleted == false && Task.ProjectId == _TaskMaster.ProjectId && Task.TaskName.Equals(_TaskMaster.TaskName) select Task.TaskId).ToList();
                    if (Dubtask.Count > 0)
                    {
                        throw new Exception("TaskName is already exist");
                    }
                    else
                    {
                        db.TaskMasters.Add(_TaskMaster);
                        db.SaveChanges();
                        return _TaskMaster;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public TaskAssign TaskAssignToAll(TaskAssign _TaskAssign)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {

                var TaskAssignees = GetTaskAssignedUsers(_TaskAssign.CompanyId, _TaskAssign.ProjectId, _TaskAssign.TaskId);
                foreach (CustomGetTaskUsers _TaskAssignees in TaskAssignees)
                {
                    TaskAssign user = new TaskAssign();
                    user.CompanyId = (int)_TaskAssignees.CompanyId;
                    user.ProjectId = (int)_TaskAssignees.ProjectId;
                    user.TaskId = _TaskAssign.TaskId;
                    user.UserId = _TaskAssignees.UserId;
                    user.EntryUser = (int)_TaskAssignees.CompanyId;
                    user.ModifiedUser = (int)_TaskAssignees.CompanyId;
                    user.EntryDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.IsDeleted = false;
                    db.TaskAssigns.Add(user);
                    db.SaveChanges();
                }
                return _TaskAssign;
            }
        }
        public TaskAssign TaskAssignUser(TaskAssign _TaskAssign)
        {

            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                _TaskAssign.EntryUser = _TaskAssign.CompanyId;
                _TaskAssign.ModifiedUser = _TaskAssign.ModifiedUser;
                _TaskAssign.EntryDate = DateTime.Now;
                _TaskAssign.ModifiedDate = DateTime.Now;
                _TaskAssign.IsDeleted = false;
                db.TaskAssigns.Add(_TaskAssign);
                db.SaveChanges();
                return _TaskAssign;
            }
        }
        public TaskMaster Update(TaskMaster _TaskMaster,int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                _TaskMaster.ModifiedUser = companyId;
                _TaskMaster.ModifiedDate = DateTime.Now;
                _TaskMaster.CompanyId = companyId;
                _TaskMaster.IsDeleted = false;
                if (_TaskMaster.StatusId == 2003)
                {
                    _TaskMaster.PriorityId = 203;
                }
                db.TaskMasters.Attach(_TaskMaster);
                db.Entry(_TaskMaster).State = EntityState.Modified;
                db.SaveChanges();
                return _TaskMaster;
            }
        }
        public List<TaskMaster> GetTaskByProject(int companyId, int ProjectId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<TaskMaster> tasks = null;
                tasks = db.TaskMasters.Where(x => x.CompanyId == companyId && x.ProjectId == ProjectId && x.IsDeleted==false).ToList();
                try
                {
                    if (tasks != null)
                        return tasks;
                    else
                        return null;
                }
                catch 
                {
                    return null;
                }
            }
        }
        public List<ProjectMaster> GetProjectname(int companyId, int ProjectId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<ProjectMaster> project = (from pro in db.ProjectMasters where pro.CompanyId == companyId && pro.ProjectId == ProjectId select pro).ToList();

                try
                {
                    if (project != null)
                        return project;
                    else
                        return null;
                }
                catch 
                {
                    return null;
                }
            }
        }

        public void DeleteAllTask(int companyId, int Pid)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<TaskAssign> Tassign = db.TaskAssigns.Where(x => x.CompanyId == companyId && x.ProjectId == Pid).ToList();
                if (Tassign != null)
                {
                    foreach (TaskAssign p in Tassign)
                    {
                        p.IsDeleted = true;
                        db.TaskAssigns.Attach(p);
                        db.Entry(p).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                List<TaskMaster> task = db.TaskMasters.Where(x => x.CompanyId == companyId && x.ProjectId == Pid).ToList();

                if (task != null)
                {
                    try
                    {
                        foreach (TaskMaster t in task)
                        {
                            t.IsDeleted = true;
                            db.TaskMasters.Attach(t);
                            db.Entry(t).State = EntityState.Modified;
                            db.SaveChanges();
                        }                        
                    }
                    catch (Exception e)
                    {
                        string r = e.Message;
                    }

                }
            }
        }

        public void DeleteCompletedTask(int companyId, int Pid)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var subtask = (from Task in db.TaskMasters where Task.CompanyId == companyId && Task.ProjectId == Pid && Task.StatusId == 2003 select Task).ToList();
                if (subtask != null)
                {
                    foreach (TaskMaster t in subtask)
                    {
                        var taskusers = (from TAssign in db.TaskAssigns where TAssign.TaskId == t.TaskId select TAssign).ToList();
                        if (taskusers != null)
                        {
                            foreach (TaskAssign _TaskAssign in taskusers)
                            {
                                _TaskAssign.IsDeleted = true;
                                db.TaskAssigns.Attach(_TaskAssign);
                                db.Entry(_TaskAssign).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                }

                List<TaskMaster> task = db.TaskMasters.Where(x => x.CompanyId == companyId && x.ProjectId == Pid && x.StatusId == 2003).ToList();

                if (task != null)
                {
                    try
                    {
                        foreach (TaskMaster t in task)
                        {
                            t.IsDeleted = true;
                            db.TaskMasters.Attach(t);
                            db.Entry(t).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        string r = e.Message;
                    }

                }
            }
        }
        public void Delete(int companyId, int ProjectId, int TaskId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {                
                List<TaskAssign> subuser = (from TaskUsers in db.TaskAssigns where TaskUsers.CompanyId == companyId && TaskUsers.ProjectId == ProjectId && TaskUsers.TaskId == TaskId select TaskUsers).ToList();

                if (subuser != null)
                {
                    foreach (TaskAssign _TaskAssign in subuser)
                    {
                        _TaskAssign.IsDeleted = true;
                        db.TaskAssigns.Attach(_TaskAssign);
                        db.Entry(_TaskAssign).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                TaskMaster task = db.TaskMasters.Where(x => x.CompanyId == companyId && x.ProjectId == ProjectId && x.TaskId == TaskId).FirstOrDefault();
                if (task != null)
                {
                    task.IsDeleted = true;
                    task.PriorityId = 203;
                    db.TaskMasters.Attach(task);
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public void DeleteUser(int AssignId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                TaskAssign Assign = db.TaskAssigns.Where(x => x.TaskAssignId == AssignId).FirstOrDefault();
                if (Assign != null)
                {
                    Assign.IsDeleted = true;
                    db.TaskAssigns.Attach(Assign);
                    db.Entry(Assign).State = EntityState.Modified;
                    db.SaveChanges();                    
                }
            }
        }
        public List<PriorityMaster> GetPriorityList()
        {
            List<PriorityMaster> priorities = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    priorities = db.PriorityMasters.ToList();
                }
                catch 
                {
                    priorities = null;
                }
            }
            return priorities;
        }
        public List<StatusMaster> GetStatusList()
        {
            List<StatusMaster> statuses = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    statuses = db.StatusMasters.ToList();
                }
                catch 
                {
                    statuses = null;
                }
            }
            return statuses;
        }

        public List<CustomTask> GetTaskList(int companyId, int ProjectId)
        {
            List<CustomTask> task = new List<CustomTask>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var _task = (from ta in db.TaskMasters
                             join pro in db.ProjectMasters on ta.ProjectId equals pro.ProjectId
                             join prio in db.PriorityMasters on ta.PriorityId equals prio.PriorityId
                             join sta in db.StatusMasters on ta.StatusId equals sta.StatusId
                             join Com in db.CompanyMasters on ta.CompanyId equals Com.CompanyId
                             where ta.CompanyId == companyId && ta.ProjectId == ProjectId 
                             orderby prio.PriorityId
                             select new CustomTask
                             {
                                 TaskId = ta.TaskId,
                                 ProjectId = ta.ProjectId,
                                 PriorityId = prio.PriorityId,
                                 StatusId = sta.StatusId,
                                 CompanyId = ta.CompanyId,
                                 StartDate = ta.StartDate,
                                 Deadline = ta.Deadline,
                                 IsActive = ta.IsActive,
                                 TaskName = ta.TaskName,
                                 TaskNotes = ta.TaskNotes,
                                 EntryUser = ta.EntryUser,
                                 ModifiedUser = ta.ModifiedUser,
                                 EntryDate = ta.EntryDate,
                                 ModifiedDate = ta.ModifiedDate,
                                 IsDeleted = ta.IsDeleted,
                                 ProjectName = pro.ProjectName,
                                 PriorityName = prio.PriorityName,
                                 StatusName = sta.StatusName,
                             }).ToList();

                foreach (CustomTask _Task in _task)
                {
                    CustomTask _customTask = new CustomTask();
                    _customTask = _Task;
                    var TaskAssignees = (from tAssign in db.TaskAssigns
                                         join user in db.UserMasters
                                        on tAssign.UserId equals user.UserId
                                         where tAssign.CompanyId == companyId && tAssign.ProjectId == ProjectId && tAssign.TaskId == _Task.TaskId && tAssign.IsDeleted == false
                                         select new CustomTaskAssignees
                                         {

                                             TaskAssignId = tAssign.TaskAssignId,
                                             TaskId = tAssign.TaskId,
                                             ProjectId = tAssign.ProjectId,
                                             CompanyId = tAssign.CompanyId,
                                             UserId = tAssign.UserId,
                                             EntryUser = tAssign.EntryUser,
                                             ModifiedUser = tAssign.ModifiedUser,
                                             EntryDate = tAssign.EntryDate,
                                             ModifiedDate = tAssign.ModifiedDate,
                                             IsDeleted = tAssign.IsDeleted,
                                             FirstName = user.FirstName,
                                             LastName = user.LastName,

                                         }).ToList();
                    foreach (CustomTaskAssignees _TaskAssignees in TaskAssignees)
                    {
                        _customTask.userassign.Add(_TaskAssignees);

                    }
                    task.Add(_customTask);
                }
            }
            return task;
        }

        public List<CustomTask> GetActiveTask(int companyId, int ProjectId)
        {
            List<CustomTask> Auser = new List<CustomTask>();
            var ActiveTask = GetTaskList(companyId, ProjectId);
            foreach (CustomTask _ActiveTask in ActiveTask)
            {
                CustomTask _customTask = new CustomTask();
                if (_ActiveTask.StatusId == 2002)
                {
                    Auser.Add(_ActiveTask);
                }
                else
                {

                }

            }
            return Auser;
        }

        public List<CustomTask> GetCompletedList(int companyId, int ProjectId)
        {
            List<CustomTask> Cuser = new List<CustomTask>();
            var CompletedTask = GetTaskList(companyId, ProjectId);
            foreach (CustomTask _CompletedTask in CompletedTask)
            {
                CustomTask _customTask = new CustomTask();
                if (_CompletedTask.StatusId == 2003)
                {
                    Cuser.Add(_CompletedTask);
                }
                else
                {
                    
                }
            }
            return Cuser;
        }
        public List<CustomTask> refreshedit(int companyId, int ProjectId, int TaskId)
        {
            List<CustomTask> Euser = new List<CustomTask>();
            var TaskEditDetails = GetTaskList(companyId, ProjectId);
            foreach (CustomTask _TaskEditDetails in TaskEditDetails)
            {
                CustomTask _customTask = new CustomTask();
                if (_TaskEditDetails.TaskId == TaskId)
                {
                    Euser.Add(_TaskEditDetails);
                }
                else
                {
                    
                }
            }
            return Euser;
        }
       
        public List<CustomGetTaskUsers> GetTaskAssignedUsers(int companyId, int selectedProjectId, int TaskId)
        {

            List<CustomGetTaskUsers> users = new List<CustomGetTaskUsers>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    var subselect = (from TAssign in db.TaskAssigns where TAssign.TaskId == TaskId && TAssign.IsDeleted == false select TAssign.UserId).ToList();

                    users = (from user in db.UserMasters
                             join company in db.CompanyMasters
                             on user.CompanyId equals company.CompanyId
                             join pAssign in db.ProjectAssigns
                             on user.UserId equals pAssign.UserId
                             where !subselect.Contains(user.UserId) && pAssign.ProjectId == selectedProjectId && pAssign.CompanyId == companyId && pAssign.IsDeleted == false
                             select new CustomGetTaskUsers
                             {
                                 ProjectId = pAssign.ProjectId,
                                 CompanyId = user.CompanyId,
                                 UserId = user.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,

                             }).ToList();
                    return users;

                }
                catch 
                {
                    return null;
                }
            }
        }

        public bool UpdateStatus(int TaskId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    var query = "UPDATE TaskMaster SET IsDeleted = 0 , PriorityId = 202 WHERE TaskId = " + TaskId;

                    db.Database.ExecuteSqlCommand(query);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
