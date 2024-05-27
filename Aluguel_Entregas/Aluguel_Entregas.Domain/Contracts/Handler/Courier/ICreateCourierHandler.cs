using Aluguel_Entregas.Domain.Commands.Courier;

namespace Aluguel_Entregas.Domain.Contracts.Handler.Courier
{
    public interface ICreateCourierHandler
    {
        Task<(bool sucess, string message)> Handle(CreateCourierCommand createCourierCommand);
    }
}
