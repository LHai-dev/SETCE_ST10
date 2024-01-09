using DemoProject.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class LoginOtp : Form
    {
        private UserDAO userDao = new UserDAO();
        private int otp_expired = 60;
        int otp;

        public LoginOtp()
        {
            InitializeComponent();
        }


        private void CfmOtp()
        {
            if (textBox4.Text.Length > 0)
            {
                otp = int.Parse(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text);
                if (!userDao.ConfirmOtp(otp))
                {
                    MessageBox.Show("Invalid OTP!");
                    return;
                }
                this.Close();
            }
        }

        private void NextTextField(object sender)
        {
            if (((Control)sender).TabIndex == 4)
            {
                return;
            }

            SelectNextControl((Control)sender, true, true, true, true);
        }

        private void PrevTextField(object sender)
        {
            if (((Control)sender).TabIndex == 1)
            {
                return;
            }
            SelectNextControl((Control)sender, false, true, true, true);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                PrevTextField(sender);
                return;
            }
            NextTextField(sender);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                PrevTextField(sender);
                return;
            }
            NextTextField(sender);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                PrevTextField(sender);
                return;
            }
            NextTextField(sender);
        }

        private void LoginOtp_Load(object sender, EventArgs e)
        {
            lbSend.Text = $"{otp_expired}s";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (otp_expired == 0)
            {
                lbSend.Text = "Resend";
                timer1.Stop();
                return;
            }

            otp_expired = otp_expired - 1;
            lbSend.Text = $"{otp_expired}s";
        }

        private void lbSend_Click(object sender, EventArgs e)
        {
            if (lbSend.Text == "Resend")
            {
                userDao.SetOtp(Program.userid);
                otp_expired = 60;
                timer1.Start();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                PrevTextField(sender);
                return;
            }
            NextTextField(sender);
            CfmOtp();
        }

    }
}
