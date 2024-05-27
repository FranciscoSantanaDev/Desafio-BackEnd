using Aluguel_Entregas.API.Feature.Courier.Request;
using Aluguel_Entregas.API.Feature.Rent.Request;
using Aluguel_Entregas.Domain.Commands.Courier;
using Aluguel_Entregas.Domain.Commands.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Handler.Courier;
using Aluguel_Entregas.Domain.Contracts.Handler.Rent;
using Aluguel_Entregas.Domain.Contracts.Repository.Motorcycle;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Enum;
using Aluguel_Entregas.Infra.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel_Entregas.API.Feature.Rent.Endpoint
{
    public static class RentEndpoints
    {
        public static void RegisterRentEndpoints(this IEndpointRouteBuilder routes)
        {
            var users = routes.MapGroup("/api/v1/rent");

            users.MapPost("", async (ICreateRentHandler createRentHandler, HttpContext context, IAuthManager authManager, [FromBody] CreateRentRequest request) =>
            {
                var authHeader = context.Request.Headers["Authorization"];
                if (authManager.IsAuthorized(authHeader, UserTypeEnum.Courier))
                {
                    var result = await createRentHandler.Handle(new CreateRentCommand(request.RentalPlans, DateTime.Now, request.ExpectedDate, authHeader, request.MotorcycleId));

                    return result.sucess ? Results.Created() : Results.BadRequest(result.message);
                }
                else
                {
                    return Results.Unauthorized();
                }


            })
                .WithName("CreateRent")
                .WithOpenApi()
                .AddFluentValidationFilter();


        }
    }
}
