namespace RailwayTicketSystem.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }

        public List<RouteStation> RouteStations { get; set; }
    }
}
