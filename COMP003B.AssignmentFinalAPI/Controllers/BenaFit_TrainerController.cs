using COMP003B.AssignmentFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.AssignmentFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenaFit_TrainerController : Controller
    {
        private List<BenaFit_Trainer> _fBenaFit_Trainer = new List<BenaFit_Trainer>();
        public BenaFit_TrainerController()
        {
            _fBenaFit_Trainer.Add(new BenaFit_Trainer { TrainerId = 1, TrainerName = "Enter Name", TrainerGender = "Enter Gender"});
            _fBenaFit_Trainer.Add(new BenaFit_Trainer { TrainerId = 2, TrainerName = "Enter Name", TrainerGender = "Enter Gender" });
            _fBenaFit_Trainer.Add(new BenaFit_Trainer { TrainerId = 3, TrainerName = "Enter Name", TrainerGender = "Enter Gender" });
            _fBenaFit_Trainer.Add(new BenaFit_Trainer { TrainerId = 4, TrainerName = "Enter Name", TrainerGender = "Enter Gender" });
            _fBenaFit_Trainer.Add(new BenaFit_Trainer { TrainerId = 5, TrainerName = "Enter Name", TrainerGender = "Enter Gender" });

        }
        [HttpGet]
        public ActionResult<IEnumerable<BenaFit_Trainer>> GetallBenaFit_Trainer()
        {
            return _fBenaFit_Trainer;
        }
        //Read
        [HttpGet("{id}")]
        public ActionResult<BenaFit_Trainer> GetBenaFit_TrainerById(int id)
        {
            var benaFit_Trainer = _fBenaFit_Trainer.Find(s => s.TrainerId == id);
            if (benaFit_Trainer == null)
            {
                return NotFound();
            }
            return benaFit_Trainer;
        }
        //Read
        [HttpPost]
        public ActionResult<BenaFit_Trainer> CreateBenaFit_Trainer(BenaFit_Trainer benaFit_Trainer)
        {
            benaFit_Trainer.TrainerId = _fBenaFit_Trainer.Max(s => s.TrainerId) + 1;
            _fBenaFit_Trainer.Add(benaFit_Trainer);
            return CreatedAtAction(nameof(GetBenaFit_TrainerById), new { id = benaFit_Trainer.TrainerId, benaFit_Trainer });
        }
        [HttpPut]
        public IActionResult UpdateBenaFit_Trainer(int id, BenaFit_Trainer updatedbenaFit_Trainer)
        {
            var benaFit_Trainer = _fBenaFit_Trainer.Find(s => s.TrainerId == id);

            if (benaFit_Trainer == null)
            {
                return BadRequest();
            }
            benaFit_Trainer.TrainerName = updatedbenaFit_Trainer.TrainerName;
            benaFit_Trainer.TrainerGender = updatedbenaFit_Trainer.TrainerGender;
            

            return NoContent();

        }
        //Delete
        [HttpDelete]
        public IActionResult DeleteBenaFit_Trainer(int id)
        {
            var benaFit_Trainer = _fBenaFit_Trainer.Find(s => s.TrainerId == id);

            if (benaFit_Trainer == null)
            {
                return NotFound();
            }
            _fBenaFit_Trainer.Remove(benaFit_Trainer);
            return NoContent();
        }
    }
}
