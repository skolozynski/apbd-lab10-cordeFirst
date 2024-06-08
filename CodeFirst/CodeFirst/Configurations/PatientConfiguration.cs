using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("patients");

        builder.HasKey(e => e.IdPatient);
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.BirthDate).HasColumnType("date");

        builder.HasData(new List<Patient>()
        {
            new Patient(){ IdPatient = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(1990, 1, 1)},
            new Patient() { IdPatient = 2, FirstName = "Ann", LastName = "Smith", BirthDate = new DateOnly(1991, 2, 2)},
            new Patient() { IdPatient = 3, FirstName = "Jack", LastName = "Taylor", BirthDate = new DateOnly(1992, 3, 3)},
            new Patient() { IdPatient = 4, FirstName = "Tom", LastName = "Brown", BirthDate = new DateOnly(1993, 4, 4)}
        });
    }
}