﻿using System.ComponentModel.DataAnnotations;

namespace COMP003B.AssignmentFinalAPI.Models
{
    public class BenaFit_Goal
    {
        public int GoalId { get; set; }

        [Required]
        public string GoalWeight { get; set; }
        [Required]
        public string GoalHealth { get; set; }
        [Required]
        public string GoalBenchPress { get; set; }
        [Required]
        public string GoalSquat { get; set; }
        [Required]
        public string GoalArmCurl { get; set; }
        [Required]

        public string GoalMileTime { get; set; }
        [Required]
        public string GoalStatus { get; set; }
    }
}
