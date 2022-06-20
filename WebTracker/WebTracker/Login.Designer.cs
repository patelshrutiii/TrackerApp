
namespace WebTracker
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.remember = new System.Windows.Forms.CheckBox();
            this.Register = new System.Windows.Forms.LinkLabel();
            this.forgot = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.hide = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtpass
            // 
            this.txtpass.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpass.Location = new System.Drawing.Point(203, 131);
            this.txtpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(207, 30);
            this.txtpass.TabIndex = 18;
            // 
            // txtemail
            // 
            this.txtemail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtemail.Location = new System.Drawing.Point(204, 46);
            this.txtemail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(207, 30);
            this.txtemail.TabIndex = 17;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.MediumPurple;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(26, 279);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(385, 49);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "Sign in";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // remember
            // 
            this.remember.AutoSize = true;
            this.remember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remember.ForeColor = System.Drawing.Color.ForestGreen;
            this.remember.Location = new System.Drawing.Point(130, 218);
            this.remember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.remember.Name = "remember";
            this.remember.Size = new System.Drawing.Size(154, 29);
            this.remember.TabIndex = 15;
            this.remember.Text = "remember me";
            this.remember.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            this.Register.ActiveLinkColor = System.Drawing.Color.SteelBlue;
            this.Register.AutoSize = true;
            this.Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register.LinkColor = System.Drawing.Color.PaleVioletRed;
            this.Register.Location = new System.Drawing.Point(258, 378);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(129, 20);
            this.Register.TabIndex = 14;
            this.Register.TabStop = true;
            this.Register.Text = "Sign up for Free";
            this.Register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Register_LinkClicked);
            // 
            // forgot
            // 
            this.forgot.ActiveLinkColor = System.Drawing.Color.SlateBlue;
            this.forgot.AutoSize = true;
            this.forgot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgot.LinkColor = System.Drawing.Color.PaleVioletRed;
            this.forgot.Location = new System.Drawing.Point(29, 376);
            this.forgot.Name = "forgot";
            this.forgot.Size = new System.Drawing.Size(145, 20);
            this.forgot.TabIndex = 13;
            this.forgot.TabStop = true;
            this.forgot.Text = "Forgot Password?";
            this.forgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgot_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 10;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // hide
            // 
            this.hide.Image = ((System.Drawing.Image)(resources.GetObject("hide.Image")));
            this.hide.Location = new System.Drawing.Point(374, 131);
            this.hide.Margin = new System.Windows.Forms.Padding(4);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(37, 33);
            this.hide.TabIndex = 19;
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // show
            // 
            this.show.BackColor = System.Drawing.SystemColors.ControlLight;
            this.show.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.show.Image = ((System.Drawing.Image)(resources.GetObject("show.Image")));
            this.show.Location = new System.Drawing.Point(373, 131);
            this.show.Margin = new System.Windows.Forms.Padding(4);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(37, 32);
            this.show.TabIndex = 20;
            this.show.UseVisualStyleBackColor = false;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(436, 477);
            this.Controls.Add(this.show);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.remember);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.forgot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox remember;
        private System.Windows.Forms.LinkLabel Register;
        private System.Windows.Forms.LinkLabel forgot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Button show;
    }
}

