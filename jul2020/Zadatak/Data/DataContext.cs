using Microsoft.EntityFrameworkCore;
using Zadatak.Models;

namespace Zadatak.Data
{
    class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}

        public DbSet<Match> Matches { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Set> Sets { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Result>().ToTable("Result");
            modelBuilder.Entity<Set>().ToTable("Set");
            modelBuilder.Entity<Player>().ToTable("Player");

            // Match - Result 1:1
            modelBuilder.Entity<Match>()
                .HasOne(match => match.Result)
                .WithOne(result => result.Match)
                .HasForeignKey<Result>(result => result.MatchId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Result - Set 1:N
            modelBuilder.Entity<Result>()
                .HasMany(result => result.Sets)
                .WithOne(set => set.Result)
                .OnDelete(DeleteBehavior.Restrict);

            // Match - Player N:2
            modelBuilder.Entity<Match>()
                .HasOne(match => match.Player1)
                .WithMany(player => player.Matches)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}