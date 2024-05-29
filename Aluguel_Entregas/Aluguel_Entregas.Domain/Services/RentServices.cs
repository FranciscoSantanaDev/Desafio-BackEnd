using Aluguel_Entregas.Domain.Contracts.Repository;
using Aluguel_Entregas.Domain.Contracts.Repository.Rent;
using Aluguel_Entregas.Domain.Contracts.Services;
using Aluguel_Entregas.Domain.Entities;
using Aluguel_Entregas.Domain.Enum;

namespace Aluguel_Entregas.Domain.Services
{
    public class RentServices : IRentServices
    {
        private readonly IRentRepository _rentRepository;

        public RentServices(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }
        public async Task<(bool sucess, string message)> CreateRent(Rent rent)
        {
            rent.Update(CalculateEndDate(rent));
            rent.Update(CalculateTotalValue(rent));
            return await _rentRepository.Create(rent);
        }

        public async Task<(bool sucess, string message)> UpdateRent(Rent rent)
        {
            return await _rentRepository.Update(rent);
        }

        public double CalculateTotalValue(Rent rent)
        {
            var forfeit = ForfeitByPlan(rent.RentalPlans);
            var valuebyplan = ValueByPlan(rent.RentalPlans);
            if (rent.ExpectedDate.Date < rent.EndDate.Date)
            {
                int days = (int)(rent.ExpectedDate.Date - rent.StartDate.Date).TotalDays;
                int daysToForfeit = (int)(rent.EndDate.Date - rent.ExpectedDate.Date).TotalDays;
                double value = days * valuebyplan;
                double daily = (daysToForfeit * valuebyplan);
                return value +(daily * (forfeit / 100));
            }
            else if (rent.ExpectedDate.Date >= rent.EndDate.Date)
            {
                int days = (int)(rent.EndDate.Date - rent.StartDate.Date).TotalDays;
                int daysToForfeit = (int)(rent.ExpectedDate.Date - rent.EndDate.Date).TotalDays;
                double value = days * valuebyplan;
                return value + (daysToForfeit * 50);
            }

            return 0;
        }

        public DateTime CalculateEndDate(Rent rent)
        {
            return rent.StartDate.AddDays(DaysToAdd(rent.RentalPlans));
        }

        private int DaysToAdd(RentalPlansEnum rentalPlans)
        {
            switch (rentalPlans)
            {
                case RentalPlansEnum.Weekly:
                    return 7;
                case RentalPlansEnum.Biweekly:
                    return 15;
                case RentalPlansEnum.Monthly:
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

        private double ForfeitByPlan(RentalPlansEnum rentalPlans)
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
