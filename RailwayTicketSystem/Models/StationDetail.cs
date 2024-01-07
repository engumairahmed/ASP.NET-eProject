using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class StationDetail
    {
        [Key]
        public int StationId { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public int Sequence { get; set; }
        public string RailwayDivisionName { get; set; }

        // Navigation properties
        public ICollection<TrainSchedule> TrainSchedules { get; set; }
    }
}
