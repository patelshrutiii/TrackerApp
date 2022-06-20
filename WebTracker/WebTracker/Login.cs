using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebTrackerBLL;

namespace WebTracker
{
    public partial class Login : Form
    {
        string passPhrase = "Pasword";        // can be any string
        string saltValue = "sALtValue";        // can be any string
        string hashAlgorithm = "SHA1";             // can be "MD5"
        int passwordIterations = 7;                  // can be any number
        string initVector = "~1B2c3D4e5F6g7H8"; // must be 16 bytes
        int keySize = 256;
        string fileName = "userinfo.txt";
        string email, pass;
        DateTime first_start;
        LoginBLL login = new LoginBLL();

        //Constructor
        public Login()
        {
            InitializeComponent();
        }

        //Methods
        //Used For Encrypt Password
        private string Encrypt(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(this.initVector);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(this.saltValue);
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            byte[] rgbKey = new PasswordDeriveBytes(this.passPhrase, rgbSalt, this.hashAlgorithm, this.passwordIterations).GetBytes(this.keySize / 8);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            ICryptoTransform transform = managed.CreateEncryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray);
            //textBox1.Text = Convert.ToBase64String(inArray);
        }

        //Used For Decrypt Password
        private string Decrypt(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(initVector);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
            byte[] buffer = Convert.FromBase64String(data);
            byte[] rgbKey = new PasswordDeriveBytes(this.passPhrase, rgbSalt, this.hashAlgorithm, this.passwordIterations).GetBytes(this.keySize / 8);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream(buffer);
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            byte[] buffer5 = new byte[buffer.Length];
            int count = stream2.Read(buffer5, 0, buffer5.Length);
            return Encoding.UTF8.GetString(buffer5, 0, count);
            stream.Close();
            stream2.Close();
            //textBox2.Text = Encoding.UTF8.GetString(buffer5, 0, count);
        }

        //App Placed In Tray
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

        //Events
        //Page Load Event
        private void Login_Load(object sender, EventArgs e)
        {
            PlaceLowerRight();
            if (File.Exists(fileName))
            {
                remember.Checked = true;

                using (StreamReader reader = new StreamReader("userinfo.txt"))
                {
                    txtemail.Text = Decrypt(reader.ReadLine());
                    txtpass.Text = Decrypt(reader.ReadLine());

                }
            }

        }

        //Form Closing Event
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }

        //Show Password
        private void show_Click(object sender, EventArgs e)
        {
            if (txtpass.PasswordChar == '*')
            {
                hide.BringToFront();
                txtpass.PasswordChar = '\0';
            }
        }

        //Hide Password
        private void hide_Click(object sender, EventArgs e)
        {
            if (txtpass.PasswordChar == '\0')
            {
                show.BringToFront();
                txtpass.PasswordChar = '*';
            }
        }

        //Login Button Event
        [Obsolete]
        private void btnLogin_Click(object sender, EventArgs e)
        {
            email = txtemail.Text;
            pass = txtpass.Text;

            //======remember me code==========
            if (remember.Checked)
            {
                string myfile = "userinfo.txt";
                using (StreamWriter sw = File.AppendText(myfile))
                {

                    sw.WriteLine(Encrypt(txtemail.Text));
                    sw.WriteLine(Encrypt(txtpass.Text));
                }
            }
            else
            {
                if (File.Exists(fileName))
                {
                    txtpass.Text = "";
                    txtemail.Text = "";
                    File.Delete(fileName);

                }
            }

            //====== End remember me code==========
            if (login.LoginUser(email, pass))
            {
                if (login.Project_Assign(email))
                {
                    this.notifyIcon1.Visible = false;
                    this.Hide();
                    first_start = DateTime.Now;
                    Worker wk = new Worker(first_start);
                    wk.Show();
                    wk.btnstart_Click_1(sender, e);
                }
                else
                {
                    MessageBox.Show("Sorry! Cannot login. You don't have any Project assigned.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Username and Password");
            }

        }

        private void forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "http://localhost:44381/Company/ForgetPassword";
            System.Diagnostics.Process.Start(url);
        }

        private void Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "http://localhost:44381/Company/Register";
            System.Diagnostics.Process.Start(url);
        }

        //Tray Icon Event
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

    }
}
