using CodeFirst.DTOs;

namespace CodeFirst.Repositories;

public interface IPrescriptionRepository
{
    Task<int> AddPrescription(NewPrescriptionDto newPrescriptionDto);
}