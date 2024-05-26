using Aluguel_Entregas.Domain.Commands.Moto;
using Aluguel_Entregas.Domain.Contracts.Handler;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain;

namespace Aluguel_Entregas.Application.Feature.Motorcycle
{
    public class CreateMotorcycleHandler : ICrateMotorcycleHandler
    {
        IMotorcycleServices _motorcycleServices;
        public CreateMotorcycleHandler(IMotorcycleServices motorcycleServices)
        {
            _motorcycleServices = motorcycleServices;
        }
        public async Task Handle(CreateMotorcycleCommand command)
        {
            Domain.Entities.Motorcycle motorcycle = new Domain.Entities.Motorcycle(command.Year,command.Model,command.Plate);
            await _motorcycleServices.CreateMotorcycle(motorcycle);
        }
    }
}
