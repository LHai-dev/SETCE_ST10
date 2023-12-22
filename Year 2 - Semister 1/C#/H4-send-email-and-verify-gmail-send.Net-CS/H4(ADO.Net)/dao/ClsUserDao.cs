using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_ADO.Net_.dao
{
    internal class ClsUserDao
    {
        public void initField()
        {
            dto.ClsUserDto u1 = new dto.ClsUserDto();
            u1.id = 1;
            u1.name = "hai";
            u1.password = "123";
            u1.dob = Convert.ToDateTime("1997-02-01");
            Program.tblUser.Add(u1);

            dto.ClsUserDto u2 = new dto.ClsUserDto();
            u2.id = 2;
            u2.name = "limhai";
            u2.password = "321";
            u2.dob = Convert.ToDateTime("1997-01-02");
            Program.tblUser.Add(u2);
        }
        public ClsUserDao()
        {
            initField();
        }
        public ClsUserDao(Boolean init)
        {
            if (init == true)
            {
                initField();
            }
        }
        public ClsUserDao(int id, string name, string password, DateTime dob)
        {
            dto.ClsUserDto u1 = new dto.ClsUserDto(id, name, password, dob);
            Program.tblUser.Add(u1);
        }

        public int getMaxID()
        {
            int id = 1;
            foreach (dto.ClsUserDto u in Program.tblUser)
            {
                if (u.id > id)
                {
                    id = u.id;
                }
            }
            return id;
        }

        public Boolean isDupplicateID(long id)
        {

            foreach (dto.ClsUserDto u in Program.tblUser)
            {
                if (id == u.id)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean isDupplicateName(string name)
        {

            foreach (dto.ClsUserDto u in Program.tblUser)
            {
                if (name == u.name)
                {
                    return true;
                }
            }
            return false;
        }

        public void addOneUser(dto.ClsUserDto user)
        {
            Program.tblUser.Add(user);
        }

        public Boolean updateRecordByID(dto.ClsUserDto user)
        {
            foreach (dto.ClsUserDto u in Program.tblUser)
            {
                if (user.id == u.id)
                {
                    u.name = user.name;
                    u.password = user.password;
                    u.dob = user.dob;
                    return true;
                }
            }
            return false;
        }

        public Boolean deleteUserByID(int id)
        {
            foreach (dto.ClsUserDto u in Program.tblUser)
            {
                if (id == u.id)
                {
                    //delete
                    Program.tblUser.Remove(u);
                    return true;
                }
            }
            return false;
        }
    }
}
