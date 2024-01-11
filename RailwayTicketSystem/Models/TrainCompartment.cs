using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class TrainCompartment
    {
        [Key]
        public int TC_Id { get; set; }
        public int TrainId { get; set; }

        public int CompartmentId { get; set; }
        public int CompartmentCount { get; set; }

        [ForeignKey("TrainId")]
        public Train Train { get; set; }
        [ForeignKey("CompartmentId")]
        public Compartment Compartment { get; set; }
    }
}
