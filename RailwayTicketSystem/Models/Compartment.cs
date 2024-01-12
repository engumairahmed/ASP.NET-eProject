using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class Compartment
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Class Name")]
        [RegularExpression("[a-zA-Z]", ErrorMessage = "Name should not contain numbers or special characters")]
        [Required]
        public string CompartmentName { get; set; }


        public ICollection<Coach> Coaches { get; set; }
        public ICollection<FareDetail> FareDetails { get; set; }
        public ICollection<TrainCompartment> TrainCompartments { get; set; }

    }
}
