using Aluguel_Entregas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluguel_Entregas.Infra.Contexts.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
    builder.ToTable("User");

        builder
            .Property(c => c.Id)
            .IsRequired();

        builder
            .HasKey(c => c.Id);

        builder.Property(c => c.Username)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(c => c.Password)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(c => c.UserType)
           .IsRequired();

        builder.HasIndex(c => c.Username).IsUnique();
    }
}