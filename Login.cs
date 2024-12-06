using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class Login : Form
    {
        public string title = DataFactory.SystemInfoRepository().FirstOrDefault(t => t.Id == 1).Title;
        public Login()
        {
            InitializeComponent();
            this.Text = title;
            this.FormBorderStyle = FormBorderStyle.None;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            lsystemname.BackColor = Color.Transparent;
            luser.BackColor = Color.Transparent;
            lpassword.BackColor = Color.Transparent;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lsystemname.Text = title;

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int x = (int)(0.5 * (this.Width - lsystemname.Width));
            int y = lsystemname.Location.Y;
            lsystemname.Location = new System.Drawing.Point(x, y);
        }

        private void Bno_Click(object sender, EventArgs e)
        {
            tuser.Text = "";
            tpassword.Text = "";
        }

        private void Bok_Click(object sender, EventArgs e)
        {
            string name = tuser.Text;
            string password = tpassword.Text;
            if (String.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                tuser.Text = "";
                tpassword.Text = "";
                tuser.Focus();
                MessageBox.Show("用户名和密码不能为空！");
            }
            else
            {
                if (DataFactory.UsersRepository().Any(t => t.Name == name && t.Password == password))
                {
                    Users my = DataFactory.UsersRepository().FirstOrDefault(t => t.Name == name && t.Password == password);
                    string sql = "update Users set Times=" + (my.Times + 1) + " where Id=" + my.Id;
                    int ok = WMSDateHelp.adddata(sql);
                    MessageBox.Show("成功登录，点击进入系统");
                    this.Close();
                    Admin admin = new Admin(my.Id.ToString());
                    admin.Show();
                }
                else
                {
                    tuser.Text = "";
                    tpassword.Text = "";
                    tuser.Focus();
                    MessageBox.Show("用户名和密码不正确！");
                }
            }
        }

        private void Bquit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
