using Aluguel_Entregas.Domain.Commands.Motorcycle;

namespace Aluguel_Entregas.Domain.Contracts.Handler.Motorcycle
{
    public interface IDeleteMotorcycleHandler
    {
        Task<(bool sucess, string message)> Handle(DeleteMotorcycleCommand deleteMotorcycleCommand);
    }
}
