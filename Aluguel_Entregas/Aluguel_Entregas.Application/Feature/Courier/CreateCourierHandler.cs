using Aluguel_Entregas.Domain.Commands.Courier;
using Aluguel_Entregas.Domain.Contracts.Handler.Courier;
using Aluguel_Entregas.Domain.Contracts.Services;

namespace Aluguel_Entregas.Application.Feature.Courier
{
    public class CreateCourierHandler : ICreateCourierHandler
    {
        ICourierServices _courierServices;
        public CreateCourierHandler(ICourierServices courierServices)
        {
            _courierServices = courierServices;
        }
        public async Task<(bool sucess, string message)> Handle(CreateCourierCommand command)
        {
            Domain.Entities.Courier courier = new Domain.Entities.Courier(command.Name, command.Cnpj, command.Birth, command.License, command.LicensesType, command.Username, command.Password);
            return await _courierServices.CreateCourier(courier);
        }
    }
}
