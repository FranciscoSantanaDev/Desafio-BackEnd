using Aluguel_Entregas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Contracts.Services
{
    public interface ICourierServices
    {
        Task<(bool sucess, string message)> CreateCourier(Courier courier);
    }
}
