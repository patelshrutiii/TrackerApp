
namespace WebTracker
{
    partial class Worker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Worker));
            this.btnstart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DailySummary = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Report = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.SignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.DashBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectCombo = new System.Windows.Forms.ComboBox();
            this.TaskCombo = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.WeekSummary = new System.Windows.Forms.Label();
            this.todaytime = new System.Windows.Forms.Label();
            this.weektime = new System.Windows.Forms.Label();
            this.uname = new System.Windows.Forms.Label();
            this.ScreenShot = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DailyTip = new System.Windows.Forms.ToolTip(this.components);
            this.WeeklyTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.BackColor = System.Drawing.Color.CadetBlue;
            this.btnstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnstart.Location = new System.Drawing.Point(31, 336);
            this.btnstart.Margin = new System.Windows.Forms.Padding(4);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(373, 58);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 362);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DailySummary
            // 
            this.DailySummary.AutoSize = true;
            this.DailySummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DailySummary.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DailySummary.Location = new System.Drawing.Point(326, 432);
            this.DailySummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DailySummary.Name = "DailySummary";
            this.DailySummary.Size = new System.Drawing.Size(76, 29);
            this.DailySummary.TabIndex = 2;
            this.DailySummary.Text = "00:00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.Report);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 28);
            this.panel1.TabIndex = 3;
            // 
            // Report
            // 
            this.Report.AutoSize = true;
            this.Report.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Report.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Report.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Report.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Report.LinkColor = System.Drawing.Color.Black;
            this.Report.Location = new System.Drawing.Point(15, 4);
            this.Report.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(75, 24);
            this.Report.TabIndex = 8;
            this.Report.TabStop = true;
            this.Report.Text = "Reports";
            this.Report.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Report_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(433, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Refresh,
            this.SignOut,
            this.Quit});
            this.settingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingToolStripMenuItem.Image")));
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            // 
            // Refresh
            // 
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(177, 26);
            this.Refresh.Text = "Refresh Data";
            this.Refresh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // SignOut
            // 
            this.SignOut.Name = "SignOut";
            this.SignOut.Size = new System.Drawing.Size(177, 26);
            this.SignOut.Text = "Sign Out ";
            this.SignOut.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // Quit
            // 
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(177, 26);
            this.Quit.Text = "Quit";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // DashBoard
            // 
            this.DashBoard.Name = "DashBoard";
            this.DashBoard.Size = new System.Drawing.Size(224, 26);
            this.DashBoard.Text = "My DashBoard";
            // 
            // ProjectCombo
            // 
            this.ProjectCombo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProjectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProjectCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectCombo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ProjectCombo.FormattingEnabled = true;
            this.ProjectCombo.IntegralHeight = false;
            this.ProjectCombo.ItemHeight = 25;
            this.ProjectCombo.Location = new System.Drawing.Point(34, 117);
            this.ProjectCombo.Margin = new System.Windows.Forms.Padding(4);
            this.ProjectCombo.Name = "ProjectCombo";
            this.ProjectCombo.Size = new System.Drawing.Size(370, 33);
            this.ProjectCombo.TabIndex = 4;
            this.ProjectCombo.SelectedIndexChanged += new System.EventHandler(this.ProjectCombo_SelectedIndexChanged);
            // 
            // TaskCombo
            // 
            this.TaskCombo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TaskCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TaskCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskCombo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TaskCombo.FormattingEnabled = true;
            this.TaskCombo.IntegralHeight = false;
            this.TaskCombo.Location = new System.Drawing.Point(35, 177);
            this.TaskCombo.Margin = new System.Windows.Forms.Padding(4);
            this.TaskCombo.Name = "TaskCombo";
            this.TaskCombo.Size = new System.Drawing.Size(369, 32);
            this.TaskCombo.TabIndex = 5;
            this.TaskCombo.SelectedIndexChanged += new System.EventHandler(this.TaskCombo_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox1.Location = new System.Drawing.Point(35, 255);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 52);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "    what are you doing now?";
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // WeekSummary
            // 
            this.WeekSummary.AutoSize = true;
            this.WeekSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeekSummary.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.WeekSummary.Location = new System.Drawing.Point(326, 478);
            this.WeekSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WeekSummary.Name = "WeekSummary";
            this.WeekSummary.Size = new System.Drawing.Size(76, 29);
            this.WeekSummary.TabIndex = 10;
            this.WeekSummary.Text = "00:00";
            // 
            // todaytime
            // 
            this.todaytime.AutoSize = true;
            this.todaytime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todaytime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.todaytime.Location = new System.Drawing.Point(33, 430);
            this.todaytime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.todaytime.Name = "todaytime";
            this.todaytime.Size = new System.Drawing.Size(71, 29);
            this.todaytime.TabIndex = 11;
            this.todaytime.Text = "today";
            // 
            // weektime
            // 
            this.weektime.AutoSize = true;
            this.weektime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weektime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.weektime.Location = new System.Drawing.Point(33, 483);
            this.weektime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.weektime.Name = "weektime";
            this.weektime.Size = new System.Drawing.Size(114, 29);
            this.weektime.TabIndex = 12;
            this.weektime.Text = "this week";
            // 
            // uname
            // 
            this.uname.AutoSize = true;
            this.uname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uname.Location = new System.Drawing.Point(93, 57);
            this.uname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uname.Name = "uname";
            this.uname.Size = new System.Drawing.Size(65, 25);
            this.uname.TabIndex = 13;
            this.uname.Text = "name";
            // 
            // ScreenShot
            // 
            this.ScreenShot.AutoSize = true;
            this.ScreenShot.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ScreenShot.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ScreenShot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScreenShot.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ScreenShot.LinkColor = System.Drawing.Color.Black;
            this.ScreenShot.Location = new System.Drawing.Point(116, 6);
            this.ScreenShot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScreenShot.Name = "ScreenShot";
            this.ScreenShot.Size = new System.Drawing.Size(118, 24);
            this.ScreenShot.TabIndex = 9;
            this.ScreenShot.TabStop = true;
            this.ScreenShot.Text = "ScreenShots";
            this.ScreenShot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ScreenShots_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(41, 57);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // DailyTip
            // 
            this.DailyTip.IsBalloon = true;
            // 
            // WeeklyTip
            // 
            this.WeeklyTip.IsBalloon = true;
            // 
            // Worker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(436, 549);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uname);
            this.Controls.Add(this.weektime);
            this.Controls.Add(this.todaytime);
            this.Controls.Add(this.WeekSummary);
            this.Controls.Add(this.ScreenShot);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TaskCombo);
            this.Controls.Add(this.ProjectCombo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DailySummary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnstart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Worker";
            this.Text = "WebWork";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Worker_FormClosing_1);
            this.Load += new System.EventHandler(this.Worker_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label DailySummary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ProjectCombo;
        private System.Windows.Forms.ComboBox TaskCombo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel Report;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label WeekSummary;
        private System.Windows.Forms.Label todaytime;
        private System.Windows.Forms.Label weektime;
        private System.Windows.Forms.Label uname;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DashBoard;
        private System.Windows.Forms.ToolStripMenuItem Refresh;
        private System.Windows.Forms.ToolStripMenuItem SignOut;
        private System.Windows.Forms.LinkLabel ScreenShot;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem Quit;
        private System.Windows.Forms.ToolTip DailyTip;
        private System.Windows.Forms.ToolTip WeeklyTip;
    }
}

