using HWOOP.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP.Dao
{
    internal class ClsEnpolyeesDao
    {
        public string salary { get; }
        public string gender { get; }

        public void initField()
        {
            ClsEnpolyee u1 = new ClsEnpolyee();
            u1.id = 1;
            u1.name = "limhai";
            u1.password = "12";
            u1.dob = Convert.ToDateTime("1997-02-01");
            u1.gender = "Male";
            u1.salary = "100$";
            Program.tblEnpolyees.Add(u1);

            ClsEnpolyee u2 = new ClsEnpolyee();
            u2.id = 2;
            u2.name = "limHeng";
            u2.gender = "Male";
            u2.password = "hai289371";
            u2.dob = Convert.ToDateTime("1997-01-02");
            u2.salary = "1000$";
            Program.tblEnpolyees.Add(u2);
        }
        public ClsEnpolyeesDao()
        {
            initField();
        }
        public ClsEnpolyeesDao(Boolean init)
        {
            if (init == true)
            {
                initField();
            }
        }
        public ClsEnpolyeesDao(int id, string name, string password, DateTime dob)
        {
            ClsEnpolyee u1 = new ClsEnpolyee(salary,id, name, gender,password, dob);
            Program.tblEnpolyees.Add(u1);
        }
        public static int getMaxID()
        {
            int id = 1;
            foreach (ClsEnpolyee u in Program.tblEnpolyees)
            {
                if (u.id > id)
                {
                    id = u.id;
                }
            }
            return id;
        }
        public static Boolean isDupplicateID(long id)
        {

            foreach (ClsEnpolyee u in Program.tblEnpolyees)
            {
                if (id == u.id)
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean isDupplicateName(string name)
        {

            foreach (ClsEnpolyee u in Program.tblEnpolyees)
            {
                if (name == u.name)
                {
                    return true;
                }
            }
            return false;
        }

        public static void addOneUser(ClsEnpolyee clsEnpolyee)
        {
            Program.tblEnpolyees.Add(clsEnpolyee);
        }

        public static Boolean updateRecordByID(ClsEnpolyee user)
        {
            foreach (ClsEnpolyee u in Program.tblEnpolyees)
            {
                if (user.id == u.id)
                {
                    //updateRecord
                    u.name = user.name;
                    u.password = user.password;
                    u.dob = user.dob;
                    return true;
                }
            }
            return false;
        }
        public static Boolean deleteUserByID(int id)
        {
            foreach (ClsEnpolyee u in Program.tblEnpolyees)
            {
                if (id == u.id)
                {
                    //delete
                    Program.tblEnpolyees.Remove(u);
                    return true;
                }
            }
            return false;
        }
    }
}
