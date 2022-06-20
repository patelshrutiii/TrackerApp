using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTracker_ProjectDLL.CustomClass
{
    public class LoginData
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
