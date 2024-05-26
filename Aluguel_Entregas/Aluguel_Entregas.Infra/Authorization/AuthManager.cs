using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Infra.Authorization
{
    public class AuthManager : IAuthManager
    {
        IUserRepository _userRepository;
        public AuthManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public  bool IsAuthorized(string authHeader, UserTypeEnum userType )
        {
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                string encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                byte[] data = Convert.FromBase64String(encodedUsernamePassword);
                string decodedUsernamePassword = Encoding.UTF8.GetString(data);
                string providedUsername = decodedUsernamePassword.Split(':', 2)[0];
                string providedPassword = decodedUsernamePassword.Split(':', 2)[1];

                var user =  _userRepository.GetUser(providedUsername).Result;

                return providedUsername == user.Username && providedPassword == user.Password && userType == user.UserType;
            }
            return false;
        }
    }
}
