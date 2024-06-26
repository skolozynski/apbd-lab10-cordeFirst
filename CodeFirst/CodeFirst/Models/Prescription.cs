namespace CodeFirst.Models;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
}