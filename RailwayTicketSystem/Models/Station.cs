using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class Station
    {
        [Key]
        public int StationId { get; set; }
        public string? StationCode { get; set; }
        public string? StationName { get; set; }
        public int? Sequence {  get; set; }
        public string? RailwayDivisionName { get; set; }

        [InverseProperty("FromStation")]
        public ICollection<StationDistance> FromStationDistances { get; set; }

        [InverseProperty("ToStation")]
        public ICollection<StationDistance> ToStationDistances { get; set; }
        public ICollection<TrainRoute> TrainRoutes { get; set; }
        public ICollection<TrainSchedule> TrainSchedules { get; set; }
    }
}