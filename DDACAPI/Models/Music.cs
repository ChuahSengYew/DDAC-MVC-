using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDACAPI.Models
{
    public class Music
    {
        public Music()
        {

        }
        public int musicid
        {
            get;
            set;
        }
        public string title
        {
            get;
            set;
        }
        public string artist
        {
            get;
            set;
        }
        public string genre
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
    }
}
