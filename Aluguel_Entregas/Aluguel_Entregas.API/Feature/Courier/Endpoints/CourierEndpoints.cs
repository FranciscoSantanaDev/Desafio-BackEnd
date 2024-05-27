using Aluguel_Entregas.API.Feature.Courier.Request;
using Aluguel_Entregas.Domain.Commands.Courier;
using Aluguel_Entregas.Domain.Contracts.Handler.Courier;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel_Entregas.API.Feature.Courier.Endpoint
{
    public static class CourierEndpoints
    {
        public static void RegisterCourierEndpoints(this IEndpointRouteBuilder routes)
        {
            var users = routes.MapGroup("/api/v1/courier");

            users.MapPost("", async (ICreateCourierHandler createCourierHandler, [FromBody] CreateCourierRequest request) =>
            {
                var result = await createCourierHandler.Handle(new CreateCourierCommand(request.Name, request.Cnpj, request.Birth, request.License, request.LicensesType, request.Username, request.Password));

                return result.sucess ? Results.Ok() : Results.BadRequest(result.message);

            })
                .WithName("CreateCourier")
                .WithOpenApi()
                .AddFluentValidationFilter();


        }
    }
}
