using Aluguel_Entregas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Infra.Authorization
{
    public  interface IAuthManager
    {
        bool IsAuthorized(string authHeader, UserTypeEnum userType);
    }
}
