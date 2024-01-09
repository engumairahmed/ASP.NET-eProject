using System.ComponentModel.DataAnnotations;

namespace RailwayTicketSystem.Models
{
    public class TrainDetail
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
        public string? Route { get; set; }

        [Display(Name = "Number of Compartments")]
        [Required(ErrorMessage = "This field is required")]
        public int NumberOfCompartments { get; set; }

        [Display(Name = "Number of AC1 type compartments")]
        [Required(ErrorMessage = "This field is required")]
        public int AC1 { get; set; }

        [Display(Name = "Number of AC2 type compartments")]
        [Required(ErrorMessage = "This field is required")]
        public int AC2 { get; set; }
        
        [Display(Name = "Number of AC3 type compartments")]
        [Required(ErrorMessage = "This field is required")]
        public int AC3 { get; set; }
        
        [Display(Name = "Number of Sleeper type compartments")]
        [Required(ErrorMessage = "This field is required")]
        public int Sleeper { get; set; }
        
        [Display(Name = "Number of General type compartments")]
        [Required(ErrorMessage = "This field is required")]
        public int General { get; set; }

        // Navigation properties
        public ICollection<PassengerDetail>? Passengers { get; set; }
        public ICollection<TrainSchedule>? Schedules { get; set; }
    }
}
