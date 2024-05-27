using Aluguel_Entregas.Domain.Commands.Motorcycle;

namespace Aluguel_Entregas.Domain.Contracts.Handler.Rent
{
    public interface ICreateRentHandler
    {
        Task<(bool sucess, string message)> Handle(CreateRentCommand createRentCommand);
    }
}
