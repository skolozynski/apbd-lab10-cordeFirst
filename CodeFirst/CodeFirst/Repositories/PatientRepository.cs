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
    
    public async Task<Object> GetPatientAsync(int id)
    {
        var result =  _context.Patients.Select(p =>
            new PatientWithPrescriptionDTO()
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Prescriptions = p.Prescriptions.Select( pp => new PrescriptionDto()
                {
                    IdPrescription = pp.IdPrescription,
                    Date = pp.Date,
                    Medicaments = pp.PrescriptionMedicaments.Select( pm => new MedicamentDto()
                    {
                        IdMedicament = pm.Medicament.IdMedicament,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose,
                        Description = pm.Medicament.Description
                    }).ToList(),
                    Doctor = new DoctorDto()
                    {
                        IdDoctor = pp.Doctor.IdDoctor,
                        FirstName = pp.Doctor.FirstName
                    }
                }).ToList()
            }).Where(p => p.IdPatient == id);
            
        return result;
    }
}