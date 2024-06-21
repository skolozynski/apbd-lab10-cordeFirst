using CodeFirst.Data;
using CodeFirst.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services;

public class PrescriptionService : IPrescriptionService
{

    private readonly ApplicationContext _context;

    public PrescriptionService(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<bool> DoesMedicamentsExist(List<MedicamentDto> medicaments)
    {
        foreach( var medicament in medicaments)
        {
            if (!await _context.Medicaments.AnyAsync(e => e.IdMedicament == medicament.IdMedicament))
                return false;
        }
        return true;
    }

    public async Task<bool> IsDateValid(NewPrescriptionDto newPrescriptionDto)
    {
        return await Task.FromResult(newPrescriptionDto.DueDate >= newPrescriptionDto.Date);
    }
}