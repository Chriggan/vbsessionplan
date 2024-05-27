using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using vbsessionplan.Contracts;
using vbsessionplan.DAO;
using vbsessionplan.Models;

namespace vbsessionplan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController(ILogger<ExercisesController> logger, IExercisesDAO exercisesDAO) : ControllerBase
{
    private readonly ILogger<ExercisesController> _logger = logger;
    private readonly IExercisesDAO _exercisesDAO = exercisesDAO;


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        return Ok(await _exercisesDAO.GetExercises());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises(string id)
    {
        return Ok(await _exercisesDAO.GetExerciseById(id));
    }

    [HttpPost]
    public async Task<IActionResult> PostExercises(PostExerciseRequest request)
    {
        await _exercisesDAO.PostExercise(request);
        return Created();
    }
}