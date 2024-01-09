using System.ComponentModel.DataAnnotations;

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

        // Other properties...

        // Navigation property to TrainSchedules
        public ICollection<TrainSchedule> TrainSchedules { get; set; }
    }
}