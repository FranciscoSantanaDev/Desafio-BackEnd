using Aluguel_Entregas.Domain.Contracts.Handler;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Commands.Motorcycle;

namespace Aluguel_Entregas.Application.Feature.Motorcycle
{
    public class CreateMotorcycleHandler : ICreateMotorcycleHandler
    {
        IMotorcycleServices _motorcycleServices;
        public CreateMotorcycleHandler(IMotorcycleServices motorcycleServices)
        {
            _motorcycleServices = motorcycleServices;
        }
        public async Task<(bool sucess, string message)> Handle(CreateMotorcycleCommand command)
        {
            Domain.Entities.Motorcycle motorcycle = new Domain.Entities.Motorcycle(command.Year,command.Model,command.Plate);
            return await _motorcycleServices.CreateMotorcycle(motorcycle);
        }
    }
}
