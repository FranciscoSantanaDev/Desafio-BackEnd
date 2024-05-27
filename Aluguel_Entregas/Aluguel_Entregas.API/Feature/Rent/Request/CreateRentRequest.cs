using Aluguel_Entregas.Domain.Enum;

namespace Aluguel_Entregas.API.Feature.Rent.Request
{
    public class CreateRentRequest
    {
        public RentalPlansEnum RentalPlans { get; set; }
        public DateTime ExpectedDate { get; set; }
        public Guid? MotorcycleId { get; set; }
    }
}
