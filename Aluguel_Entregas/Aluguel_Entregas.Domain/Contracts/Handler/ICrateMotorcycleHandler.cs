using Aluguel_Entregas.Domain.Commands.Moto;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel_Entregas.Domain.Contracts.Handler
{
    public interface ICrateMotorcycleHandler
    {
        Task<(bool sucess, string message)> Handle(CreateMotorcycleCommand createMotorcycleCommand);
    }
}
