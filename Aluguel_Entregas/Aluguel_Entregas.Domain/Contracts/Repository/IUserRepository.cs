
using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Domain.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUser(string username);
    }
}
