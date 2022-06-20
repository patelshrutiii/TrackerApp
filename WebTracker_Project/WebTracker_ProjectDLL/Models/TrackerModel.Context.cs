﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TrackerAppEntities : DbContext
    {
        public TrackerAppEntities()
            : base("name=TrackerAppEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CityMaster> CityMasters { get; set; }
        public virtual DbSet<CompanyMaster> CompanyMasters { get; set; }
        public virtual DbSet<DailySummary> DailySummaries { get; set; }
        public virtual DbSet<DailyTimeDetail> DailyTimeDetails { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<ManualTime> ManualTimes { get; set; }
        public virtual DbSet<PriorityMaster> PriorityMasters { get; set; }
        public virtual DbSet<ProjectAssign> ProjectAssigns { get; set; }
        public virtual DbSet<ProjectMaster> ProjectMasters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ScreenShot> ScreenShots { get; set; }
        public virtual DbSet<StateMaster> StateMasters { get; set; }
        public virtual DbSet<StatusMaster> StatusMasters { get; set; }
        public virtual DbSet<TaskAssign> TaskAssigns { get; set; }
        public virtual DbSet<TaskMaster> TaskMasters { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<AllCompanyDetail> AllCompanyDetails { get; set; }
        public virtual DbSet<AllDeptDetail> AllDeptDetails { get; set; }
        public virtual DbSet<AllDesDetail> AllDesDetails { get; set; }
        public virtual DbSet<AllRoleDetail> AllRoleDetails { get; set; }
        public virtual DbSet<AttendenceDetail> AttendenceDetails { get; set; }
    
        public virtual ObjectResult<AllCompanyDetailsSp_Result> AllCompanyDetailsSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AllCompanyDetailsSp_Result>("AllCompanyDetailsSp", cidParameter);
        }
    
        public virtual ObjectResult<AllDepartmentDetailsSp_Result> AllDepartmentDetailsSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AllDepartmentDetailsSp_Result>("AllDepartmentDetailsSp", cidParameter);
        }
    
        public virtual ObjectResult<AllDesignationDetailsSp_Result> AllDesignationDetailsSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AllDesignationDetailsSp_Result>("AllDesignationDetailsSp", cidParameter);
        }
    
        public virtual ObjectResult<AllProjectDetailsSp_Result> AllProjectDetailsSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AllProjectDetailsSp_Result>("AllProjectDetailsSp", cidParameter);
        }
    
        public virtual ObjectResult<AllRoleDetailsSp_Result> AllRoleDetailsSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AllRoleDetailsSp_Result>("AllRoleDetailsSp", cidParameter);
        }
    
        public virtual ObjectResult<AllTaskDetailsSp_Result> AllTaskDetailsSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AllTaskDetailsSp_Result>("AllTaskDetailsSp", cidParameter);
        }
    
        public virtual ObjectResult<AllUserDetailSp_Result> AllUserDetailSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AllUserDetailSp_Result>("AllUserDetailSp", cidParameter);
        }
    
        public virtual ObjectResult<AttendenceSp_Result> AttendenceSp(Nullable<int> cid, Nullable<int> uid, Nullable<int> did, Nullable<int> desid, Nullable<System.DateTime> sdate)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var didParameter = did.HasValue ?
                new ObjectParameter("did", did) :
                new ObjectParameter("did", typeof(int));
    
            var desidParameter = desid.HasValue ?
                new ObjectParameter("desid", desid) :
                new ObjectParameter("desid", typeof(int));
    
            var sdateParameter = sdate.HasValue ?
                new ObjectParameter("sdate", sdate) :
                new ObjectParameter("sdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AttendenceSp_Result>("AttendenceSp", cidParameter, uidParameter, didParameter, desidParameter, sdateParameter);
        }
    
        public virtual int DailySummaryInsertSP(Nullable<int> sid, Nullable<System.DateTime> stime, Nullable<System.DateTime> etime, Nullable<System.DateTime> ddiff, Nullable<System.DateTime> tdiff, Nullable<int> sec, Nullable<int> pid, Nullable<int> tid, Nullable<int> uid, Nullable<int> cid, ObjectParameter flag)
        {
            var sidParameter = sid.HasValue ?
                new ObjectParameter("sid", sid) :
                new ObjectParameter("sid", typeof(int));
    
            var stimeParameter = stime.HasValue ?
                new ObjectParameter("stime", stime) :
                new ObjectParameter("stime", typeof(System.DateTime));
    
            var etimeParameter = etime.HasValue ?
                new ObjectParameter("etime", etime) :
                new ObjectParameter("etime", typeof(System.DateTime));
    
            var ddiffParameter = ddiff.HasValue ?
                new ObjectParameter("ddiff", ddiff) :
                new ObjectParameter("ddiff", typeof(System.DateTime));
    
            var tdiffParameter = tdiff.HasValue ?
                new ObjectParameter("tdiff", tdiff) :
                new ObjectParameter("tdiff", typeof(System.DateTime));
    
            var secParameter = sec.HasValue ?
                new ObjectParameter("sec", sec) :
                new ObjectParameter("sec", typeof(int));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var tidParameter = tid.HasValue ?
                new ObjectParameter("tid", tid) :
                new ObjectParameter("tid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DailySummaryInsertSP", sidParameter, stimeParameter, etimeParameter, ddiffParameter, tdiffParameter, secParameter, pidParameter, tidParameter, uidParameter, cidParameter, flag);
        }
    
        public virtual int DailyTimeInsertSP(Nullable<int> did, Nullable<int> uid, Nullable<int> key, Nullable<int> mouse, string app, Nullable<System.DateTime> stime, Nullable<int> projid, Nullable<int> tid, Nullable<int> cid, ObjectParameter flag)
        {
            var didParameter = did.HasValue ?
                new ObjectParameter("did", did) :
                new ObjectParameter("did", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var keyParameter = key.HasValue ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(int));
    
            var mouseParameter = mouse.HasValue ?
                new ObjectParameter("mouse", mouse) :
                new ObjectParameter("mouse", typeof(int));
    
            var appParameter = app != null ?
                new ObjectParameter("app", app) :
                new ObjectParameter("app", typeof(string));
    
            var stimeParameter = stime.HasValue ?
                new ObjectParameter("stime", stime) :
                new ObjectParameter("stime", typeof(System.DateTime));
    
            var projidParameter = projid.HasValue ?
                new ObjectParameter("projid", projid) :
                new ObjectParameter("projid", typeof(int));
    
            var tidParameter = tid.HasValue ?
                new ObjectParameter("tid", tid) :
                new ObjectParameter("tid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DailyTimeInsertSP", didParameter, uidParameter, keyParameter, mouseParameter, appParameter, stimeParameter, projidParameter, tidParameter, cidParameter, flag);
        }
    
        public virtual ObjectResult<FillProjectComboSP_Result> FillProjectComboSP(Nullable<int> cid, Nullable<int> uid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FillProjectComboSP_Result>("FillProjectComboSP", cidParameter, uidParameter);
        }
    
        public virtual ObjectResult<FillTaskComboSP_Result> FillTaskComboSP(Nullable<int> pid, Nullable<int> cid)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FillTaskComboSP_Result>("FillTaskComboSP", pidParameter, cidParameter);
        }
    
        public virtual int GetDailyContractsSP(Nullable<System.DateTime> current, Nullable<int> uid, Nullable<int> cid, ObjectParameter sec)
        {
            var currentParameter = current.HasValue ?
                new ObjectParameter("current", current) :
                new ObjectParameter("current", typeof(System.DateTime));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetDailyContractsSP", currentParameter, uidParameter, cidParameter, sec);
        }
    
        public virtual int GetDailySummarySP(Nullable<System.DateTime> current, Nullable<int> pid, Nullable<int> tid, Nullable<int> uid, Nullable<int> cid, ObjectParameter sec, ObjectParameter min, ObjectParameter hour)
        {
            var currentParameter = current.HasValue ?
                new ObjectParameter("current", current) :
                new ObjectParameter("current", typeof(System.DateTime));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var tidParameter = tid.HasValue ?
                new ObjectParameter("tid", tid) :
                new ObjectParameter("tid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetDailySummarySP", currentParameter, pidParameter, tidParameter, uidParameter, cidParameter, sec, min, hour);
        }
    
        public virtual ObjectResult<string> GetTotalDailyTimeSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetTotalDailyTimeSp", cidParameter);
        }
    
        public virtual ObjectResult<string> GetTotalWeeklyTimeSp(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetTotalWeeklyTimeSp", cidParameter);
        }
    
        public virtual int GetWeeklyContractsSP(Nullable<int> uid, Nullable<int> cid, ObjectParameter sdate, ObjectParameter edate, ObjectParameter sec)
        {
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetWeeklyContractsSP", uidParameter, cidParameter, sdate, edate, sec);
        }
    
        public virtual int GetWeeklySummarySP(Nullable<int> pid, Nullable<int> tid, Nullable<int> uid, Nullable<int> cid, ObjectParameter sdate, ObjectParameter edate, ObjectParameter sec, ObjectParameter min, ObjectParameter hour)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var tidParameter = tid.HasValue ?
                new ObjectParameter("tid", tid) :
                new ObjectParameter("tid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetWeeklySummarySP", pidParameter, tidParameter, uidParameter, cidParameter, sdate, edate, sec, min, hour);
        }
    
        public virtual ObjectResult<LoginDetailSp_Result> LoginDetailSp(string email, string pass)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoginDetailSp_Result>("LoginDetailSp", emailParameter, passParameter);
        }
    
        public virtual ObjectResult<Project_AssignSP_Result> Project_AssignSP(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Project_AssignSP_Result>("Project_AssignSP", emailParameter);
        }
    
        public virtual int ProjectReportSp(Nullable<int> cid, Nullable<int> pid, Nullable<System.DateTime> todate, Nullable<System.DateTime> fromdate)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("Cid", cid) :
                new ObjectParameter("Cid", typeof(int));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("Pid", pid) :
                new ObjectParameter("Pid", typeof(int));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("Todate", todate) :
                new ObjectParameter("Todate", typeof(System.DateTime));
    
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProjectReportSp", cidParameter, pidParameter, todateParameter, fromdateParameter);
        }
    
        public virtual int ScreenShotInsertSP(Nullable<int> ss_id, Nullable<int> cid, Nullable<System.DateTime> stime, Nullable<System.DateTime> etime, Nullable<System.DateTime> sstime, string filename, Nullable<int> projid, Nullable<int> tid, Nullable<int> uid, Nullable<bool> isdelete, ObjectParameter flag)
        {
            var ss_idParameter = ss_id.HasValue ?
                new ObjectParameter("ss_id", ss_id) :
                new ObjectParameter("ss_id", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var stimeParameter = stime.HasValue ?
                new ObjectParameter("stime", stime) :
                new ObjectParameter("stime", typeof(System.DateTime));
    
            var etimeParameter = etime.HasValue ?
                new ObjectParameter("etime", etime) :
                new ObjectParameter("etime", typeof(System.DateTime));
    
            var sstimeParameter = sstime.HasValue ?
                new ObjectParameter("sstime", sstime) :
                new ObjectParameter("sstime", typeof(System.DateTime));
    
            var filenameParameter = filename != null ?
                new ObjectParameter("filename", filename) :
                new ObjectParameter("filename", typeof(string));
    
            var projidParameter = projid.HasValue ?
                new ObjectParameter("projid", projid) :
                new ObjectParameter("projid", typeof(int));
    
            var tidParameter = tid.HasValue ?
                new ObjectParameter("tid", tid) :
                new ObjectParameter("tid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var isdeleteParameter = isdelete.HasValue ?
                new ObjectParameter("isdelete", isdelete) :
                new ObjectParameter("isdelete", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ScreenShotInsertSP", ss_idParameter, cidParameter, stimeParameter, etimeParameter, sstimeParameter, filenameParameter, projidParameter, tidParameter, uidParameter, isdeleteParameter, flag);
        }
    
        public virtual ObjectResult<TaskReportSp_Result> TaskReportSp(Nullable<int> cid, Nullable<int> pid, Nullable<int> departid, Nullable<int> desigid, Nullable<System.DateTime> sdate, Nullable<System.DateTime> edate)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("Cid", cid) :
                new ObjectParameter("Cid", typeof(int));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("Pid", pid) :
                new ObjectParameter("Pid", typeof(int));
    
            var departidParameter = departid.HasValue ?
                new ObjectParameter("departid", departid) :
                new ObjectParameter("departid", typeof(int));
    
            var desigidParameter = desigid.HasValue ?
                new ObjectParameter("desigid", desigid) :
                new ObjectParameter("desigid", typeof(int));
    
            var sdateParameter = sdate.HasValue ?
                new ObjectParameter("sdate", sdate) :
                new ObjectParameter("sdate", typeof(System.DateTime));
    
            var edateParameter = edate.HasValue ?
                new ObjectParameter("edate", edate) :
                new ObjectParameter("edate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TaskReportSp_Result>("TaskReportSp", cidParameter, pidParameter, departidParameter, desigidParameter, sdateParameter, edateParameter);
        }
    
        public virtual int TeamReportSp(Nullable<int> cid, Nullable<int> uid, Nullable<System.DateTime> todate, Nullable<System.DateTime> fromdate)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("Cid", cid) :
                new ObjectParameter("Cid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("Uid", uid) :
                new ObjectParameter("Uid", typeof(int));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("Todate", todate) :
                new ObjectParameter("Todate", typeof(System.DateTime));
    
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TeamReportSp", cidParameter, uidParameter, todateParameter, fromdateParameter);
        }
    
        public virtual int UserReportSP(Nullable<int> cid, Nullable<int> uid, Nullable<int> designid, Nullable<int> deptid, Nullable<System.DateTime> todate, Nullable<System.DateTime> fromdate)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("Cid", cid) :
                new ObjectParameter("Cid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("Uid", uid) :
                new ObjectParameter("Uid", typeof(int));
    
            var designidParameter = designid.HasValue ?
                new ObjectParameter("designid", designid) :
                new ObjectParameter("designid", typeof(int));
    
            var deptidParameter = deptid.HasValue ?
                new ObjectParameter("deptid", deptid) :
                new ObjectParameter("deptid", typeof(int));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("Todate", todate) :
                new ObjectParameter("Todate", typeof(System.DateTime));
    
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UserReportSP", cidParameter, uidParameter, designidParameter, deptidParameter, todateParameter, fromdateParameter);
        }
    }
}
