using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_ProjectBLL
{
    public class TaskReportBLL
    {
        public List<TaskReportSp_Result> GetManageTaskList(int companyId, int? projectId, int? deptId, int? desId, string sdate, string edate)
        {
            List<TaskReportSp_Result> _TaskReport = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    if (projectId == null)
                    {
                        projectId = 0;
                    }
                    if (deptId == null)
                    {
                        deptId = 0;
                    }
                    if (desId == null)
                    {
                        desId = 0;
                    }
                    var sd = sdate.Split('-');
                    var sdate1 = new DateTime(Convert.ToInt32(sd[0]), Convert.ToInt32(sd[1]), Convert.ToInt32(sd[2]));
                    var ed = edate.Split('-');
                    var edate1 = new DateTime(Convert.ToInt32(ed[0]), Convert.ToInt32(ed[1]), Convert.ToInt32(ed[2]));
                    _TaskReport = db.TaskReportSp(companyId, projectId, deptId, desId, sdate1, edate1).ToList();
                    return _TaskReport;
                }
                catch 
                {
                    _TaskReport = null;
                }
                return _TaskReport;
            }
        }
    }
}
