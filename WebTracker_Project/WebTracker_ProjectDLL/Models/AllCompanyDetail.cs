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
    
    public partial class AllCompanyDetail
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLastName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPassword { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string StreetAddress { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public Nullable<int> Extension { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}
