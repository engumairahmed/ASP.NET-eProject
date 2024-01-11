using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class StationDistance
    {
        [Key]
        public int StationDistanceId { get; set; }

        [Display(Name = "From Station")]
        [Required]
        public int FromStationId { get; set; }

        [Display(Name = "To Station")]
        [Required]
        public int ToStationId { get; set; }

        [Display(Name = "Distance Between stations in Miles")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter only Number")]
        public int Distance { get; set; }

        [ForeignKey("FromStationId")]
        public Station FromStation {  get; set; }
        [ForeignKey("ToStationId")]
        public Station ToStation { get; set; }
    }
}
