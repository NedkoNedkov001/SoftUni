﻿namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballManager;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserPlayer>()
                .HasKey(u => new { u.UserId, u.PlayerId});
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserPlayer> UserPlayers { get; set; }

    }
}
