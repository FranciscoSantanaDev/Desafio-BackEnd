using Aluguel_Entregas.Domain.Commands.Motorcycle;

namespace Aluguel_Entregas.Domain.Contracts.Handler
{
    public interface IUpdateMotorcycleHandler
    {
        Task<(bool sucess, string message)> Handle(UpdateMotorcycleCommand updateMotorcycleCommand);
    }
}
