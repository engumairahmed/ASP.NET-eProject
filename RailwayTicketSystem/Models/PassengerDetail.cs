using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class PassengerDetail
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? PNRNumber { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }

        public string? ContactNumber { get; set; }

        [ForeignKey("PNRNumber")]
        public Reservation PNRNumberId { get; set; }
    }
}
