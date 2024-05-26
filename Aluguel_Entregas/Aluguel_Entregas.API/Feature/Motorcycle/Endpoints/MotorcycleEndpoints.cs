using Aluguel_Entregas.API.Feature.Motorcycle.Request;
using Aluguel_Entregas.Domain.Commands.Moto;
using Aluguel_Entregas.Domain.Contracts.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel_Entregas.API.Feature.Motorcycle.Endpoints
{
    public static class MotorcycleEndpoints
    {
        public static void RegisterMotorcycleEndpoints(this IEndpointRouteBuilder routes)
        {
            var users = routes.MapGroup("/api/v1/motorcycle");

            users.MapPost("", async (ICrateMotorcycleHandler createMotorcycleService, [FromBody] CreateMotorcycleRequest request) =>
            {
                await createMotorcycleService.Handle(new CreateMotorcycleCommand(request.Year, request.Model,
                    request.Plate));

                return Results.Accepted();
            })
                .WithName("CreateMotorcycle")
                .WithOpenApi()
                .AddFluentValidationFilter();
        }
    }
}
