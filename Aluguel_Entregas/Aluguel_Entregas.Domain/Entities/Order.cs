using Aluguel_Entregas.Domain.Enum;

namespace Aluguel_Entregas.Domain.Entities
{
    public class Order:EntityBase
    {
        public DateTime CreateDate { get; private set; }
        public double Value { get; private set; }
        public OrderSituationsEnum Situation { get; set; }
    }
}
