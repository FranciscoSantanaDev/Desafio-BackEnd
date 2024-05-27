using Aluguel_Entregas.Domain.Entities;
using Aluguel_Entregas.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel_Entregas.Infra.Contexts.Mappings;

public class RentMapping : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.ToTable("Rent");

        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.RentalPlans)
            .IsRequired();

        builder
            .Property(r => r.StartDate)
            .IsRequired();

        builder
            .Property(r => r.EndDate)
            .IsRequired();

        builder
            .Property(r => r.ExpectedDate)
            .IsRequired();

        builder
            .Property(r => r.TotalValue)
            .IsRequired();

        builder
            .HasOne(r => r.Courier);

        builder
            .HasOne(r => r.Motorcycle).WithOne(r=>r.Rent).HasPrincipalKey<Motorcycle>(m=>m.Id);

        builder
           .HasOne(r => r.Courier).WithMany(r => r.Rents).HasPrincipalKey(m => m.Id);
    }
}