using Aluguel_Entregas.Domain.Enum;

namespace Aluguel_Entregas.Domain.Commands.Motorcycle
{
    public class CreateRentCommand
    {
        public RentalPlansEnum RentalPlans { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime ExpectedDate { get; private set; }
        public double TotalValue { get; private set; }
        public string AuthHeader { get; private set; }
        public Guid? MotorcycleId { get; private set; }

        public CreateRentCommand(RentalPlansEnum rentalPlans, DateTime startDate, DateTime endDate, DateTime expectedDate, double totalValue, string authHeader, Guid? motorcycleId)
        {
            RentalPlans = rentalPlans;
            StartDate = startDate;
            EndDate = endDate;
            ExpectedDate = expectedDate;
            TotalValue = totalValue;
            AuthHeader = authHeader;
            MotorcycleId = motorcycleId;
        }
    }
}
