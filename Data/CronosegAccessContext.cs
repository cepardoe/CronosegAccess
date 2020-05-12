using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CronosegAccess.Data
{
    public class CronosegAccessContext : IdentityDbContext<IdentityUser>
    {
        public CronosegAccessContext(DbContextOptions<CronosegAccessContext> options)
            : base(options)
        {
        }

        public DbSet<CronosegAccess.Models.accTerminal> accTerminal { get; set; }

        public DbSet<CronosegAccess.Models.accZone> accZone { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<accTerminal>().ToTable("accTerminal");
            modelBuilder.Entity<accZone>().ToTable("accZone");
            modelBuilder.Entity<accUser>().ToTable("accUser");
            modelBuilder.Entity<accSchedule>().ToTable("accSchedule");
            modelBuilder.Entity<accUserZone>().ToTable("accUserZone");

            modelBuilder.Entity<accUserZone>()
                .HasKey(bc => new { bc.idUser, bc.idZone });
            modelBuilder.Entity<accUserZone>()
                .HasOne(bc => bc.user)
                .WithMany(b => b.UserZones)
                .HasForeignKey(bc => bc.idUser);
            modelBuilder.Entity<accUserZone>()
                .HasOne(bc => bc.zone)
                .WithMany(c => c.UserZones)
                .HasForeignKey(bc => bc.idZone);

            modelBuilder.Entity<accUserSchedule>()
                .HasKey(bc => new { bc.idUser, bc.idSchedule });
            modelBuilder.Entity<accUserSchedule>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserSchedules)
                .HasForeignKey(bc => bc.idUser);
            modelBuilder.Entity<accUserSchedule>()
                .HasOne(bc => bc.schedule)
                .WithMany(c => c.UserSchedules)
                .HasForeignKey(bc => bc.idSchedule);

            modelBuilder.Entity<accTerminal>()
                .HasKey(k => k.IdTerminal);
            modelBuilder.Entity<accTerminal>()
                .HasOne(bc => bc.Zone)
                .WithMany(b=>b.Terminals)
                .HasForeignKey(c=>c.idZone)
                ;
        }




        public DbSet<CronosegAccess.Models.accUser> accUser { get; set; }


        public DbSet<CronosegAccess.Models.accSchedule> accSchedule { get; set; }
    }
}
