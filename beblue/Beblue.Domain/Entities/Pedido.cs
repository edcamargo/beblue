using Beblue.Domain.Entities.NotMapped;
using System;
using System.Collections.Generic;

namespace Beblue.Domain.Entities
{
    public class Pedido : Entity
    {
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public double TotalVenda { get; set; } = 0;
        public double ValorCashback { get; set; } = 0;
        public DateTime DataVenda { get; set; } = DateTime.Today;
        public List<PedidoItem> PedidoItens { get; set; }
    }
}
