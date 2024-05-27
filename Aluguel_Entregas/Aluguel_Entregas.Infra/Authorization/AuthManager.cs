using Aluguel_Entregas.Domain.Contracts.Repository.Courier;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Entities;
using Aluguel_Entregas.Domain.Enum;
using System.Text;

namespace Aluguel_Entregas.Infra.Authorization
{
    public class AuthManager : IAuthManager
    {
        private string _user;
        private string _password;
        IUserRepository _userRepository;
        public AuthManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool IsAuthorized(string authHeader, UserTypeEnum userType )
        {
            var user = GetUserBasicAuth(authHeader);
            return user != null && _user == user.Username && _password == user.Password && userType == user.UserType;
        }

        public User GetUserBasicAuth(string authHeader)
        {
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                string encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                byte[] data = Convert.FromBase64String(encodedUsernamePassword);
                string decodedUsernamePassword = Encoding.UTF8.GetString(data);
                _user = decodedUsernamePassword.Split(':', 2)[0];
                _password = decodedUsernamePassword.Split(':', 2)[1];

                return _userRepository.GetUser(_user).Result;
            }
            return null;
        }
    }
}
