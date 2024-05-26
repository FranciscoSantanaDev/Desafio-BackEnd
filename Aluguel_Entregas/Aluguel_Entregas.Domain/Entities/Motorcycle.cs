
namespace Aluguel_Entregas.Domain.Entities
{
    public class Motorcycle : EntityBase
    {
        public int Year { get; private set; }

        public string Model { get; private set; }

        public string Plate { get; private set; }

        public Motorcycle( int year, string model , string plate)
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
    }
}
