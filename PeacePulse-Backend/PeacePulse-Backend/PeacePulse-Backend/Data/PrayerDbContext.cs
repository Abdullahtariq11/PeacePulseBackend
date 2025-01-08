using Microsoft.EntityFrameworkCore;
using PeacePulse_Backend.Models;

namespace PeacePulse_Backend.Data
{
    public class PrayerDbContext:DbContext
    {
        public PrayerDbContext(DbContextOptions<PrayerDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Prayer> Prayers { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships using Fluent API
                modelBuilder.Entity<Dashboard>()
             .HasOne(d => d.User)
             .WithOne(u => u.Dashboard)
             .HasForeignKey<Dashboard>(d => d.UserId);

            modelBuilder.Entity<Prayer>()
                .HasOne(p => p.User)
                .WithMany(u => u.Prayers)
                .HasForeignKey(p => p.UserId);

            // ... Additional configurations for relationships

            base.OnModelCreating(modelBuilder);
        }
    }
}
