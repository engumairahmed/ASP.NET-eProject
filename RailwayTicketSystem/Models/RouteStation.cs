using static System.Collections.Specialized.BitVector32;

namespace RailwayTicketSystem.Models
{
    public class RouteStation
    {
        public int RouteStationId { get; set; }

        // Foreign key to the Route table
        public int RouteId { get; set; }
        public Route Route { get; set; }

        // Foreign key to the Station table
        public int StationId { get; set; }
        public Station Station { get; set; }

        // Order of the station in the route
        public int Order { get; set; }
    }
}
