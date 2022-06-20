using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTracker_ProjectDLL.CustomClass
{
    public class CustomTask
    {
        public CustomTask()
        {
            this.userassign = new List<CustomTaskAssignees>();
        }
        public int TaskId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> PriorityId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> Deadline { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string TaskName { get; set; }
        public string TaskNotes { get; set; }
        public Nullable<int> EntryUser { get; set; }
        public Nullable<int> ModifiedUser { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string ProjectName { get; set; }
        public string PriorityName { get; set; }
        public string StatusName { get; set; }
        public List<CustomTaskAssignees> userassign { get; set; }
    }
    public class CustomTaskAssignees
    {
        public int TaskAssignId { get; set; }
        public Nullable<int> TaskId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }       
        public Nullable<int> EntryUser { get; set; }
        public Nullable<int> ModifiedUser { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

}
