using Aluguel_Entregas.Domain.Entities;
using Aluguel_Entregas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Commands.Courier
{
    public class CreateCourierCommand
    {
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime Birth { get; private set; }
        public string License { get; private set; }
        public DriverLicensesTypesEnum LicensesType { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }


        public CreateCourierCommand(string name, string cnpj, DateTime birth, string license, DriverLicensesTypesEnum licensesTypes, string username, string password)
        {
            Name = name;
            Cnpj = cnpj;
            Birth = birth;
            License = license;
            LicensesType = licensesTypes;
            Username = username;
            Password = password;
        }
    }
}
