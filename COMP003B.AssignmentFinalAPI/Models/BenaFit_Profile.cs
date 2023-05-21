using System.ComponentModel.DataAnnotations;

namespace COMP003B.AssignmentFinalAPI.Models
{
    public class BenaFit_Profile
    {
        public int ProfileId { get; set; }

        public string ProfileHeight { get; set; }
      
        public string ProfileWeight { get; set; }
        
        public string ProfileGender { get; set; }
    }
}
