using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Commands.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Handler.Motorcycle;

namespace Aluguel_Entregas.Application.Feature.Motorcycle
{
    public class DeleteMotorcycleHandler : IDeleteMotorcycleHandler
    {
        IMotorcycleServices _motorcycleServices;
        public DeleteMotorcycleHandler(IMotorcycleServices motorcycleServices)
        {
            _motorcycleServices = motorcycleServices;
        }
        public async Task<(bool sucess, string message)> Handle(DeleteMotorcycleCommand command)
        {
            var motorcycle = await _motorcycleServices.Get(command.Id);

            //todo verificação de locação
            return await _motorcycleServices.DeleteMotorcycle(motorcycle);
        }
    }
}
