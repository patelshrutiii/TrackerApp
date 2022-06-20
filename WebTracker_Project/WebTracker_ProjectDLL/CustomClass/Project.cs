using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.Models;


namespace WebTracker_ProjectDLL.CustomClass
{
    public class Project
    {
        public Project()
        {
            this.assign = new List<ProjectUser>();
        }

        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string ProjectName { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> DeadLine { get; set; }
        public Nullable<int> EstimationHour { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> EntryUser { get; set; }
        public Nullable<int> ModifiedUser { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public List<ProjectUser> assign { get; set; }
    }

    public class ProjectUser
    {
        public int ProjectAssignId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> WeeklyLimit { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<int> EntryUser { get; set; }
        public Nullable<int> ModifiedUser { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string UserName { get; set; }
    }    


}
