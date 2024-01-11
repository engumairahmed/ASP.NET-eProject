using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class TrainRoute
    {
        [Key]
        public int RouteId { get; set; }
        public int TrainId { get; set; }
        public int StationId { get; set; }
        public int StopOrder { get; set; }
        public int ArrivalTime { get; set; }
        public int DepartureTime { get; set; }

        [ForeignKey("TrainId")]
        public Train Train { get; set; }
        [ForeignKey("StationId")]
        public Station Station { get; set; }
    }
}
