
using Aluguel_Entregas.Domain.Entities;
using Aluguel_Entregas.Infra.Contexts.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Aluguel_Entregas.Infra.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<Courier> Courier { get; set; }
    public DbSet<User> User { get; set; }

    public DbSet<Rent> Rents { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new MotorcycleMapping().Configure(modelBuilder.Entity<Motorcycle>());
        new CourierMapping().Configure(modelBuilder.Entity<Courier>());
        new UserMapping().Configure(modelBuilder.Entity<User>());
        new RentMapping().Configure(modelBuilder.Entity<Rent>());
    }
}