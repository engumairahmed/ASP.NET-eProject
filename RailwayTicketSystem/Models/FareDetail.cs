using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class FareDetail
    {
        [Key]
        public int Id { get; set; }
        public int Distance { get; set; }
        public int TypeOfCompartment { get; set; }
        public string TypeOfTrain { get; set; }
    }
}
