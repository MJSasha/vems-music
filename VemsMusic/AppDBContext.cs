using Microsoft.EntityFrameworkCore;
using VemsMusic.Models;

namespace VemsMusic
{
    public class AppDBContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MusicalGroup> Groups { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
