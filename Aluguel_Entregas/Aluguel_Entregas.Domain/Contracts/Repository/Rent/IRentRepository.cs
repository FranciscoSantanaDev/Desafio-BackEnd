using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Domain.Contracts.Repository.Rent
{
    public interface IRentRepository
    {
        Task<(bool sucess, string message)> Create(Entities.Rent rent);

        Task<(bool sucess, string message)> Update(Entities.Rent rent);
    }
}
