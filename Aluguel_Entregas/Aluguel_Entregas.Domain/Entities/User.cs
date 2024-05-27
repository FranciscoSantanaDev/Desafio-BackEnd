using Aluguel_Entregas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Entities
{
    public class User: EntityBase
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public UserTypeEnum UserType { get; private set; }

        public Courier Courier { get; private set; }

        public User(string username,string password, UserTypeEnum userType, Courier courier)
        {
            Username = username;
            Password = password;
            UserType = userType;
            Courier = courier;
        }
        public User(string username, string password, UserTypeEnum userType)
        {
            Username = username;
            Password = password;
            UserType = userType;
        }
    }
}
