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
        public int License { get; private set; }
        public DriverLicensesTypesEnum LicensesType { get; private set; }

        //todo: imagem da carteira

        public Courier(string name, string cnpj, DateTime birth, int license, DriverLicensesTypesEnum licensesTypes)
        {
            Name = name;
            Cnpj = cnpj;
            Birth = birth;
            License = license;
            LicensesType = licensesTypes;
        }
    }
}
