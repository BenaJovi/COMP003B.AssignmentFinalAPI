using COMP003B.AssignmentFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
namespace COMP003B.AssignmentFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenaFit_ProfileController : Controller
    {
        
        private List<BenaFit_Profile> _fBenaFit_Profile = new List<BenaFit_Profile>();
        public BenaFit_ProfileController()
        {
            _fBenaFit_Profile.Add(new BenaFit_Profile { ProfileId = 1, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight", ProfileGender = "Enter Gender" });
            _fBenaFit_Profile.Add(new BenaFit_Profile { ProfileId = 2, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight ", ProfileGender = "Enter Gender" });
            _fBenaFit_Profile.Add(new BenaFit_Profile { ProfileId = 3, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight", ProfileGender = "Enter Gender" });
            _fBenaFit_Profile.Add(new BenaFit_Profile { ProfileId = 4, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight", ProfileGender = "Enter Gender" });
            _fBenaFit_Profile.Add(new BenaFit_Profile { ProfileId = 5, ProfileHeight = "Enter Height", ProfileWeight = "Enter Weight", ProfileGender = "Enter Gender" });

        }
        [HttpGet]
        public ActionResult<IEnumerable<BenaFit_Profile>> GetallBenaFit_Profile()
        {
            return _fBenaFit_Profile;
        }
        //Read
        [HttpGet("{id}")]
        public ActionResult<BenaFit_Profile> GetBenaFit_ProfileById(int id)
        {
            var benaFit_Profile = _fBenaFit_Profile.Find(s => s.ProfileId == id);
            if (benaFit_Profile == null)
            {
                return NotFound();
            }
            return benaFit_Profile;
        }
        //Read
        [HttpPost]
        public ActionResult<BenaFit_Profile> CreateMusic(BenaFit_Profile benaFit_Profile)
        {
            benaFit_Profile.ProfileId = _fBenaFit_Profile.Max(s => s.ProfileId) + 1;
            _fBenaFit_Profile.Add(benaFit_Profile);
            return CreatedAtAction(nameof(GetBenaFit_ProfileById), new { id = benaFit_Profile.ProfileId, benaFit_Profile });
        }
        [HttpPut]
        public IActionResult UpdateMusic(int id, BenaFit_Profile updatedBenaFit_Profile)
        {
            var benaFit_Profile = _fBenaFit_Profile.Find(s => s.ProfileId == id);

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
        public IActionResult DeleteMusic(int id)
        {
            var benaFit_Profile = _fBenaFit_Profile.Find(s => s.ProfileId == id);

            if (benaFit_Profile == null)
            {
                return NotFound();
            }
            _fBenaFit_Profile.Remove(benaFit_Profile);
            return NoContent();
        }
    }
}
