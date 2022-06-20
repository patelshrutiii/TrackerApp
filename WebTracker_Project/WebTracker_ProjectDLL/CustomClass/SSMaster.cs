using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTracker_ProjectDLL.CustomClass
{
    public class SSMaster
    {
        public SSMaster()
        {
            this.assign = new List<SSList>();
        }
        public int ScreenShotId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> TaskId { get; set; }
        public string FileName { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<System.DateTime> ScreenShotTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string ProjectName { get; set; }
        public List<SSList> assign { get; set; }

    }

    public class SSList
    {
        public int DailyTimeId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> TaskId { get; set; }
        public Nullable<int> KeyHit { get; set; }
        public Nullable<int> MouseHit { get; set; }
        public string AppName { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }

    }
}
