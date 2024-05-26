using Aluguel_Entregas.Domain.Enum;

namespace Aluguel_Entregas.API.Feature.Courier.Request
{
    public class CreateCourierRequest
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime Birth { get; set; }
        public string License { get; set; }
        public DriverLicensesTypesEnum LicensesType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
