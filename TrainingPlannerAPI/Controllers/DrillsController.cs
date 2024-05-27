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
    public async Task<ActionResult<IEnumerable<Drill>>> GetDrills(string id)
    {
        return Ok(await _drillsDAO.GetDrillById(id));
    }

    [HttpPost]
    public async Task<IActionResult> PostDrills(PostDrillRequest request)
    {
        await _drillsDAO.PostDrill(request);
        return Created();
    }
}