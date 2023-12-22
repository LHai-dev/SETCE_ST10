using System;
using System.Data.OleDb;

namespace H4_ADO.Net_.dao
{
    internal class ClsLoginDao
    {
        
        OleDbCommand cmd = new OleDbCommand("",Program.cnn);
        public long VerifyAuth(String usr_name,String pwd)
        {
            cmd.CommandText = "select user_id from tbluser where is_active = yes and user_name = '" + usr_name + "' and user_pwd = '" + pwd + "'";
            OleDbDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            
            //}
            if (dr.HasRows)
            {
                dr.Read();
                long uid = long.Parse(dr["user_id"].ToString());
                dr.Close();
                return uid;
            }
            dr.Close();
            return -1;
        }
    }
}
