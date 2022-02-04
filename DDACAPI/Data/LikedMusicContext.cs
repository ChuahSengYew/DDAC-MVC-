using DDACAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DDACAPI.Data
{
    public class LikedMusicContext : DbContext
    {
        public LikedMusicContext(DbContextOptions<LikedMusicContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
