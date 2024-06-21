using CodeFirst.DTOs;

namespace CodeFirst.Services;

public interface IPrescriptionService
{
    Task<bool> DoesMedicamentsExist(List<MedicamentDto> medicaments);
    Task<bool> IsDateValid(NewPrescriptionDto newPrescriptionDto);
}