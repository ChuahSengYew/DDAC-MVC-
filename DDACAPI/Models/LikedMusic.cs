using System.Collections.Generic;

namespace DDACAPI.Models
{
    public class LikedMusic
    {
        public LikedMusic()
        {

        }
        public List<User> User
        {
            get;
            set;
        }
        public List<Music> Music
        {
            get;
            set;
        }
    }
}
