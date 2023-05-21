using COMP003B.AssignmentFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.AssignmentFinalAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BenaFit_SpecialtyController : Controller
    {
        private List<BenaFit_Specialty> _fBenaFit_Specialty = new List<BenaFit_Specialty>();
        public BenaFit_SpecialtyController()
        {
            _fBenaFit_Specialty.Add(new BenaFit_Specialty { SpecialtyId = 1, SpecialtyName = "Enter Name", SpecialtyType = "Enter Type" });
            _fBenaFit_Specialty.Add(new BenaFit_Specialty { SpecialtyId = 2, SpecialtyName = "Enter Name", SpecialtyType = "Enter Type" });
            _fBenaFit_Specialty.Add(new BenaFit_Specialty { SpecialtyId = 3, SpecialtyName = "Enter Name", SpecialtyType = "Enter Type" });
            _fBenaFit_Specialty.Add(new BenaFit_Specialty { SpecialtyId = 4, SpecialtyName = "Enter Name", SpecialtyType = "Enter Type" });
            _fBenaFit_Specialty.Add(new BenaFit_Specialty { SpecialtyId = 5, SpecialtyName = "Enter Name", SpecialtyType = "Enter Type" });

        }
        [HttpGet]
        public ActionResult<IEnumerable<BenaFit_Specialty>> GetallBenaFit_Specialty()
        {
            return _fBenaFit_Specialty;
        }
        //Read
        [HttpGet("{id}")]
        public ActionResult<BenaFit_Specialty> GetBenaFit_SpecialtyById(int id)
        {
            var benaFit_Specialty = _fBenaFit_Specialty.Find(s => s.SpecialtyId == id);
            if (benaFit_Specialty == null)
            {
                return NotFound();
            }
            return benaFit_Specialty;
        }
        //Read
        [HttpPost]
        public ActionResult<BenaFit_Specialty> CreateBenaFit_Specialty(BenaFit_Specialty benaFit_Specialty)
        {
            benaFit_Specialty.SpecialtyId = _fBenaFit_Specialty.Max(s => s.SpecialtyId) + 1;
            _fBenaFit_Specialty.Add(benaFit_Specialty);
            return CreatedAtAction(nameof(GetBenaFit_SpecialtyById), new { id = benaFit_Specialty.SpecialtyId, benaFit_Specialty });
        }
        [HttpPut]
        public IActionResult UpdateBenaFit_Specialty(int id, BenaFit_Specialty updatedBenaFit_Specialty)
        {
            var benaFit_Specialty = _fBenaFit_Specialty.Find(s => s.SpecialtyId == id);

            if (benaFit_Specialty == null)
            {
                return BadRequest();
            }
            benaFit_Specialty.SpecialtyName = updatedBenaFit_Specialty.SpecialtyName;
            benaFit_Specialty.SpecialtyType = updatedBenaFit_Specialty.SpecialtyType;


            return NoContent();

        }
        //Delete
        [HttpDelete]
        public IActionResult DeleteBenaFit_Specialty(int id)
        {
            var benaFit_Specialty = _fBenaFit_Specialty.Find(s => s.SpecialtyId == id);

            if (benaFit_Specialty == null)
            {
                return NotFound();
            }
            _fBenaFit_Specialty.Remove(benaFit_Specialty);
            return NoContent();
        }
    }
}
