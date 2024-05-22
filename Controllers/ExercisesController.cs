using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using vbsessionplan.DAO;
using vbsessionplan.Models;

namespace vbsessionplan.Controllers;

[ApiController]
[Route("[controller]")]
public class ExercisesController(ILogger<ExercisesController> logger, ExercisesDAO exercisesDAO) : ControllerBase
{
    private readonly ILogger<ExercisesController> _logger = logger;
    private readonly ExercisesDAO _exercisesDAO = exercisesDAO;
    

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        return Ok(await _exercisesDAO.GetExercises());
    }
}
