using Aluguel_Entregas.Domain.Commands.Motorcycle;

namespace Aluguel_Entregas.Domain.Contracts.Handler
{
    public interface ICreateMotorcycleHandler
    {
        Task<(bool sucess, string message)> Handle(CreateMotorcycleCommand createMotorcycleCommand);
    }
}
