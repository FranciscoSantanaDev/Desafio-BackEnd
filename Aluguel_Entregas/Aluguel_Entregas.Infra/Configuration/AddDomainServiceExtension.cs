using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Aluguel_Entregas.Application.Feature.Motorcycle;
using Aluguel_Entregas.Application.Feature.Courier;
using Aluguel_Entregas.Infra.Authorization;
using Aluguel_Entregas.Domain.Contracts.Handler.Courier;
using Aluguel_Entregas.Domain.Contracts.Handler.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Handler.Rent;
using Aluguel_Entregas.Application.Feature.Rent;
namespace Aluguel_Entregas.Infra.Configuration
{
    public static class AddDomainServiceExtension
    {
        public static void AddDomainService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMotorcycleServices, MotorcycleServices>();
            serviceCollection.AddScoped<ICreateMotorcycleHandler, CreateMotorcycleHandler>();
            serviceCollection.AddScoped<IUpdateMotorcycleHandler, UpdateMotorcycleHandler>();
            serviceCollection.AddScoped<IDeleteMotorcycleHandler, DeleteMotorcycleHandler>();

            serviceCollection.AddScoped<ICourierServices, CourierServices>();
            serviceCollection.AddScoped<ICreateCourierHandler, CreateCourierHandler>();

            serviceCollection.AddScoped<IRentServices, RentServices>();
            serviceCollection.AddScoped<ICreateRentHandler, CreateRentHandler>();

            serviceCollection.AddScoped<IAuthManager, AuthManager>();

        }
    }
}
