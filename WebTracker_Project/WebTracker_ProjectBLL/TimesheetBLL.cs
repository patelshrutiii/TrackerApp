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
    public class TimesheetBLL
    {
        public List<DailySummary> GetProjectReport()
        {
            List<DailySummary> preport = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    preport = db.DailySummaries.ToList();
                }
                catch
                {
                    preport = null;
                }
            }
            return preport;
        }


        public List<DailySummary> GetProjectReportSP()
        {
            List<DailySummary> preport = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    preport = db.DailySummaries.ToList();
                }
                catch 
                {
                    preport = null;
                }
            }
            return preport;
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public DataTable ProjectReportSP(int companyId, int? projectId, DateTime Todate, DateTime fromdate)
        {
            TrackerAppEntities db = new TrackerAppEntities();
            if(projectId == null)
            {
                projectId = 0;
            }
            //var todate = Todate.Split('-');
            //var tdate = new DateTime(Convert.ToInt32(todate[0]), Convert.ToInt32(todate[1]), Convert.ToInt32(todate[2]));
            //var Fromdate  = fromdate.Split('-');
            //var fdate = new DateTime(Convert.ToInt32(Fromdate[0]), Convert.ToInt32(Fromdate[1]), Convert.ToInt32(Fromdate[2]));
            var cs = db.Database.Connection.ConnectionString;
            var conn = new System.Data.SqlClient.SqlConnection(cs);
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "dbo.ProjectReportSp";

            cmd.Parameters.Add(new SqlParameter("@Cid", companyId));
            cmd.Parameters.Add(new SqlParameter("@Pid", projectId));
            cmd.Parameters.Add(new SqlParameter("@Todate", Todate));
            cmd.Parameters.Add(new SqlParameter("@fromdate", fromdate));

            cmd.Connection.Open();
            var da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();

            da.Fill(Dt);
            return Dt;
        }

        public DataTable UserReportSP(int companyId, int? userId, int? designationId, int? departmentId, DateTime Todate, DateTime fromdate)
        {
            TrackerAppEntities db = new TrackerAppEntities();
            if (userId == null)
            {
                userId = 0;
            }
            if (designationId == null)
            {
                designationId = 0;
            }
            if (departmentId == null)
            {
                departmentId = 0;
            }
            var cs = db.Database.Connection.ConnectionString;
            var conn = new System.Data.SqlClient.SqlConnection(cs);
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "dbo.UserReportSp";

            cmd.Parameters.Add(new SqlParameter("@Cid", companyId));
            cmd.Parameters.Add(new SqlParameter("@Uid", userId));
            cmd.Parameters.Add(new SqlParameter("@designid", designationId));
            cmd.Parameters.Add(new SqlParameter("@deptid", departmentId));
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