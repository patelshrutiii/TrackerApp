using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.Models;
using System.Globalization;
using WebTracker_ProjectDLL.CustomClass;

namespace WebTracker_ProjectBLL
{
    public class ScreenshotBLL
    {
        public void Delete(string[] itemList)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<int> SSIds = itemList.Select(x => Int32.Parse(x)).ToList();
                for (var i = 0; i < SSIds.Count(); i++)
                {
                    var ss = db.ScreenShots.Find(SSIds[i]);
                    ss.IsDeleted = true;
                    db.ScreenShots.Attach(ss);
                    db.Entry(ss).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public void Restore(string[] itemList)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<int> SSIds = itemList.Select(x => Int32.Parse(x)).ToList();
                for (var i = 0; i < SSIds.Count(); i++)
                {
                    var ss = db.ScreenShots.Find(SSIds[i]);
                    ss.IsDeleted = false;
                    db.ScreenShots.Attach(ss);
                    db.Entry(ss).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public void Trash(string[] itemList)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                List<int> SSIds = itemList.Select(x => Int32.Parse(x)).ToList();
                for (var i = 0; i < SSIds.Count(); i++)
                {
                    var ss = db.ScreenShots.Find(SSIds[i]);
                    db.ScreenShots.Remove(ss);
                    db.SaveChanges();
                }
            }
        }

        public class _SSTime
        {
            public int time { get; set; }
            public int Hour { get; set; }

        }

        public List<ScreenShot> GetSSByUser(int companyId, int userId, int? projectId, string sdate)
        {
            List<ScreenShot> _ScreenShot = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    if(projectId == null)
                    {
                        projectId = 0;
                    }
                    var ss = sdate.Split('-');
                    var d = new DateTime(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]), Convert.ToInt32(ss[2]));
                    _ScreenShot = db.ScreenShots.Where(x => x.CompanyId == companyId && x.IsDeleted == false && x.UserId == userId && x.ProjectId == (projectId != 0 ? projectId : x.ProjectId)
                                                       && DbFunctions.TruncateTime(x.ScreenShotTime) == d).ToList();
                    return _ScreenShot;
                }
                catch
                {
                    _ScreenShot = null;
                }

            }
            return _ScreenShot;
        }

        public List<ScreenShot> GetArchieveSSByUser(int companyId, int userId, int projectId, string sdate)
        {
            List<ScreenShot> _ScreenShot = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    var ss = sdate.Split('-');
                    var d = new DateTime(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]), Convert.ToInt32(ss[2]));
                    _ScreenShot = db.ScreenShots.Where(x => x.CompanyId == companyId && x.IsDeleted == true && x.UserId == userId && x.ProjectId == (projectId != 0 ? projectId : x.ProjectId)
                                                       && DbFunctions.TruncateTime(x.ScreenShotTime) == d).ToList();
                    return _ScreenShot;
                }
                catch
                {
                    _ScreenShot = null;
                }

            }
            return _ScreenShot;
        }
     
        public List<SSMaster> GetDailyTimeDetails(int companyId, int ssid)
        {

            List<SSMaster> _ssmaster = new List<SSMaster>();
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                
                var _smaster = (from s in db.ScreenShots.Where(x => x.CompanyId == companyId && x.ScreenShotId == ssid)
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
                    SSMaster _ss = new SSMaster();
                    _ss.ScreenShotId = _screenshot.ScreenShotId;
                    _ss.ProjectId = _screenshot.ProjectId;
                    _ss.FileName = _screenshot.FileName;
                    _ss.StartTime = _screenshot.StartTime;
                    _ss.EndTime = _screenshot.EndTime;
                    _ss.ProjectName = _screenshot.ProjectName;


                    var d = (from dt in db.DailyTimeDetails.Where(x => x.StartTime >= _ss.StartTime && x.StartTime <= _ss.EndTime)
                             join p in db.ProjectMasters on dt.ProjectId equals p.ProjectId
                             join t in db.TaskMasters on dt.TaskId equals t.TaskId
                             select new SSList
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

                    foreach (SSList _sslist in d)
                    {
                        SSList _slist = new SSList();
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
