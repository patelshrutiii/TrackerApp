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
    public class TeamScreenshotBLL
    {
        public class _SSTime
        {
            public int time { get; set; }
            public int Hour { get; set; }

        }
        public List<TeamSS> GetSSByUser(int companyId, int userId, int? projectId, string sdate)
        {
            List<TeamSS> _ScreenShot = new List<TeamSS>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    if (projectId == null)
                    {
                        projectId = 0;
                    }
                    var ss = sdate.Split('-');
                    var d = new DateTime(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]), Convert.ToInt32(ss[2]));
                    var _TeamSS = (from s in db.ScreenShots.Where(x => x.CompanyId == companyId && x.IsDeleted == false && x.UserId == userId && x.ProjectId == (projectId != 0 ? projectId : x.ProjectId)
                                                       && DbFunctions.TruncateTime(x.ScreenShotTime) == d)
                                   join c in db.CompanyMasters on s.CompanyId equals c.CompanyId
                                   select new TeamSS
                                   {
                                       ScreenShotId = s.ScreenShotId,
                                       UserId = s.UserId,
                                       CompanyId = s.CompanyId,
                                       ProjectId = s.ProjectId,
                                       TaskId = s.TaskId,
                                       FileName = s.FileName,
                                       StartTime = s.StartTime,
                                       EndTime = s.EndTime,
                                       ScreenShotTime = s.ScreenShotTime,
                                       IsDeleted = s.IsDeleted,
                                       CompanyName = c.CompanyName,
                                       CompanyLastName = c.CompanyLastName
                                   }).ToList();
                    foreach (TeamSS t in _TeamSS)
                    {
                        TeamSS tlist = new TeamSS();
                        tlist.ScreenShotId = t.ScreenShotId;
                        tlist.UserId = t.UserId;
                        tlist.CompanyId = t.CompanyId;
                        tlist.ProjectId = t.ProjectId;
                        tlist.TaskId = t.TaskId;
                        tlist.FileName = t.FileName;
                        tlist.StartTime = t.StartTime;
                        tlist.EndTime = t.EndTime;
                        tlist.ScreenShotTime = t.ScreenShotTime;
                        tlist.IsDeleted = t.IsDeleted;
                        tlist.CompanyName = t.CompanyName;
                        tlist.CompanyLastName = t.CompanyLastName;
                        _ScreenShot.Add(tlist);
                    }
                    
                    return _ScreenShot;
                }
                catch
                {
                    _ScreenShot = null;
                }

            }
            return _ScreenShot;
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

        public List<UserMaster> GetTeamList(int companyId)
        {
            List<UserMaster> users = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    users = db.UserMasters.Where(x => x.CompanyId == companyId && x.IsDeleted == false).ToList();
                }
                catch 
                {
                    users = null;
                }
            }
            return users;
        }

        public List<TeamSSMaster> GetDailyTimeDetails(int companyId, int ssid)
        {
            List<TeamSSMaster> _ssmaster = new List<TeamSSMaster>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var _smaster = (from s in db.ScreenShots.Where(x => x.CompanyId == companyId && x.IsDeleted == false && x.ScreenShotId == ssid)
                                join p in db.ProjectMasters on s.ProjectId equals p.ProjectId
                                select new
                                {
                                    ScreenShotId = s.ScreenShotId,
                                    ProjectId = s.ProjectId,
                                    FileName = s.FileName,
                                    StartTime = s.StartTime,
                                    EndTime = s.EndTime,
                                    ProjectName = p.ProjectName
                                }).ToList();
                foreach (var _screenshot in _smaster)
                {
                    TeamSSMaster _ss = new TeamSSMaster();
                    _ss.ScreenShotId = _screenshot.ScreenShotId;
                    _ss.ProjectId = _screenshot.ProjectId;
                    _ss.FileName = _screenshot.FileName;
                    _ss.StartTime = _screenshot.StartTime;
                    _ss.EndTime = _screenshot.EndTime;
                    _ss.ProjectName = _screenshot.ProjectName;


                    var d = (from dt in db.DailyTimeDetails.Where(x => x.StartTime >= _ss.StartTime && x.StartTime <= _ss.EndTime)
                             join p in db.ProjectMasters on dt.ProjectId equals p.ProjectId
                             join t in db.TaskMasters on dt.TaskId equals t.TaskId
                             select new TeamSSList
                             {
                                 DailyTimeId = dt.DailyTimeId,
                                 UserId = dt.UserId,
                                 CompanyId = dt.CompanyId,
                                 ProjectId = dt.ProjectId,
                                 TaskId = dt.TaskId,
                                 KeyHit = dt.KeyHit,
                                 MouseHit = dt.MouseHit,
                                 AppName = dt.AppName,
                                 StartTime = dt.StartTime,
                                 ProjectName = p.ProjectName,
                                 TaskName = t.TaskName
                             }).ToList();

                    foreach (TeamSSList _sslist in d)
                    {
                        TeamSSList _slist = new TeamSSList();
                        _slist.DailyTimeId = _sslist.DailyTimeId;
                        _slist.UserId = _sslist.UserId;
                        _slist.CompanyId = _sslist.CompanyId;
                        _slist.ProjectId = _sslist.ProjectId;
                        _slist.TaskId = _sslist.TaskId;
                        _slist.KeyHit = _sslist.KeyHit;
                        _slist.MouseHit = _sslist.MouseHit;
                        _slist.AppName = _sslist.AppName;
                        _slist.StartTime = _sslist.StartTime;
                        _slist.ProjectName = _sslist.ProjectName;
                        _slist.TaskName = _sslist.TaskName;
                        _ss.assign.Add(_slist);
                    }
                    _ssmaster.Add(_ss);
                }
            }
            return _ssmaster;
        }

    }
}
