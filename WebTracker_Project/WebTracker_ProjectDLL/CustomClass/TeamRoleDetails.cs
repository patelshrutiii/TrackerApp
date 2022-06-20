using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTracker_ProjectDLL.CustomClass
{
    public class TeamRoleDetails
    {
        public int UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> DesignationId { get; set; }
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
        public Nullable<int> RoleId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> EntryUser { get; set; }
        public Nullable<int> ModifiedUser { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public String RoleName { get; set; }

    }
}
