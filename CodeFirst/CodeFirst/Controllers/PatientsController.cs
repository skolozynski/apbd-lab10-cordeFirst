using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPatients(int id)
    {
        return Ok(_dbService.GetPatient(id));
    }
    
}