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
        public DbSet<Compartment> Compartments { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<PassengerDetail> PassengerDetails { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FareDetail> FareDetails { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<TrainSchedule> TrainSchedules { get; set; }
        public DbSet<TrainCompartment> TrainCompartments { get; set; }
        public DbSet<StationDistance> StationDistances { get; set; }
        public DbSet<TrainRoute> TrainRoutes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server=DESKTOP-P0ITGTA\\SQLEXPRESS;Database=new_orts;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
           
        }

        
    }
}