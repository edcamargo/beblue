using Beblue.DataVo.Interfaces;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.DataVo.Converters
{
    public class PedidoItemConverter : IParser<PedidoItemVo, PedidoItem>, IParser<PedidoItem, PedidoItemVo>
    {
        public PedidoItem Parse(PedidoItemVo origin)
        {
            if (origin == null) return new PedidoItem();
            return new PedidoItem
            {
                DiscoId = origin.DiscoId
            };
        }

        public PedidoItemVo Parse(PedidoItem origin)
        {
            if (origin == null) return new PedidoItemVo();
            return new PedidoItemVo
            {
                DiscoId = origin.DiscoId
            };
        }

        public List<PedidoItem> ParseList(List<PedidoItemVo> origin)
        {
            if (origin == null) return new List<PedidoItem>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PedidoItemVo> ParseList(List<PedidoItem> origin)
        {
            if (origin == null) return new List<PedidoItemVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}