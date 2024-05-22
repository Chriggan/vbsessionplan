using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using vbsessionplan.Models;

namespace vbsessionplan.Controllers;

[ApiController]
[Route("[controller]")]
public class ExercisesController(ILogger<ExercisesController> logger) : ControllerBase
{
    private readonly ILogger<ExercisesController> _logger = logger;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> Get()
    {
        return Ok();
    }
}
