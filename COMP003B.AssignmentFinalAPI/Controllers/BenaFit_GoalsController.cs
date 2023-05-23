using COMP003B.AssignmentFinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.AssignmentFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenaFit_GoalsController : Controller
    {
        private List<BenaFit_Goal> _BenaFit_Goals = new List<BenaFit_Goal>();
        public BenaFit_GoalsController()
        {
            _BenaFit_Goals.Add(new BenaFit_Goal { GoalId = 1, GoalWeight = "Enter Goal Weight", GoalHealth = "Enter Goal Health", GoalBenchPress = "Enter Goal Bench Press", GoalSquat = "Enter Squat Goal", GoalArmCurl = "Enter Goal Arm Curl", GoalMileTime = "Enter Goal Mile Time", GoalStatus = "Enter Goal Status" });
            _BenaFit_Goals.Add(new BenaFit_Goal { GoalId = 2, GoalWeight = "Enter Goal Weight", GoalHealth = "Enter Goal Health", GoalBenchPress = "Enter Goal Bench Press", GoalSquat = "Enter Squat Goal", GoalArmCurl = "Enter Goal Arm Curl", GoalMileTime = "Enter Goal Mile Time", GoalStatus = "Enter Goal Status" });
            _BenaFit_Goals.Add(new BenaFit_Goal { GoalId = 3, GoalWeight = "Enter Goal Weight", GoalHealth = "Enter Goal Health", GoalBenchPress = "Enter Goal Bench Press", GoalSquat = "Enter Squat Goal", GoalArmCurl = "Enter Goal Arm Curl", GoalMileTime = "Enter Goal Mile Time", GoalStatus = "Enter Goal Status" });
            _BenaFit_Goals.Add(new BenaFit_Goal { GoalId = 4, GoalWeight = "Enter Goal Weight", GoalHealth = "Enter Goal Health", GoalBenchPress = "Enter Goal Bench Press", GoalSquat = "Enter Squat Goal", GoalArmCurl = "Enter Goal Arm Curl", GoalMileTime = "Enter Goal Mile Time", GoalStatus = "Enter Goal Status" });
            _BenaFit_Goals.Add(new BenaFit_Goal { GoalId = 5, GoalWeight = "Enter Goal Weight", GoalHealth = "Enter Goal Health", GoalBenchPress = "Enter Goal Bench Press", GoalSquat = "Enter Squat Goal", GoalArmCurl = "Enter Goal Arm Curl", GoalMileTime = "Enter Goal Mile Time", GoalStatus = "Enter Goal Status" });

        }
        [HttpGet]
        public ActionResult<IEnumerable<BenaFit_Goal>> GetallBenaFit_Goals()
        {
            return _BenaFit_Goals;
        }
        //Read
        [HttpGet("{id}")]
        public ActionResult<BenaFit_Goal> GetBenaFit_GoalById(int id)
        {
            var benaFit_Goal = _BenaFit_Goals.Find(s => s.GoalId == id);
            if (benaFit_Goal == null)
            {
                return NotFound();
            }
            return benaFit_Goal;
        }
        //Read 
        [HttpPost]
        public ActionResult<BenaFit_Goal> CreateBenaFit_Goal(BenaFit_Goal benaFit_Goal)
        {
            benaFit_Goal.GoalId = _BenaFit_Goals.Max(s => s.GoalId) + 1;
            _BenaFit_Goals.Add(benaFit_Goal);
            return CreatedAtAction(nameof(GetBenaFit_GoalById), new { id = benaFit_Goal.GoalId }, benaFit_Goal );
        }


        [HttpPut]
        public IActionResult UpdateBenaFit_Goal(int id, BenaFit_Goal updatedBenaFit_Goal)
        {
            var benaFit_Goal = _BenaFit_Goals.Find(s => s.GoalId == id);

            if (benaFit_Goal == null)
            {
                return BadRequest();
            }
            benaFit_Goal.GoalWeight = updatedBenaFit_Goal.GoalWeight;
            benaFit_Goal.GoalHealth = updatedBenaFit_Goal.GoalHealth;
            benaFit_Goal.GoalBenchPress = updatedBenaFit_Goal.GoalBenchPress;
            benaFit_Goal.GoalSquat = updatedBenaFit_Goal.GoalSquat;
            benaFit_Goal.GoalArmCurl = updatedBenaFit_Goal.GoalArmCurl;
            benaFit_Goal.GoalMileTime = updatedBenaFit_Goal.GoalMileTime;
            benaFit_Goal.GoalStatus = updatedBenaFit_Goal.GoalStatus;

            return NoContent();

        }
        //Delete
        [HttpDelete]
        public IActionResult DeleteBenaFit_Goal(int id)
        {
            var benaFit_Trainer = _BenaFit_Goals.Find(s => s.GoalId == id);

            if (benaFit_Trainer == null)
            {
                return NotFound();
            }
            _BenaFit_Goals.Remove(benaFit_Trainer);
            return NoContent();
        }
    }
}
