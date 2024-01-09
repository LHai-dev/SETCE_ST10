using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    internal static class Program
    {
        public static SqlConnection conn = null;
        public static int userid;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionStr = "Data Source=DESKTOP-AR09PB5;Initial Catalog=db_demo;Integrated Security=True;";
            conn = new SqlConnection(connectionStr);

            conn.Open();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIParent());
        }
    }
}
