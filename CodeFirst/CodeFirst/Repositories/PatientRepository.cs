using CodeFirst.Data;
using CodeFirst.DTOs;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationContext _context;
    
    public PatientRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<PatientWithPrescriptionDTO> GetPatientAsync(int id)
    {
        var patient = await _context.Patients.Where(p => p.IdPatient == id)
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.PrescriptionMedicaments)
            .ThenInclude(p => p.Medicament).Include(patient => patient.Prescriptions)
            .ThenInclude(prescription => prescription.Doctor).FirstOrDefaultAsync();

        var result = new PatientWithPrescriptionDTO()
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = patient.Prescriptions.Select(p => new PrescriptionDto()
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentDto()
                {
                    IdMedicament = pm.Medicament.IdMedicament,
                    Name = pm.Medicament.Name,
                    Dose = pm.Dose,
                    Description = pm.Medicament.Description
                }).ToList(),
                Doctor = new DoctorDto()
                {
                    IdDoctor = p.Doctor.IdDoctor,
                    FirstName = p.Doctor.FirstName
                }
            }).ToList()
        };
            
        return result;
    }

    public async Task<int> AddPatient(PatientDto patientDto)
    {
        var patient = new Patient()
        {
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            BirthDate = patientDto.BirthDate
        };
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient.IdPatient;
    }
}