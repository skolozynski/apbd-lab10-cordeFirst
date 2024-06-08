namespace CodeFirst.Services;

public interface IPatientService
{
    Task<bool> DoesPatientExistAsync(int id);
}