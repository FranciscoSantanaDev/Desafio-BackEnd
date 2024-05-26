using Aluguel_Entregas.Domain.Contracts.Repository;
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
        }
    }
}
