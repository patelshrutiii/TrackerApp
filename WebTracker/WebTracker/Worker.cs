using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using WebTrackerCl;
using WebTrackerCl.WinApi;
using System.Data.SqlClient;
using System.Configuration;
using WebTrackerBLL;
using System.Collections;

namespace WebTracker
{
    public partial class Worker : Form
    {
        private readonly KeyboardHookListener m_KeyboardHookManager;
        private readonly MouseHookListener m_MouseHookManager;
        int mousecnt = 0, keyboardcnt = 0 , dcnt = 0, wcnt = 0;
        int randominterval, miniterval;
        DateTime date,start_time, end_time, ss_time;
        DateTime st , et;
        string task = "";
        int user_id,Proj_id, task_id, kkey, mkey,cid;
        int getminutes, getseconds, difference;
        int second,minute,hour,wminute,whour;
        int sec,wsec,dconmin,dconhour,wconmin,wconhour;
        string filename;
        bool delStatus = false;
        DateTime diff,ddiff,tdiff;
        TimeSpan timeDiff;
        int addMin = 0,addHour = 0, addwMin = 0, addwHour = 0;
        string dtime,wtime,dailytime,weeklytime;

        Hashtable ht;
        WorkerBLL worker = new WorkerBLL();

        //Constructor
        public Worker(DateTime first_time)
        {
            InitializeComponent();
            m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            m_KeyboardHookManager.Enabled = true;

            m_MouseHookManager = new MouseHookListener(new GlobalHooker());
            m_MouseHookManager.Enabled = true;
            st = first_time;
            user_id = WebTrackerBLL.globals.uid;
            cid = WebTrackerBLL.globals.cid;


            worker.fillProjectCombo(ProjectCombo, cid, user_id);
        }

        //Methods
        //Placed Form on Right Bottom
        private void PlaceLowerRight()
        {
            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
        }

        //Take ScreenShots.
        public void screenshots()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width + 400, Screen.PrimaryScreen.Bounds.Width);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg";
            bitmap.Save("D:/Sem7-Project/WebTracker_Project/WebTracker_Project/Content/Screenshots/" + filename);
        }
       

        #region "WinAPI"       

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        #endregion
     
        //Get Active Window Title
        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                string t = Buff.ToString();
                if (t.Contains("Google Chrome"))
                {
                    return getChromeUrl();
                }
                else if (t.Contains("Mozilla Firefox"))
                {
                    return getFoxUrl();
                }
                else if (t.Contains("Microsoft? Edge"))
                {
                    return getEdgeUrl();
                }
                else if (t.Contains("Opera"))
                {
                    return getOperaUrl();
                }
                else
                {
                    return Buff.ToString();
                }
            }
            return "";
        }

        //Fetch Url From Google Chrome
        public string getChromeUrl()
        {
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            foreach (Process chrome in procsChrome)
            {
                // the chrome process must have a window
                if (chrome.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                AutomationElement root = AutomationElement.FromHandle(chrome.MainWindowHandle);
                var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));
                if (SearchBar != null)
                {
                    ValuePattern val = ((ValuePattern)SearchBar.GetCurrentPattern(ValuePattern.Pattern));
                    return val.Current.Value;
                }
            }
            return "";
        }

        //Fetch Url From FireFox
        public string getFoxUrl()
        {
            Process[] procsFox = Process.GetProcessesByName("firefox");
            foreach (Process firefox in procsFox)
            {
                //the firefox process must have a window
                if (firefox.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }
                AutomationElement root = AutomationElement.FromHandle(firefox.MainWindowHandle);
                AutomationElement SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Search with Google or enter address"));
                // if it can be found, get the value from the editbox
                if (SearchBar != null)
                {
                    ValuePattern val = ((ValuePattern)SearchBar.GetCurrentPattern(ValuePattern.Pattern));
                    return val.Current.Value;
                }
            }
            return "";
        }

        //Fetch Url From Microsoft Edge
        public string getEdgeUrl()
        {
            Process[] procsEdge = Process.GetProcessesByName("msedge");
            foreach (Process edge in procsEdge)
            {
                // the chrome process must have a window
                if (edge.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                AutomationElement root = AutomationElement.FromHandle(edge.MainWindowHandle);
                var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));
                if (SearchBar != null)
                {
                    ValuePattern val = ((ValuePattern)SearchBar.GetCurrentPattern(ValuePattern.Pattern));
                    return val.Current.Value;
                }
            }
            return "";
        }     

        //Fetch Url From Opera Browser
        public string getOperaUrl()
        {
            Process[] procsOpera = Process.GetProcessesByName("opera");
            foreach (Process opera in procsOpera)
            {
                // the chrome process must have a window
                if (opera.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                // find the automation element
                AutomationElement root = AutomationElement.FromHandle(opera.MainWindowHandle);
                AutomationElement SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address field"));

                if (SearchBar != null)
                {
                    ValuePattern val = ((ValuePattern)SearchBar.GetCurrentPattern(ValuePattern.Pattern));
                    return val.Current.Value;
                }
            }
            return "";
        }

        //Get Daily Working Time
        public void GetDailyTime()
        {
            ht = new Hashtable();

            ht = worker.getDailyTime(DateTime.Now, Proj_id, task_id, user_id, cid);
            hour = Convert.ToInt32(ht["Hour"]) + addHour;
            minute = Convert.ToInt32(ht["Minute"]) + addMin;
            if(minute >= 60)
            {
                hour += minute / 60;
                minute = minute % 60;
            }
            dailytime = hour.ToString() + ":" + minute.ToString();
            DailySummary.Text = dailytime;
        }

        //Get Weekly Working Time
        public void GetWeeklyTime()
        {
            ht = new Hashtable();
            ht = worker.getWeeklyTime(Proj_id, task_id, user_id, cid);
            whour = Convert.ToInt32(ht["weekHour"]) + addwHour;
            wminute = Convert.ToInt32(ht["weekMinute"]) + addwMin;
            if (wminute >= 60)
            {
                whour += wminute / 60;
                wminute = wminute % 60;
            }
            weeklytime = whour.ToString() + ":" + wminute.ToString();
            WeekSummary.Text = weeklytime;
        }

        //Get Total Working Hours Per Day
        public string GetAllContractsdaily()
        {
            ht = new Hashtable();
            ht = worker.getDailyContracts(DateTime.Now, user_id, cid);
            sec = Convert.ToInt32(ht["Second"]) + dcnt;
            dconhour = sec / 3600;
            dconmin = (sec - (3600 * dconhour)) / 60;
            dtime = dconhour.ToString() + ":" + dconmin.ToString();
            return dtime;
        }

        //Get Total Working Hours Per Week
        public string GetAllContractsweekly()
        {
            ht = new Hashtable();
            ht = worker.getWeeklyContracts(user_id, cid);
            wsec = Convert.ToInt32(ht["Second"]) + wcnt;
            wconhour = wsec / 3600;
            wconmin = (wsec - (3600 * wconhour)) / 60;
            wtime = wconhour.ToString() + ":" + wconmin.ToString();
            return wtime;
        }
        
        //Get Working Time Project and Task Wise.
        public void OnChangeEvent()
        {
            timer1.Interval = 1000;
            et = DateTime.Now;
            timeDiff = et.Subtract(st);
            second = (int)timeDiff.TotalSeconds;
            diff = Convert.ToDateTime(timeDiff.ToString());
            ddiff = diff.Date;
            tdiff = Convert.ToDateTime(diff.TimeOfDay.ToString());
            worker.InsertDailySummary(Proj_id, task_id, user_id, cid, st, et, ddiff, tdiff, second);
            GetDailyTime();
            GetWeeklyTime();
            GetAllContractsdaily();
            GetAllContractsweekly();
            DailySummary.Text = "0:0";
            WeekSummary.Text = "0:0";
            st = DateTime.Now;
            addHour = 0;
            addMin = 0;
            addwHour = 0;
            addwMin = 0;
            dcnt = 0;
            wcnt = 0;
        }

       

        //Events
        //Page Load Event
        private void Worker_Load(object sender, EventArgs e)
        {
            PlaceLowerRight();
            uname.Text = WebTrackerBLL.globals.uname;
        }

        //Count Total Pressed Key
        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyboardcnt++;
        }

        //Count Total Mouse Clicked
        private void HookManager_MouseClick(object sender, MouseEventArgs e)
        {
            mousecnt++;
        }

        //Start Button Click Event
        [Obsolete]
        internal void btnstart_Click_1(object sender, EventArgs e)
        {

            if (timer1.Enabled == false)
            {
                pictureBox1.Image = Image.FromFile("D:/Sem7-Project/WebTracker/WebTracker/Images/Green.png");
                timer1.Start();
                timer2.Start();
                timer1.Interval = 1000;
                timer2.Interval = 100;
                start_time = DateTime.Now;
                st = DateTime.Now;
                GetAllContractsdaily();
                GetAllContractsweekly();
                btnstart.Text = "Stop";
                btnstart.BackColor = System.Drawing.Color.DarkRed;
                m_KeyboardHookManager.KeyPress += HookManager_KeyPress;
                m_MouseHookManager.MouseClickExt += HookManager_MouseClick;
            }
            else
            {
                pictureBox1.Image = Image.FromFile("D:/Sem7-Project/WebTracker/WebTracker/Images/Red1.png");
                et = DateTime.Now;
                end_time = DateTime.Now;
                timeDiff = et.Subtract(st);
                second = (int)timeDiff.TotalSeconds;
                diff = Convert.ToDateTime(timeDiff.ToString());
                ddiff = diff.Date;
                tdiff = Convert.ToDateTime(diff.TimeOfDay.ToString());
                worker.InsertDailySummary(Proj_id, task_id, user_id, cid, st, et, ddiff, tdiff, second);
                GetAllContractsdaily();
                GetAllContractsweekly();
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                //Add2();
                dcnt = 0;
                wcnt = 0;
                btnstart.Text = "Start";
                btnstart.BackColor = System.Drawing.Color.CadetBlue;
            }
        }

        //Timer Event For Every One Minute          
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 60000;
            mkey = mousecnt;
            kkey = keyboardcnt;
            mousecnt = 0;
            keyboardcnt = 0;
            date = DateTime.Now;
            task = GetActiveWindowTitle();
            et = DateTime.Now;
            timeDiff = et.Subtract(st);
            addMin = (int)timeDiff.TotalMinutes;
            addHour = (int)timeDiff.TotalHours;
            addwMin = (int)timeDiff.TotalMinutes;
            addwHour = (int)timeDiff.TotalHours;           
            worker.InsertDailyTime(user_id, cid, kkey, mkey, task, date, Proj_id, task_id);
            GetDailyTime();
            GetWeeklyTime();
            DailyTip.SetToolTip(DailySummary, "Total Work: " + GetAllContractsdaily());
            dcnt += 60;
            DailyTip.SetToolTip(WeekSummary, "Total Work: " + GetAllContractsweekly());
            wcnt += 60;
        }

        //Timer Event For Every 10 Minutes
        private void timer2_Tick(object sender, EventArgs e)
        {
            getminutes = Convert.ToInt32(start_time.Minute);
            int temp = (((getminutes) + 9) / 10);
            int mins = temp * 10;
            getseconds = Convert.ToInt32(start_time.Second);
            if (getseconds < 60)
            {
                getseconds = 60 - getseconds;
            }
            difference = Convert.ToInt32(mins) - getminutes;
            if (difference == 0)
            {
                difference = 10;
            }

            end_time = start_time.AddMinutes(difference);
            if (difference < 9)
            {
                int ts;
                if (end_time.Minute > start_time.Minute)
                {
                    ts = end_time.Minute - start_time.Minute;
                    miniterval = ts * 60000;
                }
                else if (end_time.Minute == 00 || end_time.Minute < 00)
                {
                    ts = 60 - start_time.Minute;
                    miniterval = ts * 60000;
                }

                timer2.Interval = (int)miniterval;
                Random rnd = new Random(); //generating random number
                randominterval = rnd.Next(0, (int)miniterval);
                timer3.Interval = randominterval;
                timer3.Start();
            }
            else
            {
                timer2.Interval = 600000;
                Random rnd = new Random(); //generating random number
                randominterval = rnd.Next(20000, 540000);
                timer3.Interval = randominterval;
                timer3.Start();
            }
        }

        //Timer Event For Clicking Screenshots
        private void timer3_Tick(object sender, EventArgs e)
        {
            screenshots();

            ss_time = DateTime.Now;
            //Add1();
            worker.InsertSS(user_id, cid, Proj_id, task_id, filename, start_time, end_time, ss_time, delStatus);

            timer3.Stop();
            start_time = end_time.AddSeconds(2);
        }

        private void Report_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "http://localhost:44381/TeamReport/List?companyId=" + cid + "&userId=" + user_id;
            System.Diagnostics.Process.Start(url);
        }

        private void ScreenShots_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {          
            string url = "http://localhost:44381/TeamScreenShot/List?companyId=" + cid + "&userId=" + user_id;
            System.Diagnostics.Process.Start(url);
        }

        //Selected Event On Project Combo.
        private void ProjectCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                OnChangeEvent();
            }
            if (ProjectCombo.SelectedValue.ToString() != null)
            {
                Proj_id = Convert.ToInt32(ProjectCombo.SelectedValue.ToString());
                task_id = 0;
                worker.fillTaskCombo(TaskCombo, Proj_id, cid);
            }
        }

        //Selected Event On Task Combo.
        private void TaskCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                OnChangeEvent();
            }
            if (TaskCombo.SelectedValue.ToString() != null)
            {
                task_id = Convert.ToInt32(TaskCombo.SelectedValue.ToString());
            }
            
        }

        //Event Of Refresh Button
        private void Refresh_Click(object sender, EventArgs e)
        {
            GetDailyTime();
            GetWeeklyTime();
        }

        //Event Of SignOut Button
        private void SignOut_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                OnChangeEvent();
            }
            this.Close();
            notifyIcon1.Visible = false;
            cid = 0;
            new Login().Show();
        }

        //Quit Event
        private void Quit_Click(object sender, EventArgs e)
        {
            OnChangeEvent();
            notifyIcon1.Dispose();
            Application.Exit();
        }

        //Tray Icon Click Event
        private void notifyIcon1_DoubleClick_1(object sender, EventArgs e)
        {
            this.Show();
            PlaceLowerRight();
        }

        //App Running in Backend Even App was Closed.
        private void Worker_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }

        //placed App in tray
        //Stored App in Tray
        //public void MinimizeToTray()
        //{
        //    try
        //    {
        //        if (FormWindowState.Minimized == this.WindowState)
        //        {
        //            notifyIcon1.Visible = true;
        //            notifyIcon1.ShowBalloonTip(500);
        //            this.Hide();
        //        }
        //        else if (FormWindowState.Normal == this.WindowState)
        //        {
        //            notifyIcon1.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}


        //Insert Record in Datatable
        //public void Add()
        //{
        //    DataRow row = dt.NewRow();
        //    row["Start Time"] = date;
        //    row["KeyHit"] = kkey;
        //    row["MouseHit"] = mkey;
        //    row["Task"] = task.ToString();            
        //    dt.Rows.Add(row);           
        //}

       //public void Add1()
       // {
       //     DataRow row1 = dt1.NewRow();
       //     row1["Start Time SS"] = start_time.ToString("HH:mm:ss");
       //     row1["stop time"] = end_time.ToString("HH:mm:ss");
       //     row1["screenshot time"] = ss_time.ToString("HH:mm:ss");
       //     row1["File name"] = filename;
       //     dt1.Rows.Add(row1);
       // }

    }
}

