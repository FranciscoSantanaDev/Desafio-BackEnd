using Aluguel_Entregas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Contracts.Services
{
    public interface IMotorcycleServices
    {
        Task<(bool sucess, string message)> CreateMotorcycle(Motorcycle motorcycle);
    }
}
