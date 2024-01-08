namespace RailwayTicketSystem.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteDescription { get; set; }

        public ICollection<RouteStation> RouteStations { get; set; }
    }
}
