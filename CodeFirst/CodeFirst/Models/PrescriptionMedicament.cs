namespace CodeFirst.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; } = string.Empty;
    
    public Medicament Medicament { get; set; }
    public Prescription Prescription { get; set; }
}