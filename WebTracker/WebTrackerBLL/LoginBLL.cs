using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebTrackerDLL;

namespace WebTrackerBLL
{
   public class LoginBLL
    {
        DataSet ds;
        CommonClass common = new CommonClass();

        //Check Logged User
        public bool LoginUser(string email, string pass)
        {
            common.Connect();
            ds = new DataSet();
            common.BeginTransaction(IsolationLevel.ReadCommitted);
            common.AddInParameter("@email", SqlDbType.VarChar, email);
            common.AddInParameter("@pass", SqlDbType.VarChar, pass);
            common.LoadDataset("LoginDetailSp", ref ds, "UserMaster");
            if (ds.Tables["UserMaster"].Rows.Count > 0)
            {
                globals.uid = Convert.ToInt32(ds.Tables["UserMaster"].Rows[0]["UserId"]);
                globals.uname = ds.Tables["UserMaster"].Rows[0]["FirstName"].ToString()
                    + " " + ds.Tables["UserMaster"].Rows[0]["LastName"].ToString();
                globals.cid = Convert.ToInt32(ds.Tables["UserMaster"].Rows[0]["CompanyId"]);

                return true;
            }
            else
                return false;
            common.Disconnect();
        }

        //Check Project Was Assigned or not
        public bool Project_Assign(string email)
        {
            common.Connect();
            ds = new DataSet();
            common.BeginTransaction(IsolationLevel.ReadCommitted);
            common.AddInParameter("@email", SqlDbType.VarChar, email);
            common.LoadDataset("Project_AssignSP", ref ds, "ProjectAssign");
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
            common.Disconnect();
        }

    }
}
