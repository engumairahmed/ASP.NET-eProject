﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTicketSystem.Models
{
    public class TrainSchedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int TrainId { get; set; }
        public bool Direction { get; set; }
        public string Date { get; set; }
        public int RouteId { get; set; }

        [ForeignKey("TrainId")]
        public Train Train { get; set; }
        [ForeignKey("RouteId")]
        public TrainRoute Route { get; set; }

    }
}
