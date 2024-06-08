using CodeFirst.Models;

namespace CodeFirst.Services;

public interface IDbService
{
   Task<List<Patient>> GetPatient(int id);
   
}