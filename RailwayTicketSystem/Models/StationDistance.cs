using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class StationDistance
    {
        [Key]
        public int StationDistanceId { get; set; }
        public int FromStationId { get; set; }
        public int ToStationId { get; set; }
        public int Distance { get; set; }

        public Station FromStation {  get; set; }
        public Station ToStation { get; set; }
    }
}
