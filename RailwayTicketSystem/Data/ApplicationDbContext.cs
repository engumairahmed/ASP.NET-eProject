using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using RailwayTicketSystem.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace RailwayTicketSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PassengerDetail> PassengerDetails { get; set; }
        public DbSet<TrainDetail> TrainDetails { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TicketDetail> TicketDetails { get; set; }
        public DbSet<FareDetail> FareDetails { get; set; }
        public DbSet<Station> StationDetails { get; set; }
        public DbSet<TrainSchedule> TrainSchedules { get; set; }
        public DbSet<StationDistance> StationDistances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-P0ITGTA\\SQLEXPRESS;Database=new_orts;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<StationDistance>()
                .HasKey(sd => sd.StationDistanceId);

            builder.Entity<StationDistance>()
                .HasOne(sd => sd.FromStation)
                .WithMany()
                .HasForeignKey(sd => sd.FromStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StationDistance>()
                .HasOne(sd => sd.ToStation)
                .WithMany()
                .HasForeignKey(sd => sd.ToStationId)
                .OnDelete(DeleteBehavior.Restrict);

           
        }

        
    }
}