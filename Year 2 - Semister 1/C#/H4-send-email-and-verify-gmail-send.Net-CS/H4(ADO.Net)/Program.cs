using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;

namespace H4_ADO.Net_
{
    internal static class Program
    {
        //public static OleDbConnection cnn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source = D:\Y2S1\C# II\Heng\ADO.Net\DB1.mdb;Persist Security Info=False");

        //public static OleDbConnection cnn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = DB1.H4.mdb;Persist Security Info=False");

        public static long uid;

        public static String uname;

        public static OleDbConnection cnn = new OleDbConnection(@"Provider = Microsoft.JET.OLEDB.4.0;Data Source = DB1.H4.mdb; Persist Security Info = False");

        public static List<dto.ClsUserDto> tblUser = new List<dto.ClsUserDto>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //read last user login
            if (System.IO.File.Exists(Application.StartupPath + @"\usrinfo.txt"))
            {
                Program.uname = System.IO.File.ReadAllText(Application.StartupPath + @"\usrinfo.txt");
            }

            cnn.Open();
            //cnn.Close();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new User_frm());
            Application.Run(new Main_frm());
        }
    }
}
