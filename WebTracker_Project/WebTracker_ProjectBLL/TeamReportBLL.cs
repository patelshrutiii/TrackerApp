using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_ProjectBLL
{
    public class TeamReportBLL
    {
        public List<UserMaster> GetTeamList(int companyId)
        {
            List<UserMaster> users = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    users = db.UserMasters.Where(x => x.CompanyId == companyId && x.IsDeleted == false).ToList();
                }
                catch 
                {
                    users = null;
                }
            }
            return users;
        }
        public DataTable TeamReportSP(int companyId, int userId, DateTime Todate, DateTime fromdate)
        {
            TrackerAppEntities db = new TrackerAppEntities();
            var cs = db.Database.Connection.ConnectionString;
            var conn = new System.Data.SqlClient.SqlConnection(cs);
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "dbo.TeamReportSp";

            cmd.Parameters.Add(new SqlParameter("@Cid", companyId));
            cmd.Parameters.Add(new SqlParameter("@Uid", userId));
            cmd.Parameters.Add(new SqlParameter("@Todate", Todate));
            cmd.Parameters.Add(new SqlParameter("@fromdate", fromdate));

            cmd.Connection.Open();
            var da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();

            da.Fill(Dt);
            return Dt;
        }
    }
}
