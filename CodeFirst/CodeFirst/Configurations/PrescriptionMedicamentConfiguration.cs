using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.ToTable("prescriotion_medicaments");
        
        builder.HasKey(e => new { e.IdMedicament, e.IdPrescription });
        
        builder.Property(e => e.Details).HasMaxLength(100).IsRequired();

        builder.HasOne(e => e.Medicament)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdMedicament)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Prescription)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey( e => e.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<PrescriptionMedicament>()
        {
            new() { IdMedicament = 1, IdPrescription = 1, Dose = 2, Details = "Twice a day"},
            new() { IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "Once a day"},
            new() { IdMedicament = 3, IdPrescription = 1, Dose = 3, Details = "Three times a day"},
        });
    }
}