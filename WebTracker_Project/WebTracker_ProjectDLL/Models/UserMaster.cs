//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTracker_ProjectDLL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserMaster()
        {
            this.DailySummaries = new HashSet<DailySummary>();
            this.DailyTimeDetails = new HashSet<DailyTimeDetail>();
            this.ManualTimes = new HashSet<ManualTime>();
            this.ProjectAssigns = new HashSet<ProjectAssign>();
            this.ScreenShots = new HashSet<ScreenShot>();
            this.TaskAssigns = new HashSet<TaskAssign>();
        }
    
        public int UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Additionalinfo { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public string ResetPasswordCode { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> EntryUser { get; set; }
        public Nullable<int> ModifiedUser { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual CompanyMaster CompanyMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailySummary> DailySummaries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyTimeDetail> DailyTimeDetails { get; set; }
        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManualTime> ManualTimes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectAssign> ProjectAssigns { get; set; }
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScreenShot> ScreenShots { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskAssign> TaskAssigns { get; set; }
    }
}
