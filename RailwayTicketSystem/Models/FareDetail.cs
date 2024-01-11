using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class FareDetail
    {
        [Key]
        public int fd_id { get; set; }
        public int Train { get; set; }
        public int Compartment { get; set; }
        public int BaseCharges { get; set; }
        public int DistanceCharges { get; set; }


        [ForeignKey("Train")]
        public Train TrainEntity { get; set; }
        [ForeignKey("Compartment")]
        public Compartment CompartmentEntity { get; set; }
    }
}
