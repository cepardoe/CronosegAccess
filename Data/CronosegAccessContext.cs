using CronosegAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CronosegAccess.Data
{
    public class CronosegAccessContext : DbContext
    {
        public CronosegAccessContext(DbContextOptions<CronosegAccessContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Zone> Zone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Zone>().ToTable("Zone");
            modelBuilder.Entity<Terminal>().ToTable("Terminal");
            modelBuilder.Entity<UserZone>().ToTable("UserZone");
            modelBuilder.Entity<UserZone>()
                .HasKey(c => new { c.idUser, c.IdZone });
        }

        public DbSet<Terminal> Terminal { get; set; }
    }
}
