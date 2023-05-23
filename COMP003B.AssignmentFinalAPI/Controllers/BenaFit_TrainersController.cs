using COMP003B.AssignmentFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.AssignmentFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenaFit_TrainersController : Controller
    {
        private List<BenaFit_Trainer> _BenaFit_Trainers = new List<BenaFit_Trainer>();
        public BenaFit_TrainersController()
        {
            _BenaFit_Trainers.Add(new BenaFit_Trainer { TrainerId = 1, TrainerName = "Enter Name", TrainerGender = "Enter Gender"});
            _BenaFit_Trainers.Add(new BenaFit_Trainer { TrainerId = 2, TrainerName = "Enter Name", TrainerGender = "Enter Gender" });
            _BenaFit_Trainers.Add(new BenaFit_Trainer { TrainerId = 3, TrainerName = "Enter Name", TrainerGender = "Enter Gender" });
            _BenaFit_Trainers.Add(new BenaFit_Trainer { TrainerId = 4, TrainerName = "Enter Name", TrainerGender = "Enter Gender" });
            _BenaFit_Trainers.Add(new BenaFit_Trainer { TrainerId = 5, TrainerName = "Enter Name", TrainerGender = "Enter Gender" });

        }
        [HttpGet]
        public ActionResult<IEnumerable<BenaFit_Trainer>> GetallBenaFit_Trainer()
        {
            return _BenaFit_Trainers;
        }
        //Read
        [HttpGet("{id}")]
        public ActionResult<BenaFit_Trainer> GetBenaFit_TrainerById(int id)
        {
            var benaFit_Trainer = _BenaFit_Trainers.Find(s => s.TrainerId == id);
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
            benaFit_Trainer.TrainerId = _BenaFit_Trainers.Max(s => s.TrainerId) + 1;
            _BenaFit_Trainers.Add(benaFit_Trainer);
            return CreatedAtAction(nameof(GetBenaFit_TrainerById), new { id = benaFit_Trainer.TrainerId }, benaFit_Trainer );
        }
        [HttpPut]
        public IActionResult UpdateBenaFit_Trainer(int id, BenaFit_Trainer updatedbenaFit_Trainer)
        {
            var benaFit_Trainer = _BenaFit_Trainers.Find(s => s.TrainerId == id);

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
            var benaFit_Trainer = _BenaFit_Trainers.Find(s => s.TrainerId == id);

            if (benaFit_Trainer == null)
            {
                return NotFound();
            }
            _BenaFit_Trainers.Remove(benaFit_Trainer);
            return NoContent();
        }
    }
}
