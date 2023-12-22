using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace H4_ADO.Net_
{
    public partial class Login_frm : Form
    {
        public Login_frm()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !(chkShowPassword.Checked);
        }

        dao.ClsLoginDao dao = new dao.ClsLoginDao();

        int vCode = 1000;
        String to, from, pass, mail, randomcode;

        private void Login_frm_Load(object sender, EventArgs e)
        {

        }

        private void btnReSend_Click(object sender, EventArgs e)
        {
            txtVerificationCode.Clear();
            btnLogin_Click(null, null);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Common.ClsCommon.isEmpty(txtLoginName, txtPassword)) { return; }
            long uid = dao.VerifyAuth(txtLoginName.Text, txtPassword.Text);
            if (uid > 0 && txtVerificationCode.Text == randomcode)
            {
                Program.uid = uid;
                Program.uname = txtLoginName.Text;
                System.IO.File.WriteAllText(Application.StartupPath + @"\usrinfo.txt", txtLoginName.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed Auth!");
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = true;
            btnReSend.Enabled = true;
            //======================================================================

            timvcode.Stop();

            Random rand = new Random();
            randomcode = (rand.Next(vCode)).ToString();
            //to = txtEmail.Text;
            to = "killinaction58@gmail.com";// Your gmail goes here
            from = "killinaction58@gmail.com"; // Your gmail goes here
            mail = "hello bong";
            pass = "wyoqxjammjuqgcbu"; // Your app password goes here
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = randomcode;
            message.Subject = "limhai"; // Mail Subject
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Verification Code sent successful! Go to Gmail and got it", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVerificationCode.Enabled = true;
                btnConfirm.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //======================================================================
            
        }
    }
}
