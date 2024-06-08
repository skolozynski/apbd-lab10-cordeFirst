namespace CodeFirst.Models;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }

    public  ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}