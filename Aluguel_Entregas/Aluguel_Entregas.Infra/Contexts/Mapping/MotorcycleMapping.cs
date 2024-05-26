using Aluguel_Entregas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel_Entregas.Infra.Contexts.Mappings;

public class MotorcycleMapping : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.ToTable("Motorcycle");

        builder
            .Property(c => c.Id)
            .IsRequired();

        builder
            .HasKey(c => c.Id);

        builder.Property(c => c.Model)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(c => c.Year)
            .IsRequired();

        builder.Property(c => c.Plate)
           .HasColumnType("varchar(7)")
           .IsRequired();

        builder.HasIndex(c => c.Plate).IsUnique();    

    }
}