using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DemoProject.dao
{
    internal class UserDAO
    {
        private SqlCommand cmd = new SqlCommand("", Program.conn);
        public int LoginUser(string username, string password)
        {
            string sql = "select id from users where username=@username and password=@pwd;";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pwd", password);
            try
            {
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }catch(Exception ex)
            {
                MessageBox.Show($"Something goes down at server! {ex.Message}");
            }
            return 0;
        }

        private string Rand4Digit()
        {
            Random random = new Random();
            int ran4digit = random.Next(1000,10000);
            return ran4digit.ToString();
        }


        public bool SetOtp(int userid)
        {
            string sql = "update users\r\n" +
                "set otp = @otp,\r\n" +
                "otp_expired = DATEADD(MINUTE, 1, GETDATE())\r\n" +
                "where id = @userid;";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@otp", Rand4Digit());
            cmd.Parameters.AddWithValue("@userid", userid);
            int affectRow = cmd.ExecuteNonQuery();

            if(affectRow > 0)
            {
                return true;
            }
            return false;
        }

        public bool ConfirmOtp(int otp)
        {
            string sql = "select id from users\r\nwhere id = @userid and otp = @otp;";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@otp", otp);
            cmd.Parameters.AddWithValue("@userid", Program.userid);
            SqlDataReader r = cmd.ExecuteReader();
            cmd.Parameters.Clear();

            if (r.Read())
            {
                return true;
            }
            r.Close();
            return false;
        }
    }
}
