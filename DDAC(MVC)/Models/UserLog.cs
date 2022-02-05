using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_MVC_.Models
{
    public class UserLog
    {

        public int logid
        {
            get;
            set;
        }

        public int userid
        {
            get;
            set;
        }

        public string username
        {
            get;
            set;
        }

        public DateTime login
        {
            get;
            set;
        }

        public DateTime logout
        {
            get;
            set;
        }



    }
}
