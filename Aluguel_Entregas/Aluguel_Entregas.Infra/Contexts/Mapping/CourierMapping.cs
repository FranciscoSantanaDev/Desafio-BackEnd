using Aluguel_Entregas.Domain.Entities;
using Aluguel_Entregas.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel_Entregas.Infra.Contexts.Mappings;

public class CourierMapping : IEntityTypeConfiguration<Courier>
{
    public void Configure(EntityTypeBuilder<Courier> builder)
    {
        builder.ToTable("Courier");

        builder
            .Property(c => c.Id)
            .IsRequired();

        builder
            .HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(c => c.Cnpj)
            .HasColumnType("varchar(18)")
            .IsRequired();

        builder.Property(c => c.Birth)
           .HasColumnType("TIMESTAMP")
           .IsRequired();

        builder.Property(c => c.License)
             .HasColumnType("varchar(11)")
            .IsRequired();

        builder.Property(c => c.LicensesType)
            .IsRequired();

        builder.HasIndex(c => c.Cnpj)
            .IsUnique();

        builder.HasIndex(c => c.License)
            .IsUnique();

        builder.HasOne(c => c.User);
    }
}