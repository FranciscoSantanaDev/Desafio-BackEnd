using Aluguel_Entregas.Domain.Entities;
using Aluguel_Entregas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Contracts.Services
{
    public  interface IAuthManager
    {
        bool IsAuthorized(string authHeader, UserTypeEnum userType);
        User GetUserBasicAuth(string authHeader);
    }
}
