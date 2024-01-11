using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        // Foreign keys
        public int? TrainScheduleId { get; set; }

        public string? PNRNumber { get; set; }
        public int? SeatNumber { get; set; }
        public string? CoachNumber { get; set; }
        public int? Fare { get; set; }
        public string? ReservationDate { get; set; }

        [ForeignKey("TrainScheduleId")]
        public TrainSchedule TrainSchedule { get; set; }
    }
}
