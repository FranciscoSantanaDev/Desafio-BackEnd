using Aluguel_Entregas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Entities
{
    public class Courier : EntityBase
    {
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime Birth { get; private set; }
        public string License { get; private set; }
        public DriverLicensesTypesEnum LicensesType { get; private set; }

        public User User { get; private set; }

        public ICollection<Rent> Rents { get; private set; }


        //todo: imagem da carteira

        public Courier(string name, string cnpj, DateTime birth, string license, DriverLicensesTypesEnum licensesTypes, string username, string password)
        {
            Name = name;
            Cnpj = cnpj;
            Birth = birth;
            License = license;
            LicensesType = licensesTypes;
            User = new User(username, password, UserTypeEnum.Courier);
            Id = Guid.NewGuid();
        }

        public Courier()
        {
            
        }
    }
}
