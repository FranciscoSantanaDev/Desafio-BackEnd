using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Commands.Moto
{
    public class CreateMotorcycleCommand
    {
        public int Year { get; private set; }

        public string Model { get; private set; }

        public string Plate { get; private set; }

        public CreateMotorcycleCommand(int year, string model, string plate)
        {
            Year = year;
            Model = model;
            Plate = plate;
        }
    }
}
