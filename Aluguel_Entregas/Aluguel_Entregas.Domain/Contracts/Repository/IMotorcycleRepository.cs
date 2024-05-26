﻿
using Aluguel_Entregas.Domain.Entities;

namespace Aluguel_Entregas.Domain.Contracts.Repository
{
    public interface IMotorcycleRepository
    {
        Task<(bool sucess, string message)> Create(Motorcycle motorcycle);

        Task Update(Motorcycle motorcycle);

        Task Delete (Motorcycle motorcycle);


    }
}
