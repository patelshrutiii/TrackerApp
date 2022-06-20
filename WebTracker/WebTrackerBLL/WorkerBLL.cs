using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using WebTrackerDLL;
using System.Collections;

namespace WebTrackerBLL
{
    public class WorkerBLL
    {
        DataSet ds;
        CommonClass common = new CommonClass();

        //Filling Project ComboBox
        public void fillProjectCombo(ComboBox combo, int cid,int uid)
        {
            common.Connect();
            ds = new DataSet();
            common.BeginTransaction(IsolationLevel.ReadCommitted);
            common.AddInParameter("@cid", SqlDbType.Int, cid);
            common.AddInParameter("@uid", SqlDbType.Int, uid);
            common.LoadDataset("FillProjectComboSP", ref ds, "ProjectAssign");
            combo.DisplayMember = "ProjectName";
            combo.ValueMember = "ProjectId";
            combo.DataSource = ds.Tables[0];
            common.Disconnect();
        }


        //Filling Task ComboBox
        public void fillTaskCombo(ComboBox combo, int pid, int cid)
        {
            common.Connect();
            ds = new DataSet();
            common.BeginTransaction(IsolationLevel.ReadCommitted);
            common.AddInParameter("@pid", SqlDbType.Int, pid);
            common.AddInParameter("@cid", SqlDbType.Int, cid);
            common.LoadDataset("FillTaskComboSP", ref ds, "TaskMaster");
            DataRow row = ds.Tables["TaskMaster"].NewRow();
            row["TaskId"] = 0;
            row["TaskName"] = "no task";
            ds.Tables["TaskMaster"].Rows.InsertAt(row, 0);
            combo.DisplayMember = "TaskName";
            combo.ValueMember = "TaskId";
            combo.DataSource = ds.Tables[0];
            common.Disconnect();
        }


        //Insert Every Minute Events
        public void InsertDailyTime(int uid, int cid, int kkey, int mkey, string task, DateTime date, int pid, int tid)
        {
            try
            {
                common.Connect();
                common.BeginTransaction(IsolationLevel.ReadCommitted);
                common.AddInParameter("@did", SqlDbType.Int, 0);
                common.AddInParameter("@uid", SqlDbType.Int, uid);
                common.AddInParameter("@cid", SqlDbType.Int, cid);
                common.AddInParameter("@key", SqlDbType.Int, kkey);
                common.AddInParameter("@mouse", SqlDbType.Int, mkey);
                common.AddInParameter("@app", SqlDbType.VarChar, task);
                common.AddInParameter("@stime", SqlDbType.DateTime, date);
                common.AddInParameter("@projid", SqlDbType.Int, pid);
                common.AddInParameter("@tid", SqlDbType.Int, tid);
                common.AddOutParameter("@flag", SqlDbType.VarChar, 8000);
                common.ExecuteSP("DailyTimeInsertSP");
                string p_flag = common.getParameter("@flag").ToString();
                if (p_flag == "Y")
                {
                    common.Commit();
                }
                else
                {
                    common.Rollback();
                }
                common.Disconnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Insert Working Time
        public void InsertDailySummary(int pid, int tid, int uid, int cid, DateTime stime, DateTime etime, DateTime ddiff, DateTime tdiff, int sec)
        {
            try
            {
                common.Connect();
                common.BeginTransaction(IsolationLevel.ReadCommitted);
                common.AddInParameter("@sid", SqlDbType.Int, 0);
                common.AddInParameter("@pid", SqlDbType.Int, pid);
                common.AddInParameter("@tid", SqlDbType.Int, tid);
                common.AddInParameter("@uid", SqlDbType.Int, uid);
                common.AddInParameter("@cid", SqlDbType.Int, cid);
                common.AddInParameter("@stime", SqlDbType.DateTime, stime);
                common.AddInParameter("@etime", SqlDbType.DateTime, etime);
                common.AddInParameter("@ddiff", SqlDbType.DateTime, ddiff);
                common.AddInParameter("@tdiff", SqlDbType.DateTime, tdiff);
                common.AddInParameter("@sec", SqlDbType.Int, sec);
                common.AddOutParameter("@flag", SqlDbType.VarChar, 8000);
                common.ExecuteSP("DailySummaryInsertSP");
                string p_flag = common.getParameter("@flag").ToString();
                if (p_flag == "Y")
                {
                    common.Commit();
                }
                else
                {
                    common.Rollback();
                }
                common.Disconnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Insert ScreenShots
        public void InsertSS(int uid, int cid, int pid, int tid, string file, DateTime stime, DateTime etime, DateTime sstime,bool isdelete)
        {
            try
            {
                common.Connect();
                common.BeginTransaction(IsolationLevel.ReadCommitted);
                common.AddInParameter("@ss_id", SqlDbType.Int, 0);
                common.AddInParameter("@uid", SqlDbType.Int, uid);
                common.AddInParameter("@cid", SqlDbType.Int, cid);
                common.AddInParameter("@projid", SqlDbType.Int, pid);
                common.AddInParameter("@tid", SqlDbType.Int, tid);
                common.AddInParameter("@filename", SqlDbType.VarChar, file);
                common.AddInParameter("@stime", SqlDbType.DateTime, stime);
                common.AddInParameter("@etime", SqlDbType.DateTime, etime);
                common.AddInParameter("@sstime", SqlDbType.DateTime, sstime);
                common.AddInParameter("@isdelete", SqlDbType.Bit, isdelete);
                common.AddOutParameter("@flag", SqlDbType.VarChar, 8000);
                common.ExecuteSP("ScreenShotInsertSP");
                string p_flag = common.getParameter("@flag").ToString();
                if (p_flag == "Y")
                {
                    common.Commit();
                }
                else
                {
                    common.Rollback();
                }
                common.Disconnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Display Working Hours Per Day
        public Hashtable getDailyTime(DateTime current, int pid, int tid, int uid, int cid)
        {
            try
            {
                Hashtable ht = new Hashtable();
                common.Connect();
                common.BeginTransaction(IsolationLevel.ReadCommitted);
                common.AddInParameter("@current", SqlDbType.DateTime, current);
                common.AddInParameter("@pid", SqlDbType.Int, pid);
                common.AddInParameter("@tid", SqlDbType.Int, tid);
                common.AddInParameter("@uid", SqlDbType.Int, uid);
                common.AddInParameter("@cid", SqlDbType.Int, cid);
                common.AddOutParameter("@sec", SqlDbType.Int, 10);
                common.AddOutParameter("@min", SqlDbType.Int, 10);
                common.AddOutParameter("@hour", SqlDbType.Int, 10);
                common.ExecuteSP("GetDailySummarySP");

                int h = Convert.ToInt32(common.getParameter("@hour"));
                int m = Convert.ToInt32(common.getParameter("@min"));
                ht["Hour"] = h;
                ht["Minute"] = m;
                return ht;

                common.Disconnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }


        //Display Working Hours Per Week
        public Hashtable getWeeklyTime(int pid, int tid, int uid, int cid)
        {
            try
            {
                Hashtable ht = new Hashtable();
                common.Connect();
                common.BeginTransaction(IsolationLevel.ReadCommitted);
                common.AddInParameter("@pid", SqlDbType.Int, pid);
                common.AddInParameter("@tid", SqlDbType.Int, tid);
                common.AddInParameter("@uid", SqlDbType.Int, uid);
                common.AddInParameter("@cid", SqlDbType.Int, cid);
                common.AddOutParameter("@sdate", SqlDbType.DateTime, 30);
                common.AddOutParameter("@edate", SqlDbType.DateTime, 30);
                common.AddOutParameter("@sec", SqlDbType.Int, 10);
                common.AddOutParameter("@min", SqlDbType.Int, 10);
                common.AddOutParameter("@hour", SqlDbType.Int, 10);
                common.ExecuteSP("GetWeeklySummarySP");
                int h = Convert.ToInt32(common.getParameter("@hour"));
                int m = Convert.ToInt32(common.getParameter("@min"));
                ht["weekHour"] = h;
                ht["weekMinute"] = m;
                return ht;
                common.Disconnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }


        //Display Total Working Hours Per Day
        public Hashtable getDailyContracts(DateTime current, int uid, int cid)
        {
            try
            {
                Hashtable ht = new Hashtable();
                common.Connect();
                common.BeginTransaction(IsolationLevel.ReadCommitted);
                common.AddInParameter("@current", SqlDbType.DateTime, current);
                common.AddInParameter("@uid", SqlDbType.Int, uid);
                common.AddInParameter("@cid", SqlDbType.Int, cid);
                common.AddOutParameter("@sec", SqlDbType.Int, 10);
                common.ExecuteSP("GetDailyContractsSP");
                int sec = Convert.ToInt32(common.getParameter("@sec"));
                ht["Second"] = sec;
                return ht;
                common.Disconnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }


        //Display Total Working Hours Per Week
        public Hashtable getWeeklyContracts(int uid, int cid)
        {
            try
            {
                Hashtable ht = new Hashtable();
                common.Connect();
                common.BeginTransaction(IsolationLevel.ReadCommitted);
                common.AddInParameter("@uid", SqlDbType.Int, uid);
                common.AddInParameter("@cid", SqlDbType.Int, cid);
                common.AddOutParameter("@sdate", SqlDbType.DateTime, 30);
                common.AddOutParameter("@edate", SqlDbType.DateTime, 30);
                common.AddOutParameter("@sec", SqlDbType.Int, 10);
                common.ExecuteSP("GetWeeklyContractsSP");
                int sec = Convert.ToInt32(common.getParameter("@sec"));
                ht["Second"] = sec;
                return ht;
                common.Disconnect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }


    }
}
