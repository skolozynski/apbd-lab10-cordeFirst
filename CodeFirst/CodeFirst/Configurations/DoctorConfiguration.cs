using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("doctors");

        builder.HasKey(e => e.IdDoctor);
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.Email).HasMaxLength(100);

        builder.HasData(new List<Doctor>()
        {
            new Doctor() { IdDoctor = 1, FirstName = "John", LastName = "Travolta", Email ="jtravolta@email.com" },
            new Doctor() { IdDoctor = 2, FirstName = "Adam", LastName = "Wiśniewski", Email ="adamw@email.com" },
            new Doctor() { IdDoctor = 3, FirstName = "Cezary", LastName = "Hilton", Email ="chilton@email.com" }
        });
    }
}