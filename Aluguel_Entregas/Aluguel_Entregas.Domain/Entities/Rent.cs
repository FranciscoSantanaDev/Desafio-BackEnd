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
        public Courier Courier { get; private set; }
        public Motorcycle Motorcycle { get; private set; }

        public Rent(RentalPlansEnum rentalPlans, DateTime startDate, DateTime endDate, DateTime expectedDate, double totalValue, Courier courier, Motorcycle motorcycle)
        {
            RentalPlans = rentalPlans;
            StartDate = startDate.AddDays(1);
            EndDate = endDate;
            ExpectedDate = expectedDate;
            TotalValue = totalValue;
            Courier = courier;
            Motorcycle = motorcycle;
            Id = Guid.NewGuid();
        }

        public Rent(RentalPlansEnum rentalPlans, DateTime startDate, DateTime expectedDate, Courier courier, Motorcycle motorcycle)
        {
            RentalPlans = rentalPlans;
            StartDate = startDate.AddDays(1);
            ExpectedDate = expectedDate;
            Courier = courier;
            Motorcycle = motorcycle;
            Id = Guid.NewGuid();
        }

        public void CalculateTotalValue()
        {
            var forfeit = ForfeitByPlan(RentalPlans);
            var valuebyplan = ValueByPlan(RentalPlans);
            if (ExpectedDate<EndDate)
            {
                int days = (int)(StartDate.Date - ExpectedDate.Date).TotalDays;
                int daysToForfeit = (int)(EndDate.Date - ExpectedDate.Date).TotalDays;
                double value = days * valuebyplan;
                value += (daysToForfeit * valuebyplan) * (forfeit / 100);
                TotalValue = value;
            }
            else if (ExpectedDate >= EndDate)
            {
                int days = (int)(StartDate.Date - EndDate.Date).TotalDays;
                int daysToForfeit = (int)(ExpectedDate.Date - EndDate.Date).TotalDays;
                double value = days * valuebyplan;
                value += daysToForfeit * 50;
                TotalValue = value;
            }
        }

        public void CalculateEndDate()
        {
            EndDate = StartDate.AddDays(DaysToAdd(RentalPlans));
        }

        private int DaysToAdd(RentalPlansEnum rentalPlans)
        {
            switch (rentalPlans) {
                case RentalPlansEnum.Weekly :
                    return 7;
                case RentalPlansEnum.Biweekly:
                    return 15;
                case RentalPlansEnum.Monthly : 
                    return 30;
            }
            return 0;
        }

        private double ValueByPlan(RentalPlansEnum rentalPlans)
        {
            switch (rentalPlans)
            {
                case RentalPlansEnum.Weekly:
                    return 30.00;
                case RentalPlansEnum.Biweekly:
                    return 28.00;
                case RentalPlansEnum.Monthly:
                    return 22.00;
            }
            return 0;
        }

        private int ForfeitByPlan(RentalPlansEnum rentalPlans)
        {
            switch (rentalPlans)
            {
                case RentalPlansEnum.Weekly:
                    return 20;
                case RentalPlansEnum.Biweekly:
                    return 40;
                case RentalPlansEnum.Monthly:
                    return 60;
            }
            return 0;
        }
    }
}
