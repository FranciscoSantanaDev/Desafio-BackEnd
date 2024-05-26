using Aluguel_Entregas.Domain.Contracts.Handler;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Commands.Motorcycle;

namespace Aluguel_Entregas.Application.Feature.Motorcycle
{
    public class UpdateMotorcycleHandler : IUpdateMotorcycleHandler
    {
        IMotorcycleServices _motorcycleServices;
        public UpdateMotorcycleHandler(IMotorcycleServices motorcycleServices)
        {
            _motorcycleServices = motorcycleServices;
        }
        public async Task<(bool sucess, string message)> Handle(UpdateMotorcycleCommand command)
        {
            var motorcycle = await _motorcycleServices.Get(command.Id);
            motorcycle.Update(command.Plate);
            return await _motorcycleServices.UpdateMotorcycle(motorcycle);
        }
    }
}
