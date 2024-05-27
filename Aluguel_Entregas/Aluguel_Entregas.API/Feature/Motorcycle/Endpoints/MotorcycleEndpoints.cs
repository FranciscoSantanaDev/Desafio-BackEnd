using Aluguel_Entregas.API.Feature.Motorcycle.Request;
using Aluguel_Entregas.Domain.Commands.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Handler.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Repository.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

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
                     var result = await updateMotorcycleHandler.Handle(new UpdateMotorcycleCommand(id, request.Plate));

                     return result.sucess ? Results.Ok() : Results.BadRequest(result.message);
                 }
                 else
                 {
                     return Results.Unauthorized();
                 }
             })
         .WithName("UpdateMotorcycle")
         .WithOpenApi()
         .AddFluentValidationFilter();

            endpoint.MapDelete("{id}", async (IDeleteMotorcycleHandler deleteMotorcycleHandler, [FromRoute] Guid id, IAuthManager authManager, HttpContext context) =>
            {
                if (authManager.IsAuthorized(context.Request.Headers["Authorization"], UserTypeEnum.Admin))
                {
                   var result =  await deleteMotorcycleHandler.Handle(new DeleteMotorcycleCommand(id));

                    return result.sucess ? Results.Ok() : Results.BadRequest(result.message);
                }
                else
                {
                    return Results.Unauthorized();
                }
            })
           .WithName("DeleteMotorcycle")
           .WithOpenApi()
           .AddFluentValidationFilter();
        }
    }
}
