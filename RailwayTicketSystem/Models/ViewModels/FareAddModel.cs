using System.ComponentModel;

namespace RailwayTicketSystem.Models.ViewModels
{
    public class FareAddModel
    {
        public List<Train> Trains { get; set; }
        public Train Train { get; set; }
        public List<Compartment> Compartments { get; set; }
        public Compartment Compartment { get; set; }
        public List<FareDetail> FareDetails { get; set; }
        public FareDetail FareDetail { get; set; }
    }
}
