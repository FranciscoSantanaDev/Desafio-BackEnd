
using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Domain.Contracts.Repository
{
    public interface ICourierRepository
    {
        Task<(bool sucess, string message)> Create(Courier courier);

        Task Update(Courier courier);

        Task Delete (Courier courier);
    }
}
