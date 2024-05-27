using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Contracts.Repository.Rent;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Domain.Services
{
    public class RentServices : IRentServices
    {
        private readonly IRentRepository _rentRepository;

        public RentServices(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }
        public async Task<(bool sucess, string message)> CreateRent(Rent rent)
        {
            return await _rentRepository.Create(rent);
        }

        public async Task<(bool sucess, string message)> UpdateRent(Rent rent)
        {
            return await _rentRepository.Update(rent);
        }
    }
}
