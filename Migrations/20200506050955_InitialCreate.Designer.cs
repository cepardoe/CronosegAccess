﻿// <auto-generated />
using System;
using CronosegAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CronosegAccess.Migrations
{
    [DbContext(typeof(CronosegAccessContext))]
    [Migration("20200506050955_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CronosegAccess.Models.Terminal", b =>
                {
                    b.Property<int>("IdTerminal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("ZoneIdZone")
                        .HasColumnType("int");

                    b.HasKey("IdTerminal");

                    b.HasIndex("ZoneIdZone");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("CronosegAccess.Models.Zone", b =>
                {
                    b.Property<int>("IdZone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdZone");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("CronosegAccess.Models.Terminal", b =>
                {
                    b.HasOne("CronosegAccess.Models.Zone", "Zone")
                        .WithMany("Terminals")
                        .HasForeignKey("ZoneIdZone");
                });
#pragma warning restore 612, 618
        }
    }
}