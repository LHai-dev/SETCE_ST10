using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal static class Program
    {

        public static List<ClsCar> clsCars = new List<ClsCar>();

        public static  List<ClsUser> clsUser = new List<ClsUser>();
        public static List<ClsComputer> clsComputter = new List<ClsComputer>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ClsUser u = new ClsUser();
            u.id = 10;
            u.name = "limhai";
            u.gender = "male";
            clsUser.Add(u);

            ClsUser u1 = new ClsUser();
            u1.id = 10;
            u1.name = "limhai";
            u1.gender = "male";
            clsUser.Add(u1);


            ClsCar c = new ClsCar();
            c.chair = 10;
            c.year = 2010;
            c.cid = 10;
            c.weight = "20";
            c.color = "yellow";
            ClsCar c1 = new ClsCar();
            c1.chair = 10;
            c1.year = 2010;
            c1.cid = 10;
            c1.weight = "12";
            c1.color = "yellow";
            clsCars.Add(c1);

            ClsComputer clsComputer = new ClsComputer();
            clsComputer.computerName = "limhai";
            clsComputer.year = 10;
            clsComputer.brand = "mis";
            clsComputer.price = "200$";
            clsComputer.core = "11";
            clsComputter.Add(clsComputer);

        Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new ComputerForm());
            //Application.Run(new UserForm1());
            //Application.Run(new animalForm());
            //Application.Run(new employeeForm());


        }
    }
}
