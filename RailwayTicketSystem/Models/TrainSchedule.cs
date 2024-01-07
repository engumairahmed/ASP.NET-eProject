using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class TrainSchedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public string TrainNumber { get; set; }
        public int StationId { get; set; }
        public int Distance { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }

        // Navigation properties
        public TrainDetail Train { get; set; }
        public StationDetail Station { get; set; }
    }
}
