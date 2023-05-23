using COMP003B.AssignmentFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
namespace COMP003B.AssignmentFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenaFit_ProfilesController : Controller
    {
        
        private List<BenaFit_Profile> _BenaFit_Profiles = new List<BenaFit_Profile>();
        public BenaFit_ProfilesController()
        {
            _BenaFit_Profiles.Add(new BenaFit_Profile { ProfileId = 1, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight", ProfileGender = "Enter Gender" });
            _BenaFit_Profiles.Add(new BenaFit_Profile { ProfileId = 2, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight ", ProfileGender = "Enter Gender" });
            _BenaFit_Profiles.Add(new BenaFit_Profile { ProfileId = 3, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight", ProfileGender = "Enter Gender" });
            _BenaFit_Profiles.Add(new BenaFit_Profile { ProfileId = 4, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight", ProfileGender = "Enter Gender" });
            _BenaFit_Profiles.Add(new BenaFit_Profile { ProfileId = 5, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight", ProfileGender = "Enter Gender" });

        }
        [HttpGet]
        public ActionResult<IEnumerable<BenaFit_Profile>> GetallBenaFit_Profile()
        {
            return _BenaFit_Profiles;
        }
        //Read
        [HttpGet("{id}")]
        public ActionResult<BenaFit_Profile> GetBenaFit_ProfileById(int id)
        {
            var benaFit_Profile = _BenaFit_Profiles.Find(s => s.ProfileId == id);
            if (benaFit_Profile == null)
            {
                return NotFound();
            }
            return benaFit_Profile;
        }
        //Read
        [HttpPost]
        public ActionResult<BenaFit_Profile> CreateBenaFit_Profile(BenaFit_Profile benaFit_Profile)
        {
            benaFit_Profile.ProfileId = _BenaFit_Profiles.Max(s => s.ProfileId) + 1;
            _BenaFit_Profiles.Add(benaFit_Profile);
            return CreatedAtAction(nameof(GetBenaFit_ProfileById), new { id = benaFit_Profile.ProfileId }, benaFit_Profile );
        }
        [HttpPut]
        public IActionResult UpdateBenaFit_Profile(int id, BenaFit_Profile updatedBenaFit_Profile)
        {
            var benaFit_Profile = _BenaFit_Profiles.Find(s => s.ProfileId == id);

            if (benaFit_Profile == null)
            {
                return BadRequest();
            }
            benaFit_Profile.ProfileHeight = updatedBenaFit_Profile.ProfileHeight;
            benaFit_Profile.ProfileWeight = updatedBenaFit_Profile.ProfileWeight;
            benaFit_Profile.ProfileGender = updatedBenaFit_Profile.ProfileGender;

            return NoContent();

        }
        //Delete
        [HttpDelete]
        public IActionResult DeleteBenaFit_Profile(int id)
        {
            var benaFit_Profile = _BenaFit_Profiles.Find(s => s.ProfileId == id);

            if (benaFit_Profile == null)
            {
                return NotFound();
            }
            _BenaFit_Profiles.Remove(benaFit_Profile);
            return NoContent();
        }
    }
}
