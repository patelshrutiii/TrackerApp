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
    
    public partial class AttendenceSp_Result
    {
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> UserId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public string UserName { get; set; }
        public string TotalTime { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> StopTime { get; set; }
    }
}