using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Domain.Contracts.Repository.Motorcycle
{
    public interface IMotorcycleRepository
    {
        Task<(bool sucess, string message)> Create(Entities.Motorcycle motorcycle);

        Task<(bool sucess, string message)> Update(Entities.Motorcycle motorcycle);

        Task<(bool sucess, string message)> Delete(Entities.Motorcycle motorcycle);

        Task<IEnumerable<Entities.Motorcycle>> Get(string? plate);

        Task<Entities.Motorcycle> Get(Guid Id);

        Task<Entities.Motorcycle> GetAvailable();
    }
}
