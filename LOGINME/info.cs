using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
namespace LOGINME
{
    class info
    {


        [PrimaryKey, AutoIncrement]

        public int id { get; set; }

        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
