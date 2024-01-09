using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class TicketDetail
    {
        [Key]
        public int Id { get; set; }
        public string? PnrNo { get; set; }
        public int? SeatNo { get; set; }
        public string? CoachNo { get; set; }
    }
}
