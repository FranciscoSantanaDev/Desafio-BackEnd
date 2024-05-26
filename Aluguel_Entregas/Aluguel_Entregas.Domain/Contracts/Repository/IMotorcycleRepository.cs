
using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Domain.Contracts.Repository
{
    public interface IMotorcycleRepository
    {
        Task<(bool sucess, string message)> Create(Motorcycle motorcycle);

        Task<(bool sucess, string message)> Update(Motorcycle motorcycle);

        Task<(bool sucess, string message)> Delete (Motorcycle motorcycle);

        Task<IEnumerable<Motorcycle>> Get(string? plate);

        Task<Motorcycle> Get(Guid Id);

    }
}
