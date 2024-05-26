using Aluguel_Entregas.API.Feature.Motorcycle.Request;
using Aluguel_Entregas.Domain.Commands.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Handler;
using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Enum;
using Aluguel_Entregas.Infra.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aluguel_Entregas.API.Feature.Motorcycle.Endpoints
{
    public static class MotorcycleEndpoints
    {
        public static void RegisterMotorcycleEndpoints(this IEndpointRouteBuilder routes)
        {
            var endpoint = routes.MapGroup("/api/v1/motorcycle");

            endpoint.MapPost("", async (ICreateMotorcycleHandler createMotorcycleService, IAuthManager authManager, [FromBody] CreateMotorcycleRequest request, HttpContext context) =>
            {
                if (authManager.IsAuthorized(context.Request.Headers["Authorization"], UserTypeEnum.Admin))
                {
                    var result = await createMotorcycleService.Handle(new CreateMotorcycleCommand(request.Year, request.Model,
                        request.Plate));

                    return result.sucess ? Results.Created() : Results.BadRequest(result.message);
                }
                else
                {
                    return Results.Unauthorized();
                }
            })
                .WithName("CreateMotorcycle")
                .WithOpenApi()
                .AddFluentValidationFilter();

            endpoint.MapGet("", async (IMotorcycleRepository motorcycleRepository, IAuthManager authManager, [FromQuery] string? plate, HttpContext context) =>
            {
                if (authManager.IsAuthorized(context.Request.Headers["Authorization"], UserTypeEnum.Admin))
                {
                    var motorcycle = await motorcycleRepository.Get(plate);

                    return motorcycle.Count() > 0 ? TypedResults.Ok(motorcycle) : Results.NoContent();
                }
                else
                {
                    return Results.Unauthorized();
                }
            })
           .WithName("Get")
           .WithOpenApi()
           .AddFluentValidationFilter();

            endpoint.MapPut("{id}",
             async (IUpdateMotorcycleHandler updateMotorcycleHandler, IAuthManager authManager, [FromBody] UpdateMotorcycleRequest request, [FromRoute] Guid id, HttpContext context) =>
             {
                 if (authManager.IsAuthorized(context.Request.Headers["Authorization"], UserTypeEnum.Admin))
                 {
                    var result =  await updateMotorcycleHandler.Handle(new UpdateMotorcycleCommand(id, request.Plate));

                     return result.sucess ? Results.Ok() : Results.BadRequest(result.message);
                 }
                 else
                 {
                     return Results.Unauthorized();
                 }
                
             })
         .WithName("AtualizaContato")
         .WithOpenApi()
         .AddFluentValidationFilter();
        }
    }
}
