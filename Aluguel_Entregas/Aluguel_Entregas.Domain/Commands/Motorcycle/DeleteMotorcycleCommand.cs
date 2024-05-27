using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel_Entregas.Domain.Commands.Motorcycle
{
    public class DeleteMotorcycleCommand
    {
        public Guid Id { get; private set; }

        public DeleteMotorcycleCommand(Guid id)
        {
            Id = id;
        }
    }
}
