using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using RailwayTicketSystem.Models;
using System.Reflection.Emit;

namespace RailwayTicketSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
                //builder.Entity<StationDistance>()
                //    .HasOne(sd => sd.FromStationId)
                //    .WithMany(s => s.DistancesFrom)
                //    .HasForeignKey(sd => sd.FromStation)
                //    .OnDelete(DeleteBehavior.Restrict);

                //builder.Entity<StationDistance>()
                //    .HasOne(sd => sd.ToStationId)
                //    .WithMany(s => s.DistancesTo)
                //    .HasForeignKey(sd => sd.ToStationId)
                //    .OnDelete(DeleteBehavior.Restrict);


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

            //a hasher to hash the password before seeding the user to the db
            //var hasher = new PasswordHasher<IdentityUser>();


            //Seeding the User to AspNetUsers table
           //builder.Entity<IdentityUser>().HasData(
           //     new IdentityUser
           //     {
           //         Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
           //         UserName = "myuser",
           //         NormalizedUserName = "MYUSER",
           //         PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
           //         EmailConfirmed= true,
           //     }
           // );


            //Seeding the relation between our user and role to AspNetUserRoles table
            //builder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);
        }

        
    }
}