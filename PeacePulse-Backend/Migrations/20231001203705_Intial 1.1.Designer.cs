﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PeacePulse_Backend.Data;

#nullable disable

namespace PeacePulse_Backend.Migrations
{
    [DbContext(typeof(PrayerDbContext))]
    [Migration("20231001203705_Intial 1.1")]
    partial class Intial11
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PeacePulse_Backend.Models.Dashboard", b =>
                {
                    b.Property<int>("DashboardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DashboardId"));

                    b.Property<int>("CompletedPrayer")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MissedPrayer")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPrayers")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<decimal>("completedPercentage")
                        .HasColumnType("numeric");

                    b.Property<decimal>("failedPercentage")
                        .HasColumnType("numeric");

                    b.HasKey("DashboardId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("PeacePulse_Backend.Models.Prayer", b =>
                {
                    b.Property<int>("PrayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PrayerID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DashboardId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PrayerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PrayerID");

                    b.HasIndex("DashboardId");

                    b.HasIndex("UserId");

                    b.ToTable("Prayers");
                });

            modelBuilder.Entity("PeacePulse_Backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("Createdt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PeacePulse_Backend.Models.Dashboard", b =>
                {
                    b.HasOne("PeacePulse_Backend.Models.User", "User")
                        .WithOne("Dashboard")
                        .HasForeignKey("PeacePulse_Backend.Models.Dashboard", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeacePulse_Backend.Models.Prayer", b =>
                {
                    b.HasOne("PeacePulse_Backend.Models.Dashboard", "Dashboard")
                        .WithMany("Prayers")
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeacePulse_Backend.Models.User", "User")
                        .WithMany("Prayers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dashboard");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeacePulse_Backend.Models.Dashboard", b =>
                {
                    b.Navigation("Prayers");
                });

            modelBuilder.Entity("PeacePulse_Backend.Models.User", b =>
                {
                    b.Navigation("Dashboard")
                        .IsRequired();

                    b.Navigation("Prayers");
                });
#pragma warning restore 612, 618
        }
    }
}
