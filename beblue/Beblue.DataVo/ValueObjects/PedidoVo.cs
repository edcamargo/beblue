using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Beblue.DataVo.ValueObjects
{
    [DataContract]
    public class PedidoVo
    {
        [DataMember(Order = 1, Name = "ClienteId", IsRequired = true)]
        public string ClienteId { get; set; }
        public virtual ClienteVo Cliente { get; set; }

        [DataMember(Order = 2, Name = "PedidoItens", IsRequired = true)]
        public List<PedidoItemVo> PedidoItens { get; set; }
    }
}
