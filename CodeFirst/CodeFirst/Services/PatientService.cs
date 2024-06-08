using CodeFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services;

public class PatientService : IPatientService
{
    private readonly ApplicationContext _context;
    
    public PatientService(ApplicationContext context)
    {
        _context = context;
    }
    
    
    public async Task<bool> DoesPatientExistAsync(int id)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == id);
    }
}