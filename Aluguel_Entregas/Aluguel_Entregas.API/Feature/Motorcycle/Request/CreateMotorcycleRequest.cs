namespace Aluguel_Entregas.API.Feature.Motorcycle.Request
{
    public class CreateMotorcycleRequest
    {
        public int Year { get; set; }

        public string Model { get; set; }

        public string Plate { get; set; }
    }
}
