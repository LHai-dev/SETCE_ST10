using HWOOP.Dao;
using HWOOP.Dto;

namespace HWOOP
{
    internal static class Program
    {
        public static List<ClsEnpolyee> tblEnpolyees = new List<ClsEnpolyee>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormEnpolyees());
        }
    }
}