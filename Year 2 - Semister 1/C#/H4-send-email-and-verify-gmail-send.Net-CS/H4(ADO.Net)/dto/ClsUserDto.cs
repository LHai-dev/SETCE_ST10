using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_ADO.Net_.dto
{
    internal class ClsUserDto
    {
        public int id;
        public string name;
        public string password;
        public DateTime dob;

        public ClsUserDto()
        {
            // do nothing
        }

        public ClsUserDto(int id, string name, string password, DateTime dob)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.dob = dob;
        }

        public string AsString()
        {
            return id + "-" + "-" + password;
        }

        public int GetAge()
        {
            return DateTime.Now.Year - dob.Year;
        }
    }
}
