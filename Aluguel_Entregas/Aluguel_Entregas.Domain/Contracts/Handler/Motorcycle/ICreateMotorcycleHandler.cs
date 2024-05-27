using Aluguel_Entregas.Domain.Commands.Motorcycle;

namespace Aluguel_Entregas.Domain.Contracts.Handler.Motorcycle
{
    public interface ICreateMotorcycleHandler
    {
        Task<(bool sucess, string message)> Handle(CreateMotorcycleCommand createMotorcycleCommand);
    }
}
