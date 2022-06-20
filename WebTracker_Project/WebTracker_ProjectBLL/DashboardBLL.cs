using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_ProjectBLL
{
    public class DashboardBLL
    {
        public Hashtable TaskProgress(int companyId)
        {
            Hashtable ht = new Hashtable();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    var totalTask = (from task in db.TaskMasters.Where(z => z.CompanyId == companyId && z.IsDeleted == false)
                                     join c in db.CompanyMasters on task.CompanyId equals c.CompanyId
                                     select task).Count();
                    var totalTodo = (from task in db.TaskMasters.Where(z => z.CompanyId == companyId && z.IsDeleted == false && z.StatusId == 2001)
                                     join c in db.CompanyMasters on task.CompanyId equals c.CompanyId                                     
                                     select task).Count();
                    var totalDoing = (from task in db.TaskMasters.Where(z => z.CompanyId == companyId && z.IsDeleted == false && z.StatusId == 2002)
                                      join c in db.CompanyMasters on task.CompanyId equals c.CompanyId
                                      select task).Count();
                    var totalDone = (from task in db.TaskMasters.Where(z => z.CompanyId == companyId && z.IsDeleted == false && z.StatusId == 2003)
                                     join c in db.CompanyMasters on task.CompanyId equals c.CompanyId                                 
                                     select task).Count();
                 
                    ht["TotalTask"] = totalTask;
                    ht["TotalToDo"] = totalTodo;
                    ht["TotalDoing"] = totalDoing;
                    ht["TotalDone"] = totalDone;
                    ht["ProgressTodo"] = totalTodo * 100 / totalTask;
                    ht["ProgressDoing"] = totalDoing * 100 / totalTask;
                    ht["ProgressDone"] = totalDone * 100 / totalTask;
                    return ht;
                }
                catch
                {
                    ht = null;
                }
                return ht;
            }
        }

        public List<AllUserDetailSp_Result> GetAllUsers(int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<AllUserDetailSp_Result> _UserDetail = null;
                try
                {
                    _UserDetail = db.AllUserDetailSp(companyId).ToList();
                    return _UserDetail;
                }
                catch 
                {
                    _UserDetail = null;
                }
                return _UserDetail;
            }
        }

        public List<AllProjectDetailsSp_Result> GetAllProjects(int companyId)
        {            
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<AllProjectDetailsSp_Result> _ProjectDetail = null;
                try
                {
                    _ProjectDetail = db.AllProjectDetailsSp(companyId).ToList();
                }
                catch 
                {
                    _ProjectDetail = null;
                }
                return _ProjectDetail;
            }
        }

        public List<AllTaskDetailsSp_Result> GetAllTasks(int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<AllTaskDetailsSp_Result> _TaskDetail = null;
                try
                {
                    _TaskDetail = db.AllTaskDetailsSp(companyId).ToList();
                }
                catch 
                {
                    _TaskDetail = null;
                }
                return _TaskDetail;
            }
        }

        public List<AllRoleDetailsSp_Result> GetAllRoles(int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<AllRoleDetailsSp_Result> _RoleDetail = null;
                try
                {
                    _RoleDetail = db.AllRoleDetailsSp(companyId).ToList();
                }
                catch
                {
                    _RoleDetail = null;
                }
                return _RoleDetail;
            }
        }

        public List<AllDepartmentDetailsSp_Result> GetAllDepartments(int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<AllDepartmentDetailsSp_Result> _DepartmentDetail = null;
                try
                {
                    _DepartmentDetail = db.AllDepartmentDetailsSp(companyId).ToList();
                }
                catch
                {
                    _DepartmentDetail = null;
                }
                return _DepartmentDetail;
            }
        }

        public List<AllDesignationDetailsSp_Result> GetAllDesignations(int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<AllDesignationDetailsSp_Result> _DesignationDetail = null;
                try
                {
                    _DesignationDetail = db.AllDesignationDetailsSp(companyId).ToList();
                }
                catch
                {
                    _DesignationDetail = null;
                }
                return _DesignationDetail;
            }
        }

        public Hashtable GetTotalDailyTime(int companyId)
        {
            Hashtable ht = new Hashtable();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    ht["TotalDaily"] = db.GetTotalDailyTimeSp(companyId).FirstOrDefault();
                    return ht;
                }
                catch 
                {
                    ht = null;
                }
                return ht;
            }
        }

        public Hashtable GetTotalWeeklyTime(int companyId)
        {
            Hashtable ht = new Hashtable();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {                    
                   ht["TotalWeekly"] = db.GetTotalWeeklyTimeSp(companyId).FirstOrDefault();
                }
                catch(Exception e)
                {
                    ht = null;
                }
                return ht;
            }
        }

       
    }
}