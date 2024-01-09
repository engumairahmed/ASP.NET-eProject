using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class PassengerDetail
    {
        [Key]
        public int PassengerId { get; set; }

        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public int? TotalPassenger { get; set; }
        public DateTime? DateOfTravel { get; set; }
        public string? Class { get; set; }

        // Foreign key
        public string? TrainNumber { get; set; }
        public TrainDetail? Train { get; set; }
    }
}
