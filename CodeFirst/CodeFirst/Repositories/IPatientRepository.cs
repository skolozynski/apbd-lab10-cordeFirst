using CodeFirst.DTOs;
using CodeFirst.Models;

namespace CodeFirst.Repositories;

public interface IPatientRepository
{
    Task<PatientWithPrescriptionDTO> GetPatientAsync(int id);
    Task<int> AddPatient(PatientDto patientDto);
}