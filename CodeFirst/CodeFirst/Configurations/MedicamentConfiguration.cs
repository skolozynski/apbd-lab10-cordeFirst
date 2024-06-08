using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.ToTable("medicaments");

        builder.HasKey(e => e.IdMedicament);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(100);
        builder.Property(e => e.Type).HasMaxLength(100);
        
        builder.HasData(new List<Medicament>()
        {
            new() { IdMedicament = 1, Name = "Paracetamol", Description = "Description1", Type = "Przeciwbólowy"},
            new() { IdMedicament = 2, Name = "Ibuprom", Description = "Coś na ból głowy", Type = "Przeciwbólowy"},
            new() { IdMedicament = 3, Name = "Antybiotyk", Description = "Jakiś tam antybiotyk", Type = "Antybiotyk"}
        });
    }
}