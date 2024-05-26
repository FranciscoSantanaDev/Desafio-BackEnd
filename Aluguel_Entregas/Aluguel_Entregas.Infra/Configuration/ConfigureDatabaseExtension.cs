using Aluguel_Entregas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aluguel_Entregas.Infra.Configurations;

public static class ConfigureDatabaseExtension
{
    public static void ConfigureDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(
            options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Aluguel_Entregas.Infra")
                ));
    }
}