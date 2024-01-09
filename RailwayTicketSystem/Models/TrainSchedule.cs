using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class TrainSchedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public string TrainNumber { get; set; }
        public int StationId { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }

        // Navigation properties
        public TrainDetail Train { get; set; }
        public Station Station { get; set; }
    }
}
