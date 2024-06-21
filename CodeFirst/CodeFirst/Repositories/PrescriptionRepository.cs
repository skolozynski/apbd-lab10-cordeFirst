using CodeFirst.Data;
using CodeFirst.DTOs;
using CodeFirst.Models;
using CodeFirst.Services;

namespace CodeFirst.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly ApplicationContext _context;
    private readonly IPatientService _patientService;
    private readonly IPatientRepository _patientRepository;

    public PrescriptionRepository(ApplicationContext context,
                                IPatientService patientService,
                                IPatientRepository patientRepository)
    {
        _context = context;
        _patientService = patientService;
        _patientRepository = patientRepository;
    }

    public async Task<int> AddPrescription(NewPrescriptionDto newPrescriptionDto)
    {
        var patientId = newPrescriptionDto.Patient.IdPatient;
        if (!await _patientService.DoesPatientExistAsync(newPrescriptionDto.Patient.IdPatient))
            patientId = await _patientRepository.AddPatient(newPrescriptionDto.Patient);

        var prescription = new Prescription()
        {
            Date = newPrescriptionDto.Date,
            DueDate = newPrescriptionDto.DueDate,
            IdPatient = patientId,
            IdDoctor = newPrescriptionDto.IdDoctor
        };
        await _context.Prescriptions.AddAsync(prescription);
        foreach (var medcicamentDto in newPrescriptionDto.Medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament()
            {
                IdMedicament = medcicamentDto.IdMedicament,
                IdPrescription = prescription.IdPrescription,
                Dose = medcicamentDto.Dose,
                Details = medcicamentDto.Description
            };
            await _context.PrescriptionMedicaments.AddAsync(prescriptionMedicament);
        }
        await _context.SaveChangesAsync();
        
        return prescription.IdPrescription;
    }
}