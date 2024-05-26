using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Domain.Services
{
    public class CourierServices : ICourierServices
    {
        private readonly ICourierRepository _courierRepository;

        public CourierServices(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }
        public async Task<(bool sucess, string message)> CreateCourier(Courier courier)
        {
            return await _courierRepository.Create(courier);
        }
    }
}
