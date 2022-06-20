using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebTrackerDLL
{
    public class CommonClass
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter adp;
        private DataTable dt;       
        private IsolationLevel IsolationLevel;
        private SqlTransaction transaction;

        //Constructor
        public CommonClass()
        {
            string str = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con = new SqlConnection(str);           
            dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Type", typeof(SqlDbType));
            dt.Columns.Add("Size", typeof(int));
            dt.Columns.Add("Direction", typeof(ParameterDirection));
            dt.Columns.Add("Nullable", typeof(bool));
            dt.Columns.Add("Value", typeof(object));

        }

        //Methods
        //For Opening Connection
        public void Connect()
        {
            if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        
        //For Closing Connection
        public void Disconnect()
        {
            if (this.cmd != null)
            {
                this.cmd.Connection.Close();
                this.cmd.Dispose();
                if (this.con != null)
                {
                    this.con.Close();
                }
            }
            this.transaction = (SqlTransaction)null;
            this.dt.Rows.Clear();
        }

        //Begin Transaction
        public SqlTransaction BeginTransaction(IsolationLevel isolationlevel)
        {
            if (this.transaction == null)
            {
                this.IsolationLevel = isolationlevel;
                this.transaction = this.con.BeginTransaction(isolationlevel);
            }
            return this.transaction;
        }

        //Commit Changes
        public void Commit()
        {
            if (this.transaction == null)
            {
                return;
            }
            this.transaction.Commit();
            this.transaction = (SqlTransaction)null;
        }

        //RollBack Changes
        public void Rollback()
        {
            if (this.transaction == null)
            {
                return;
            }
            this.transaction.Rollback();
            this.transaction = (SqlTransaction)null;
        }

        //Prepared Execute Statement For Stored Procedure
        public SqlCommand PreparedStatementSP(string Spname)
        {
            this.cmd = new SqlCommand(Spname);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Connection = this.con;
            this.cmd.CommandTimeout = 2000;
            if (this.dt.Rows.Count != 0 && this.cmd.Parameters.Count == 0)
            {
                foreach (DataRow drrow in (InternalDataCollectionBase)this.dt.Rows)
                {
                    try
                    {
                        this.cmd.Parameters.Add(new SqlParameter(drrow["Name"].ToString(), (SqlDbType)drrow["Type"],
                                                                    Convert.ToInt32(drrow["Size"].ToString()),
                                                                    (ParameterDirection)drrow["Direction"],
                                                                    bool.Parse(drrow["Nullable"].ToString()), (byte)0,
                                                                    (byte)0, "", DataRowVersion.Default,
                                                                    drrow["Value"]));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return this.cmd;
        }

        //Prepared Execute Statement For SQL Query
        public SqlCommand PreparedStatementQry(string qry)
        {
            this.cmd = new SqlCommand(qry);
            this.cmd.Connection = this.con;
            this.cmd.CommandTimeout = 2000;           
            return this.cmd;
        }

        //Adding Parameter
        public void AddPrameter(string name, SqlDbType dbtype, int size, ParameterDirection direction, bool nullable, object value)
        {
            DataRow row = this.dt.NewRow();
            row.ItemArray = new object[6]
            {
                (object) name,
                (object) dbtype,
                (object) size,
                (object) direction,
                (object) (bool) (nullable ? true : false) ,
                value
        };
            this.dt.Rows.Add(row);

        }

        //Adding Parameter For In Procedure
        public void AddInParameter(string name, SqlDbType dbtype, object value)
        {
            this.AddPrameter(name, dbtype, 0, ParameterDirection.Input, false, value);

        }

        public void AddInParameter(string name, SqlDbType dbtype, bool nullable, object value)
        {
            this.AddPrameter(name, dbtype, 0, ParameterDirection.Input, false, value);
        }

        //Adding Parameter For Out Procedure
        public void AddOutParameter(string name, SqlDbType dbType, int size)
        {
            this.AddPrameter(name, dbType, size, ParameterDirection.Output, true, (byte)0);
        }

        //Fetch String Value
        public object getParameter(string name)
        {
            return this.cmd.Parameters[name].Value;
        }

        //Fetch Int Value
        public object getParameter(int val)
        {
            return this.cmd.Parameters[val].Value;
        }

        //Clear Parameters
        private void clear()
        {
            if (this.dt.Rows.Count <= 0)
            {
                return;
            }
            this.dt.Rows.Clear();
        }

        //Execution of Stored Procedure
        public int ExecuteSP(string Spname)
        {           
            this.cmd = this.PreparedStatementSP(Spname);
            this.cmd.Transaction = this.BeginTransaction(this.IsolationLevel);
            int i = this.cmd.ExecuteNonQuery();
            this.clear();
            return i;
        }

        //Execution of Query
        public int ExecuteQuery(string qry)
        {
            this.cmd = this.PreparedStatementQry(qry);
            this.cmd.CommandTimeout = 2000;
            this.cmd.Transaction = this.BeginTransaction(this.IsolationLevel);
            int i = this.cmd.ExecuteNonQuery();
            this.clear();
            return i;
        }

        //Loads Dataset Using Stored Procedure
        public void LoadDataset(string Spname,ref DataSet ds,string t)
        {
            try
            {
                this.cmd = this.PreparedStatementSP(Spname);
                this.cmd.Transaction = this.BeginTransaction(this.IsolationLevel);
                this.cmd.CommandTimeout = 2000;                
                adp = new SqlDataAdapter(this.cmd);
                ds = new DataSet();
                adp.Fill(ds,t);
                this.clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Loads Dataset Using Query
        public void LoadDatasetQry(string qry, ref DataSet ds)
        {
            try
            {
                this.cmd = this.PreparedStatementQry(qry);
                this.cmd.Transaction = this.BeginTransaction(this.IsolationLevel);
                this.cmd.CommandTimeout = 2000;
                adp = new SqlDataAdapter(this.cmd);
                ds = new DataSet();
                adp.Fill(ds);
                this.clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      
    }
}