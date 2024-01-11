using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class Train
    {
        [Key]
        public int T_Id { get; set; }

        [Display(Name = "Train No.")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Train field is required")]
        public int TrainNo { get; set; }

        [Display(Name = "Train Name")]
        [Required(ErrorMessage = "This field is required")]
        public string? TrainName { get; set; }

        public ICollection<Coach> Coaches { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<TrainRoute> TrainRoutes { get; set; }
        public ICollection<TrainSchedule> TrainSchedules { get; set; }
        public ICollection<TrainCompartment> TrainCompartments { get; set; }
        public ICollection<FareDetail> FareDetails { get; set; }
    }
}
