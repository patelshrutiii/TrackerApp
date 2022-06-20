using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTracker_ProjectDLL.CustomClass
{
    public class CustomGetTaskUsers
    {
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
    }
}
