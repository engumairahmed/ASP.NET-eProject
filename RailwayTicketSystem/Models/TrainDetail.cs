using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class TrainDetail
    {
        [Key]
        public string TrainNo { get; set; }
        public string TrainName { get; set; }
        public string Route { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int NumberOfCompartments { get; set; }
        public int AC1 { get; set; }
        public int AC2 { get; set; }
        public int AC3 { get; set; }
        public int Sleeper { get; set; }
        public int General { get; set; }

        // Navigation properties
        public ICollection<PassengerDetail> Passengers { get; set; }
        public ICollection<TrainSchedule> Schedules { get; set; }
    }
}
