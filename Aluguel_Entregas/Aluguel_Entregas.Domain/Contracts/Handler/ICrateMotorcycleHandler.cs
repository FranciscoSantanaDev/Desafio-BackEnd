using Aluguel_Entregas.Domain.Commands.Moto;

namespace Aluguel_Entregas.Domain.Contracts.Handler
{
    public interface ICrateMotorcycleHandler
    {
        Task Handle(CreateMotorcycleCommand createMotorcycleCommand);
    }
}
