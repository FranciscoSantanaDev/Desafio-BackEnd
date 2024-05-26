using Aluguel_Entregas.Domain.Contracts.Handler;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Aluguel_Entregas.Application.Feature.Motorcycle;
namespace Aluguel_Entregas.Infra.Configuration
{
    public static class AddDomainServiceExtension
    {
        public static void AddDomainService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMotorcycleServices, MotorcycleServices>();
            serviceCollection.AddScoped<ICrateMotorcycleHandler, CreateMotorcycleHandler>();

        }
    }
}
