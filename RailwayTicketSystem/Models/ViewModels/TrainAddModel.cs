namespace RailwayTicketSystem.Models.ViewModels
{
    public class TrainAddModel
    {
        public List<Train> Trains { get; set; }

        public Train Train {  get; set; }
        public List<Compartment> Compartments { get; set; }
        public List<Coach> Coaches { get; set; }
        public Coach Coach {  get; set; }
        public int SelectedCompartmentId { get; set; }
    }
}
