using Aluguel_Entregas.Domain.Contracts.Repository.Courier;
using Aluguel_Entregas.Domain.Contracts.Repository.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Repository.Rent;
using Aluguel_Entregas.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Infra.Configuration
{
    public static class AddRepositoriesExtension
    {
        public static void ConfigureRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            serviceCollection.AddScoped<ICourierRepository, CourierRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IRentRepository, RentRepository>();
        }
    }
}
