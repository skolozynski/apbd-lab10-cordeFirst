using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable("prescriptions");
        
        builder.HasKey(e => e.IdPrescription);

        builder.HasOne(e => e.Doctor)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdDoctor);

        builder.HasOne(e => e.Patient)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdPatient);

        builder.HasData(new List<Prescription>()
        {
            new Prescription() { IdPrescription = 1, Date = new DateOnly(), DueDate = new DateOnly().AddDays(3), IdDoctor = 1, IdPatient = 1},
            new Prescription() { IdPrescription = 2, Date = new DateOnly(), DueDate = new DateOnly().AddDays(1), IdDoctor = 1, IdPatient = 2},
            new Prescription() { IdPrescription = 3, Date = new DateOnly().AddDays(2), DueDate = new DateOnly().AddDays(13), IdDoctor = 2, IdPatient = 3},
        });
    }
}