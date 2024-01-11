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
        public int TrainId { get; set; }
        public int CompartmentId { get; set; }
        public int TotalSeats { get; set; }

        [ForeignKey("TrainId")]
        public Train Train { get; set; }

        [ForeignKey("CompartmentId")]
        public Compartment Compartment { get; set; }
    }
}
