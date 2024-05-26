using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Commands.Motorcycle
{
    public class UpdateMotorcycleCommand
    {
        public Guid Id { get; private set; }

        public string Plate { get; private set; }

        public UpdateMotorcycleCommand(Guid id, string plate)
        {
            Id = id;
            Plate = plate;
        }
    }
}
