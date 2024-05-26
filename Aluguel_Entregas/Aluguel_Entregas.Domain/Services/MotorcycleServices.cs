using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Services
{
    public class MotorcycleServices : IMotorcycleServices
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleServices(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }
        public async Task<(bool sucess , string message)> CreateMotorcycle(Motorcycle motorcycle)
        {
            return await _motorcycleRepository.Create(motorcycle);
        }
    }
}
