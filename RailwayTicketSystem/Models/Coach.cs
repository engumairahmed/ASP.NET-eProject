using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace RailwayTicketSystem.Models
{
    public class Coach
    {
        [Key]
        public int CoachId { get; set; }
        [Display(Name = "Coach Number")]
        public int CoachNumber { get; set; }
        public int TrainId { get; set; }
        public int CompartmentId { get; set; }
        [Display(Name ="Total Seats")]
        public int TotalSeats { get; set; }

        [ForeignKey("TrainId")]
        public Train Train { get; set; }

        [ForeignKey("CompartmentId")]
        public Compartment Compartment { get; set; }
    }
}
