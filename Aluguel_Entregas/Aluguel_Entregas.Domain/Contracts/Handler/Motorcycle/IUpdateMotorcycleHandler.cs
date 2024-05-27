using Aluguel_Entregas.Domain.Commands.Motorcycle;

namespace Aluguel_Entregas.Domain.Contracts.Handler.Motorcycle
{
    public interface IUpdateMotorcycleHandler
    {
        Task<(bool sucess, string message)> Handle(UpdateMotorcycleCommand updateMotorcycleCommand);
    }
}
