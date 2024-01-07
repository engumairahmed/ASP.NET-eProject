using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        // Foreign keys
        public int TrainScheduleId { get; set; }
        public string UserId { get; set; } 


        public string PNRNumber { get; set; }
        public int SeatNumber { get; set; }
        public string CoachNumber { get; set; }
        public decimal Fare { get; set; }
        public DateTime ReservationDate { get; set; }

        // Navigation properties
        public TrainSchedule TrainSchedule { get; set; }
        public IdentityUser User { get; set; }
    }
}
