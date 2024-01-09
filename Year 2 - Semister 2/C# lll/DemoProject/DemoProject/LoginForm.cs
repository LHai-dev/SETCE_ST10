using DemoProject.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnexit_Click(null,null);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            int id = userDAO.LoginUser(txtusername.Text.Trim(), txtpass.Text.Trim());

            if(id > 0)
            {
                Program.userid = id;
                LoginOtp loginOtp = new LoginOtp();
                userDAO.SetOtp(Program.userid);
                loginOtp.ShowDialog();
                this.Hide();

                return;
            }
            MessageBox.Show("Failed Login!");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = true;
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnlogin_Click(null,null);
            }
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
