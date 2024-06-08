using CodeFirst.DTOs;
using CodeFirst.Models;

namespace CodeFirst.Repositories;

public interface IPatientRepository
{
    Task<Object?> GetPatientAsync(int id);
}