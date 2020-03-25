using Microsoft.EntityFrameworkCore;
using Treehouse.AspNetCore.Models;
using static Treehouse.AspNetCore.Models.League;

namespace Treehouse.AspNetCore.Data
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) 
            :base(options)
        {
            
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Player2.Rootobject> Players { get; set; }

        public DbSet<Team2> Team2 { get; set; }
        public DbSet<Division> Division { get; set; }
        //public DbSet<User> User { get; set; }

        public DbSet<Token> Token { get; set; }

        public DbSet<Venue> Venue { get; set; }
        public DbSet<Conference> Conference { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Removing the pluralizing table name convention 
            // so our table names will use our entity class singular names.
            /*modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .OnDelete(DeleteBehavior.Cascade);*/
        }

         public DbSet<Treehouse.AspNetCore.Models.User> User { get; set; }
    }
}
