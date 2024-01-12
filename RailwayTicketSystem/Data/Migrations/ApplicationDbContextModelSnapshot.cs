﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayTicketSystem.Data;

#nullable disable

namespace RailwayTicketSystem.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Coach", b =>
                {
                    b.Property<int>("CoachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoachId"), 1L, 1);

                    b.Property<int>("CoachNumber")
                        .HasColumnType("int");

                    b.Property<int>("CompartmentId")
                        .HasColumnType("int");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("CoachId");

                    b.HasIndex("CompartmentId");

                    b.HasIndex("TrainId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Compartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Compartments");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.FareDetail", b =>
                {
                    b.Property<int>("fd_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("fd_id"), 1L, 1);

                    b.Property<int>("BaseCharges")
                        .HasColumnType("int");

                    b.Property<int>("Compartment")
                        .HasColumnType("int");

                    b.Property<int>("DistanceCharges")
                        .HasColumnType("int");

                    b.Property<int>("Train")
                        .HasColumnType("int");

                    b.HasKey("fd_id");

                    b.HasIndex("Compartment");

                    b.HasIndex("Train");

                    b.ToTable("FareDetails");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.PassengerDetail", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PNRNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PNRNumber");

                    b.ToTable("PassengerDetails");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<string>("CoachNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Fare")
                        .HasColumnType("int");

                    b.Property<string>("PNRNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReservationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TrainScheduleId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TrainT_Id")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("TrainScheduleId");

                    b.HasIndex("TrainT_Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StationId"), 1L, 1);

                    b.Property<string>("RailwayDivisionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sequence")
                        .HasColumnType("int");

                    b.Property<string>("StationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StationId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.StationDistance", b =>
                {
                    b.Property<int>("StationDistanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StationDistanceId"), 1L, 1);

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("FromStationId")
                        .HasColumnType("int");

                    b.Property<int>("ToStationId")
                        .HasColumnType("int");

                    b.HasKey("StationDistanceId");

                    b.HasIndex("FromStationId");

                    b.HasIndex("ToStationId");

                    b.ToTable("StationDistances");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Train", b =>
                {
                    b.Property<int>("T_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("T_Id"), 1L, 1);

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainNo")
                        .HasColumnType("int");

                    b.HasKey("T_Id");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.TrainCompartment", b =>
                {
                    b.Property<int>("TC_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TC_Id"), 1L, 1);

                    b.Property<int>("CompartmentCount")
                        .HasColumnType("int");

                    b.Property<int>("CompartmentId")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("TC_Id");

                    b.HasIndex("CompartmentId");

                    b.HasIndex("TrainId");

                    b.ToTable("TrainCompartments");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.TrainRoute", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"), 1L, 1);

                    b.Property<int>("ArrivalTime")
                        .HasColumnType("int");

                    b.Property<int>("DepartureTime")
                        .HasColumnType("int");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.Property<int>("StopOrder")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("RouteId");

                    b.HasIndex("StationId");

                    b.HasIndex("TrainId");

                    b.ToTable("TrainRoutes");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.TrainSchedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"), 1L, 1);

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Direction")
                        .HasColumnType("bit");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId");

                    b.HasIndex("RouteId");

                    b.HasIndex("StationId");

                    b.HasIndex("TrainId");

                    b.ToTable("TrainSchedules");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Coach", b =>
                {
                    b.HasOne("RailwayTicketSystem.Models.Compartment", "Compartment")
                        .WithMany("Coaches")
                        .HasForeignKey("CompartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTicketSystem.Models.Train", "Train")
                        .WithMany("Coaches")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compartment");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.FareDetail", b =>
                {
                    b.HasOne("RailwayTicketSystem.Models.Compartment", "CompartmentEntity")
                        .WithMany("FareDetails")
                        .HasForeignKey("Compartment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTicketSystem.Models.Train", "TrainEntity")
                        .WithMany("FareDetails")
                        .HasForeignKey("Train")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompartmentEntity");

                    b.Navigation("TrainEntity");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.PassengerDetail", b =>
                {
                    b.HasOne("RailwayTicketSystem.Models.Reservation", "PNRNumberId")
                        .WithMany()
                        .HasForeignKey("PNRNumber");

                    b.Navigation("PNRNumberId");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Reservation", b =>
                {
                    b.HasOne("RailwayTicketSystem.Models.TrainSchedule", "TrainSchedule")
                        .WithMany()
                        .HasForeignKey("TrainScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTicketSystem.Models.Train", null)
                        .WithMany("Reservations")
                        .HasForeignKey("TrainT_Id");

                    b.Navigation("TrainSchedule");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.StationDistance", b =>
                {
                    b.HasOne("RailwayTicketSystem.Models.Station", "FromStation")
                        .WithMany("FromStationDistances")
                        .HasForeignKey("FromStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTicketSystem.Models.Station", "ToStation")
                        .WithMany("ToStationDistances")
                        .HasForeignKey("ToStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromStation");

                    b.Navigation("ToStation");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.TrainCompartment", b =>
                {
                    b.HasOne("RailwayTicketSystem.Models.Compartment", "Compartment")
                        .WithMany("TrainCompartments")
                        .HasForeignKey("CompartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTicketSystem.Models.Train", "Train")
                        .WithMany("TrainCompartments")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compartment");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.TrainRoute", b =>
                {
                    b.HasOne("RailwayTicketSystem.Models.Station", "Station")
                        .WithMany("TrainRoutes")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTicketSystem.Models.Train", "Train")
                        .WithMany("TrainRoutes")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.TrainSchedule", b =>
                {
                    b.HasOne("RailwayTicketSystem.Models.TrainRoute", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTicketSystem.Models.Station", null)
                        .WithMany("TrainSchedules")
                        .HasForeignKey("StationId");

                    b.HasOne("RailwayTicketSystem.Models.Train", "Train")
                        .WithMany("TrainSchedules")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Compartment", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("FareDetails");

                    b.Navigation("TrainCompartments");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Station", b =>
                {
                    b.Navigation("FromStationDistances");

                    b.Navigation("ToStationDistances");

                    b.Navigation("TrainRoutes");

                    b.Navigation("TrainSchedules");
                });

            modelBuilder.Entity("RailwayTicketSystem.Models.Train", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("FareDetails");

                    b.Navigation("Reservations");

                    b.Navigation("TrainCompartments");

                    b.Navigation("TrainRoutes");

                    b.Navigation("TrainSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
