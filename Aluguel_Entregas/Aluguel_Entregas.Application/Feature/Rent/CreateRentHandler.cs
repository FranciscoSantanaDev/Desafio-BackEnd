using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Commands.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Handler.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Handler.Rent;
using Aluguel_Entregas.Domain.Services;
using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Application.Feature.Rent
{
    public class CreateRentHandler : ICreateRentHandler
    {
        IRentServices _rentServices;
        IMotorcycleServices _motorcycleServices;
        IAuthManager _authManager;
        public CreateRentHandler(IRentServices rentServices, IMotorcycleServices motorcycleServices, IAuthManager authManager)
        {
            _rentServices = rentServices;
            _motorcycleServices = motorcycleServices;
            _authManager = authManager;
        }
        public async Task<(bool sucess, string message)> Handle(CreateRentCommand command)
        {

            var motorcycle = command.MotorcycleId.HasValue ? await _motorcycleServices.Get(command.MotorcycleId.Value) : await _motorcycleServices.GetAvailable();

            if (motorcycle != null || motorcycle?.Rent != null)
            {
                var user = _authManager.GetUserBasicAuth(command.AuthHeader);
                Domain.Entities.Rent rent = new Domain.Entities.Rent(command.RentalPlans, command.StartDate, command.ExpectedDate, user.Courier, motorcycle);
                return await _rentServices.CreateRent(rent);
            }
            else {
                return (false, "There are no motorcycles available");
            }

        }
    }
}
