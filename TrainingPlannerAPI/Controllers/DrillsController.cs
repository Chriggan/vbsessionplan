using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using vbsessionplan.Contracts;
using vbsessionplan.DAO;
using vbsessionplan.Models;

namespace vbsessionplan.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrillsController(ILogger<DrillsController> logger, IDrillsDAO drillsDAO) : ControllerBase
{
    private readonly ILogger<DrillsController> _logger = logger;
    private readonly IDrillsDAO _drillsDAO = drillsDAO;


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Drill>>> GetDrills()
    {
        return Ok(await _drillsDAO.GetDrills());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Drill>> GetDrillById(string id)
    {
        return Ok(await _drillsDAO.GetDrillById(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> PostDrills(PostDrillRequest request)
    {
        await _drillsDAO.PostDrill(request);
        return Created();
    }
}