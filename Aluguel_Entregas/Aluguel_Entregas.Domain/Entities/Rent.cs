using Aluguel_Entregas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Entities
{
    public class Rent:EntityBase
    {
        public RentalPlansEnum RentalPlans { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime ExpectedDate { get; private set; }
        public double TotalValue { get; private set; }
        public Courier? Courier { get; private set; }
        public Motorcycle? Motorcycle { get; private set; }

        public Guid? MotorcycleId { get; private set; }

        public Rent(RentalPlansEnum rentalPlans, DateTime startDate, DateTime endDate, DateTime expectedDate, double totalValue, Courier courier, Motorcycle motorcycle, Guid? motorcycleId)
        {
            RentalPlans = rentalPlans;
            StartDate = startDate.AddDays(1).ToUniversalTime();
            EndDate = endDate.ToUniversalTime();
            ExpectedDate = expectedDate.ToUniversalTime();
            TotalValue = totalValue;
            Courier = courier;
            Motorcycle = motorcycle;
            Id = Guid.NewGuid();
            MotorcycleId = motorcycleId;
        }

        public Rent(RentalPlansEnum rentalPlans, DateTime startDate, DateTime endDate, DateTime expectedDate, double totalValue)
        {
            RentalPlans = rentalPlans;
            StartDate = startDate.ToUniversalTime();
            EndDate = endDate.ToUniversalTime();
            ExpectedDate = expectedDate.ToUniversalTime();
            TotalValue = totalValue;
        }

        public Rent(RentalPlansEnum rentalPlans, DateTime startDate, DateTime expectedDate, Courier courier, Motorcycle motorcycle)
        {
            RentalPlans = rentalPlans;
            StartDate = startDate.AddDays(1).ToUniversalTime();
            ExpectedDate = expectedDate.ToUniversalTime();
            Courier = courier;
            Motorcycle = motorcycle;
            Id = Guid.NewGuid();
        }

        public void Update(DateTime endDate)
        {
            EndDate = endDate.ToUniversalTime();
        }

        public void Update(double totalValue)
        {
           TotalValue = totalValue;
        }
    }
}
