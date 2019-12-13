using Beblue.DataVo.Interfaces;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.DataVo.Converters
{
    public class PedidoConverter : IParser<PedidoVo, Pedido>, IParser<Pedido, PedidoVo>
    {
        private ClienteConverter _clienteConverter = new ClienteConverter();

        private PedidoItemConverter _pedidoItemConverter = new PedidoItemConverter();

        public Pedido Parse(PedidoVo origin)
        {
            if (origin == null) return new Pedido();
            return new Pedido
            {
                ClienteId = origin.ClienteId,
                PedidoItens = _pedidoItemConverter.ParseList(origin.PedidoItens)
            };
        }

        public PedidoVo Parse(Pedido origin)
        {
            if (origin == null) return new PedidoVo();
            return new PedidoVo
            {
                ClienteId = origin.ClienteId,
                Cliente = _clienteConverter.Parse(origin.Cliente),
                PedidoItens = _pedidoItemConverter.ParseList(origin.PedidoItens)
            };
        }

        public List<Pedido> ParseList(List<PedidoVo> origin)
        {
            if (origin == null) return new List<Pedido>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PedidoVo> ParseList(List<Pedido> origin)
        {
            if (origin == null) return new List<PedidoVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
