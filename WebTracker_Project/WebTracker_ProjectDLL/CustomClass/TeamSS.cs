using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTracker_ProjectDLL.CustomClass
{
    public class TeamSS
    {
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
        public string CompanyName { get; set; }
        public string CompanyLastName { get; set; }

    }
}
