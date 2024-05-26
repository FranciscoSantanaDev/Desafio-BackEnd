using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Entities;

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

        public async Task<(bool sucess, string message)> UpdateMotorcycle(Motorcycle motorcycle)
        {
            return await _motorcycleRepository.Update(motorcycle);
        }

        public async Task<Motorcycle> Get(Guid Id)
        {
            return await _motorcycleRepository.Get(Id);
        }
    }
}
