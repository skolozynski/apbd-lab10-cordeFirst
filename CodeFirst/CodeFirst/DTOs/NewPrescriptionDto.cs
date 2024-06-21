using System.ComponentModel.DataAnnotations;

namespace CodeFirst.DTOs;

public class NewPrescriptionDto
{
    [Required]
    public PatientDto Patient { get; set; }
    [Required]
    public List<MedicamentDto> Medicaments { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public DateOnly DueDate { get; set; }
    [Required]
    public int IdDoctor { get; set; }
}

public class PatientDto
{
    [Required]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateOnly BirthDate { get; set; }
}