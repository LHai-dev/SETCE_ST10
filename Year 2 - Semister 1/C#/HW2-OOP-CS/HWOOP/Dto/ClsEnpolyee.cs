using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP.Dto
{
     class ClsEnpolyee : ClsUser
    {
        public string salary;

        public ClsEnpolyee()
        {
            //onting 
        }
        public ClsEnpolyee(string salary, int id, string name, string gender,string password, DateTime dob)
        {
            this.id = id;
            this.gender = gender;
            this.name = name;
            this.password = password;
            this.dob = dob;
            this.salary = salary;
        }
    }
}
