using System.ComponentModel.DataAnnotations;

namespace COMP003B.AssignmentFinalAPI.Models
{
    public class BenaFit_Trainer
    {
        public int TrainerId { get; set; }

        [Required]
        public string TrainerName { get; set; }

        [Required]
        public string TrainerGender { get; set; }


        public int Age { get; set; } 
    }
}
