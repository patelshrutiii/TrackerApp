using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_ProjectBLL
{
    public class RoleBLL
    {
        public List<Role> GetRoleList(int companyId)
        {
            List<Role> role = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    role = db.Roles.Where(x => x.CompanyId == companyId).ToList();
                }
                catch 
                {
                    role = null;
                }
            }
            return role;
        }

    }
}
