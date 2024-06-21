using CodeFirst.Data;
using CodeFirst.DTOs;
using CodeFirst.Models;
using CodeFirst.Repositories;
using CodeFirst.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;
    private readonly IPatientRepository _patientRepository;
    
    public PatientsController(IPatientService patientService, IPatientRepository patientRepository)
    {
        _patientService = patientService;
        _patientRepository = patientRepository;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        if (!await _patientService.DoesPatientExistAsync(id))
            return NotFound($"Patient with id {id} not found.");
        var result = await _patientRepository.GetPatientAsync(id);
        return Ok(result);
    }
    
}