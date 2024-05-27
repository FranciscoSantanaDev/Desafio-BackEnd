
namespace Aluguel_Entregas.Domain.Contracts.Repository.Courier
{
    public interface ICourierRepository
    {
        Task<(bool sucess, string message)> Create(Entities.Courier courier);

        Task Update(Entities.Courier courier);

        Task Delete(Entities.Courier courier);
    }
}
