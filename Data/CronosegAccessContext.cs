using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CronosegAccess.Data
{
    public class CronosegAccessContext : IdentityDbContext<IdentityUser>
    {
        public CronosegAccessContext(DbContextOptions<CronosegAccessContext> options)
            : base(options)
        {
        }

        public DbSet<accTerminal> accTerminal { get; set; }
        public DbSet<accZone> accZone { get; set; }
        public DbSet<accUser> accUser { get; set; }
        public DbSet<accSchedule> accSchedule { get; set; }

        public DbSet<accEnter> accEnter { get; set; }

        public DbSet<accResult> accResult { get; set; }

        public DbSet<accMode> accMode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<accTerminal>().ToTable("accTerminal");
            modelBuilder.Entity<accZone>().ToTable("accZone");
            modelBuilder.Entity<accUser>().ToTable("accUser");
            modelBuilder.Entity<accSchedule>().ToTable("accSchedule");
            modelBuilder.Entity<accUserZone>().ToTable("accUserZone");
            modelBuilder.Entity<accMode>().ToTable("accMode");
            modelBuilder.Entity<accResult>().ToTable("accResult");
            modelBuilder.Entity<accEnter>().ToTable("accEnter");


            modelBuilder.Entity<accEnter>()
                .HasKey(k => k.idEnter);
             modelBuilder.Entity<accEnter>()
                .HasOne(bc => bc.user)
                .WithMany(b => b.Enters)
                .HasForeignKey(c => c.idUser);
            modelBuilder.Entity<accEnter>()
                .HasOne(bc => bc.mode)
                .WithMany(b => b.Enters)
                .HasForeignKey(c => c.idMode);
            modelBuilder.Entity<accEnter>()
                .HasOne(bc => bc.result)
                .WithMany(b => b.Enters)
                .HasForeignKey(c => c.idResult);

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
                .HasForeignKey(c=>c.idZone);
        }


    }
}
