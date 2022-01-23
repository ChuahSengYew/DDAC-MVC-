using DDACAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDACAPI.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {

        }
        public DbSet<Music> Music { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>().HasData(
                new Music { musicid = 1, title = "Off My Face", artist = "Justin Bieber", genre = "R&B", description = "Off My Face" }
                );
                
        }*/



    }
}
