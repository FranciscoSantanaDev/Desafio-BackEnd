using Aluguel_Entregas.API.Feature.Motorcycle.Validators;
using FluentValidation;
using Aluguel_Entregas.Infra.Configuration;
using Aluguel_Entregas.API.Feature.Motorcycle.Endpoints;
using Aluguel_Entregas.Infra.Configurations;
using Microsoft.AspNetCore.Authentication;
using Aluguel_Entregas.API.Feature.Courier.Endpoint;
using Aluguel_Entregas.API.Feature.Rent.Endpoint;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddDomainService();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCourierRequestValidator>();
builder.Services.ConfigureRepositories();
builder.AddFluentValidationEndpointFilter();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseHttpsRedirection();

app.RegisterMotorcycleEndpoints();
app.RegisterCourierEndpoints();
app.RegisterRentEndpoints();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
