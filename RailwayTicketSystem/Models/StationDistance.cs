using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class StationDistance
    {
        [Key]
        public int StationDistanceId { get; set; }
        public int FromStation { get; set; }
        public int ToStation { get; set; }
        public int Distance { get; set; }

        public ICollection<Station> FStations {  get; set; }
        public ICollection<Station> TStations { get; set; }
    }
}
