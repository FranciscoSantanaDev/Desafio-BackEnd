
namespace Aluguel_Entregas.Domain.Entities
{
    public class Motorcycle : EntityBase
    {
        public int Year { get; private set; }

        public string Model { get; private set; }

        public string Plate { get; private set; }

        public Rent? Rent { get; private set; }

        public Motorcycle( int year, string model , string plate, Rent rent)
        {
            Year = year;
            Model = model;
            Plate = plate;
            Rent = rent;
            Id = Guid.NewGuid();
        }

        public Motorcycle(int year, string model, string plate)
        {
            Year = year;
            Model = model;
            Plate = plate;
            Id = Guid.NewGuid();
        }
        public void Update(string plate)
        {
            Plate = plate;
        }

        public Motorcycle() { }
    }
}
