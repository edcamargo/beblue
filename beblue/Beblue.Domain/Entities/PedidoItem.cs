using Beblue.Domain.Entities.NotMapped;
using System.Collections.Generic;

namespace Beblue.Domain.Entities
{
    public class PedidoItem : Entity
    {
        public string PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        public string DiscoId { get; set; }
        public virtual Disco Discos { get; set; }
        public double ValorCashBack { get; set; }
    }
}
