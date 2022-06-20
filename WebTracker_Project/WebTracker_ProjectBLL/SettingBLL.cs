using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.CustomClass;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_ProjectBLL
{
    public class SettingBLL
    {       
        public List<CustomGetAccountInfo> GetAccountInfo(int companyId,string cname)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                var comname = cname.Split(' ');
                string company = comname[0];
                var role = (from user in db.UserMasters.Where(x => x.CompanyId == companyId && x.FirstName.Equals(company))
                         join Role in db.Roles on user.RoleId equals Role.RoleId
                         join com in db.CompanyMasters on user.CompanyId equals com.CompanyId

                         select new CustomGetAccountInfo
                         {
                             CompanyName = com.CompanyName,
                             CompanyLastName = com.CompanyLastName,
                             RoleName = Role.RoleName,

                         }
                     ).ToList();
                try
                {
                    if (role != null)
                        return role;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }
    }
}
