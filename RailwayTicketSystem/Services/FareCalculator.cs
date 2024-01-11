using Microsoft.EntityFrameworkCore;
using RailwayTicketSystem.Data;

namespace RailwayTicketSystem.Services
{
    public class FareCalculator
    {
        private readonly ApplicationDbContext _dbContext;

        public FareCalculator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public decimal CalculateFare(int fromStationId, int toStationId, string trainType)
        {
            var distance = GetDistance(fromStationId, toStationId);
            var fareRate = GetFareRate(trainType);

            return distance * fareRate;
        }

        private decimal GetDistance(int fromStationId, int toStationId)
        {
            var orderedStations = _dbContext.Stations
            .Where(s => s.Sequence>= fromStationId && s.Sequence <= toStationId)
            .OrderBy(s => s.Sequence)
            .ToList();

            var totalDistance = 0;

            for (int i = 0; i < orderedStations.Count - 1; i++)
            {
                var fromStation = orderedStations[i].StationId;
                var toStation = orderedStations[i + 1].StationId;

                var distance = _dbContext.StationDistances
                    .Where(sd => sd.FromStationId == fromStation && sd.ToStationId == toStation)
                    .Select(sd => sd.Distance)
                    .FirstOrDefault();

                totalDistance += distance;
            }
            //var distance = _dbContext.s
            //    .Where(sd => sd.FromStationId == fromStationId && sd.ToStationId == toStationId)
            //    .Select(sd => sd.Distance)
            //    .FirstOrDefault();

            return totalDistance;
        }

        private decimal GetFareRate(string trainType)
        {
            // Implement logic to retrieve fare rate based on train type
            // This can be from a configuration table or any other source
            switch (trainType)
            {
                case "T1":
                    return 20.0m; // Replace with actual fare rate for T1
                case "T2":
                    return 25.0m; // Replace with actual fare rate for T2
                case "T3":
                    return 30.0m; // Replace with actual fare rate for T3
                default:
                    return 0.0m;  // Default fare rate if train type is not recognized
            }
        }
    }

}
