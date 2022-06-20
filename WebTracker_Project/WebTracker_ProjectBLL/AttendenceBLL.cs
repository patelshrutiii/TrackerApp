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
using System.Data;
using System.Data.SqlClient;

namespace WebTracker_ProjectBLL
{
    public class AttendenceBLL
    {
        public List<AttendenceSp_Result> GetAttendence(int companyId, int? userId, int? deptId, int? desId, string sdate)
        {
            List<AttendenceSp_Result> _AttendenceDetail = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    if(userId == null)
                    {
                        userId = 0;
                    }
                    if (deptId == null)
                    {
                        deptId = 0;
                    }
                    if (desId == null)
                    {
                        desId = 0;
                    }
                    var ss = sdate.Split('-');
                    var d = new DateTime(Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]), Convert.ToInt32(ss[2]));
                    _AttendenceDetail = db.AttendenceSp(companyId,userId,deptId,desId,d).ToList();
                    return _AttendenceDetail;
                }
                catch
                {
                    _AttendenceDetail = null;
                }
                return _AttendenceDetail;
            }           
        }
    }
}
