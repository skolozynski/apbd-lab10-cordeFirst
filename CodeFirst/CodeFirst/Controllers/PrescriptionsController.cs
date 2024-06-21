using CodeFirst.DTOs;
using CodeFirst.Repositories;
using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IPatientService _patientService;

    public PrescriptionsController(IPrescriptionService prescriptionService, 
                                    IPrescriptionRepository prescriptionRepository, 
                                    IPatientRepository patientRepository, 
                                    IPatientService patientService)
    {
        _prescriptionService = prescriptionService;
        _prescriptionRepository = prescriptionRepository;
        _patientRepository = patientRepository;
        _patientService = patientService;
    }


    [HttpPost]
    public async Task<IActionResult> AddPrescription(NewPrescriptionDto newPrescriptionDto)
    {
        if (newPrescriptionDto.Medicaments.Count > 10)
            return BadRequest("There can be only 10 medicaments on one prescription!");
        
        if (!await _prescriptionService.DoesMedicamentsExist(newPrescriptionDto.Medicaments))
            return BadRequest("One or more medicaments do not exist in the database!");
        
        if (!await _prescriptionService.IsDateValid(newPrescriptionDto))
            return BadRequest("Due date must be later than issue date!");

        var id = await _prescriptionRepository.AddPrescription(newPrescriptionDto);
        
        return Ok($"Prescription added with id = {id}");
    }
    
    
}